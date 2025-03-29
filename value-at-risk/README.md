https://www.youtube.com/watch?v=92WaNz9mPeY&ab_channel=MITOpenCourseWare
# Value-at-Risk
(Ken Abbott, Morgan Stanley)

#### Risk Management's Mission

1. To ensure that manegement is FULLY INFORMED about the RISK PROFILE of the bank.
   1.1 Express complex concepts in simple words and pretty pictures (No quant boss [example](https://en.wikipedia.org/wiki/Regression_analysis)
3. To protect the bank against UNACCEPTABLY large losses resulting from CONCENTRATION of risk.
4. In other words: NO SURPRISES
5. Two analogies
   4.1 Spotlight
   4.2 Coloring book

#### Methodology

1. Example of one-asset VaR
   1.1 Price-based instruments
   1.2 Yeild-based instruments
2. Variance/Covariance (quadratic form)
3. Monte Carlo Simulation (quadratic form)
4. Historical Simulation

#### Variables in Methods

1. Interest Rate Sensitivity, duration, PV01
2. Equity Exposure
3. Commodity Exposure
4. Credit - spread duration
5. Distribution / Linearity of price behavior
6. Regularity of cash flow / prepayment
7. Correlation across sectors and classes

#### Methodology - What are we trying to calculate?

- Order Statistics
- We want to estimate the worst 1% of the outcomes
- In Equity, a position, distrubution of returns, week, month, year
  - *likely* to be symmetric, unimodal , may or may not have *fat tails*
  - if the distribution is normal the 1% worse case outcome can be measured
    based on AUC (integrating -inf to 5 or 6 [stddev](https://www.youtube.com/watch?v=92WaNz9mPeY&t=640s).
    AUC of (-inf to -2.33) one-sided confidence interval (vs two-sided confidence interval).
    For 5% worst cases = AUC (-inf to 1.645 stddev = 0.05).
- "Normal distribution is like latin" - "no body use it anymore, but everything is based upon, but we relax these assumptions"
- IPC Historical Data (Mexican Exchange)
- VaR: We can conclude that giving the one-asset historical data that we expect to lose no more than 4.1689% of the value of
  our position, 99% of the time.

AI queries:
does the value-at-risk look at the negative side of returns perspective considering the equity market? 
ChatGPT said:
Reasoned about value-at-risk perspective for a couple of seconds
Yes. Value at Risk (VaR) is typically defined as a threshold loss value such that the probability that the loss on the portfolio over a given time horizon exceeds this value is at a specified confidence level. In other words, VaR deals explicitly with losses (the “left tail” or negative side of the return distribution) and is used to estimate how much one can lose with a given probability under normal market conditions.


