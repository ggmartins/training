<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

- [1. CDIS Open Source Studies](#1-cdis-open-source-studies)
  - [1.1 General Architecture](#11-general-architecture)
- [3. Cancer Research DS Courses](#3-cancer-research-ds-courses)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# 1. CDIS Open Source Studies

## 1.1 General Architecture

```mermaid
flowchart TB
    USERS["Researchers and data scientists"]
    IDP["Federated identity providers"]

    subgraph CENTRAL["Central data-mesh environment"]
        COP["Central mesh operator"]
        CGIT["Central GitOps configuration"]
        CHELM["Central Gen3 Helm release"]
        CK8S["Central Kubernetes cluster"]

        HUB["Data Hub / Discovery Portal"]
        AGG["Aggregated Metadata Service"]
        MESH["Shared Mesh APIs and services"]
        CWS["Cross-commons workspaces"]

        COP -. "maintains" .-> CGIT
        CGIT --> CHELM
        CHELM --> CK8S
        CK8S --> HUB
        CK8S --> AGG
        CK8S --> MESH
        CK8S --> CWS

        HUB --> AGG
        HUB --> CWS
        HUB --> MESH
    end

    subgraph INST_A["Institution A — UChicago"]
        AOP["UChicago Gen3 Operator"]
        AGIT["UChicago values, secrets and dictionary"]
        AHELM["Helm release: uchicago-gen3"]
        AK8S["UChicago Kubernetes cluster"]
        ACOMMONS["UChicago Data Commons"]
        ASTORE["UChicago databases and object storage"]

        AOP -. "maintains" .-> AGIT
        AGIT --> AHELM
        AHELM --> AK8S
        AK8S --> ACOMMONS
        ACOMMONS --> ASTORE
    end

    subgraph INST_B["Institution B — Northwestern"]
        BOP["Northwestern Gen3 Operator"]
        BGIT["Northwestern values, secrets and dictionary"]
        BHELM["Helm release: northwestern-gen3"]
        BK8S["Northwestern Kubernetes cluster"]
        BCOMMONS["Northwestern Data Commons"]
        BSTORE["Northwestern databases and object storage"]

        BOP -. "maintains" .-> BGIT
        BGIT --> BHELM
        BHELM --> BK8S
        BK8S --> BCOMMONS
        BCOMMONS --> BSTORE
    end

    USERS --> HUB
    USERS --> ACOMMONS
    USERS --> BCOMMONS

    IDP --> ACOMMONS
    IDP --> BCOMMONS
    IDP --> MESH

    ACOMMONS -->|"publishes discovery metadata"| AGG
    BCOMMONS -->|"publishes discovery metadata"| AGG

    MESH <-->|"standard APIs"| ACOMMONS
    MESH <-->|"standard APIs"| BCOMMONS

    CWS -->|"authorized data access"| ACOMMONS
    CWS -->|"authorized data access"| BCOMMONS
```

<img width="609" height="472" alt="image" src="https://github.com/user-attachments/assets/0067aa9c-f9a8-4419-b4ad-da15c925b362" />

# 3. Cancer Research DS Courses

- https://www.coursera.org/specializations/genomic-data-science
- https://www.freecodecamp.org/news/how-to-build-microservices-based-rest-apis-for-healthcare-portals/
