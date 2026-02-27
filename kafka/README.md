# 1. Kafka Intro

- event-driven architecture, or receiver-driven routing architecture - based for decoupled/plugabble architecture
  - sender doesn't know anything about receiver
  - transfer state enabling integration

goal: parts can evolve independently for each other

Book: Designing Event Driven Systems: Concepts and Patterns.. Ben Stopford

## 1.1 Basics: Architecture & Data Flow

- default message retention: 2 weeks, but can also be infinite
- immutable messages
- append only log data structure messages

```
                 +-----------------------------------------------------------------------------+
                 |             +-------------+       +-------------+        +-------------+    |
                 |          +--| ZooKeeper 1 |-------| ZooKeeper 2 |--------| ZooKeeper 3 |--+ |
+----------+     |          |  +-------------+       +-------------+        +-------------+  | |
| Producer |-+   |          +----------------------------------------------------------------+ |
| Clients  | |-+ |        _____               +-----------------+                              |
+----------+ | | |       /     \___________   | Broker 1        |                              |
  +----------+ |-|------+       Writes Msg \  | +------------+  |                              |
    +----------+ |       \      to Topic A,  +--| P0  |1|2|  |--|-----------\                  |   +------------------------+
                 |        \     Partition 0   | +------------+  |             \                |   | Topic A Consumer Group |
                 |         \                  | +------------+  |              \               |   |                        |
                 |          \                 | | P1  |1|2|3 |  |                \_____________|___|__+----------------+    |
                 |           \                | +------------+  |                              |   |  | Consumer 1     |    |
                 |            \               +-----------------+                              |   |  +----------------+    |
                 |             +--------------\                                                |   |  +----------------+    |
                 |      +-----------------+     \           +-----------------+             ___|___|__| Consumer 2     |    |
                 |      | Broker 2        |       \         | Broker 3        |            /   |   |  +----------------+    |
                 |      | +------------+  |         \       | +------------+  |          /     |   |                        |
                 |      | | P0  |1|2|  |  | Writes Msg \    | | P0  |1|2|  |  |        /       |   |  size: 2               |
                 |      | +------------+  | to Topic A, \   | +------------+  |      /         |   +------------------------+
                 |      | +------------+  | Partition 1  \___ +------------+  |    /           |
                 |      | | P1  |1|2|3 |  |                 | | P1  |1|2|3 |__|__/             |
                 |      | +------------+  |                 | +------------+  |                |
                 |      +-----------------+                 +-----------------+                |
                 +-----------------------------------------------------------------------------+
```
### 1.1.1 Brokers         

- Designed to store data produced by producers and consumed by consumers
- offer scalability through data distributions
- resiliency via replication (multiple brokers)

### 1.1.2 Zookeepers (TB phased out)

- Maintain operational meta deta about brokers

### 1.1.3 Topics

A logical container to group messages that can be produced and consumed from.

### 1.1.4 Topic-Partition

Allows concurrent writing/reading (linearity scaling), it's a subset of topic's message.
By increasing partitions, increase throughput of messages. Partitions spread across
brokers have assigned leaders for each partition. 

### 1.1.5 Replication

Topic replication is the processing of replicating data/topic partitions across multiple
broker nodes. If a broker fails, the data is replicated in another broker.

### 1.1.6 Consumer Groups

A group of Kafka consumers. Used to have the size aligned with the partions so the reading
can occur is parallel.

### 1.1.7 Partition Offset

Slots (offset) in the partition that holds the messages

### 1.1.8 Message

## 1.2 APIs (Clients)

### 1.2.1 Admin API

### 1.2.2 Producer API

### 1.2.4 Consumer API

## 1.5 Schema Registry: Kafka Maturity

## 1.6 Kafka Connect: Near Real-Time Data Pipeline

## 1.7 Stream Processing and Kafka Related Technologies

