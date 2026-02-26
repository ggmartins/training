# 1. AWS Intro

- On-demand delivery of compute, storage, database and IT resources
- pay-as-you-go
- provision the exact type and size of computing resources you need
- instant access to resources through friedly interface

Private Cloud:

- Cloud services used by a single organization
- Complete Control
- Security for sensitive apps
- Meet specific business needs

Public Cloud:

- AWS, Azure, GCP
- Cloud resources owned and operated by a third-party cloud service provider delivered over the internet
- Five characteristics:
  - On demand self service - user provision resources without help from providers
  - Broad network access - resources can be accessed by a diverse network
  - multi-tenancy and resource pooling
    - multiple customers can share the same infrastructure and apps with security and privacy
    - multiple customers are serviced from the same physical resources
  - rapid elasticity and scalability - automatically and quick acquire and dispose resources when needed, easily scale on demand
  - immediate access
  - measured resources
- Six advantages:
  - no up front cost, trade CAPEX (capital expense) for OPEX (operational expense)
    - Pay on demand, don't own hardware
  - benefit from massive economy of scale
    - prices are reduced as AWS is more efficient due to the large scale
  - stop guessing capacity
    - scale based on actual measured capacity
  - increase speed and agility
  - no money on data center maintenaince
  - go global in minutes
- In other words:
  - Flexibility: change resources type when needed
  - Cost-effectiveness: pay-as-you-go, for what you use
  - Scalability: accommodate larger workloads by adding more nodes or upgrading existing hw
  - Elasticity: ability to scale-out or scale-in when needed
  - High availability and fault-tolerance: build across data centers / availability zones
  - Agility: rapidly develop, test and launch software applications

Hybrid Cloud:
- Keep some servers on-prem
- Extend capabilities to the cloud
- Control over sensitive assent on prem
- flexibility and cost effectiveness of the cloud

## 1.1 Types of Cloud Computing

- IaaS Infrastructure as a Service - building blocks of cloud IT (eg EC2):
  - network,
  - computers,
  - storage etc.
  - Highest Level of Flexibility
  - Easy parallel with traditional on-premises IT
- PaaS Platform as a Service (eg. Elastic Beanstalk):
  - No need to manage underlaying infrastructure
  - Focus on deploying and managing applications 
- SaaS Software as a Service: (ex. Rekognition for ML)
  - Complete software that runs on the cloud.

```
On-Prem                IaaS                   PaaS                   SaaS
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Applications*   |    | Applications*   |    | Applications*   |    | Applications+   |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Data*           |    | Data*           |    | Data*           |    | Data+           |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Runtime*        |    | Runtime*        |    | Runtime+        |    | Runtime+        |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Middleware*     |    | Middleware*     |    | Middleware+     |    | Middleware+     |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| OS*             |    | OS+             |    | OS+             |    | OS+             |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Virtualization* |    | Virtualization+ |    | Virtualization+ |    | Virtualization+ |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Servers*        |    | Servers+        |    | Servers+        |    | Servers+        |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Storage*        |    | Storage+        |    | Storage+        |    | Storage+        |
+-----------------+    +-----------------+    +-----------------+    +-----------------+
| Networking*     |    | Networking+     |    | Networking+     |    | Networking+     |
+-----------------+    +-----------------+    +-----------------+    +-----------------+

(*) Unmanaged
(+) Managed
```
## 1.2 Pricing

3 pricing fundamentals in pay-as-you-go:

- Compute - pay for compute time
- Storage - pay for the data stored (size) in the cloud
- Networking - pay for data transferred OUT (not in)
(solves the expensive issue of traditional IT)

## 1.3 Global Services

- AWS Regions
- AWS Availability Zones
- AWS Data Centers
- AWS Edge Locations / Point of presence

https://infrastructure.aws

## 1.4 Coming from Azure

Core mental model: how AWS “feels” vs Azure:

- Tenant vs. Org:
  - Azure: AAD tenant → Management Groups → Subscriptions → Resource Groups → Resources
  - AWS: Organizations → OUs → Accounts (hard isolation boundary) → Regions/AZs → VPCs → Resources
- Tip: Think “many small AWS accounts” instead of “one subscription with many RGs.”
- Identity & auth: Azure AD + RBAC → AWS IAM roles/policies + IAM Identity Center (SSO). Assume roles, don’t pass keys.
- Policy & governance: Azure Policy/Blueprints → AWS Service Control Policies (SCPs) + AWS Config + Organizations.
- Networking: VNet/peering/vWAN → VPC/peering/Transit Gateway. Security groups are stateful; NACLs are stateless.

```
+---------------------------+
| AWS Organizations         |
+---------------------------+
| OU Organization Unit      |
+---------------------------+
| Accounts (Hard Isolation) |
+---------------------------+
| AZ Availability Zone      |
+---------------------------+
| VPCs                      |
+---------------------------+
| Resources                 |
+---------------------------+
```

Org & identity you’ll set up first:

- AWS Organizations: Create OUs (e.g., security/, sandbox/, workloads/) and accounts per env (dev/test/prod).
- IAM Identity Center (SSO): Connect to your IdP (Entra ID works) → Permission Sets → Users assume roles in accounts.
- Guardrails: (Service Control Policies) SCPs (deny root access key, deny non-approved regions, require tagging), AWS Config + conformance packs, CloudTrail org-trail.

# 2. AWS Certifications

## 2.1 Basic

### 2.1.1 Cloud Practioner

Covering 40 out of 200+ AWS services. Example question:
- Which AWS Service simplify DB migration to AWS?
  - A. AWS Storage Gateway <- We'll learn
  - B. AWS Database Migration Services <- We'll learn
  - C. Amazon EC2 <- We'll learn
  - D. Amazon AppStream 2.0 <- distractor (over 200 services in AWS)
 
https://explore.skillbuilder.aws/learn/course/external/view/elearning/I4050/aws-certified-cloud-practitioner-official-practice-question-set-clf-c02-english

https://skillbuilder.aws/search?searchText=aws-certified-cloud-practitioner-official-practice-question-set-clf-c02-english&showRedirectNotFoundBanner=true

https://aws.amazon.com/free

### 2.1.2 AI Practioner

## 2.2 Associate

### 2.2.1 Developer Associate (DVA-C02) 

Link: https://aws.amazon.com/certification/certified-developer-associate/

Main Goal:

The exam validates a candidate’s ability to demonstrate proficiency in:
- developing
- testing
- deploying
- debugging AWS Cloud-based applications. 

Additional Goal:
- Develop and **optimize** applications on AWS.
- **Package** and **deploy** by using continuous integration and continuous delivery *(CI/CD)* workflows.
- **Secure** application code and data.
- **Identify and resolve** application issues. 

Technologies involved:

- AWS Services: including compute, container, database, application integration, analytics, storage, networking, and machine learning services.
- Security: Understand AWS security services, IAM policies, encryption, and compliance services to secure your applications.
- Deployment: Gain insights into AWS deployment services like CloudFormation, AWS SAM, CodeDeploy, and Elastic Beanstalk, and how to deploy applications effectively.
- Troubleshooting and Optimization: Learn how to monitor and optimize AWS applications using services like AWS X-Ray and DynamoDB.


#### 2.2.1.1 Content

##### 2.2.1.1.1 Content Domain 1: Development with AWS Services
Task 1: Develop code for applications hosted on AWS.

Knowledge of:
- Architectural patterns (for example, event-driven, microservices, monolithic, choreography, orchestration, fanout)
- Idempotency
- Differences between stateful and stateless concepts
- Differences between tightly coupled and loosely coupled components
- Fault-tolerant design patterns (for example, retries with exponential backoff and jitter, dead-letter queues)
- Differences between synchronous and asynchronous patterns

Skills in:
- Creating fault-tolerant and resilient applications in a programming language (for example, Java, C#, Python, JavaScript, TypeScript, Go)
- Creating, extending, and maintaining APIs (for example, response/request transformations, enforcing validation rules, overriding status codes)
- Writing and running unit tests in development environments (for example, using AWS Serverless Application Model [AWS SAM])
- Writing code to use messaging services
- Writing code that interacts with AWS services by using APIs and AWS SDKs
- Handling data streaming by using AWS services

Task 2: Develop code for AWS Lambda.

Knowledge of:
- Event source mapping
- Stateless applications
- Unit testing
- Event-driven architecture
- Scalability
- The access of private resources in VPCs from Lambda code

Skills in:
- Configuring Lambda functions by defining environment variables and parameters (for example, memory, concurrency, timeout, runtime, handler, layers, extensions, triggers, destinations)
- Handling the event lifecycle and errors by using code (for example, Lambda Destinations, dead-letter queues)
- Writing and running test code by using AWS services and tools
- Integrating Lambda functions with AWS services
- Tuning Lambda functions for optimal performance

Task 3: Use data stores in application development.

Knowledge of:
- Relational and non-relational databases
- Create, read, update, and delete (CRUD) operations
- High-cardinality partition keys for balanced partition access
- Cloud storage options (for example, file, object, databases)
- Database consistency models (for example, strongly consistent, eventually consistent)
- Differences between query and scan operations
- Amazon DynamoDB keys and indexing
- Caching strategies (for example, write-through, read-through, lazy loading, TTL)
- Amazon Simple Storage Service (Amazon S3) tiers and lifecycle management
- Differences between ephemeral and persistent data storage patterns
  
Skills in:
- Serializing and deserializing data to provide persistence to a data store
- Using, managing, and maintaining data stores
- Managing data lifecycles
- Using data caching services

##### 2.2.1.1.2 Content Domain 2: Security

Task 1: Implement authentication and/or authorization for applications and AWS
services.

Knowledge of:
- Identity federation (for example, Security Assertion Markup Language [SAML], OpenID Connect [OIDC], Amazon Cognito)
- Bearer tokens (for example, JSON Web Token [JWT], OAuth, AWS Security Token Service [AWS STS])
- The comparison of user pools and identity pools in Amazon Cognito
- Resource-based policies, service policies, and principal policies
- Role-based access control (RBAC)
- Application authorization that uses ACLs
- The principle of least privilege
- Differences between AWS managed policies and customer-managed policies
- Identity and access management

Skills in:
- Using an identity provider to implement federated access (for example, Amazon Cognito, AWS Identity and Access Management [IAM])
- Securing applications by using bearer tokens
- Configuring programmatic access to AWS
- Making authenticated calls to AWS services
- Assuming an IAM role
- Defining permissions for principals

Task 2: Implement encryption by using AWS services.

Knowledge of:
- Encryption at rest and in transit
- Certificate management (for example, AWS Private Certificate Authority)
- Key protection (for example, key rotation)
- Differences between client-side encryption and server-side encryption
- Differences between AWS managed and customer managed AWS Key Management Service (AWS KMS) keys

Skills in:
- Using encryption keys to encrypt or decrypt data
- Generating certificates and SSH keys for development purposes
- Using encryption across account boundaries
- Enabling and disabling key rotation

Task 3: Manage sensitive data in application code.

Knowledge of:
- Data classification (for example, personally identifiable information [PII], protected health information [PHI])
- Environment variables
- Secrets management (for example, AWS Secrets Manager, AWS Systems Manager Parameter Store)
- Secure credential handling

Skills in:
- Encrypting environment variables that contain sensitive data
- Using secret management services to secure sensitive data
- Sanitizing sensitive data

##### 2.2.1.1.3 Content Domain 3: Deployment

Task 1: Prepare application artifacts to be deployed to AWS.

Knowledge of:
- Ways to access application configuration data (for example, AWS AppConfig, Secrets Manager, Parameter Store)
- Lambda deployment packaging, layers, and configuration options
- Git-based version control tools (for example, Git)
- Container images

Skills in:
- Managing the dependencies of the code module (for example, environment variables, configuration files, container images) within the package
- Organizing files and a directory structure for application deployment
- Using code repositories in deployment environments
- Applying application requirements for resources (for example, memory, cores)

Task 2: Test applications in development environments.

Knowledge of:
- Features in AWS services that perform application deployment
- Integration testing that uses mock endpoints
- Lambda versions and aliases

Skills in:
- Testing deployed code by using AWS services and tools
- Performing mock integration for APIs and resolving integration dependencies
- Testing applications by using development endpoints (for example, configuring stages in Amazon API Gateway)
- Deploying application stack updates to existing environments (for example, deploying an AWS SAM template to a different staging environment)

Task 3: Automate deployment testing.

Knowledge of:
- API Gateway stages
- Branches and actions in the continuous integration and continuous delivery (CI/CD) workflow
- Automated software testing (for example, unit testing, mock testing)

Skills in:
- Creating application test events (for example, JSON payloads for testing Lambda, API Gateway, AWS SAM resources)
- Deploying API resources to various environments
- Creating application environments that use approved versions for integration testing (for example, Lambda aliases, container image tags, AWS Amplify branches, AWS Copilot environments)
- Implementing and deploying infrastructure as code (IaC) templates (for example, AWS SAM templates, AWS CloudFormation templates)
- Managing environments in individual AWS services (for example, differentiating between development, test, and production in API Gateway)

Task 4: Deploy code by using AWS CI/CD services.

Knowledge of:
- Git-based version control tools (for example, Git)
- Manual and automated approvals in AWS CodePipeline
- Access application configurations from AWS AppConfig and Secrets Manager
- CI/CD workflows that use AWS services
- Application deployment that uses AWS services and tools (for example, CloudFormation, AWS Cloud Development Kit [AWS CDK], AWS SAM, AWS CodeArtifact, AWS Copilot, Amplify, Lambda)
- Lambda deployment packaging options
- API Gateway stages and custom domains
- Deployment strategies (for example, canary, blue/green, rolling)

Skills in:
- Updating existing IaC templates (for example, AWS SAM templates, CloudFormation templates)
- Managing application environments by using AWS services
- Deploying an application version by using deployment strategies
- Committing code to a repository to invoke build, test, and deployment actions
- Using orchestrated workflows to deploy code to different environments
- Performing application rollbacks by using existing deployment strategies
- Using labels and branches for version and release management
- Using existing runtime configurations to create dynamic deployments (for example, using staging variables from API Gateway in Lambda functions)


##### 2.2.1.1.4 Content Domain 4: Troubleshooting and Optimization
Task 1: Assist in a root cause analysis.

Knowledge of:
- Logging and monitoring systems
- Languages for log queries (for example, Amazon CloudWatch Logs Insights)
- Data visualizations
- Code analysis tools
- Common HTTP error codes
- Common exceptions generated by SDKs
- Service maps in AWS X-Ray
Skills in:
- Debugging code to identify defects
- Interpreting application metrics, logs, and traces
- Querying logs to find relevant data
- Implementing custom metrics (for example, CloudWatch embedded metric format [EMF])
- Reviewing application health by using dashboards and insights
- Troubleshooting deployment failures by using service output logs

Task 2: Instrument code for observability.

Knowledge of:
- Distributed tracing
- Differences between logging, monitoring, and observability
- Structured logging
- Application metrics (for example, custom, embedded, built-in)

Skills in:
- Implementing an effective logging strategy to record application behavior and state
- Implementing code that emits custom metrics
- Adding annotations for tracing services
- Implementing notification alerts for specific actions (for example, notifications about quota limits or deployment completions)
- Implementing tracing by using AWS services and tools

Task 3: Optimize applications by using AWS services and features.

Knowledge of:
- Caching
- Concurrency
- Messaging services (for example, Amazon Simple Queue Service [Amazon SQS], Amazon Simple Notification Service [Amazon SNS])
  
Skills in:
- Profiling application performance
- Determining minimum memory and compute power for an application
- Using subscription filter policies to optimize messaging
- Caching content based on request headers

### 2.2.2 Solutions Architect

### 2.2.3 SysOps Administrator

### 2.2.3 Data Engineer

### 2.2.4 Machine Learning Engineer

## 2.3 Professional

### 2.3.1 DevOps Engineer

### 2.3.2 Solutions Architect

## 2.4 Specialty

### 2.4.1 Machine Learning

### 2.4.2 Security

### 2.4.3 Advanced Networking

# 3. Messaging Services

Most high-speed trading or low-latency market-data infrastructure uses:

- Kafka / MSK
  - Push-based via consumer group polling (but tight + low-latency)
  - Millisecond-level delivery
  - Replay + retention
  - Partition-level ordering
  - Much higher throughput
  - Much more predictable latency
- Redis Streams
  - Microsecond reads
  - Persistent or ephemeral
  - Great for order routing pipelines
- NATS / JetStream
  - Ultra-low latency messaging (sub-millisecond)
- In-memory queues (C++/Java trading engines)

## 3.1 SQS Simple Queue Service

Simple, not used for low/mid f latency, fully managed queue for decoupling workers (jobs/tasks). Easiest ops, good for serverless and background jobs, limited replay/ordering.

Vs Kafka: managed event log/stream for high-throughput, ordered, replayable event pipelines and multiple independent consumers. More powerful, more to operate/tune.

Choose SQS if you want:
- Fire-and-forget task queues for workers/Lambda (image processing, ETL jobs, webhooks → worker).
- Minimal ops: no brokers/partitions to plan, scales automatically.
- Dead-letter queues, visibility timeouts, simple backoff/retries built in.
- Pay-per-request economics at modest throughput.
- Integration with serverless (Lambda event source mappings, Step Functions) and simple IAM auth.

Choose MSK/Kafka if you need:
- Replay and long-term retention of events for new consumers/audits.
- Strict per-key ordering with high throughput/low latency.
- Multiple independent consumer groups processing the same topic differently.
- Stream processing (Kafka Streams, ksqlDB, Flink) and exactly-once semantics (idempotent producers + transactions).
- Large messages/throughput, backpressure control, and fine-grained batching.

### 3.1.1 Queues
- Can be provisioned through iac
- Hold messages
- Order not guaranteed by default
- Owned by subscribers, not publishers
- If fifo'd configured: limit to publishing ~100 messages per second
### 3.1.2 Messages
- Can be any time: blob, image, json, etc
- Limited Size cap
### 3.1.3 Polling
- SQS is a pull-based messaging system
- There is "no push" mechanism built into SQS itself
- A) Lambda → SQS integration (Managed Poller: AWS runs an internal poller for you)
  - AWS manages a fleet of long pollers behind the scenes.
- B) Custom Consumer (EC2, ECS, EKS, on-prem, Fargate)
  - You write the polling code defining WaitTimeSeconds=20 for polling








