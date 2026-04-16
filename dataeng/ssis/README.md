# SSIS SQL Server Integration Services Training

# 1. Intro

- A component of SQL Server
- Building Enterprise-Level solutions to complex problems
    - Data Integration
    - Data Transformation
- 1 of 3 Business Intelligence Components
    - Analysis Services (Data Mining, Multi dimension data structures)
    - Reporting Services (Server-based reporting) (*)
- Only available on Standard, Business Intelligence and Enterprise
  editions only (**)

(*) Reports can be deployed on a shared server,
    and can be viewed with a sharepoint dashboard
(**) Not available for SQL Server Express Edition

```
+--------------------+
| Reporting          |
| Services           |
+--------------------+
| Analysis           |
| Services           |
+--------------------+
| Integration        |
| Services           |
+--------------------+
| SQL Server DB      |
| Engine             |
+--------------------+

```

## 1.1 What can it be used for?

- ELT Extract, Transform and Loading (ETL)

Data Sources:

```
+---------------+
| Spreadsheets  |
+---------------+\
                  \_____+---------+    +------------+    +--------+   
+---------------+       |         |    | Transform  |    |        |   
| Databases     |-------| Extract |----| (merge,sort|----|  Load  |---+ 
+---------------+  _____|         |    | convert,etc|    |        |   |
                  /     +---------+    +------------+    +--------+   |
+---------------+/                                                   /
| XML/CSV Files |                                                  /
+---------------+                                 +----------------+.  +-------------+
                                                  | Data Warehouse |---| Analysis    | 
                                                  +----------------+.  +-------------+
                                                          |
                                                  +----------------+
                                                  | Reporting      |
                                                  +----------------+
- Web Service Integration
    - Geospacial service > geographical plotting of clients across the globe
    - SMS eg. messaging workers with client information updates
- Database Management
    - Integrity Check
    - Rebuilding Indexes and Clean-up

``` 

## 1.2 Learning Objectives

- ETL
- Transformations (merging, sorting, conversion)
- Making solutions dynamic ie. changing behavior at runtime
- Interacting with external applications using *scripts*
- Common issues:
    - Driver incompatibility
    - Data type inconscistences

# 2 Creating a Package and Processing of Flat File

Prerequisits

- SQL Server Installed (Standard, Business Intelligence, or Enterprise Edition)
    - Business Intelligence Developer Studio (SQL Server pre-2012 versions)
    - SQL Server Data Tools installed (SQL Server 2012 or newer)
    - Management Tools - Complete installed
    - Integration Services installed

- New SQL Server database created or access to an existing SQL Server database
- SQL Server or Windows Authenticated user (preferable a member of the SQL Server db_owner role)
- Sample flat file in csv or text format (sample data generator: mockaroo.com)

## 2.1 Learning Objectives

- How to create an integration Services Project
- An overview of the basic SQL Server Data Tools' features
- How to create integration Services Tasks
- How to create connections to and from an Integration Services Package
- How to read data from flat files
- How to write data to a SQL Server Database Tools
- How to connect to a SQL Server Instances
- How to view data in SQL Server Database

## 2.2 SSIS Overview

- SSIS Toolbox on the left
- Solution explorer on the right
  - Project.params
  - SSIS Packages
    - Package.dtsx
- Main tab
  - Control Flow
  - Data Flow - Drag Data Flow Task into Control flow (*)
  - Parameters
  - Event Handlers
  - Package Explorer

(*) Data Flow Task - A task that ETLs, Common -> Bulk Insert Task could also be used,
    if transformation os not needed

### 2.2.1 Data Flow

- drag Other Sources -> Flat File *Source* into data flow
  - 2 arrows (blue: data flow normal reading, red: data flow error ocurrence)

- drag Other Sources -> ADO (ActiveX Data Object) NET *Destination*
  - 1 red arrow (only red: for handling errors, no blue since we can't data direct destination)

- Flat File Connection Manager inside the Connection Manager tab




