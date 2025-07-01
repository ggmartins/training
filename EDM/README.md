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

Customers are able to streamline front, middle and back office operations and create
consistent versions of data in a fully audited and transparent environment.
The transparency of where data has come from, who has touched it, what rules were applied is ensured by EDM’s data lineage. 
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
## 1.1 Standard EDM Processing Flow

EDM essentially provides Extract, Transform and Load (ETL) functionality. 
```
+----------------------------------------------------------------------------+
 \   LOAD: Data Flow Process -> 1.Source, 2.Sequence, 3.Target              /
  +------------------------------------------------------------------------+
   \  DATA TYPE: Data Flow Sequence -> Data Typing checks                 /
     +-------------------------------------------------------------------+
      \ TRANSFORM ALIGN: text data -> typed data (validate CUSIP/ISIN) /
        +-------------------------------------------------------------+
         \ PREMATCH: Data Flow Sequence steps perform pre-match val / (Validate and Transform)
          +--------------------------------------------------------+
           \  CONSOLIDATION: (Optional) use Data Contructor to    / merge feeds.
             +---------------------------------------------------+
                                     |
                              +-------------+ Sources are matched and unique Cadis
                              |    MATCH    | IDs are assigned by the Core Matcher
                              +-------------+ Matched IDs are enriched on to related entities such as Prices, Trades and Positions.
                                     |
             +---------------------------------------------------+
           /  SOURCE VALIDATION: Data Inspector validates source  \ alignment.
          +--------------------------------------------------------+
        /  MASTERING: Business Inspection Framework: Master Gold Copy\ is built using hierarchy rules in data contructor.
       +--------------------------------------------------------------+
     /  MASTER VALIDATION: Data Inspector performs vertical / horizontal\ Master Validation
    +--------------------------------------------------------------------+
   / TARGET TRANSFORMATION: Data Contructor creates Master Data into target\ tables ready for exporting (Mapping Tables).
  +-------------------------------------------------------------------------+
/  EXPORT: Target Data is exported by Data Porter                            \
+-----------------------------------------------------------------------------+

```

### 1.1.1 LOAD Data Flow Process
### 1.1.2 DATA TYPE Data Floe Sequence
### 1.1.3 TRANSFORM ALIGN Data Flow Process
Data is aligned to house standards using mapping tables; e.g. currencies mapped to ISO 4217 Currency Codes.
### 1.1.4 PREMATCH Data Flow Sequence
### 1.1.5 CONSOLIDATION Data Constructor
### 1.1.6 MATCH Core Matcher
### 1.1.7 SOURCE VALIDATION Data Inspector
### 1.1.8 MASTERING Data Contructor
### 1.1.9 MASTER VALIDATION Data Inspector
### 1.1.10 TARGET TRANSFORMATION Data Contructor
### 1.1.11 EXPORT Data Porter

          
