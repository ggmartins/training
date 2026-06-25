<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [AI Engineering Study Guide](#ai-engineering-study-guide)
- [1. What is AI Engineering?](#1-what-is-ai-engineering)
  - [1.1 Why AI Engineering Became Important](#11-why-ai-engineering-became-important)
    - [1.1.1 Better Models](#111-better-models)
    - [1.1.2 Lower Build Barrier](#112-lower-build-barrier)
  - [1.2 AI Engineering vs Traditional Machine Learning](#12-ai-engineering-vs-traditional-machine-learning)
    - [1.2.1 Traditional ML Workflow](#121-traditional-ml-workflow)
    - [1.2.2 AI Engineering Workflow](#122-ai-engineering-workflow)
  - [1.3 Applications Powered by Foundation Models](#13-applications-powered-by-foundation-models)
  - [1.4 The AI Engineering Mindset](#14-the-ai-engineering-mindset)
    - [1.4.1 Product Thinking](#141-product-thinking)
    - [1.4.2 Systems Thinking](#142-systems-thinking)
    - [1.4.3 Iterative Improvement](#143-iterative-improvement)
- [2. Understanding Foundation Models](#2-understanding-foundation-models)
  - [2.1 How Foundation Models Learn](#21-how-foundation-models-learn)
    - [2.1.1 Self-Supervision](#211-self-supervision)
    - [2.1.2 From Language Models to LLMs](#212-from-language-models-to-llms)
    - [2.1.3 From LLMs to Multimodal Models](#213-from-llms-to-multimodal-models)
  - [2.2 Training Data and Its Limits](#22-training-data-and-its-limits)
    - [2.2.1 Web-Crawled Data](#221-web-crawled-data)
    - [2.2.2 Filtering and Data Quality](#222-filtering-and-data-quality)
    - [2.2.3 Language and Domain Skew](#223-language-and-domain-skew)
  - [2.3 Transformer Architecture](#23-transformer-architecture)
    - [2.3.1 Before Transformers](#231-before-transformers)
    - [2.3.2 Attention](#232-attention)
    - [2.3.3 Parallel Processing](#233-parallel-processing)
  - [2.4 Inference Mechanics](#24-inference-mechanics)
    - [2.4.1 Prefill](#241-prefill)
    - [2.4.2 Decode](#242-decode)
  - [2.5 Scaling and Bottlenecks](#25-scaling-and-bottlenecks)
    - [2.5.1 Diminishing Returns](#251-diminishing-returns)
    - [2.5.2 Data Bottlenecks](#252-data-bottlenecks)
    - [2.5.3 Energy Bottlenecks](#253-energy-bottlenecks)
  - [2.6 Post-Training](#26-post-training)
    - [2.6.1 Supervised Fine-Tuning](#261-supervised-fine-tuning)
    - [2.6.2 Preference Optimization](#262-preference-optimization)
- [3. Evaluating AI Models](#3-evaluating-ai-models)
  - [3.1 Training Metrics](#31-training-metrics)
    - [3.1.1 Cross-Entropy](#311-cross-entropy)
    - [3.1.2 Perplexity](#312-perplexity)
    - [3.1.3 Limits of Perplexity](#313-limits-of-perplexity)
  - [3.2 Functional Correctness](#32-functional-correctness)
    - [3.2.1 Task Completion](#321-task-completion)
    - [3.2.2 Execution Accuracy](#322-execution-accuracy)
    - [3.2.3 Objective Game or Tool Metrics](#323-objective-game-or-tool-metrics)
  - [3.3 Reference-Based Evaluation](#33-reference-based-evaluation)
    - [3.3.1 Exact Match](#331-exact-match)
    - [3.3.2 Lexical Similarity](#332-lexical-similarity)
    - [3.3.3 Semantic Similarity](#333-semantic-similarity)
  - [3.4 AI-as-Judge Evaluation](#34-ai-as-judge-evaluation)
    - [3.4.1 What AI Judges Can Score](#341-what-ai-judges-can-score)
    - [3.4.2 Judge Prompt Design](#342-judge-prompt-design)
    - [3.4.3 Limits of AI Judges](#343-limits-of-ai-judges)
    - [3.4.4 Bias Mitigation](#344-bias-mitigation)
  - [3.5 Evaluation Pipelines](#35-evaluation-pipelines)
    - [3.5.1 End-to-End and Component Evaluation](#351-end-to-end-and-component-evaluation)
    - [3.5.2 Turn-Based Evaluation](#352-turn-based-evaluation)
    - [3.5.3 Task-Based Evaluation](#353-task-based-evaluation)
    - [3.5.4 Rubrics](#354-rubrics)
    - [3.5.5 Business Metrics](#355-business-metrics)
  - [3.6 Reliability of Evaluation](#36-reliability-of-evaluation)
    - [3.6.1 Bootstrap Testing](#361-bootstrap-testing)
    - [3.6.2 Data Slices](#362-data-slices)
    - [3.6.3 Metric Correlation](#363-metric-correlation)
    - [3.6.4 Evaluation Cost and Latency](#364-evaluation-cost-and-latency)
- [4. Model Selection](#4-model-selection)
  - [4.1 Selection Criteria](#41-selection-criteria)
    - [4.1.1 Performance](#411-performance)
    - [4.1.2 Cost](#412-cost)
    - [4.1.3 Latency](#413-latency)
    - [4.1.4 Privacy](#414-privacy)
    - [4.1.5 Control](#415-control)
  - [4.2 Public Benchmarks](#42-public-benchmarks)
    - [4.2.1 Benchmark Mismatch](#421-benchmark-mismatch)
    - [4.2.2 Data Contamination](#422-data-contamination)
    - [4.2.3 Contamination Signals](#423-contamination-signals)
  - [4.3 Shortlisting Models](#43-shortlisting-models)
    - [4.3.1 Start Broad](#431-start-broad)
    - [4.3.2 Run Application Benchmarks](#432-run-application-benchmarks)
    - [4.3.3 Choose for the System, Not the Demo](#433-choose-for-the-system-not-the-demo)
  - [4.4 Model Routing](#44-model-routing)
    - [4.4.1 Simple Tasks](#441-simple-tasks)
    - [4.4.2 Complex Tasks](#442-complex-tasks)
    - [4.4.3 Fallbacks](#443-fallbacks)
- [5. Prompt Engineering](#5-prompt-engineering)
  - [5.1 Why Prompt Engineering Matters](#51-why-prompt-engineering-matters)
    - [5.1.1 Lightweight Adaptation](#511-lightweight-adaptation)
    - [5.1.2 Not Enough by Itself](#512-not-enough-by-itself)
  - [5.2 Components of a Prompt](#52-components-of-a-prompt)
    - [5.2.1 Task Description](#521-task-description)
    - [5.2.2 Examples](#522-examples)
    - [5.2.3 Concrete User Task](#523-concrete-user-task)
  - [5.3 In-Context Learning](#53-in-context-learning)
    - [5.3.1 Zero-Shot](#531-zero-shot)
    - [5.3.2 One-Shot](#532-one-shot)
    - [5.3.3 Few-Shot](#533-few-shot)
  - [5.4 System and User Prompts](#54-system-and-user-prompts)
    - [5.4.1 System Prompt](#541-system-prompt)
    - [5.4.2 User Prompt](#542-user-prompt)
    - [5.4.3 Chat Templates](#543-chat-templates)
  - [5.5 Prompting Strategies](#55-prompting-strategies)
    - [5.5.1 Write Clear Instructions](#551-write-clear-instructions)
    - [5.5.2 Use Personas Carefully](#552-use-personas-carefully)
    - [5.5.3 Provide Examples](#553-provide-examples)
    - [5.5.4 Specify Output Format](#554-specify-output-format)
    - [5.5.5 Break Complex Tasks into Subtasks](#555-break-complex-tasks-into-subtasks)
    - [5.5.6 Give the Model Time to Reason](#556-give-the-model-time-to-reason)
    - [5.5.7 Iterate Systematically](#557-iterate-systematically)
  - [5.6 Prompt Automation](#56-prompt-automation)
    - [5.6.1 Automated Prompt Optimization](#561-automated-prompt-optimization)
    - [5.6.2 Risks of Automation](#562-risks-of-automation)
- [6. RAG and Context Construction](#6-rag-and-context-construction)
  - [6.1 What RAG Solves](#61-what-rag-solves)
  - [6.2 Main Components of RAG](#62-main-components-of-rag)
    - [6.2.1 Retriever](#621-retriever)
    - [6.2.2 Generator](#622-generator)
  - [6.3 Indexing and Querying](#63-indexing-and-querying)
    - [6.3.1 Indexing](#631-indexing)
    - [6.3.2 Querying](#632-querying)
  - [6.4 Chunking](#64-chunking)
    - [6.4.1 Equal-Length Chunking](#641-equal-length-chunking)
    - [6.4.2 Overlapping Chunks](#642-overlapping-chunks)
    - [6.4.3 Chunk Size Tradeoffs](#643-chunk-size-tradeoffs)
  - [6.5 Retrieval Methods](#65-retrieval-methods)
    - [6.5.1 Term-Based Retrieval](#651-term-based-retrieval)
    - [6.5.2 Embedding-Based Retrieval](#652-embedding-based-retrieval)
    - [6.5.3 Hybrid Retrieval](#653-hybrid-retrieval)
  - [6.6 Reranking](#66-reranking)
    - [6.6.1 Recency Signals](#661-recency-signals)
    - [6.6.2 Relevance Signals](#662-relevance-signals)
  - [6.7 Query Rewriting](#67-query-rewriting)
    - [6.7.1 Conversation Context](#671-conversation-context)
    - [6.7.2 Query Expansion](#672-query-expansion)
  - [6.8 Context Augmentation](#68-context-augmentation)
    - [6.8.1 Metadata](#681-metadata)
    - [6.8.2 Document Summaries](#682-document-summaries)
  - [6.9 Choosing a Retrieval Solution](#69-choosing-a-retrieval-solution)
  - [6.10 Multimodal and Tabular RAG](#610-multimodal-and-tabular-rag)
    - [6.10.1 Multimodal RAG](#6101-multimodal-rag)
    - [6.10.2 Tabular RAG](#6102-tabular-rag)
- [7. Agents and Memory Systems](#7-agents-and-memory-systems)
  - [7.1 What Is an Agent?](#71-what-is-an-agent)
    - [7.1.1 Examples of Environments](#711-examples-of-environments)
    - [7.1.2 Tools Make Agents Powerful](#712-tools-make-agents-powerful)
  - [7.2 Agent Workflow](#72-agent-workflow)
    - [7.2.1 Observe](#721-observe)
    - [7.2.2 Plan](#722-plan)
    - [7.2.3 Act](#723-act)
    - [7.2.4 Evaluate](#724-evaluate)
    - [7.2.5 Continue or Finish](#725-continue-or-finish)
  - [7.3 Tool Categories](#73-tool-categories)
    - [7.3.1 Knowledge Augmentation Tools](#731-knowledge-augmentation-tools)
    - [7.3.2 Capability Extension Tools](#732-capability-extension-tools)
    - [7.3.3 Write-Action Tools](#733-write-action-tools)
  - [7.4 Planning](#74-planning)
    - [7.4.1 Generate a Plan](#741-generate-a-plan)
    - [7.4.2 Validate the Plan](#742-validate-the-plan)
    - [7.4.3 Execute After Validation](#743-execute-after-validation)
  - [7.5 Improving Agent Planning](#75-improving-agent-planning)
    - [7.5.1 Clear Tool Descriptions](#751-clear-tool-descriptions)
    - [7.5.2 Natural Language Plans First](#752-natural-language-plans-first)
    - [7.5.3 Parameter Reporting](#753-parameter-reporting)
  - [7.6 Agent Failures](#76-agent-failures)
    - [7.6.1 Planning Failures](#761-planning-failures)
    - [7.6.2 Tool Failures](#762-tool-failures)
    - [7.6.3 Compounding Errors](#763-compounding-errors)
  - [7.7 Evaluating Agents](#77-evaluating-agents)
    - [7.7.1 Planning Dataset](#771-planning-dataset)
    - [7.7.2 Planning Metrics](#772-planning-metrics)
    - [7.7.3 Efficiency Metrics](#773-efficiency-metrics)
  - [7.8 Memory Systems](#78-memory-systems)
    - [7.8.1 Internal Knowledge](#781-internal-knowledge)
    - [7.8.2 Context Window](#782-context-window)
    - [7.8.3 External Memory](#783-external-memory)
    - [7.8.4 Memory Design Rule](#784-memory-design-rule)
  - [7.9 Safety and Oversight](#79-safety-and-oversight)
- [8. 43:02 Finetuning](#8-4302-finetuning)
  - [8.1 When to Fine-Tune](#81-when-to-fine-tune)
    - [8.1.1 Domain Capability](#811-domain-capability)
    - [8.1.2 Instruction Following](#812-instruction-following)
  - [8.2 When Not to Fine-Tune](#82-when-not-to-fine-tune)
    - [8.2.1 Use Prompting First](#821-use-prompting-first)
    - [8.2.2 Use RAG for Knowledge Updates](#822-use-rag-for-knowledge-updates)
    - [8.2.3 Avoid Fine-Tuning for Real-Time Facts](#823-avoid-fine-tuning-for-real-time-facts)
  - [8.3 Types of Fine-Tuning](#83-types-of-fine-tuning)
    - [8.3.1 Full Fine-Tuning](#831-full-fine-tuning)
    - [8.3.2 Parameter-Efficient Fine-Tuning](#832-parameter-efficient-fine-tuning)
    - [8.3.3 LoRA-Style Adaptation](#833-lora-style-adaptation)
  - [8.4 Fine-Tuning Dataset Requirements](#84-fine-tuning-dataset-requirements)
    - [8.4.1 High-Quality Examples](#841-high-quality-examples)
    - [8.4.2 Representative Coverage](#842-representative-coverage)
    - [8.4.3 Clear Output Style](#843-clear-output-style)
  - [8.5 Fine-Tuning Risks](#85-fine-tuning-risks)
    - [8.5.1 Overfitting](#851-overfitting)
    - [8.5.2 Regression](#852-regression)
    - [8.5.3 Data Quality Amplification](#853-data-quality-amplification)
  - [8.6 Fine-Tuning Evaluation](#86-fine-tuning-evaluation)
    - [8.6.1 Compare Against Prompting](#861-compare-against-prompting)
    - [8.6.2 Compare Against RAG](#862-compare-against-rag)
    - [8.6.3 Measure Production Metrics](#863-measure-production-metrics)
- [9. Dataset Engineering](#9-dataset-engineering)
  - [9.1 Why Dataset Engineering Matters](#91-why-dataset-engineering-matters)
    - [9.1.1 Garbage In, Garbage Out](#911-garbage-in-garbage-out)
    - [9.1.2 Data as Product Infrastructure](#912-data-as-product-infrastructure)
  - [9.2 Types of Datasets in AI Engineering](#92-types-of-datasets-in-ai-engineering)
    - [9.2.1 Evaluation Datasets](#921-evaluation-datasets)
    - [9.2.2 Fine-Tuning Datasets](#922-fine-tuning-datasets)
    - [9.2.3 Preference Datasets](#923-preference-datasets)
    - [9.2.4 Retrieval Datasets](#924-retrieval-datasets)
    - [9.2.5 Feedback Datasets](#925-feedback-datasets)
  - [9.3 Data Collection](#93-data-collection)
    - [9.3.1 Human-Written Examples](#931-human-written-examples)
    - [9.3.2 Production Logs](#932-production-logs)
    - [9.3.3 Synthetic Data](#933-synthetic-data)
    - [9.3.4 Domain Documents](#934-domain-documents)
  - [9.4 Data Quality](#94-data-quality)
    - [9.4.1 Relevance](#941-relevance)
    - [9.4.2 Correctness](#942-correctness)
    - [9.4.3 Diversity](#943-diversity)
    - [9.4.4 Consistency](#944-consistency)
    - [9.4.5 Freshness](#945-freshness)
  - [9.5 Dataset Versioning](#95-dataset-versioning)
    - [9.5.1 Reproducibility](#951-reproducibility)
    - [9.5.2 Regression Testing](#952-regression-testing)
    - [9.5.3 Dataset Lineage](#953-dataset-lineage)
  - [9.6 Human and AI Labeling](#96-human-and-ai-labeling)
    - [9.6.1 Human Labels](#961-human-labels)
    - [9.6.2 AI Labels](#962-ai-labels)
    - [9.6.3 Hybrid Review](#963-hybrid-review)
  - [9.7 Dataset Maintenance](#97-dataset-maintenance)
    - [9.7.1 Add New Failures](#971-add-new-failures)
    - [9.7.2 Remove Stale Information](#972-remove-stale-information)
    - [9.7.3 Monitor Distribution Shift](#973-monitor-distribution-shift)
- [10. Inference Optimization](#10-inference-optimization)
  - [10.1 Why Inference Optimization Matters](#101-why-inference-optimization-matters)
    - [10.1.1 Latency](#1011-latency)
    - [10.1.2 Throughput](#1012-throughput)
    - [10.1.3 Cost](#1013-cost)
  - [10.2 Token Optimization](#102-token-optimization)
    - [10.2.1 Shorter Prompts](#1021-shorter-prompts)
    - [10.2.2 Context Pruning](#1022-context-pruning)
    - [10.2.3 Output Length Control](#1023-output-length-control)
  - [10.3 Caching](#103-caching)
    - [10.3.1 Prompt Cache](#1031-prompt-cache)
    - [10.3.2 Response Cache](#1032-response-cache)
    - [10.3.3 Retrieval Cache](#1033-retrieval-cache)
  - [10.4 Model Routing](#104-model-routing)
    - [10.4.1 Small Model First](#1041-small-model-first)
    - [10.4.2 Escalation](#1042-escalation)
    - [10.4.3 Specialized Models](#1043-specialized-models)
  - [10.5 Batching and Parallelism](#105-batching-and-parallelism)
    - [10.5.1 Batch Similar Requests](#1051-batch-similar-requests)
    - [10.5.2 Parallel Tool Calls](#1052-parallel-tool-calls)
    - [10.5.3 Parallel Candidate Generation](#1053-parallel-candidate-generation)
  - [10.6 Streaming](#106-streaming)
    - [10.6.1 User Experience](#1061-user-experience)
    - [10.6.2 Monitoring](#1062-monitoring)
  - [10.7 Quantization and Efficient Serving](#107-quantization-and-efficient-serving)
    - [10.7.1 Quantization](#1071-quantization)
    - [10.7.2 Hardware-Aware Deployment](#1072-hardware-aware-deployment)
    - [10.7.3 Distillation](#1073-distillation)
  - [10.8 Reliability and Fallbacks](#108-reliability-and-fallbacks)
    - [10.8.1 Retry Strategy](#1081-retry-strategy)
    - [10.8.2 Graceful Degradation](#1082-graceful-degradation)
    - [10.8.3 Validation Gates](#1083-validation-gates)
- [11. Architecture and User Feedback](#11-architecture-and-user-feedback)
  - [11.1 Production AI Architecture](#111-production-ai-architecture)
    - [11.1.1 Core Components](#1111-core-components)
    - [11.1.2 Separation of Concerns](#1112-separation-of-concerns)
    - [11.1.3 Configuration over Hardcoding](#1113-configuration-over-hardcoding)
  - [11.2 Observability](#112-observability)
    - [11.2.1 What to Log](#1121-what-to-log)
    - [11.2.2 Privacy-Aware Logging](#1122-privacy-aware-logging)
    - [11.2.3 Traceability](#1123-traceability)
  - [11.3 Feedback Loops](#113-feedback-loops)
    - [11.3.1 Explicit Feedback](#1131-explicit-feedback)
    - [11.3.2 Implicit Feedback](#1132-implicit-feedback)
    - [11.3.3 Expert Feedback](#1133-expert-feedback)
  - [11.4 Turning Feedback into Improvements](#114-turning-feedback-into-improvements)
    - [11.4.1 Evaluation Updates](#1141-evaluation-updates)
    - [11.4.2 Prompt Updates](#1142-prompt-updates)
    - [11.4.3 Retrieval Updates](#1143-retrieval-updates)
    - [11.4.4 Fine-Tuning Updates](#1144-fine-tuning-updates)
  - [11.5 Deployment and Experimentation](#115-deployment-and-experimentation)
    - [11.5.1 A/B Testing](#1151-ab-testing)
    - [11.5.2 Canary Releases](#1152-canary-releases)
    - [11.5.3 Rollbacks](#1153-rollbacks)
  - [11.6 Human-in-the-Loop Design](#116-human-in-the-loop-design)
    - [11.6.1 Escalation](#1161-escalation)
    - [11.6.2 Review Queues](#1162-review-queues)
    - [11.6.3 Approval Before Action](#1163-approval-before-action)
  - [11.7 Safety, Security, and Governance](#117-safety-security-and-governance)
    - [11.7.1 Permissions](#1171-permissions)
    - [11.7.2 Policy Enforcement](#1172-policy-enforcement)
    - [11.7.3 Auditability](#1173-auditability)
  - [11.8 The Continuous Improvement Loop](#118-the-continuous-improvement-loop)
- [Practical Learning Checklist](#practical-learning-checklist)
  - [A. Build a Minimal AI Application](#a-build-a-minimal-ai-application)
  - [B. Add Evaluation](#b-add-evaluation)
  - [C. Add RAG](#c-add-rag)
  - [D. Add Agent Tools](#d-add-agent-tools)
  - [E. Add Feedback](#e-add-feedback)
- [Summary](#summary)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# AI Engineering Study Guide

Source transcript: `ai/eng/yt_marina_wyss_transcript.txt` from `ggmartins/training`  
Original video source: https://www.youtube.com/watch?v=JV3pL1_mn2M  
Context: Marina Wyss summary of Chip Huyen's *AI Engineering*.

This README organizes the transcript into a practical learning guide. It keeps the same major flow from the video: what AI engineering is, how foundation models work, how to evaluate and select models, how to adapt them through prompts/RAG/agents/fine-tuning, and how to build production systems with dataset engineering, inference optimization, architecture, and user feedback.

---

# 1. What is AI Engineering?

AI engineering is the discipline of building useful applications on top of foundation models. Instead of training every model from scratch, AI engineers combine existing large models with prompts, retrieval, tools, memory, fine-tuning, evaluation pipelines, product architecture, and user feedback loops.

The key idea is adaptation. Traditional machine learning usually starts from a task, collects a dataset, trains a model, tunes the model, deploys it, and monitors it. AI engineering often starts with a general-purpose model and adapts it to a product or workflow.

## 1.1 Why AI Engineering Became Important

AI engineering grew quickly because two things happened at the same time:

- Foundation models became much better at solving real problems.
- The barrier to building applications with them became much lower.

This changed the role of the engineer. Instead of spending most effort on model training, the AI engineer spends more effort on system design: choosing the right model, constructing the right context, evaluating outputs, managing cost and latency, collecting feedback, and improving the system over time.

### 1.1.1 Better Models

Modern foundation models can generate text, write code, summarize documents, answer questions, reason over structured and unstructured context, and interact with external tools. This makes them useful as general building blocks for many applications.

### 1.1.2 Lower Build Barrier

APIs, open-source models, vector databases, hosted inference platforms, prompt tools, and agent frameworks make it possible to build AI products without owning the full training stack.

## 1.2 AI Engineering vs Traditional Machine Learning

Traditional ML engineering often focuses on building and training a task-specific model. AI engineering focuses on using a foundation model as a base capability and adapting it for a product.

### 1.2.1 Traditional ML Workflow

A common traditional ML workflow looks like this:

1. Define the task.
2. Collect labeled data.
3. Train a model.
4. Tune hyperparameters.
5. Evaluate on held-out data.
6. Deploy and monitor.

### 1.2.2 AI Engineering Workflow

A common AI engineering workflow looks like this:

1. Define the product behavior.
2. Select a foundation model.
3. Design prompts, schemas, tools, or retrieval pipelines.
4. Evaluate outputs against task and business metrics.
5. Improve with prompt iteration, RAG, agents, memory, fine-tuning, or dataset engineering.
6. Optimize inference cost, latency, and reliability.
7. Use user feedback to improve the system.

## 1.3 Applications Powered by Foundation Models

Foundation models can power many product categories:

- Coding assistants.
- Writing assistants.
- Customer support bots.
- Data analysis systems.
- Image generation tools.
- Search and knowledge assistants.
- Workflow automation agents.
- Multimodal assistants that handle text, image, video, or tabular data.

## 1.4 The AI Engineering Mindset

AI engineering is not only about getting a model to answer once. It is about building a reliable product around a probabilistic model.

### 1.4.1 Product Thinking

A model output is useful only if it helps users accomplish a goal. AI engineers should connect model metrics to product metrics such as task completion, support automation rate, time saved, conversion, user trust, or error reduction.

### 1.4.2 Systems Thinking

The final AI system usually includes many components:

- User interface.
- Prompt construction.
- Retrieval layer.
- Model router.
- Tool execution layer.
- Safety filters.
- Evaluation pipeline.
- Logging and monitoring.
- Feedback collection.
- Cost and latency controls.

### 1.4.3 Iterative Improvement

AI systems improve through iteration. The transcript emphasizes experimentation: try simple adaptation first, measure, then add complexity only when the evaluation results justify it.

---

# 2. Understanding Foundation Models

Foundation models are large, general-purpose AI systems trained on massive datasets. They are called "foundation" models because many applications can be built on top of them.

## 2.1 How Foundation Models Learn

Foundation models learn patterns from data. For language models, the core training objective is often predicting the next token or missing parts of text.

### 2.1.1 Self-Supervision

Self-supervision reduces the need for manually labeled data. Instead of requiring humans to label every example, the model learns from the structure of the input itself.

For example, in language modeling, the system can hide or predict parts of text. The text provides both the input and the target. This helped remove the data labeling bottleneck that limited many earlier AI systems.

### 2.1.2 From Language Models to LLMs

As models scaled with more data and more compute, they evolved from smaller language models into large language models. These models became capable of more general behavior, including instruction following, summarization, question answering, and code generation.

### 2.1.3 From LLMs to Multimodal Models

Foundation models expanded beyond text. Large multimodal models can process or generate multiple data types such as text, images, audio, video, or structured data.

## 2.2 Training Data and Its Limits

A model can only learn from the data it has seen during training. This has major implications for coverage, bias, factuality, and domain expertise.

### 2.2.1 Web-Crawled Data

Many foundation models are trained on large web-crawled datasets. Web data is broad, but it can include misinformation, clickbait, duplicated content, toxic text, fake news, low-quality pages, and biased distributions.

### 2.2.2 Filtering and Data Quality

Training teams use filters to remove low-quality or unsafe data. The transcript mentions filtering examples such as using signals from community platforms to decide what content may be higher quality. The larger lesson is that data selection has a strong effect on model behavior.

### 2.2.3 Language and Domain Skew

Training data is not evenly distributed across languages or domains. English and popular web topics are overrepresented, while many languages, specialized domains, and private enterprise contexts are underrepresented.

This explains why domain-specific models and language-specific models can matter.

## 2.3 Transformer Architecture

Most modern foundation models use transformer architectures based on the attention mechanism.

### 2.3.1 Before Transformers

Earlier sequence-to-sequence models processed inputs and outputs token by token. They often compressed the input into a representation that the decoder used to generate output. This created two problems:

- Long inputs were difficult to represent well.
- Sequential processing was slow for long sequences.

### 2.3.2 Attention

Attention allows the model to weigh the importance of different input tokens while generating each output token. Instead of relying only on a compressed summary, the model can attend to the most relevant parts of the context.

### 2.3.3 Parallel Processing

Transformers process input tokens in parallel during the prefill stage, making them efficient for long inputs compared with purely sequential approaches.

## 2.4 Inference Mechanics

Inference is the process of using the model to generate an output.

### 2.4.1 Prefill

The model first processes the full input prompt or context. This is the prefill stage. It is affected by prompt length, context construction, and retrieval strategy.

### 2.4.2 Decode

After prefill, the model generates output tokens one at a time. This decode stage often dominates latency for long answers.

## 2.5 Scaling and Bottlenecks

Scaling models with more data and compute can improve performance, but the transcript highlights diminishing returns and bottlenecks.

### 2.5.1 Diminishing Returns

Improving a model from one error rate to a slightly lower error rate can require much more data, compute, or energy. Even small gains can matter for downstream applications, but they may become expensive.

### 2.5.2 Data Bottlenecks

High-quality public internet data is limited. As models consume more of it, future systems may need proprietary data, synthetic data, better curation, or domain-specific datasets.

### 2.5.3 Energy Bottlenecks

Large-scale training and inference require significant electricity. Production AI systems must consider energy, infrastructure, cost, and efficiency.

## 2.6 Post-Training

Pretrained models are usually optimized for text completion, not necessarily for helpful conversations or safe task completion. Post-training adapts them.

### 2.6.1 Supervised Fine-Tuning

Supervised fine-tuning teaches a pretrained model to respond in more useful conversational or instruction-following formats.

### 2.6.2 Preference Optimization

Models can also be adjusted using human or AI preference signals. The goal is to make outputs more helpful, safe, aligned, and useful for users.

---

# 3. Evaluating AI Models

Evaluation is one of the hardest parts of AI engineering because model outputs can be open-ended, probabilistic, subjective, and context-dependent.

## 3.1 Training Metrics

Some metrics are useful during model training but are not always enough for production quality.

### 3.1.1 Cross-Entropy

Cross-entropy measures how well a model predicts the next token. Lower cross-entropy means the model is better at matching the distribution of the training data.

### 3.1.2 Perplexity

Perplexity is related to cross-entropy. It measures how uncertain a model is when predicting the next token. Lower perplexity usually means the model finds the sequence more predictable.

### 3.1.3 Limits of Perplexity

Perplexity is useful as a proxy for general language modeling capability, but it becomes less reliable after heavy post-training. A model can become better at following instructions while becoming less optimal at raw next-token prediction.

## 3.2 Functional Correctness

The best evaluation metric is often whether the system did the intended job.

### 3.2.1 Task Completion

If the user asks the system to book a reservation, the key question is not whether the answer sounds good. The key question is whether the correct reservation was made.

### 3.2.2 Execution Accuracy

For coding tasks, functional correctness often means the generated code runs and produces the expected result.

### 3.2.3 Objective Game or Tool Metrics

For game-playing agents, bots, or tool-using systems, evaluation can use objective measures such as win rate, success rate, number of steps, execution errors, or cost per successful task.

## 3.3 Reference-Based Evaluation

When reference answers exist, model outputs can be compared against them.

### 3.3.1 Exact Match

Exact match works when there is a single definitive answer. It is simple and cheap, but too strict for many natural language tasks.

### 3.3.2 Lexical Similarity

Lexical similarity compares token overlap, edit distance, BLEU, ROUGE, or similar metrics. It is useful but limited because many correct answers can use different wording.

### 3.3.3 Semantic Similarity

Semantic similarity compares meaning rather than exact words. This often uses embeddings and cosine similarity. It helps when answers can be phrased differently, but it depends on the quality of the embedding model.

## 3.4 AI-as-Judge Evaluation

An AI judge is another model used to evaluate outputs.

### 3.4.1 What AI Judges Can Score

AI judges can evaluate qualities such as:

- Correctness.
- Factual consistency.
- Relevance.
- Helpfulness.
- Toxicity.
- Hallucination risk.
- Safety.
- Format compliance.

### 3.4.2 Judge Prompt Design

A good judge prompt should include:

- The evaluation task.
- The scoring criteria.
- The scoring scale.
- Few-shot examples.
- Clear output format.

### 3.4.3 Limits of AI Judges

AI judges are probabilistic. They can give different scores across runs or prompts. They can also have biases:

- Self-bias: preferring outputs from the same model family.
- Position bias: preferring the first answer.
- Verbosity bias: preferring longer answers.

### 3.4.4 Bias Mitigation

Mitigation tactics include randomizing response order, using multiple judges, calibrating with human review, and measuring judge agreement.

## 3.5 Evaluation Pipelines

Production evaluation should be systematic, repeatable, and tied to business impact.

### 3.5.1 End-to-End and Component Evaluation

Evaluate the full system output and also evaluate intermediate components such as retrieval quality, prompt formatting, tool call validity, and final answer quality.

### 3.5.2 Turn-Based Evaluation

Turn-based evaluation assesses each individual response in a multi-turn conversation.

### 3.5.3 Task-Based Evaluation

Task-based evaluation measures whether the system completed the task and how many turns, tool calls, retries, or corrections were needed.

### 3.5.4 Rubrics

Rubrics should be unambiguous. A good rubric helps human evaluators and AI judges score consistently.

### 3.5.5 Business Metrics

Model metrics should connect to business metrics. For example, if a chatbot reaches a certain factual consistency threshold, that may translate into a higher percentage of support requests that can be automated safely.

## 3.6 Reliability of Evaluation

Evaluation itself must be evaluated.

### 3.6.1 Bootstrap Testing

Create multiple bootstrap samples from the evaluation dataset. If scores vary widely across samples, the evaluation pipeline is not reliable enough.

### 3.6.2 Data Slices

Evaluate across user segments, languages, query types, difficulty levels, and edge cases. Aggregate performance can hide failures on important subgroups.

### 3.6.3 Metric Correlation

If two metrics are perfectly correlated, one may be redundant. If important metrics are completely uncorrelated, that may reveal a measurement problem or a tradeoff.

### 3.6.4 Evaluation Cost and Latency

Evaluation pipelines add cost and latency. Use cheap automated checks broadly and more expensive human or judge-based evaluations on smaller sampled subsets.

---

# 4. Model Selection

Model selection is the process of choosing the right foundation model for a specific application. The transcript emphasizes that the challenge is no longer only building models; it is selecting the right model for your needs.

## 4.1 Selection Criteria

A model should be selected based on several dimensions, not only benchmark score.

### 4.1.1 Performance

Measure performance on your own tasks. Public benchmarks are useful for shortlisting, but they rarely represent your application perfectly.

### 4.1.2 Cost

Model cost includes input tokens, output tokens, embedding calls, tool calls, reranking, retries, evaluation, and infrastructure.

### 4.1.3 Latency

A more accurate model may be too slow for a real-time workflow. AI engineers must balance answer quality with response time.

### 4.1.4 Privacy

Some use cases require careful handling of private data. This may influence whether to use a hosted API, a private deployment, an open-source model, or a hybrid architecture.

### 4.1.5 Control

More control may be needed when the team wants custom fine-tuning, custom inference, specialized safety filters, deterministic behavior, or deployment in a restricted environment.

## 4.2 Public Benchmarks

Public benchmarks can help narrow the list of candidate models, but they should not be treated as final proof.

### 4.2.1 Benchmark Mismatch

A model that scores well on public tests may not perform best for your customer support, legal review, coding assistant, internal search, or data analysis workflow.

### 4.2.2 Data Contamination

A benchmark can be contaminated if the model saw the benchmark data during training. This can make the model appear better than it really is.

### 4.2.3 Contamination Signals

Potential signals include unusually low perplexity on the evaluation data or high overlap between training-like content and evaluation examples.

## 4.3 Shortlisting Models

Use public information to create a shortlist, then run your own evaluations.

### 4.3.1 Start Broad

Begin with candidate models across different categories:

- Strong frontier models.
- Smaller cheaper models.
- Open-source models.
- Domain-specific models.
- Embedding models.
- Rerankers.

### 4.3.2 Run Application Benchmarks

Test candidates against your real tasks, representative prompts, realistic documents, realistic tool calls, and known failure cases.

### 4.3.3 Choose for the System, Not the Demo

The best demo model is not always the best production model. A smaller model may be better if it is cheaper, faster, easier to deploy, or sufficient for the task.

## 4.4 Model Routing

A production system may route different tasks to different models.

### 4.4.1 Simple Tasks

Use cheaper or smaller models for classification, routing, extraction, formatting, or low-risk tasks.

### 4.4.2 Complex Tasks

Use stronger models for reasoning, planning, tool use, difficult writing, or high-stakes decisions.

### 4.4.3 Fallbacks

Fallbacks improve reliability. A system can retry with a stronger model if the first output fails validation.

---

# 5. Prompt Engineering

Prompt engineering is the process of crafting instructions and context that guide a model toward the desired output. It is the easiest and most common adaptation technique because it does not change model weights.

## 5.1 Why Prompt Engineering Matters

Prompting may look simple, but effective prompt engineering requires experimental rigor. The transcript emphasizes extracting maximum value from prompting before moving to heavier techniques such as fine-tuning.

### 5.1.1 Lightweight Adaptation

Prompting changes behavior without training. This makes it fast to test, cheap to iterate, and easy to deploy.

### 5.1.2 Not Enough by Itself

Production systems still need statistics, evaluation, experiment tracking, dataset curation, monitoring, and product design.

## 5.2 Components of a Prompt

A prompt may contain multiple parts.

### 5.2.1 Task Description

The task description tells the model what role to play and what output is expected.

Example elements:

- Role.
- Goal.
- Constraints.
- Output format.
- Safety boundaries.

### 5.2.2 Examples

Examples show the model how to perform the task. These are especially useful for classification, formatting, tone, style, and edge cases.

### 5.2.3 Concrete User Task

The user task is the specific input to answer, summarize, transform, classify, or act on.

## 5.3 In-Context Learning

In-context learning means teaching the model what to do using examples inside the prompt.

### 5.3.1 Zero-Shot

The model receives instructions but no examples.

### 5.3.2 One-Shot

The model receives one example.

### 5.3.3 Few-Shot

The model receives multiple examples. Few-shot prompting can improve performance but increases context size and cost.

## 5.4 System and User Prompts

Many chat models distinguish system prompts from user prompts.

### 5.4.1 System Prompt

The system prompt usually contains role, goals, constraints, policies, and expected behavior.

### 5.4.2 User Prompt

The user prompt contains the current request or task.

### 5.4.3 Chat Templates

Different models use different chat templates. A mismatch in template formatting can cause silent performance failures.

## 5.5 Prompting Strategies

The transcript lists several practical strategies.

### 5.5.1 Write Clear Instructions

Reduce ambiguity. Specify the scoring system, output format, allowed assumptions, and what to do when information is missing.

### 5.5.2 Use Personas Carefully

Asking the model to respond as a particular expert or for a particular audience can change style and focus.

### 5.5.3 Provide Examples

Examples can strongly influence output style and behavior.

### 5.5.4 Specify Output Format

Tell the model whether to output JSON, Markdown, bullet points, a table, a schema, or no preamble.

### 5.5.5 Break Complex Tasks into Subtasks

Breaking a complex task into steps can improve monitoring, debugging, and parallelization. It can also increase latency if users do not see intermediate progress.

### 5.5.6 Give the Model Time to Reason

Process instructions, self-critique, and explicit step-by-step decomposition can improve quality, but they increase token usage and latency.

### 5.5.7 Iterate Systematically

Version prompts, track experiments, evaluate with standardized metrics, and store prompts outside application code.

## 5.6 Prompt Automation

Tools can automate prompt search, but the transcript recommends starting manually.

### 5.6.1 Automated Prompt Optimization

Some tools let you specify input/output formats, metrics, and evaluation data, then search for better prompts.

### 5.6.2 Risks of Automation

Automated prompt tools can be expensive, generate awkward prompts, include typos, or fail to keep up with changing model behavior.

---

# 6. RAG and Context Construction

Retrieval-Augmented Generation, or RAG, gives a model access to external information at inference time. It is a way to connect a foundation model to memory, documents, databases, images, or other knowledge sources.

## 6.1 What RAG Solves

A foundation model only knows what is in its training data and context window. RAG helps with:

- Fresh information.
- Private enterprise data.
- Long documents.
- Domain-specific knowledge.
- Reducing hallucinations by grounding answers.

## 6.2 Main Components of RAG

A RAG system has two main components.

### 6.2.1 Retriever

The retriever finds relevant information from an external memory source.

### 6.2.2 Generator

The generator is the foundation model that produces an answer using the retrieved context.

## 6.3 Indexing and Querying

Retrievers perform two main functions.

### 6.3.1 Indexing

Indexing prepares documents so they can be searched quickly later. This may include chunking, metadata extraction, embeddings, and storage in a search index or vector database.

### 6.3.2 Querying

Querying takes the user's request and retrieves relevant chunks. The indexing strategy determines what can be retrieved effectively.

## 6.4 Chunking

Large documents usually need to be split into smaller chunks because retrieving whole documents can exceed the model's context window.

### 6.4.1 Equal-Length Chunking

Documents can be split by characters, words, sentences, or paragraphs.

### 6.4.2 Overlapping Chunks

Overlap helps preserve boundary information so important context is not lost between chunks.

### 6.4.3 Chunk Size Tradeoffs

Smaller chunks allow more diverse information to fit into context, but they can lose surrounding meaning and increase embedding overhead. Larger chunks preserve context but reduce retrieval diversity.

## 6.5 Retrieval Methods

Production retrieval systems often combine multiple retrieval mechanisms.

### 6.5.1 Term-Based Retrieval

Term-based retrieval works well for exact names, IDs, error codes, and keywords.

### 6.5.2 Embedding-Based Retrieval

Embedding retrieval uses vector similarity to find semantically related content. It can outperform term-based retrieval for meaning-based search but can struggle with exact identifiers.

### 6.5.3 Hybrid Retrieval

Hybrid retrieval combines keyword and vector search. A cheaper retriever may first fetch candidates, then a more precise method reranks or filters them.

## 6.6 Reranking

Reranking refines the initial retrieval results. It helps when too many documents are retrieved or when the context window is limited.

### 6.6.1 Recency Signals

For time-sensitive data, newer documents may receive more weight.

### 6.6.2 Relevance Signals

Additional metadata, user permissions, source quality, document type, or business rules can affect ranking.

## 6.7 Query Rewriting

Query rewriting modifies the user's query to include missing context.

### 6.7.1 Conversation Context

If the user asks, "What is its population?" after asking about Paris, the system may rewrite the query as, "What is the population of Paris?"

### 6.7.2 Query Expansion

The system can add synonyms, entities, abbreviations, or domain terms to improve recall.

## 6.8 Context Augmentation

Chunks can be enriched with additional information to improve retrieval.

### 6.8.1 Metadata

Metadata may include tags, titles, authors, dates, permissions, product categories, or source systems.

### 6.8.2 Document Summaries

A chunk can include a short summary of the full document to preserve global meaning.

## 6.9 Choosing a Retrieval Solution

A retrieval system should be selected based on:

- Term search support.
- Embedding search support.
- Hybrid search support.
- Vector search algorithms.
- Embedding model compatibility.
- Indexing speed.
- Batch processing.
- Query latency.
- Storage scalability.
- Pricing.
- Compliance requirements.

## 6.10 Multimodal and Tabular RAG

RAG is not limited to text.

### 6.10.1 Multimodal RAG

A system can retrieve images, video frames, audio, or other media to answer questions.

### 6.10.2 Tabular RAG

A system can translate a user question into SQL, query a database, and use the results to generate an answer. For complex schemas, the system may first choose the relevant table or schema subset.

---

# 7. Agents and Memory Systems

Agents go beyond passive response generation. They can observe an environment, make decisions, call tools, take actions, and use results to continue the task.

## 7.1 What Is an Agent?

An agent is a system that can perceive its environment and act on it. In AI engineering, the environment depends on the use case.

### 7.1.1 Examples of Environments

- A game for a game-playing agent.
- The internet for a web agent.
- A database for a data analysis agent.
- Internal APIs for an enterprise workflow agent.

### 7.1.2 Tools Make Agents Powerful

A model becomes more capable when it can use tools such as search, SQL execution, calculators, browsers, APIs, file readers, or code interpreters.

## 7.2 Agent Workflow

An agent often follows a loop.

### 7.2.1 Observe

The agent receives user input or reads information from the environment.

### 7.2.2 Plan

The agent decides how to solve the task.

### 7.2.3 Act

The agent calls tools or takes actions.

### 7.2.4 Evaluate

The agent checks whether the result is sufficient.

### 7.2.5 Continue or Finish

If the task is incomplete, the agent repeats the loop. If complete, it produces the final response.

## 7.3 Tool Categories

The transcript groups tools into several categories.

### 7.3.1 Knowledge Augmentation Tools

These help the agent access information:

- Text retrievers.
- Image retrievers.
- SQL executors.
- Web search.
- APIs.
- Email readers.
- Browsers.

### 7.3.2 Capability Extension Tools

These give the model abilities it may not perform reliably internally:

- Calculators.
- Unit converters.
- Time zone converters.
- Translation services.
- Code interpreters.

### 7.3.3 Write-Action Tools

These allow the agent to change external systems:

- Sending email.
- Updating records.
- Creating tickets.
- Modifying files.
- Triggering workflows.

Write actions require stronger safety, permissions, validation, and logging.

## 7.4 Planning

Complex tasks require planning. Planning should often be separated from execution.

### 7.4.1 Generate a Plan

Ask the agent to propose steps before it acts.

### 7.4.2 Validate the Plan

Validate that the plan uses allowed tools, respects constraints, and does not include unnecessary or unsafe steps.

### 7.4.3 Execute After Validation

Only execute the plan once it passes validation. For sensitive tasks, include a human review step.

## 7.5 Improving Agent Planning

Planning can be improved through prompt engineering, stronger models, tool descriptions, and fine-tuning.

### 7.5.1 Clear Tool Descriptions

Tools should have clear names, parameter descriptions, constraints, and examples.

### 7.5.2 Natural Language Plans First

One useful pattern is to generate a natural language plan first, then translate it into exact function calls.

### 7.5.3 Parameter Reporting

Ask the agent to report the parameter values it plans to use for each function call. This creates a sanity check before execution.

## 7.6 Agent Failures

Agents can fail in multiple ways.

### 7.6.1 Planning Failures

Examples include:

- Invalid tools.
- Too many steps.
- Missing constraints.
- Wrong decomposition.
- Failure to satisfy the goal.

### 7.6.2 Tool Failures

Examples include:

- Bad translation from plan to function call.
- Invalid parameters.
- No access to required tools.
- Tool output is wrong or incomplete.
- Bad generated SQL.

### 7.6.3 Compounding Errors

Agents often require many steps. Each step can fail, so the overall success rate decreases as the workflow gets longer.

## 7.7 Evaluating Agents

Agent evaluation should measure validity, success, efficiency, cost, and safety.

### 7.7.1 Planning Dataset

Create examples as tuples of:

- Task.
- Available tools.
- Constraints.
- Expected outcome.

### 7.7.2 Planning Metrics

Useful metrics include:

- Percentage of valid plans.
- Attempts needed to get a valid plan.
- Percentage of valid tool calls.
- Rate of invalid tool calls.
- Constraint satisfaction rate.

### 7.7.3 Efficiency Metrics

Useful metrics include:

- Average steps per task.
- Cost per completed task.
- Latency per action.
- Slowest or most expensive actions.
- Comparison to human or agent baselines.

## 7.8 Memory Systems

Memory helps agents retain and use information over time.

### 7.8.1 Internal Knowledge

Internal knowledge is stored in model weights during training. It is useful for information needed across many tasks.

### 7.8.2 Context Window

The context window acts as short-term memory for the current session or task.

### 7.8.3 External Memory

External memory includes RAG systems, databases, files, user profiles, or other storage. It is useful for long-term or rarely needed information.

### 7.8.4 Memory Design Rule

A practical rule from the transcript:

- Essential information for all tasks belongs in training or system-level configuration.
- Rarely needed information belongs in long-term external memory.
- Immediate task-specific information belongs in the context window.

## 7.9 Safety and Oversight

Agents with tools can affect real systems. The more capable the agent, the more important safety, security, permission checks, monitoring, and human oversight become.

---

# 8. 43:02 Finetuning

Fine-tuning adapts a model to a specific task by further training it and adjusting its weights. Compared with prompting and RAG, fine-tuning is a deeper customization technique that requires more expertise, data, and resources.

## 8.1 When to Fine-Tune

Fine-tuning can improve model performance in two main ways.

### 8.1.1 Domain Capability

Fine-tuning can improve domain-specific performance, such as coding, medicine, finance, legal reasoning, support workflows, or company-specific language.

### 8.1.2 Instruction Following

Fine-tuning can improve adherence to specific formats, policies, tone, output schemas, or workflow constraints.

## 8.2 When Not to Fine-Tune

Fine-tuning should not be the first solution for every problem.

### 8.2.1 Use Prompting First

If better instructions, examples, decomposition, or output schemas solve the issue, prompting is simpler.

### 8.2.2 Use RAG for Knowledge Updates

If the issue is missing, private, or frequently changing knowledge, RAG is often better than fine-tuning.

### 8.2.3 Avoid Fine-Tuning for Real-Time Facts

Fine-tuning changes model behavior but does not create a live knowledge connection. Real-time facts need retrieval or tools.

## 8.3 Types of Fine-Tuning

Fine-tuning can vary by how much of the model is updated.

### 8.3.1 Full Fine-Tuning

Full fine-tuning updates all or most model weights. It can be powerful but expensive and risky if the dataset is small or low quality.

### 8.3.2 Parameter-Efficient Fine-Tuning

Parameter-efficient techniques update only a small number of parameters or adapters. They reduce training cost and make customization more practical.

### 8.3.3 LoRA-Style Adaptation

Low-rank adaptation methods add small trainable components while keeping the base model mostly frozen. This can be useful when you need customization without full model training cost.

## 8.4 Fine-Tuning Dataset Requirements

Fine-tuning depends heavily on dataset quality.

### 8.4.1 High-Quality Examples

The dataset should contain examples of the behavior you want the model to learn.

### 8.4.2 Representative Coverage

Include realistic user inputs, edge cases, failure modes, and desired outputs.

### 8.4.3 Clear Output Style

If you want the model to follow a format, every training example should consistently demonstrate that format.

## 8.5 Fine-Tuning Risks

Fine-tuning can introduce problems.

### 8.5.1 Overfitting

A model may memorize narrow examples instead of learning a robust behavior.

### 8.5.2 Regression

The fine-tuned model may improve on one task but get worse on general tasks.

### 8.5.3 Data Quality Amplification

Bad examples can teach bad behavior. Fine-tuning amplifies the quality of the dataset.

## 8.6 Fine-Tuning Evaluation

Evaluate the fine-tuned model against the baseline.

### 8.6.1 Compare Against Prompting

A fine-tuned smaller model may be cheaper and faster than prompting a larger model, but this must be measured.

### 8.6.2 Compare Against RAG

If RAG solves the knowledge problem, fine-tuning may be unnecessary.

### 8.6.3 Measure Production Metrics

Measure accuracy, latency, cost, safety, format compliance, and business outcomes.

---

# 9. Dataset Engineering

Dataset engineering is the process of creating, improving, filtering, labeling, and maintaining the data used to build, evaluate, fine-tune, or improve AI systems. Even when companies do not train foundation models from scratch, they still need strong dataset engineering for evaluation, RAG, fine-tuning, and user feedback.

## 9.1 Why Dataset Engineering Matters

AI systems are highly data-dependent. Better data often matters more than more complex modeling.

### 9.1.1 Garbage In, Garbage Out

Low-quality examples create low-quality behavior. Contradictory, outdated, biased, or noisy data can make the system unreliable.

### 9.1.2 Data as Product Infrastructure

Datasets are not one-time artifacts. They are production infrastructure that should be versioned, tested, monitored, and improved.

## 9.2 Types of Datasets in AI Engineering

Different parts of an AI system need different datasets.

### 9.2.1 Evaluation Datasets

Evaluation datasets measure whether the system works. They should include representative user tasks, edge cases, and failure cases.

### 9.2.2 Fine-Tuning Datasets

Fine-tuning datasets teach the model a desired behavior, output format, tone, or domain skill.

### 9.2.3 Preference Datasets

Preference datasets compare outputs and indicate which response is better. These can be used for ranking, reward modeling, or preference optimization.

### 9.2.4 Retrieval Datasets

Retrieval datasets include documents, chunks, metadata, embeddings, queries, and relevance labels.

### 9.2.5 Feedback Datasets

Feedback datasets come from user ratings, corrections, clicks, escalations, support tickets, or observed behavior.

## 9.3 Data Collection

Data can come from multiple sources.

### 9.3.1 Human-Written Examples

Human experts can write ideal examples, rubrics, corrections, and edge cases.

### 9.3.2 Production Logs

Production usage reveals real user language, common failures, ambiguous requests, and missing knowledge.

### 9.3.3 Synthetic Data

AI models can generate synthetic examples, but synthetic data should be filtered and evaluated carefully.

### 9.3.4 Domain Documents

Internal manuals, support articles, policies, contracts, specifications, and databases can become retrieval or fine-tuning data.

## 9.4 Data Quality

Quality matters more than volume in many AI engineering workflows.

### 9.4.1 Relevance

Examples should match the actual task.

### 9.4.2 Correctness

Outputs should be factually correct and aligned with the desired policy.

### 9.4.3 Diversity

The dataset should cover different user types, query styles, difficulty levels, and edge cases.

### 9.4.4 Consistency

Labels, formats, and tone should be consistent across examples.

### 9.4.5 Freshness

Knowledge-heavy systems need updates when documents, policies, prices, laws, or product behavior change.

## 9.5 Dataset Versioning

Every dataset used for evaluation or training should be versioned.

### 9.5.1 Reproducibility

Versioning makes experiments reproducible. You should know which dataset produced which model, prompt, or evaluation score.

### 9.5.2 Regression Testing

Keep old failure cases in the dataset so future changes do not reintroduce solved problems.

### 9.5.3 Dataset Lineage

Track where data came from, how it was filtered, who labeled it, and what transformations were applied.

## 9.6 Human and AI Labeling

Labeling can be performed by humans, AI systems, or a hybrid process.

### 9.6.1 Human Labels

Human labels are valuable for high-stakes, ambiguous, or domain-specific examples.

### 9.6.2 AI Labels

AI labels can scale quickly but need validation. AI-generated labels can inherit model bias or systematic mistakes.

### 9.6.3 Hybrid Review

A practical approach is to let AI label many examples and have humans review a subset or the most uncertain cases.

## 9.7 Dataset Maintenance

Datasets should evolve with the product.

### 9.7.1 Add New Failures

When production errors occur, add them to evaluation and training datasets.

### 9.7.2 Remove Stale Information

Outdated examples can train or evaluate the system against the wrong target behavior.

### 9.7.3 Monitor Distribution Shift

User behavior changes over time. Evaluation data should remain representative of current usage.

---

# 10. Inference Optimization

Inference optimization is the process of making model serving faster, cheaper, more reliable, and scalable. In production AI engineering, inference often determines whether a system is economically viable.

## 10.1 Why Inference Optimization Matters

Users care about response time, reliability, and quality. Businesses care about cost, throughput, and scalability.

### 10.1.1 Latency

Latency is how long the user waits. It includes retrieval, prompt construction, model prefill, decoding, tool calls, and post-processing.

### 10.1.2 Throughput

Throughput is how many requests the system can handle per unit of time.

### 10.1.3 Cost

Cost includes model calls, tokens, embeddings, reranking, retries, vector database queries, tool calls, and evaluation.

## 10.2 Token Optimization

Token usage affects both cost and latency.

### 10.2.1 Shorter Prompts

Keep prompts concise while preserving necessary instructions and context.

### 10.2.2 Context Pruning

Do not send irrelevant retrieved chunks. Use retrieval, reranking, and summarization to keep context focused.

### 10.2.3 Output Length Control

Set output limits and request concise formats when appropriate.

## 10.3 Caching

Caching avoids repeated work.

### 10.3.1 Prompt Cache

Cache repeated system prompts or shared context when the infrastructure supports it.

### 10.3.2 Response Cache

Cache deterministic or common responses when freshness requirements allow it.

### 10.3.3 Retrieval Cache

Cache frequent search results, embeddings, or reranked candidates.

## 10.4 Model Routing

Different tasks can use different models.

### 10.4.1 Small Model First

Start with a cheaper model for simple requests.

### 10.4.2 Escalation

Escalate to a stronger model when validation fails, confidence is low, or the task is complex.

### 10.4.3 Specialized Models

Use specialized models for embeddings, reranking, moderation, extraction, classification, or summarization.

## 10.5 Batching and Parallelism

Production systems can improve throughput through batching and parallelism.

### 10.5.1 Batch Similar Requests

Batching can improve hardware utilization, especially for self-hosted models.

### 10.5.2 Parallel Tool Calls

Independent retrieval or tool calls can run in parallel to reduce end-to-end latency.

### 10.5.3 Parallel Candidate Generation

Generate multiple candidates in parallel when quality matters, then use a judge or ranker to select the best one.

## 10.6 Streaming

Streaming improves perceived latency by showing partial output as it is generated.

### 10.6.1 User Experience

Users may tolerate longer total latency if useful output starts quickly.

### 10.6.2 Monitoring

Streaming does not remove the need for output validation, safety checks, or tool execution controls.

## 10.7 Quantization and Efficient Serving

For self-hosted or open-source models, serving optimizations can reduce cost.

### 10.7.1 Quantization

Quantization reduces numerical precision to make models smaller and faster, usually with some quality tradeoff.

### 10.7.2 Hardware-Aware Deployment

Model choice should match available hardware, memory, throughput requirements, and latency targets.

### 10.7.3 Distillation

A smaller student model can be trained to imitate a stronger teacher model for a narrower task.

## 10.8 Reliability and Fallbacks

Optimization should not reduce reliability.

### 10.8.1 Retry Strategy

Retries can handle transient failures but increase cost and latency.

### 10.8.2 Graceful Degradation

If a strong model is unavailable, the system can fall back to a simpler answer, a smaller model, or human escalation.

### 10.8.3 Validation Gates

Use schema validation, policy checks, factuality checks, or tool-output checks before returning high-risk answers.

---

# 11. Architecture and User Feedback

Architecture connects all AI engineering components into a production system. User feedback turns production usage into continuous improvement.

## 11.1 Production AI Architecture

A production AI system is more than a model call.

### 11.1.1 Core Components

A typical architecture includes:

- User interface.
- Request router.
- Prompt builder.
- Retrieval system.
- Tool layer.
- Model gateway.
- Output validator.
- Safety and policy layer.
- Logging and observability.
- Evaluation pipeline.
- Feedback collector.

### 11.1.2 Separation of Concerns

Separate prompts, retrieval, tool execution, model selection, validation, and feedback. This makes the system easier to debug and improve.

### 11.1.3 Configuration over Hardcoding

Prompts, thresholds, model choices, and routing rules should be configurable so they can be updated without changing application code.

## 11.2 Observability

AI systems need logs and traces because failures can occur at many layers.

### 11.2.1 What to Log

Log inputs, prompt versions, model versions, retrieved documents, tool calls, outputs, validation failures, latency, cost, and user feedback.

### 11.2.2 Privacy-Aware Logging

Logs may contain sensitive data. Apply redaction, access control, retention limits, and compliance policies.

### 11.2.3 Traceability

For each answer, the team should be able to reconstruct what happened: what prompt was used, what context was retrieved, what model responded, and what validations ran.

## 11.3 Feedback Loops

User feedback is a major source of improvement.

### 11.3.1 Explicit Feedback

Users can provide thumbs up/down, ratings, comments, corrections, or selected reasons.

### 11.3.2 Implicit Feedback

Behavioral signals include clicks, retries, edits, abandoned sessions, escalations, and whether the user completed the task.

### 11.3.3 Expert Feedback

Domain experts can review sampled outputs, high-risk cases, or failures reported by users.

## 11.4 Turning Feedback into Improvements

Feedback should flow into engineering workflows.

### 11.4.1 Evaluation Updates

Add recurring failures to the evaluation set.

### 11.4.2 Prompt Updates

Use feedback to improve instructions, examples, constraints, and output formats.

### 11.4.3 Retrieval Updates

If failures come from missing or irrelevant context, improve chunking, metadata, query rewriting, reranking, or source documents.

### 11.4.4 Fine-Tuning Updates

If failures show a consistent behavioral gap, create high-quality examples for fine-tuning.

## 11.5 Deployment and Experimentation

Production AI systems should change gradually and measurably.

### 11.5.1 A/B Testing

Compare prompts, models, retrieval settings, or UI changes against metrics such as task success, latency, cost, and user satisfaction.

### 11.5.2 Canary Releases

Roll out changes to a small percentage of users first.

### 11.5.3 Rollbacks

Every model, prompt, retrieval index, and dataset update should be rollbackable.

## 11.6 Human-in-the-Loop Design

Human review is important for high-risk, ambiguous, or expensive actions.

### 11.6.1 Escalation

The system should know when to escalate to a human instead of forcing an answer.

### 11.6.2 Review Queues

Route low-confidence, policy-sensitive, or high-impact outputs to a review queue.

### 11.6.3 Approval Before Action

For write actions, require confirmation or approval before the agent changes external systems.

## 11.7 Safety, Security, and Governance

AI architecture must include guardrails.

### 11.7.1 Permissions

Agents and tools should only access systems and data the user is allowed to access.

### 11.7.2 Policy Enforcement

Use safety policies, content filters, business rules, and output validation.

### 11.7.3 Auditability

Keep enough trace data to audit important decisions and actions.

## 11.8 The Continuous Improvement Loop

The production loop is:

1. Build a baseline system.
2. Evaluate it before launch.
3. Deploy carefully.
4. Collect user feedback and logs.
5. Analyze failures.
6. Improve prompts, retrieval, datasets, tools, models, or architecture.
7. Re-evaluate.
8. Repeat.

AI engineering is therefore not a one-time model integration. It is an ongoing system-building discipline.

---

# Practical Learning Checklist

Use this checklist to study the README and convert it into hands-on projects.

## A. Build a Minimal AI Application

- Choose one task.
- Pick one model.
- Write a baseline prompt.
- Create 20 test examples.
- Evaluate outputs manually.

## B. Add Evaluation

- Define success criteria.
- Create a rubric.
- Add exact, semantic, or AI-judge evaluation.
- Track prompt and model versions.

## C. Add RAG

- Create a small document corpus.
- Chunk documents.
- Add metadata.
- Retrieve relevant chunks.
- Compare answers with and without RAG.

## D. Add Agent Tools

- Add one safe read-only tool.
- Require the agent to plan before calling the tool.
- Validate tool parameters.
- Log every tool call.

## E. Add Feedback

- Add thumbs up/down.
- Store user comments.
- Turn failures into evaluation examples.
- Improve the system in small iterations.

---

# Summary

AI engineering is the practice of turning foundation models into useful, reliable, and cost-effective products. The core skills are:

- Understanding foundation models and their limits.
- Evaluating outputs rigorously.
- Selecting the right model for the task.
- Prompting systematically.
- Building RAG and context pipelines.
- Designing agents and memory systems safely.
- Knowing when to fine-tune.
- Engineering datasets.
- Optimizing inference.
- Building architecture and feedback loops for continuous improvement.
