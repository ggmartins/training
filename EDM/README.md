# 1. EDM Enterprise Data Manager Intro

```
                        Data
                     +------------------+
                     |  * Trade         |            ____________
- Acquires           |  * Operational   |          /              \
- Validates  ---->   |  * Risk          |   ---> +  Single Version  +
- Distribute         |  * Finance       |          \______________/
                     |  * Customer      |
                     +------------------+       Consistent & Fully Audited Env
                                                Greater Control
                                                Ongoing compliance
                                                Transparency 
```

* Data governance: Creates a single version of the truth, data stewardship of data assets and a transparent audit trail.
* Data quality: Data is validated, enriched and reconciled across multiple sources reducing operational risk.
* Data transparency: Data lineage provides look through hierarchy and side by side source comparisons.
* Data integration: Internal and external data silos can be eliminated. Legacy applications and systems can be consolidated.
* Data dissemination: Data can be aggregated and presented in the right format at the right time as needed by each business


```
EDM is a SASS that can run in the cloud or on-prem.

                                __________           ___________          ___________ 
                              /  Back      \       /  Analytics  \      /  Analytics  \
          ___________        +   Office     +     +   Provider    +    +   Provider    +    +----------------------+
        /  Reference  \        \___________/       \_____________/      \_____________/     | Price Data Provider  |
      +    Data         +          \                    /                    /    _________/+----------------------+
       \   Provider   /           ___\______________   /                   /    /      +----------------------+
    ...   -----------  \        /                  /  \ ------------------+----+-------| Price Data Provider  |
    ___________          \    /                   /    \                               +----------------------+
  /  Reference  \          \ |                   |     |                                           +--------------------+
+    Data         +----------+         EDM       |     +------------------------------------------>+ *** BENCHMARKS *** |
  \  Provider   /            |                   |     |                                           +--------------------+
    -----------               \                   \   /
                                \___________________\/
                                         ^
                                         |
             +----------------------------------------------------------+
             |                 |                     |                  |
   +-----------------+         |                     |         +-----------------+
   | Reporting Cubes |         |                     |         | Data Warehouse  |
   +-----------------+         |                     |         +-----------------+
                               |                     |
                               v                     v
   +---------------------------+---------------------+---------------------------+
   |                           |                     |                           |
+-----------------+  +-------------------+  +-----------------+  +-------------------+
| Trading Systems |  | Sales & MArketing |  | Risk Systems    |  | Analytics System  |
+-----------------+  +-------------------+  +-----------------+  +-------------------+
```
