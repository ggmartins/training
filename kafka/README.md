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

### 1.1.2 Zookeepers & KRaft(TB phased out)

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

```
+------------------------+
| Message                |
| +--------------------+ |
| | Header             | |
| | +----------------+ | |
| | | Topic          | | |
| | | Partition      | | |
| | +----------------+ | |
| +--------------------+ |
| | Key          test1 | |
| +--------------------+ |
| | Timestamp  1742004 | |
| +--------------------+ |
| | Offset           1 | |
| +--------------------+ |
| | Value  {"name":".. | |
| +--------------------+ |
+------------------------+
```

## 1.2 APIs (Clients)

### 1.2.1 Admin API

### 1.2.2 Producer API

### 1.2.4 Consumer API

## 1.5 Schema Registry: Kafka Maturity

## 1.6 Kafka Connect: Near Real-Time Data Pipeline

## 1.7 Stream Processing and Kafka Related Technologies

# 2. Managing Kafka

https://www.freecodecamp.org/news/stop-managing-kafka-manually-a-guide-to-kafka-ui-and-cruise-control/

# 3. AWS MKS (Managed Kafka Services)

https://docs.aws.amazon.com/msk/latest/developerguide/msk-provisioned.html

https://www.youtube.com/watch?v=5WaIgJwYpS8&list=PLhr1KZpdzukd2EuSB1F9zoWMTwinTkqVn

Reference Code:
```
https://github.com/ggmartins/dataengbb/tree/master/kafka

wget https: //archive.apache.org/dist/katka/2.6.2/kafka_2.12-2.6.2.tgz
tar -xzf kafka_2.12-2.6.2.tgz
aws kafka list-clusters

/nome/ec2-user/kafka_2.12-2.6.2/bin/katka-topics.sh create --bootstrap-server b-1.msk101.h90rjq.c10.kafka.us-west2.amazonaws.com:9092,
b-3.msk101.h90rjq.c10.kafka.us ... --replication-factor 3 —-partitions 1 --topic MSK101Topic

/nome/ec2-user/kafka_2.12-2.6.2/bin/katka-topics.sh —-bootstrap-server b-1.msk101.h9orjq.c10.kafka.us-west-2.amazonaws.com:9092,
b3.msk101.h9orjq.c10.kafka.us—west-2.amazonaws.com:9092, b-2.msk101.h9orjq.c10.kafka.us-west-2.amazonaws.com:9092 list

/home/ec2-user/kafka_2.12-2.6.2/bin/kafka-console-producer.sh —-bootstrap-server b-1.msk101.h90rjq.c1@.kafka.us-west-2.amazonaws.com: 9092,
b-3.msk101.h90rjq.c1@.kafka.us—west-2.amazonaws.com:9092,b-2.msk101.h9orjq.c10.kafka.us-west-2.amazonaws.com:9092 —topic MSK101Topic

Consume from Topic
/home/ec2-user /kafka_2.12-2.6.2/bin/kafka-console-consumer.sh —-bootstrap-server ... —topic MSK101Topic --from-beginning

```
