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
# 2. API
## 2.1 Required Concepts
### 2.1.1 Always On
Always-On solutions are preloaded into memory on the application server,
so that EDM can begin processing data as quickly as possible by reducing individual component-level startup times.
This guide explains how this functionality works and contains the following sections
#### 2.1.1.1 Use Cases
The most common application of an Always-On solution will be:
- Intraday solutions that are called multiple times throughout the business day.
- Solutions invoked from the UI.
- Solutions where optimal processing time is considered to be crucial.
#### 2.1.1.2 Installation Requirements

It is mandatory to install the *EDM Process Launcher Windows Service* on the *Application Server* for Always-On solutions,
even if you are not using a Process Launcher component.
Please refer to the EDM Services Installation Guide for further instructions on how to configure the EDM Services.

It is also mandatory to configure the *EDM Process Launcher REST API* on the Application Server for Always-On solutions,
which are run through the API. Please refer to the Process Launcher REST API guide to ensure the API is properly configured.

When the Process Launcher Windows Service starts up, any solutions that have been designated as Always-On will be preloaded into memory on the application server. To confirm that any Always-On solutions have successfully loaded, you may refer to the database view CADIS.vwServiceLog or the appropriate service log file commonly stored in the EDM temporary files location (e.g. C:\Users\windows.user\AppData\Local\MarkitEDM Temporary Files\Log).

#### 2.1.1.3 Solution Designation
In order for a solution to be preloaded into memory on service start, any appropriate solutions will need to be designated
as Always-On in the EDM thick-client application.

With the Solution open in the EDM thick-client application, you can access the component Properties via the tool bar icon.
The Solution Properties dialog allows you to select the Always On Solution checkbox to designate the Solution as such.

(System Properties with Always On Solution marked)


          
