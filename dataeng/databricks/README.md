<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. Databricks Certified Data Engineer Associate (DB-DEA)](#1-databricks-certified-data-engineer-associate-db-dea)
  - [1.1 Exam Breakdown](#11-exam-breakdown)
- [2. Data](#2-data)
  - [2.1 Data Types](#21-data-types)
  - [2.2 Data Document](#22-data-document)
  - [2.3 Data Movement](#23-data-movement)
    - [2.3.1 Batch](#231-batch)
    - [2.3.2 Streaming](#232-streaming)
  - [2.4 Data Modelling](#24-data-modelling)
    - [2.4.1 Relational vs Non-relational](#241-relational-vs-non-relational)
    - [2.4.2  Schema (Relational databases)](#242--schema-relational-databases)
      - [2.4.2.1 DSL (Domain Specific Language)](#2421-dsl-domain-specific-language)
    - [2.4.3 Schemaless (Non-relationship)](#243-schemaless-non-relationship)
  - [2.5 Data Integrity and Corruption](#25-data-integrity-and-corruption)
  - [2.5.1 Normalized vs Denormalized](#251-normalized-vs-denormalized)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 1. Databricks Certified Data Engineer Associate (DB-DEA)

- Managing data within databricks
- Creating ETL Workflows and Jobs within Databricks
- Governance, Security and Quality of Data within Databricks
- Apache Spark SQL Knowledge

Exam code for Databricks Data Engineer DB-DEA: *PR000054

- Practical knowledge over conceptual

Source: https://www.databricks.com/learn/training/certification#certifications


## 1.1 Exam Breakdown

- 10% Databricks Intelligence Platform
- 30% Development and Ingestion
- 21% Data Processing and Transformation
- 18% Productionizing Data Pipelines
- 11% Data Governance and Quality

More Info:
- 45 Questions - Multiple choice - no 
- 70% Min Score 700/1000 (12-ish questions wrong)
- 1.5 Hours (2 min per question)

# 2. Data

Data: units of information.




```
+------------------------------------------------------------+
| Data - units of information                                |
| +-------------------------------------------------------+  |
| | Data documents - types of abstract grouping of data   |  |
| | +---------------------------------------------------+ |  |
| | | Datasets - Logical grouping of data (*)           | |  |
| | | +-----------------------------------------------+ | |  |
| | | | Data Structures - structured data             | | |  |
| | | | +-------------------------------------------+ | | |  |
| | | | | Data Types - How single units of data are | | | |  |
| | | | | intended to be used / interpreted         | | | |  |
| | | | |                                           | | | |  |
| | | | +-------------------------------------------+ | | |  |
| | | +-----------------------------------------------+ | |  |
| | +---------------------------------------------------+ |  |
| +-------------------------------------------------------+  |
+------------------------------------------------------------+

(* structured or unstructured)
```

## 2.1 Data Types

A data type is (typed) units of information that can be text, numbers, images, videos, audio, physical documents
```
| Data type            |                Typical memory | Typical range / precision              | Key characteristics                                                                                                                       |
| -------------------- | ----------------------------: | -------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `byte` / `uint8`     |                        1 byte | 0 to 255                               | Smallest commonly addressable integer. Useful for binary data, files, images, and network packets.                                        |
| `sbyte` / `int8`     |                        1 byte | −128 to 127                            | Signed 8-bit integer.                                                                                                                     |
| `short` / `int16`    |                       2 bytes | −32,768 to 32,767                      | Saves memory when values are known to be small. Arithmetic may still be performed using 32-bit registers.                                 |
| `ushort` / `uint16`  |                       2 bytes | 0 to 65,535                            | Unsigned 16-bit integer.                                                                                                                  |
| `int` / `int32`      |                       4 bytes | −2.147 billion to 2.147 billion        | Usually the default integer type. Exact arithmetic within its range. Subject to overflow.                                                 |
| `uint` / `uint32`    |                       4 bytes | 0 to 4.294 billion                     | Doubles the positive range but cannot represent negative values.                                                                          |
| `long` / `int64`     |                       8 bytes | About ±9.22 quintillion                | Useful for timestamps, database identifiers, counters, and large quantities.                                                              |
| `ulong` / `uint64`   |                       8 bytes | 0 to about 18.44 quintillion           | Very large positive integer range. Interoperability can be less convenient because some systems lack unsigned integers.                   |
| `BigInteger`         |                      Variable | Limited mainly by memory               | Arbitrarily large exact integers. Slower and consumes more memory than fixed-size integers.                                               |
| `float` / `float32`  |                       4 bytes | About 7 decimal significant digits     | Fast and compact, but cannot exactly represent most decimal fractions. Accumulated arithmetic error is common.                            |
| `double` / `float64` |                       8 bytes | About 15–17 significant digits         | Default floating-point choice in many languages. More accurate than `float`, but still approximate.                                       |
| `decimal`            |        Usually 16 bytes in C# | About 28–29 significant decimal digits | Base-10-oriented representation. Appropriate for financial calculations. Still cannot represent repeating values such as `1 / 3` exactly. |
| Fixed-point number   |     Depends on representation | Predetermined scale                    | Often implemented as an integer plus an implied decimal scale. Exact for values within the selected scale.                                |
| Complex number       | Usually two floats or doubles | Depends on component type              | Represents a real and imaginary component, such as `3 + 4i`.                                                                              |
| Enum                 | Inherit for int/uint/byte     | Inherit for int/uint/byte              | Group of constants unchangeble states/options                                                                                                |
| 
```

## 2.2 Data Document

Data document is a definition of the collective form in which the data exists.
- Database: structured data that can be quickly accessed and serve searches/queries eg. Azure SQL
- Dataset: a logical grouping of data (structured, semi-structured or unstructured). eg MNIST Dataset
- Datastore: unstructured or semi-structured data repository eg. S3 Bucket / Azure Datalake
- Data Warehouse: structured or semistructured data that serve analytics and reports eg Azure Synapse Analytics
- Notebooks: data that is arranged in pages or cells designed for easy consumption eg Jupyter Notebooks

## 2.3 Data Movement



### 2.3.1 Batch

When you send batches (or collections) of data to be processed. Usually:
- Scheduled
- Not realtime
- Cost effective
- Good for large workloads

### 2.3.2 Streaming

You process the data as soon as it arrives using a pipeline of producers and consumers
- Good for real-time analytics
- Most expensive
- eg [Kafka](../../kafka/README.md)


## 2.4 Data Modelling

How do we design our data? 

### 2.4.1 Relational vs Non-relational

How do we access our data for query and search?

### 2.4.2  Schema (Relational databases) 

How do we structure out data for search?

- Schema: formal language that defines the structure of the data
  - Tables, Fields, Relationships, Indexes, Views, Packages, Procedures, Functions, XML Schemas,
  - Queues, Triggers, Types, Sequences, Materialized views, Database links, directories

#### 2.4.2.1 DSL (Domain Specific Language)

Schemas, DSLs (Domain Specific Languages), and tools like Pydantic are essential because they
automate data validation, type-checking, and serialization. They act as a strict contract between
different parts of a system, preventing errors, ensuring data integrity,
and making codebases easier to maintain and document.
  
### 2.4.3 Schemaless (Non-relationship)

"Schemaless" data management refers to handling dynamic data structures that lack a fixed,
predefined schema at storage time. This is typically achieved using native dictionary types,
interacting with NoSQL document databases, or building relational-backed key-value abstractions.

- Schemaless: when the data or data instance or primary "cell" of the data can accept many types
  -  Key/Value, Document, Columns/WideColumns, Graph


## 2.5 Data Integrity and Corruption

How do we trust our data?

## 2.5.1 Normalized vs Denormalized

Trading quality versus speed

