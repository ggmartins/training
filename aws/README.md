

# 1. AWS Intro


# 1.1 Coming from Azure

Core mental model: how AWS “feels” vs Azure:

- Tenant vs. Org:
  - Azure: AAD tenant → Management Groups → Subscriptions → Resource Groups → Resources
  - AWS: Organizations → OUs → Accounts (hard isolation boundary) → Regions/AZs → VPCs → Resources
- Tip: Think “many small AWS accounts” instead of “one subscription with many RGs.”
- Identity & auth: Azure AD + RBAC → AWS IAM roles/policies + IAM Identity Center (SSO). Assume roles, don’t pass keys.
- Policy & governance: Azure Policy/Blueprints → AWS Service Control Policies (SCPs) + AWS Config + Organizations.
- Networking: VNet/peering/vWAN → VPC/peering/Transit Gateway. Security groups are stateful; NACLs are stateless.

Org & identity you’ll set up first:

- AWS Organizations: Create OUs (e.g., security/, sandbox/, workloads/) and accounts per env (dev/test/prod).
- IAM Identity Center (SSO): Connect to your IdP (Entra ID works) → Permission Sets → Users assume roles in accounts.
- Guardrails: (Service Control Policies) SCPs (deny root access key, deny non-approved regions, require tagging), AWS Config + conformance packs, CloudTrail org-trail.

# 2. AWS Certifications

## 2.1 Basic

### 2.1.1 Cloud Practioner

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





