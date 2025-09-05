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

## 2.2 Data Proccess API
## 2.3 Data Generator API

The Data Generator is a universal data maintenance and inquiry tool, which can be configured to display and allow editing of data items from any EDM database table or view.
The Data Generator grid's appearance can be customized using Data Illustrators, and user-entered data can be validated using Rule Builders.
Permission to edit can be set at the user level or field level, and it is possible to control whether data rows can be added or deleted.

A Data Generator comprises a Data Generator Function (the configuration part) and a Data Generator Inbox (the display part),
and the Data Generator Function can be configured as an input source to a Data Manager Function,
which allows edits to take place on the data displayed within the Data Manager according to the parameters set within the Data Generator.

```
+--------+-------------------------------------+
| Method | Path                                |
+--------+-------------------------------------+
| GET    | /api/datagenerator                  |
+--------+-------------------------------------+
| GET    | /api/datagenerator/{name}           |
+--------+-------------------------------------+
| GET    | /api/datagenerator/{name}/data      |
+--------+-------------------------------------+
| POST   | /api/datagenerator/{name}/data      |
+--------+-------------------------------------+
| DELETE | /api/datagenerator/{name}/data/{id} |
+--------+-------------------------------------+
| PUST   | /api/datagenerator/{name}/data/{id} |
+--------+-------------------------------------+
```
### 2.3.1 Data Generator Functions
TBD
Every DG Functions is associated with a data source.

### 2.3.2 Data Generator Inbox

The Generator Inbox allows users to view and maintain a selection of rows from a table, as configured in the Generator Function described above. 

How the Data Generator Inbox displays and how the user can interact with it depends on the options selected in the Generator Inbox Grid UI element in the thick client.

The options allow users to select the Data Generator on which to base the grid, whether the Data Generator's Add / Edit / Delete permissions should be overridden for this Element,
and to display field action buttons in the inbox grid.

As EDM uses a web-based UI, the default items per page can be set so that (for example) they reduce network traffic.

Users can also choose whether to show the full Data Generator toolbar, or to hide it unless the inbox grid is zoomed to full screen.
The specific buttons that will be visible on the toolbar can be individually enabled (the "Filter" option can no longer be disabled as of EDM v17.1).

The option to make double-clicking the grid cause the Next button to be triggered on the Workflow is also available.
This emulates a drill-down from a row on the grid into another Page in the Workflow.

If no Quick Search is selected, the Quick searched defined in the Data Generator function will be available for the end-user's use,
just like they would be in EDM. If a Quick Search is picked in the Element definition, then the quick search is fixed, and the user will not be able to select a different one.
The parameters from the selected Quick Search are added to the input parameters however, allowing the values to be controlled by other Workflow Elements.
This facility is used to provide a programmable filter for an inbox grid, for example to be used to show some search results.

When the 'Default values for new rows' option is selected, all the inbox columns are presented with the option to be able to flag which ones should have default values.
Any selected to have default values will create a new input parameter. This can then be set in the Workflow designer.
When setting and creating a new row in the inbox, any columns with their default value set will be populated on the Inbox grid.

Users can also select whether error dialogues should be suppressed, unsaved warnings should be hidden,
CTRL+C copies formatted values and custom context menu items should be added to the inbox grid.


### 2.3.3 DG API End-Points

#### 2.3.3.1 GET /api/datagenerator
This request returns the definitions of the subset of permitted Data Generator functions for which the API client user has minimal 'Open' Console Group permission. 
Use <b>limit & offset</b> to control pagination.<b>x-total-count</b> gives the total number of records.
```json
[
 {
  "Name" : "BookList",
  "Enabled": true,
  "Parameters": [],
  "Fields": [
    {
      "Name": "BookID",
      "IllustratedName": "Book ID",
      "Type": "Integer (32 bit)",
      "KeyField": true,
      "HasDecodes":true
    },
    {
      "Name": "BookName",
      "IllustratedName": "Book Name -",
      "Type": "Text",
      "KeyField": false,
      "HasDecodes":true
    },
    ...
  ]
 },
 ...
]
```
#### 2.3.3.2 GET /api/datagenerator/{name}

This request returns the definition of the specified Data Generator function.
If the API client does not have permissions to the specified function, this is indicated in the API response body.

eg. GET edmtest.example.com/api/datagenerator/Ops%20Transactions

#### 2.3.3.3 GET /api/datagenerator/{name}/data


# 3. EDM Test Harness

Framework for running CADIS process agent. Knobs for:
* set up test environment for each test in the form of _initialization actions_.
  - Compare results of the process that run:
    - database tables that have been populated as a result of the test
    - files that have been produced (through finalizing actions
  - it can run any executable component, eg:
    - data porter inspector  matching a constructor
    - data flow
    - full solution
    - sulution of solutions

```
+-------------------------------------------+    +-------------------------------------------+
| Client Machine                            |    | File Server                +-------------+|
|                                           |    |                          +-------------+ ||
|  +----------------------+                 |    | +-------------------+  +-------------+ | ||
|  | Input Files          |                 |    | | QATesting\        |  | Package     | | ||
|  | +----------------------+  <------+----------+ | AutomatedTesting\ |  | Test Data   | | ||
|  | | Output Files         |         |     |    | | Test Cases XXXX   |  | DB Scripts  | | ||
|  | |                      |         |     |    | +-------------------+  | DB Params   | | ||
|  | |                      |         |     |    |                        |             | | ||
|  +-|                      |         |     |    |                        | Expected    | | +|
|    |                      |         |     |    |                        | Results     | +  |
|    +----------------------+         |     |    |                        +-------------+    |
|   ______                            |     |    +-------------------------------------------+
|  /      \ <-- Test Harness ---------+     |
|  \______/     EDM Database                |
|                                           |
|   +-------------------------------+       |    +-------------------------------------------+
|   |      Test Harness App         | <----------+ Test Config (DB Server)                   |
|   +-------------------------------+       |    |   ______                                  |
|                                           |    |  /      \                                 |
|   +--------------------+     +-----------+|    |  \______/                                 |
|   | Working Files      |     | Test      ||    +-------------------------------------------+
|   | +-------------------+    | Harness   ||
|   | | Program Files     |    | Config    ||
|   + | +------------------+   | XML       ||
|     | | Log Files        |    \__________||
|     + |                  |                |
|       |                  |                |
|       +------------------+                |
+-------------------------------------------+
```
