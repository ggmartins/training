<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [SSIS SQL Server Integration Services Training](#ssis-sql-server-integration-services-training)
- [1. Intro](#1-intro)
  - [1.1 What can it be used for?](#11-what-can-it-be-used-for)
  - [1.2 Learning Objectives](#12-learning-objectives)
- [2 Creating a Package and Processing of Flat File](#2-creating-a-package-and-processing-of-flat-file)
  - [2.1 Learning Objectives](#21-learning-objectives)
  - [2.2 SSIS Overview](#22-ssis-overview)
    - [2.2.1 Data Flow](#221-data-flow)
    - [2.2.2 Importing Multiple Files](#222-importing-multiple-files)
    - [2.2.3 Exporting Results into a Flat File](#223-exporting-results-into-a-flat-file)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

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

- Drag Other Sources -> Flat File *Source* into data flow
  - 2 arrows (blue: data flow normal reading, red: data flow error ocurrence)

- Drag Other Sources -> ADO (ActiveX Data Object) NET *Destination*
  - 1 red arrow (only red: for handling errors, no blue since we can't data direct destination)

- Flat File Connection Manager inside the Connection Manager tab

### 2.2.2 Importing Multiple Files

Look at SSIS Toolbox -> Containers

- For Loop Container
- Foreach Loop Container
- Sequence Container

Drag Foreach Loop Container into Control Flow

- General
- Collection
- Variable Mappings
- Expressions

Foreach File Enumerator. But also common use: <br>
Foreach ADO.NET Schema Rowset Enumerator (loop over all tables or rows)<br>

Foreach Loop Container:

- Select Foreach File Enumerator
- Foreach Loop Container -> Edit -> Collection -> Choose source folder, file pattern *.csv
- Foreach Loop Container -> Edit -> Variables Mapping -> Add Variable -> Select scope, Name: FilePath, Name space: User (String), Value [Leave Empty] (User::FilePath)
- Flat File Connection -> Properties -> Expressions (Property Expressions Editor)

Select *ConnectionString* property to change it dynamically -> Expression box: Drag from "System Variables" User::FilePath
<br>
<br>
Expression Builder Window (Similar to execel functions)



### 2.2.3 Exporting Results into a Flat File

- Drag Foreach Loop Container into Control Flow
- Edit Foreach Loop Container and change for Foreach SMO Enumerator 

Foreach SMO Enumerator -> Iterate over databases, schema, tables and treat it as programmable objects<br>
<br>
Select SMO Enumerator
- Objects (Prepopulate option)
- Names (table names)
- URNs
<br>
- Variable Mappings (map to variable to use in expressions)

Foreach Loop Container -> Execute Process Task (Drag into)

- Select Process -> Executable (Select SQLCMD.exe to run T-SQL)
- Select Expression -> Arguments (Property) User::TableName
Expression in double quotes:<br>
```
"-d Test -E -o \"C:\\User\\user1\\Desktop\\\" + @[User::TableName] + ".csv\" -Q \"SET NOCOUNT ON; SELECT * FROM Test.dbo.[" + @[User::TableName] + "]\" -s \",\" -W"
```