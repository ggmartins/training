<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. RabbitMQ Intro](#1-rabbitmq-intro)
- [2. AMQP Asychnonous Message Queue Protocol](#2-amqp-asychnonous-message-queue-protocol)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 1. RabbitMQ Intro

Asynchronous communication, message broker for distributed systems. It may use MQTT, AMQP or STOMP implementations
as protocol plugins. Most commonly used with AMQP.

# 2. AMQP Advanced Message Queue Protocol

`Producer → Exchange → (routing/binding) → Queue → Consumer`

It is an open standard protocol for messaging between systems. It lets applications send messages through a broker instead of calling each other directly.

A common AMQP broker is RabbitMQ.

## 2.1 Core AMQP concepts

- Producer: The app that sends a message.
- Exchange: Receives messages from producers and decides where to route them.
- Routing key: A label used by the exchange to decide which queue should get the message.
- Binding: A rule connecting an exchange to a queue.
- Queue: Stores messages until consumers read them.
- Consumer: The app that receives/processes messages.

## 2.2 AMQP vs Kafka

```
| Feature         | AMQP / RabbitMQ                     | Kafka                              |
| --------------- | ----------------------------------- | ---------------------------------- |
| Main model      | Message broker                      | Distributed log (append only)      |
| Best for        | Work queues, routing, commands      | Event streaming, replay, analytics |
| Message removal | Usually consumed/acked then removed | Retained for configured time       |
| Routing         | Very flexible exchanges             | Topic/partition-based              |
| Replay          | Not the main strength               | Core strength                      |

```

# 3 RabbitMQ Exchange Types:

```
| Exchange type | Routing logic             | Best for                     |
| ------------- | ------------------------- | ---------------------------- |
| **direct**    | Exact routing key match   | Specific event/command types |
| **fanout**    | Send to all bound queues  | Broadcast/pub-sub            |
| **topic**     | Pattern match routing key | Flexible event routing       |
| **headers**   | Match message headers     | Attribute-based routing      |

```

## 3.1 Direct exchange
## 3.2 Fanout Exchange
## 3.3 Topic Exchange
## 3.4 Header Exchange


