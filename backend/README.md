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

## 3.1 4 Pillars of Good System Design

### 3.1.1 Escalability

### 3.1.2 Maintainability

### 3.1.3 Efficiency

### 3.1.4 Reliability

# 4 Typical Flows

## 4.1 Long time to process (>1min)

<img width="449" height="482" alt="image" src="https://github.com/user-attachments/assets/376c776f-2a33-40d8-b1aa-c91e16b9bc27" />

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

