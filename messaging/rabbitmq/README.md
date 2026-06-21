<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->



<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 1. RabbitMQ Intro

Asynchronous communication, message broker for distributed systems. It may use MQTT, AMQP or STOMP implementations
as protocol plugins. Most commonly used with AMQP.

# 2. AMQP Asychnonous Message Queue Protocol

`Producer → Exchange → (binding) → Queue → Consumer`

It is an open standard protocol for messaging between systems. It lets applications send messages through a broker instead of calling each other directly.

A common AMQP broker is RabbitMQ.

Example flow:

Producer → Exchange → Queue → Consumer
Core AMQP concepts

Producer
The app that sends a message.

Exchange
Receives messages from producers and decides where to route them.

Queue
Stores messages until consumers read them.

Consumer
The app that receives/processes messages.

Binding
A rule connecting an exchange to a queue.

Routing key
A label used by the exchange to decide which queue should get the message.

