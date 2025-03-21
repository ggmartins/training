# Formula to Determine the Price of a Security

There isn’t a single universal formula that applies to *every* type of security under *all* circumstances, but in classical finance theory, the most common way to determine the “fair” price of a security is through **discounted cash flow (DCF)** analysis. The core idea is:

\[
\text{Price} \;=\;\sum_{t=1}^{T} \frac{E[\text{Cash Flow}_t]}{(1+r)^t}
\]

Where:

- \(E[\text{Cash Flow}_t]\) is the expected cash flow at time \(t\).  
- \(r\) is the required rate of return (or discount rate) that reflects the riskiness and the time value of money.  
- \(T\) is the number of periods in the future for which you’re modeling these cash flows.  

---

## Key Points

1. **Expected Future Cash Flows**  
   This encompasses dividends (if it’s a stock), coupon and principal payments (if it’s a bond), rental income (if it’s a real estate investment), or other cash flows specific to the security.

2. **Discount Rate (\(r\))**  
   - This rate represents both:
     - The time value of money (a dollar today is worth more than a dollar in the future).
     - A premium for the risk of the security (riskier investments require higher expected returns, hence a higher discount rate).

3. **Variation by Security Type**  
   - **Stocks** might be priced using a dividend discount model (a special case of DCF focusing on dividends) or a more generalized free-cash-flow model.  
     - For a perpetual dividend-paying stock with constant dividends, a simple model is \( P = \frac{D}{r} \).  
     - If those dividends grow at a constant rate \(g\), the Gordon Growth Model is \( P = \frac{D_1}{r - g} \), where \(D_1\) is the next dividend.
   - **Bonds** are typically priced by discounting each coupon payment and the face (par) value at maturity:
     \[
     \text{Bond Price} = \sum_{t=1}^{n} \frac{\text{Coupon}}{(1 + i)^t} \;+\; \frac{\text{Face Value}}{(1 + i)^n}
     \]
     where \(i\) is the yield (required return) for the bond.
   - **Options** and other derivatives often use more specialized models (e.g., Black-Scholes for European options) that incorporate volatility and other factors.

4. **Market Dynamics**  
   - Even though DCF-based models give a theoretical or “intrinsic” value, *actual* market prices can deviate due to supply and demand, investor sentiment, liquidity constraints, and broader economic conditions.

---

## The Big Takeaway

In most standard finance theory, the price of a security (or its “intrinsic value”) is *the present value of the security’s expected future cash flows,* discounted at a rate appropriate for its risk. Other pricing models (dividend discount, bond pricing, or Black-Scholes for options) are specialized applications of that same discounted cash flow principle with assumptions tailored to each type of security.


# Pass-Through Securities vs. Collateralized Mortgage Obligations (CMOs)

Mortgage-backed securities (MBS) come in various forms, but two primary structures are pass-through securities and collateralized mortgage obligations (CMOs). Here’s how they differ:

---

### 1. Basic Structure

- **Pass-Through Securities**  
  - Investors receive periodic payments (principal + interest) that directly “pass through” from the pooled mortgage loans.  
  - Cash flows are not typically separated into different tranches or classes. Instead, all investors share pro rata in the interest and principal from the underlying mortgage pool.

- **Collateralized Mortgage Obligations (CMOs)**  
  - The mortgage pool is sliced into multiple tranches, each with unique payment priorities, interest rates, and maturities.  
  - Principal and interest payments from the pool are distributed according to specific rules that define which tranche is paid first (and so on).

---

### 2. Cash Flow Distribution

- **Pass-Through Securities**  
  - All investors are effectively in the same “class,” and they receive principal and interest payments based on their proportionate share in the mortgage pool.  
  - Prepayments affect all investors equally, lowering the outstanding principal pool for everyone proportionally.

- **CMOs**  
  - Each tranche can have different levels of risk, maturity schedules, and interest payment structures (e.g., some tranches may pay interest-only for a period, while others pay both interest and principal).  
  - Prepayment risk is allocated differently among the tranches—some bear more prepayment risk, others less.

---

### 3. Risk and Complexity

- **Pass-Through Securities**  
  - Straightforward structure and simpler to understand.  
  - Investors face prepayment risk directly (if mortgage borrowers prepay or refinance, investors receive principal back sooner than expected).  
  - Typically, pass-throughs are well-suited for investors who need a straightforward MBS investment without complex structuring.

- **CMOs**  
  - More sophisticated and complex.  
  - By creating multiple tranches, issuers can tailor the cash flow patterns and risk exposure for different investors (e.g., short-duration tranches vs. long-duration tranches, planned amortization class (PAC) tranches, support tranches, etc.).  
  - Different tranches allow investors to choose exposure to prepayment risk, maturity timelines, and yield levels that fit their investment objectives.

---

### 4. Investor Profiles

- **Pass-Through Securities**  
  - Suitable for investors comfortable with a single, undifferentiated stream of principal and interest payments.  
  - Simpler to value and trade relative to CMOs.

- **CMOs**  
  - Attractive to more specialized or sophisticated investors who want to manage or customize certain aspects of risk (e.g., prepayment or extension risk).  
  - Can be structured to meet specific maturity needs and risk tolerances.

---

### Summary

- **Pass-Through Securities**: A single, direct stream of principal and interest from the underlying mortgage loans. Less complex, but all investors share similar prepayment risk.  
- **CMOs**: Multiple tranches with distinct cash flow priorities and risk/return profiles. More complex, but can be tailored to fit different investor needs and risk appetites.

Both structures help lenders and financial institutions access capital markets by packaging and selling mortgages, but the choice between pass-through securities and CMOs depends on the desired complexity, risk exposure, and maturity preferences of investors.

