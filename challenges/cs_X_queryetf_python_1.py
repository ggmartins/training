#! /usr/bin/env -S uv run
# /// script
# requires-python = ">=3.13"
# dependencies = [
#     "pandas",
#     "pytest",
# ]
# ///
from functools import lru_cache
from bisect import bisect_left, bisect_right
import pandas as pd
import pytest
from pathlib import Path
from pprint import pformat as pf
from datetime import date


def singleton(cls):
    instances = {}
    def get_instance(*args, **kwargs):
        if cls not in instances:
            instances[cls] = cls(*args, **kwargs)
        return instances[cls]
    return get_instance

@singleton
class ETFMember:

    _byetf: dict[str, list[dict]] = {}

    def __init__(self, files: list[str]):
        for f in files:
            for k, v in self._load_file(f).items():
                self._byetf[k] = self._byetf.get(k, []) + v
        return

    def _load_file(self, f: str):
        df = pd.read_csv(f, dtype={
                    "CUSIP": "string",
                    "ticker": "string",
                    "price_buy": "float64",
                    "etfmember": "string",
                },
                parse_dates=["buydate"],)

        df1 = df.assign(etfmember=df["etfmember"].str.split("|")). \
                explode("etfmember", ignore_index=True)

        result = {
            etf: etfgroup \
                .sort_values("buydate")[["CUSIP", "ticker", "price_buy", "buydate"]] \
                .to_dict("records")
            for etf, etfgroup in df1.groupby("etfmember")
        }
        return result

    @lru_cache(maxsize=None)
    def query(self, etf: str, date_start: date, date_end: date) -> dict:
        etfdata = self._byetf.  get(etf, []);
        left = bisect_left(etfdata, date_start, key=lambda d: d['buydate'].date())
        right = bisect_right(etfdata, date_end, key=lambda d: d['buydate'].date())
        return etfdata[left:right]


    def __repr__(self):
        return pf(self._byetf)

def test_etfmember_load():
    etfmember = ETFMember(list(Path("./").rglob("cs_X_queryetf_*.csv")))
    print(etfmember)

def test_etfmember_query():
    etfmember = ETFMember(list(Path("./").rglob("cs_X_queryetf_*.csv")))
    result = list(etfmember.query("SPY", date(2023, 1, 1), date(2024, 12, 31)))
    tickers = [r["ticker"] for r in result]
    print(tickers)
    assert "TEST" in tickers
    assert "AMZN" in tickers

if __name__ == "__main__":
    pytest.main([__file__, "-s"])

  
