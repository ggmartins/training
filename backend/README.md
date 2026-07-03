<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. Backend Development Intro](#1-backend-development-intro)
- [2. REST API](#2-rest-api)
  - [2.1 Common Methods](#21-common-methods)
    - [2.1.1 Headers](#211-headers)
    - [2.1.2 Status Code](#212-status-code)
- [3 System Design Practices](#3-system-design-practices)
  - [3.1 The 4 Pillars of Good System Design](#31-the-4-pillars-of-good-system-design)
    - [3.1.1 Scalability](#311-scalability)
    - [3.1.2 Maintainability](#312-maintainability)
    - [3.1.3 Efficiency](#313-efficiency)
    - [3.1.4 Reliability](#314-reliability)
  - [3.2 The 3 Key Elements of Systems Design](#32-the-3-key-elements-of-systems-design)
    - [3.2.1 Moving Data](#321-moving-data)
    - [3.2.2 Storing Data](#322-storing-data)
    - [3.2.3 Trasforming Data](#323-trasforming-data)
  - [3.3 CAP Theorem](#33-cap-theorem)
    - [3.3.1 Consitency](#331-consitency)
    - [3.3.2 Availability](#332-availability)
    - [3.3.3 Partition Tolerance](#333-partition-tolerance)
    - [3.3.4 Examples](#334-examples)
- [4 Typical Flows](#4-typical-flows)
  - [4.1 Long time to process (>1min)](#41-long-time-to-process-1min)
  - [4.2 Pagination results](#42-pagination-results)
    - [4.2.1 Cursor Pagination vs Offset](#421-cursor-pagination-vs-offset)
    - [4.2.2 Lazy Loading](#422-lazy-loading)
  - [4.3 Locking and Conditional Write/Update (API version)](#43-locking-and-conditional-writeupdate-api-version)
    - [4.3.1 Locking Examples](#431-locking-examples)
      - [4.3.1.1 Optimistic Locking](#4311-optimistic-locking)
      - [4.3.1.2 Pessimistic Locking](#4312-pessimistic-locking)
- [5. API Sec](#5-api-sec)
  - [5.1 Regulation Landscape](#51-regulation-landscape)
  - [5.2 OWASP Top 10](#52-owasp-top-10)
    - [5.2.1 API1: Broken Object Level Authorization (BOLA)](#521-api1-broken-object-level-authorization-bola)
      - [5.2.1.1 API1 Example:](#5211-api1-example)
    - [5.2.2 API2: Broken User Authentication](#522-api2-broken-user-authentication)
    - [5.2.3 API3: Excessive Data Exposure](#523-api3-excessive-data-exposure)
    - [5.2.4 API4: Lack of Resources & Rate Limiting](#524-api4-lack-of-resources--rate-limiting)
    - [5.2.5 API5: Broken Function Level Authorization](#525-api5-broken-function-level-authorization)
- [6. API Infra](#6-api-infra)
  - [6.1 API Gateway](#61-api-gateway)
  - [6.2 Ingress Controller](#62-ingress-controller)
  - [6.3 Comparison API Gateway vs Ingress Controller](#63-comparison-api-gateway-vs-ingress-controller)
- [7. Caching](#7-caching)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 1. Backend Development Intro

# 2. REST API

## 2.1 Common Methods

Old way: GET/POST. Examples:

- GET localhost:3333/users/123/posts  (posts of user 123 ONLY)
- GET localhost:3333/posts?userID=123 (ALL posts permissions)

```
Feature      Route Params       Query Params
-----------+------------------+------------------
Location   | Part of the URL  |  After ? Symb
           | path             |  (?userID=123)
           | (/users/123)     |  (*) be aware if the URL max size
+----------+------------------+------------------
Purpose    | To identify a    |  To FILTER (optional),
           | specific and     |  sort or
           | REQUIRED res.    |  paginate res.
+----------+------------------+------------------
Visibility | Embedded in the  |  KV pairs 
           | URL structure    |  appended at
           |                  |  the end
+----------+------------------+------------------
Optionality| Usually mandatory|  Usually Optional
+----------+------------------+------------------
```

- POST localhost:3333/users/123/posts + Request Body (create a post, NOT idempotent by default)

Should not encode (encodeURIComponent("my params. ")) any sensitive data,
or any data at all. Use request body. Can use Idempotent Key for become idempotent.

- PUT localhost:3333/posts/1 + Request Body (update a post, idempotent)
- PATCH localhost:3333/posts/1/title + Request Body (update an INFO of that post)
- DELETE localhost:3333/posts/1 + Request Body
- HEAD localhost:3333/posts/1 (to know if the URL exists or NOT)
- OPTIONS

### 2.1.1 Headers

HTTPS headers are key-value pairs of metadata sent between a client (browser) and a server, transmitting crucial information about a request or response, such as content type, caching behavior, and security policies. 

- Accept-Language: en


### 2.1.2 Status Code

- https://www.webfx.com/web-development/glossary/http-status-codes/
- https://developers.cloudflare.com/support/troubleshooting/http-status-codes/

In a nutshell:

- 2XX = Success
- 3XX = Redirect
- 4XX = ERROR Client
- 5XX = ERROR Server

- 201 Created  : 
- 202 Accepted : it has being processed but no guarantees
- 204 No content

- 409 Conflict "email already exist" The request format is valid, but the operation conflicts with business state.
- 401 Unauthorized Despite the name, it really means not authenticated.
- 403 Forbidde "I know who you are, but you are not allowed to do this."
- 418 "not compatible"
- 404 Not found.

# 3 System Design Practices

## 3.1 The 4 Pillars of Good System Design

### 3.1.1 Scalability

Systems grows with the user base.

- Vertical Scaling: When traffic is low but CPU/MEM is high (utilization)
  - Can't add infinite CPU/MEM
  - No fail over mechnism SPOF (Single Point of Failure)
- Horizontal Scaling: When traffic is high and CPU/MEM utilization is moderate/high
  - Load balancing is always required

### 3.1.2 Maintainability

Ensure new users can understand and improve the current system.

### 3.1.3 Efficiency

Ensure the system is making the best use of the resources.

### 3.1.4 Reliability

Planning for failure. The system can still run and it's resilient to failures.

## 3.2 The 3 Key Elements of Systems Design

### 3.2.1 Moving Data

Ensure data moves smoothly, securely and as fast as possible from A to B, B to A, A to N, etc. 

### 3.2.2 Storing Data

Understading key components like:
- Data access patterns
- Access speed strategies (indexing, caching, etc)
- Backup strategies
- Trade off between data store technologies

### 3.2.3 Trasforming Data

Common operations:
- Transforming data to a new format
- Aggregating/Grouping/Calculating
- Mastering, matching and enriching data

## 3.3 CAP Theorem

Principles of the trade-off of designing distributed systems. The system can only accomodate for 2 out of 3 properties at the same time.

### 3.3.1 Consitency

Consistency ensures that multiple nodes all have the same version of the data at a the same time.
Changes should propagate to all other nodes.

### 3.3.2 Availability

Availability ensures that the system is capable of producing a valid response to operations regardless of what is happening behind the scenes.

### 3.3.3 Partition Tolerance

The system can still fully operate even after a partition failure event.

### 3.3.4 Examples

- Banking system: Consistency + Availability
- TODO: more examples and questions here.

# 4 Typical Flows

## 4.1 Long time to process (>1min)

<img width="479" height="449" alt="image" src="https://github.com/user-attachments/assets/04800b08-bd91-4180-8777-4d31f0fbb599" />

## 4.2 Pagination results

This is done via query params filters

- GET /orders?limit=50&offset=0
- GET /orders?limit=50&offset=50
- GET /orders?limit=50&offset=100

### 4.2.1 Cursor Pagination vs Offset

Cursor pagination uses a pointer to the last item from the previous page.

GET /orders?limit=50
```json
{
  "data": [
    {
      "id": 1050,
      "created_at": "2026-05-13T12:00:00Z"
    },
    {
      "id": 1049,
      "created_at": "2026-05-13T11:59:00Z"
    }
  ],
  "next_cursor": "eyJjcmVhdGVkX2F0IjoiMjAyNi0wNS0xM1QxMTo1OTowMFoiLCJpZCI6MTA0OX0="
}
```
- GET /orders?limit=50&cursor=eyJjcmVhdGVkX2F0IjoiMjAyNi0wNS0xM1QxMTo1OTowMFoiLCJpZCI6MTA0OX0=
<br>
Where `eyJjcmVhdGVkX2F0IjoiMjAyNi0wNS0xM1QxMTo1OTowMFoiLCJpZCI6MTA0OX0=`
being: `{"created_at":"2026-05-13T11:59:00Z","id":1049}`

```SQL
SELECT *
FROM orders
WHERE
  (created_at < '2026-05-13T11:59:00Z')
  OR
  (created_at = '2026-05-13T11:59:00Z' AND id < 1049)
ORDER BY created_at DESC, id DESC
LIMIT 50;
```

```
| Feature                     | Offset pagination | Cursor pagination |
| --------------------------- | ----------------: | ----------------: |
| Easy to implement           |               Yes |            Medium |
| Supports page numbers       |               Yes |     Not naturally |
| Good for large datasets     |         Not ideal |               Yes |
| Good for fast-changing data |         Not ideal |            Better |
| Can jump to page 50         |               Yes |        Not easily |
| Common for admin tables     |               Yes |         Sometimes |
| Common for feeds/timelines  |         Not ideal |               Yes |

```


`Always enforce a maximum page size.`

### 4.2.2 Lazy Loading

Lazy loading improves initial performance, but if implemented carelessly it can create N+1 queries or excessive API calls. Use batching, joins, prefetching, or include parameters where appropriate.

- `<img src="/images/product-123.jpg" loading="lazy" alt="Product image">`
- `const AdminPage = React.lazy(() => import("./AdminPage"));`

Use pre-fetching:

```sql
SELECT *
FROM orders
JOIN customers ON customers.id = orders.customer_id
LIMIT 50;
```

or batching:

`GET /customers?ids=1,2,3,4,5...,50`

In GraphQL/DataLoader-style systems, batching is commonly used to avoid N+1.

## 4.3 Locking and Conditional Write/Update (API version)

<img width="503" height="441" alt="image" src="https://github.com/user-attachments/assets/01519bb0-7d18-4127-85cc-f7fc4c4839d1" />

CAS, compare-and-swap, is the atomic primitive behind many optimistic techniques: update the value only if it still equals the expected value. A SQL UPDATE ... WHERE version = oldVersion is essentially a database-level CAS.


### 4.3.1 Locking Examples 
```
| Question                         | Pessimistic               | Optimistic                   |
| -------------------------------- | ------------------------- | ---------------------------- |
| Lock before work?                | Yes                       | No                           |
| Others blocked?                  | Yes                       | No                           |
| Conflict detected when?          | Before/during access      | At commit/update             |
| Best when conflicts are          | Common                    | Rare                         |
| Failure mode                     | Waiting/deadlock          | Retry/conflict               |
| Typical DB feature               | `SELECT FOR UPDATE`       | `version` column             |
| Distributed-system friendly?     | Less                      | More                         |
| Throughput under low contention  | Lower                     | Higher                       |
| Throughput under high contention | Often better than retries | Can suffer from retry storms |
```

#### 4.3.1.1 Optimistic Locking

User A UPDATE (succeeded):
```sql
UPDATE account
SET balance = 80,
    version = 2
WHERE id = 123
  AND version = 1;
```
User B UPDATE (fails):
```sql
UPDATE account
SET balance = 50,
    version = 2
WHERE id = 123
  AND version = 1;
```

Optimistic locking assumes conflicts are rare, so it allows concurrent reads and only checks at write time whether the record changed, usually with a version column or ETag. If the version has changed, the update fails and the caller retries or returns a conflict.

#### 4.3.1.2 Pessimistic Locking

Pessimistic locking assumes conflicts are likely, so it locks the resource before modifying it, for example with SELECT FOR UPDATE. This prevents concurrent updates but can reduce throughput and cause waiting or deadlocks.

```sql
SELECT *
FROM account
WHERE id = 123
FOR UPDATE;
```

# 5. API Sec

API endpoints development must be protected against known vulnerabilities and common
flaws like:

- Over-permissioning - Not following least privilege policy
- Too much info - Returning more information than it's required
- Access to unauthorized content
- Expose login flaws
- Brute-force attacks - No rate limiting or account lockout
- Injection flaws - No input validation or sanitization
- Insecure direct object references - No access control checks on object references
- And More

Account for Security, Privacy and Accessibility

## 5.1 Regulation Landscape

- SOCs
- PCI DSS 4.0 (Payment Card Industry Data Security Standard) - Global (payment card data) - Does your app process credit card/payments?
- CCPA (California Consumer Privacy Act) - California, USA
- HIPAA (Health Insurance Portability and Accountability Act) - USA (healthcare)
- FedRAMP (Goverment Data)
- GDPR (General Data Protection Regulation) - European Union

- LGPD (Lei Geral de Proteção de Dados) - Brazil
- PIPEDA (Personal Information Protection and Electronic Documents Act) - Canada
- APPI (Act on the Protection of Personal Information) - Japan

## 5.2 OWASP Top 10

<img width="676" height="441" alt="image" src="https://github.com/user-attachments/assets/d81b0d5b-c409-49c0-9e11-67f90056be6b" />

3 Pillars of API sec

- Governance: Establish consistency and structure on developing secure APIs
- Monitoring: Detect threats in production
- Testing: Identify and fix vulnerabilities before production

### 5.2.1 API1: Broken Object Level Authorization (BOLA)

What it is?

- Broken Authorization refers to the flaws in logic/rules governing access
- Most common in damaging API vulnerability
- Very difficult to detect in runtime
- Critical to test for BOLA in pre-production

Examples:
- Significant risk of data Loss
- Can a user A, access user B information?
- Fraudulent Transactions

#### 5.2.1.1 API1 Example:

Coinbase: missing logic for validation check:

- Check user authorization
- Check account id
- Check price/quantity
- It was't checking asset id (change: ETH -> BTC)

### 5.2.2 API2: Broken User Authentication

### 5.2.3 API3: Excessive Data Exposure

### 5.2.4 API4: Lack of Resources & Rate Limiting

### 5.2.5 API5: Broken Function Level Authorization

# 6. API Infra

## 6.1 API Gateway

API-management layer for clients consuming your services. Manage, secure, observe, and control API traffic.

```terraform

/* app.py
import json

def handler(event, context):
    return {
        "statusCode": 200,
        "headers": {
            "Content-Type": "application/json"
        },
        "body": json.dumps({
            "message": "Hello from Lambda behind API Gateway",
            "path": event.get("path"),
            "method": event.get("httpMethod")
        })
    }
*/


terraform {
  required_version = ">= 1.5.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }

    archive = {
      source  = "hashicorp/archive"
      version = "~> 2.4"
    }
  }
}

provider "aws" {
  region = "us-east-1"
}

data "archive_file" "lambda_zip" {
  type        = "zip"
  source_file = "${path.module}/lambda/app.py"
  output_path = "${path.module}/lambda.zip"
}

resource "aws_iam_role" "lambda_role" {
  name = "example-api-lambda-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Principal = {
          Service = "lambda.amazonaws.com"
        }
        Action = "sts:AssumeRole"
      }
    ]
  })
}

resource "aws_iam_role_policy_attachment" "lambda_basic_execution" {
  role       = aws_iam_role.lambda_role.name
  policy_arn = "arn:aws:iam::aws:policy/service-role/AWSLambdaBasicExecutionRole"
}

resource "aws_lambda_function" "api_lambda" {
  function_name = "example-api-lambda"
  role          = aws_iam_role.lambda_role.arn
  runtime       = "python3.12"
  handler       = "app.handler"

  filename         = data.archive_file.lambda_zip.output_path
  source_code_hash = data.archive_file.lambda_zip.output_base64sha256
}

resource "aws_api_gateway_rest_api" "api" {
  name        = "example-rest-api"
  description = "Example API Gateway REST API using Terraform"
}

resource "aws_api_gateway_resource" "hello" {
  rest_api_id = aws_api_gateway_rest_api.api.id
  parent_id   = aws_api_gateway_rest_api.api.root_resource_id
  path_part   = "hello"
}

resource "aws_api_gateway_method" "hello_get" {
  rest_api_id   = aws_api_gateway_rest_api.api.id
  resource_id   = aws_api_gateway_resource.hello.id
  http_method   = "GET"
  authorization = "NONE"
}

resource "aws_api_gateway_integration" "lambda_integration" {
  rest_api_id = aws_api_gateway_rest_api.api.id
  resource_id = aws_api_gateway_resource.hello.id
  http_method = aws_api_gateway_method.hello_get.http_method

  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = aws_lambda_function.api_lambda.invoke_arn
}

resource "aws_lambda_permission" "api_gateway" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = aws_lambda_function.api_lambda.function_name
  principal     = "apigateway.amazonaws.com"

  source_arn = "${aws_api_gateway_rest_api.api.execution_arn}/*/*"
}

resource "aws_api_gateway_deployment" "deployment" {
  depends_on = [
    aws_api_gateway_integration.lambda_integration
  ]

  rest_api_id = aws_api_gateway_rest_api.api.id

  triggers = {
    redeployment = sha1(jsonencode([
      aws_api_gateway_resource.hello.id,
      aws_api_gateway_method.hello_get.id,
      aws_api_gateway_integration.lambda_integration.id
    ]))
  }

  lifecycle {
    create_before_destroy = true
  }
}

resource "aws_api_gateway_stage" "dev" {
  deployment_id = aws_api_gateway_deployment.deployment.id
  rest_api_id   = aws_api_gateway_rest_api.api.id
  stage_name    = "dev"
}

#########
output "api_url" {
  value = "${aws_api_gateway_stage.dev.invoke_url}/hello"
}

```

## 6.2 Ingress Controller

Kubernetes-native HTTP routing into the cluster. Route external HTTP/S traffic into Kubernetes services. An Ingress Controller watches Kubernetes Ingress resources and configures a proxy such as NGINX, Traefik, HAProxy, or Envoy.

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: app-ingress
spec:
  rules:
    - host: api.example.com
      http:
        paths:
          - path: /users
            pathType: Prefix
            backend:
              service:
                name: user-service
                port:
                  number: 80
          - path: /orders
            pathType: Prefix
            backend:
              service:
                name: order-service
                port:
                  number: 80
```

## 6.3 Comparison API Gateway vs Ingress Controller

```
| Feature                         | Ingress Controller | API Gateway |
| ------------------------------- | -----------------: | ----------: |
| Path-based routing              |                Yes |         Yes |
| Host-based routing              |                Yes |         Yes |
| TLS termination                 |                Yes |         Yes |
| Load balancing                  |                Yes |         Yes |
| JWT/OAuth validation            |          Sometimes |     Usually |
| API keys                        |          Sometimes |     Usually |
| Rate limiting                   |          Sometimes |     Usually |
| Request/response transformation |  Limited/sometimes |     Usually |
| Developer portal                |                 No |   Sometimes |
| API versioning                  |              Basic |    Stronger |
| Usage analytics                 |    Basic/sometimes |    Stronger |
| Monetization / quotas           |                 No |   Sometimes |
| API lifecycle management        |                 No |     Usually |
```
Some tools can be both:
```
| Tool                       |          Can be Ingress Controller? |                         Can be API Gateway? |
| -------------------------- | ----------------------------------: | ------------------------------------------: |
| NGINX Ingress              |                                 Yes |                Limited API gateway features |
| Kong                       |                                 Yes |                                         Yes |
| Traefik                    |                                 Yes |                                         Yes |
| Envoy / Istio Gateway      |                             Yes-ish |                                     Yes-ish |
| AWS API Gateway            | Not a Kubernetes Ingress Controller |                                         Yes |
| AWS ALB Ingress Controller |                                 Yes | More load balancer/ingress than API gateway |

```


# 7. Caching

Considerations when using caching:

- Use most for read intensive data
- Expiration time: use not too short, not too high
- Consistency challenges: keep data store and cache in-sync
  (data modification can generate inconsistencies because updating data store and cache are not a single transaction)
- SPOF (Single Point of Failure)
- Eviction Policy:
  - LRU least recent used
  - LFU least frequently used
  - FIFO first in first out


