# 1. Introduction

DevOps is an approach that brings together software development (Dev) and IT operations (Ops) to shorten the systems development life cycle and provide continuous delivery with high software quality.
The goal is to enhance the speed and reliability of software delivery.

- It focuses on continuous improvement, automation, and collaboration between teams that were once siloed., aiming to shorten the between development and operations teams.
- The ultimate goal is to create a culture and enviroment where building, testing and releasing software can happen quickly, frequently and reliably.

```
       + Code +    + Deploy +
      /         \ / Release  \
   Build (DEV)   \   (OPS)   Operate
      \        / Plan        /
       + Test /      Monitor+
```

Azure Services:

Code    = Azure Repos
Build   = Azure Artefacts
Test    = Azure Test Plans
Deploy  = Azure Pipelines
Operate = Logic App
Monitor = Azure Monitor / App Insights
Plan    = Azure Boards

- Pipelines machines run on Agents
  - Microsoft hosted agents (main service + configuration machines)
  - Configure your own agents and connect them to the platform
  - Or a mix of both

- DevOps eliminates inefficiencies, misconfiguration, and delays that arise from traditional
  gaps between development and operations teams.

Key challanges of DevOps:
- Miscomunication and collaboration gaps between development and operations teams: Enhances communication and collaboration reducing misunderstandings and accelerating the release process.
- Conflicting Goals: Aligns the goals of Dev and Ops team towards quickly reliable, and high quality software delivery.
- Manual Processes and Bottlenecks: Advocates for automation to decrease manual effort, errors and delays.
- Lead Time vs Cycle Time:

## 1.1 The Role of DevOps

- Infrastructure as a Code (IaC) - Infra Reproducibility and Automation: Automate the provisioning of resources to be more agile and to better control of env, to increase efficiency and consistency;
- Configuration Management - Control and manage changes in a repeatable way and standarddized way;
- CI/CD - Continuous Integration (CI) - Source code integration: Automate the build and testing and deployment of software (get fast feedback on changes and development); Continuous Delivery (CD) - Automate the delivery of software: make every change ready for delivery as fast as possible;
- Automated Testing - Control and automate the execution of testing to get fast feedback on changes and development;
- Monitoring and Operations: implement monitoring solutions to track application and infrastructure performance ensuring **high availability and reliability**.

Making sure that the infrastructure is reliable efficient and and easy to deploy;
SRE: (Monitoring, Logging, and Tracing)

Transition to cloud: cut costs and improve manageability;

- Intro do DevOps: History and SDLC, Prioritize Customers
- Azure Infrastructure Fundamentals: Virtual Machines, Virtual Networks, Load Balancing, Azure Portal and Azure CLI
- Security Best Practices: Azure Security Center, Azure Policy, Network Security Group
- Infrastructure as code: Terraform and Packer
- Deployment of Web Server in Azure: Scalable, Load Balacing (VMs on Backend)
https://www.youtube.com/watch?v=JxxdgqCaCGI&t=296s&ab_channel=Udacity

- SDLC
- History of DevOps
- Configuration Management: help ensure that builds run smoothly and that people can efficiently get what they need when using things we've built.
- Identify and Prioritize Customer Needs
- Gotchas: Common gotchas that can arise when trying to apply DevOps and agile practices.

https://www.youtube.com/watch?v=EREgyhFGndA&t=347s&ab_channel=Udacity

## 1.2 Tools

- Version Control Systems (VCS): Git
- Agile and Lean techniques: for planning, sprint isolation, and capacity management.
- Containerization: Docker
- Orchestration: Kubernetes
- Continuous Integration and Continuous Delivery (CI/CD): Jenkins, Azure DevOps
- IaC tools: Terraform - automate the provisioning of resources, reprodicibility and consistency.
- Monitoring and Logging: Azure Monitor, Azure Log Analytics, Azure Application Insights
- Public and Private Cloud: Azure, AWS, Google Cloud
- Cloud Security: Azure Security Center, Azure Policy, Network Security Group

## 1.2.1 Tools on stages:

- Planning: Azure Boards, GitHub, Jira
- CI/Build: Azure Repos, GitHub Repos, OWASP ZA, NuGet, Azure Lab Services, Azure Artefacts;
- CD: Azure Pipelines, GitHub Actions, Jenkins, Terraform(?), Ansiable (?)
- Operations: Azure Monitor, Azure Log Analytics, Azure Application Insights
- Security: Azure Security Center, Azure Policy, Network Security Group
- Docs: Azure DevOps Wiki

## 1.3 DevOps Principles

- Don't Repeat Yourself: DRY
- Infrastructure as Code: IaC
- Configuration Management: CMS
- High Availability: HA
- Customer First: Customer-centric
- Shared Responsibility Model: SRM Devs don't blame Ops and Ops don't blame Devs

### 1.3.1 Configuration Management

- Configuration identification and control
- Build and process management
- Environment management
- Version control

Tools:
- Verstion Control Systems (VCS): Git
- Documentation: README.md, Release Notes, Wiki, Comments in the code, git commit messages
- Change Advisory Board (CAB)
- Infrastructure as Code (IaC): Terraform

## 1.4 DevOps WorkFlow

Standard Workflow (Pipelines)
Plan -> Code -> Test -> Package -> Deploy

# 2. Azure Fundamentals

- What the various IaaS resource types are that we can deploy.
- How to use the in-portal wizard to deploy a virtual machine.
- How to do virtual networking and load balancing, which will be critical for our project at the end of the course.
- How to use Azure Monitor to optimize virtual machine performance and cost.
- How to use Azure Active Directory for role-based access controls, users, and service principals.
- How to use the Azure CLI (instead of the portal) to deploy resources.
- When to use Azure portal vs. Azure CLI.


## 2.1 IaaS vs PaaS

- IaaS: Infrastructure as a Service, Storage, Compute, Networking; Flexible and customizable; Inexpensive;
- PaaS: Platform as a Service, Application Hosting, Easy to Run and Scale, More expensive than IaaS: Database, Web App, Mobile App, API, Logic App, Function App;
https://www.youtube.com/watch?v=yQc-fIAnmkA&t=64s&ab_channel=Udacity

## 2.2 Resource Groups (RGs)

- RGs are associated with regions, but that's only for storing the meta data
- RGs can contain resources from MULTIPLE regions
- RGs can contain MULTIPLE resource TYPES
- CANNOT put a RG inside another RG
- CAN move resources from RG to RG
- RG is NOT a BOUDARY of USAGE
- REASON 1 for RG: they SHARE a LIFE CYCLE
- REASON 2 for RG: applied RBAC, POLICY and BUDGET to RG
- use TAGGING to organize RG
 - Resources inside RG won't get the same TAG unless there's a policy to enforce this
- use what makes most sense, eg. for db team, use a db RG as a container for db infra

```
+---------------------------------+   +------------+
| RG 1             +-----------+  |   | RG 2       |
| +------+  +---+--| Public IP |  |   |    +------+|
| | VM 1 |--|NIC|  +-----------+  |   |    | VNET ||
| +------+  +---\______belongs to_________ /------+|     
+---------------------------------+   +------------+
```

### 2.2.1 Management Groups: A management group is a container for subscriptions. Exist under the heading of 
  an account where the account is assigned uniquely to a company or organization. Can be 1, a single
  account or a 10k MG under a directory. Contains 1 or more subscriptions to which people will require common access. (manage multiple subscription)

  (May not get access to it by default)

  - apply BUDGET, POLICY and RBAC (IAM) to multiple subscriptions under the MG instead of doing one sub at the time
   - BUDGET, POLICY and RBAC are inherited down -> MG -> SUBS -> RG -> RESOURCES (IMPORT)


### 2.2.2 Subscriptions: A subscription is a container for resources. Often assigned to businesses or
  teams or maybe for dev, test and prod. Can be 1 or more resource groups. Can be only associated
  with 1 Management Group (tenant).

  - Base Unit of AGREEMENT between a customer and microsoft (a billing boundary)
  - billing model:
    - pas as you go
    - enterprise agreement
  - limits IMPORTANT: https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/azure-subscription-service-limits
  - live inside Azure AD that has users, groups and devices
  - can move subscriptions to a different directory in Azure AD (net tenant or MG)
  - everthing that can applied to RG can be applied to subscriptions
   - eg. policy, role grant (RBAC), budgets applied
  - IMPORTANT: RGs inherit what was applied to Subs   
  - for small companies, 1 sub (?)
  - for large companies (separate by env):
    - dev subscription
    - test subscription
    - prod subscription
  - use tagging for billing, but can also use diff subs

### 2.2.3 Resource Groups: Often resouce groups can exist for a single app or a single project.

```
     ______________
   /                \
  /   AD Tenant 1    \
   \________________/
      |                                                +------------------------+
  +-------------------------+                          | RBAC / IAM inheritance |
  | Root Management Group   |                          +------------------------+
  +-------------------------+\__________                   |
      |                                  \                 V
      |                                   \
  +--------------------+
  | Management Group 1 | -------------------+--- ... (LEVEL 1 UP to 6 levels of MG)
  +--------------------+                     \                               \
      |                 \                     \                             LEVEL 2 MGs
  +----------------+   +----------------+      +----------------------+
  | Subscription 1 |   | Subscription 2 | ..   | Management Group 1.2 |
  +----------------+   +----------------+      +----------------------+
      |_____________________      \...
      |                      \                      \
  +------------------+   +------------------+       +----------------+
  | Resource Group 1 |   | Resource Group 2 | ...   | Subscription 3 | \
  +------------------+   +------------------+       +----------------+   \
     /                \            \      \______                  |      +-------------------+
    /                   \           \             \                 \_    | Resource Group 3  |
+------------+   +------------+   +------------+   +------------+      \  +-------------------+
| RESOURCE 1 |   | VNET 1     |   | Resource 3 |   | VNET 2     | ...   \    \
+------------+   +------------+   +------------+   +------------+       |     X -> RG can't have "sub" RGs
                    | |                                |                |      \
                    | +-CAN TALK TO--------------------+                |     +-------------------+
                    +-------------CANNOT TALK TO RES BELOW Sub 2 and 3--+     | Resource Group 4  |
                                                                              +-------------------+
```

- https://www.youtube.com/watch?v=NLsc7fTxFq8&t=2s&ab_channel=Udacity


## 2.3 IaaS

- Virtual Machines: Windows and/or Linux; VM Size (CPU, RAM, Storage), Special Machines (GPU, High Performance, etc.);
- Virtual Networks: Only /24 (256 IPs); /16 (65536 IPs); /8 (16777216 IPs);
- Virtual Subnets (no overlapping);
- Load Balancing:
- More

```
+-------------------------------------------------+
| Virtual Network 1                               |
|                                                 |
| +-------------------------+                     |
| | Virtual Subnet 1        | ...                 |
| |                         |                     |
| |  +-------------------+  |                     |
| |  | Virtual Machine 1 |..|                     |
| |  +--------------NIC--+  |                     |
| |                         |                     |
| | NIC needs to be created |                     |
| +-------------------------+                     |
|                                                 |
+-------------------------------------------------+
```

### 2.3.1 Storage Accounts and Blob Storage

Storage accounts are general purpose storage in Azure that provide a scalable object store. Storage accounts provide highly available, scalable, and secure storage for all kinds of objects. In Azure, storage services consist of:

- Azure Blobs
- Azure Files
- Azure Queues
- Azure Tables
- Azure Disks

Azure Disks are storage volumes for virtual machines, and you'll normally only see them in that context. If you'd like to learn more, the other four types of storage accounts are detailed in the Azure documentation(opens in a new tab), but one important type of storage account you should be aware of is Blob Storage.

https://docs.microsoft.com/azure/storage/common/storage-introduction

Storage Account names must be unique across all azure users, while azure storage containers (blob) can have same names within different storage container. 

#### 2.3.1.1 Blob Storage
Blob Storage is the general purpose storage solution in Azure. It's designed for storing and serving unstructured data such as images, text, or other files.

More detail can be found in the Blob Storage Documentation(opens in a new tab)
https://docs.microsoft.com/azure/storage/blobs/storage-blobs-introduction

#### 2.3.1.2 SQL Servers
SQL servers are the most common type of database server, and Azure offers regular SQL databases as well as fully managed instances. You can also run SQL Server on an Azure virtual machine! SQL servers are a powerful way to store, serve, and manage structured data.

More detail can be found in the Azure SQL Documentation
https://docs.microsoft.com/azure/azure-sql/

### 2.3.2 VMs

- Network Security Groups (NSG) are not required for creating a VM
- Disk Types are not required for creating a VM
- Some VM types support premium disks, recommended for high IOPS workloads
- VM with Premium SSD Disks qualify for 99.9% SLA
- Encryption types:
  - Encryption at rest with a platform-managed key
  - Ecryption at rest with a customer-managed key
  - Encryption at rest with a customer-managed key and Azure Disk Encryption (?)
- Managed Disks (Add data disks to VM)
- Ephemmeral OS Disks
- Networking
  - Virtual Network
  - Subnet
  - Network Security Group
  - Public IP Address
- Select Load Balancer (if existing or create new)
- Aditional Settings for Monitoring, IAM and backup
- Extensions
  - can expand configuration management
  - Anti virus
- Tags
- For 1 VM the following resources are created:
  - Virtual Network
  - Public IP Address
  - Network Security Group
  - Network Interface
  - Virtual Machine
  - Storage Account
  - Disk

### 2.3.3 Networking

(DO NOT ENABLE SSH / RDP to THE INTERNET)
(USE AZURE BASTION instead - jump box)
a VN exists within:
- subscription
- a region
- it CANNOT span across subs or regions
- a VN is an ip range (ipv4 or ipv6)
- subnet have access to internet by default (SNAT)
- instance level public IP :-(
- SNAT implicit
- SNAT explicit
- SNAT standard LB  public ip defined \ _ Public IP Prefix    (Internal LB needs to be configured for accessing inet) QUESTION
- SNAT NAT Gateway  public ip defined /
- RFC 1918, but not exclusively
- The address space is broken up into subnets with the smallest subnet possible
being a /29 which will give 3 usable ip addresses
- subnets are regional, they span AZ (az1, az2, az3) QUESTION: Any latency considerations when using diff AZ?

```
192.168/16
172.16/12
10/8
Any public ip used in VN has to have a good reason for it.

Like in  10.0/16
A subnet 10.0.1.0 loses -5 ips 
.0 network address
.1 gateway azure provides
.2 dns services
.3 dns 
.255 broadcast
a /29 is 8 ip addresses -5, only 3 usable ips
```

- can assign ipv6 as well (bigger addressing space) but it's always DUAL stack
- An IP address of anything always comes from fabric 
- ip can be reserve in ARM, guest OS thinks it's DHCP
- VMs can be configured with multiple NICs, on diff SN but needs to be connected on same VN
- Using multiple NICs doesn't make sense when you have SDN. 
- Many VM types support accelerated networking (It should be turned on whenever we can)
- Accelerated Networking; bypass Hypervisor, connects nic to nic via virtual functions
- Many IP configurations per NIC, can have one public ip (optional)
- supported traffic TCP/UDP/ICMP (other things work, but controllers and NSG might not understand and block it)
- multicast does not work, as well as IP-in-IP and GRE (all blocked)
- cannot ping the azure gateway or use tools like tracert (IMPORTANT)
- VLAN not supported
- can't sniff in promouscous mode
- network watched (packet tracing capabilities)
- can't use DHCP server
- AKS supports ipv6 in cube net scenario
- ExpressRoute private peering support
- There's no DMZ in Azure
- By default Azure provides outbound SNAT / PAT enabling resources to access the internet 
and receive responses
- To provide services to the internet either
  - give an instance level public IP (bad idea, even with native protection against VN DDOS)
  - place instance behind a LB or an app gateway
  - azure firewall (not designed for that kind of things)
  - USE a NETWORK VIRTUAL APPLIANCE for that (only exposing required ports eg 443)
  - standard ddos service protection can be added
- bring your own ip (minimum size /24 ipv4) validate -> provision -> comission

#### 2.3.3.1 Subnetting

In software defined networks we create our own subnets and network topologies.
- To reduce congestion
- Improve security
- Can create as many subnets as IP addresses are available
- Subnetting is a way to divide a network into smaller networks (must not overlap)
- Subnet contains VMs and network cars (vnics)
- Subnet and Networks are separate from VMs and can persist after VM is deleted
- Having fewer large vNets with many subnets is better than many smaller vNets with similarly sized subnets

https://docs.microsoft.com/azure/virtual-network/manage-virtual-network

#### 2.3.3.2 NIC
- Assigned a private IP address IPV4 and IPV6
- Must be created in the same region as the VM (gotcha)
TIP: first 3 ip addresses in the VN (Subnet ?) is reserved for the network
- Public IP can be dynamic (less expensive) or static (can be used for DNS)

#### 2.3.3.3 Network Security Group (NSG)
- Rules that define what type of traffic can flow in and out of the VM
- Associanted to Virtual Network Subnets
- Extensive Customization (firewalls)

#### 2.3.3.4 Load Balancer (L4 Network LB)

- Load Balancer is a service that distributes traffic across multiple VMs

https://www.youtube.com/watch?v=mrlByef5ReM&t=29s&ab_channel=Udacity

```
                   +---------------------+
                   |    Public IP Addr   |  Network LB
      +------------|                     |--------------+
      |            |                     |              |
      |  +---------+---------------------+----------+   |
      |  |            Front-End IP Pool             |   |     
      |  +------------------------------------------+   |
      |              Load Balancer Rules                |
      |  +------------------------------------------+   |
      |  |            Back-End IP Pool              |   |
      |  +------------------------------------------+   |
      +-------------------------------------------------+
```

#### 2.3.3.5 Application Load Balancer (L7 Application LB)

- Works at the application layer (HTTP, HTTPS, WebSockets)
- Allows fine grained control over traffic using app attributes
- Built-in web application firewall
- More expensive than Network LB
- You can also write health probes(opens in a new tab) to allow a Load Balancer to detect the status of the virtual machine at the endpoint. (https://docs.microsoft.com/azure/load-balancer/load-balancer-custom-probe-overview)
- L4 LB only ip ports protocol
- L7 app level cookie based affinity (gateway)

Types:
- Load Balancer - Global and regional TCP and UDP load balancing.
 - Standard load balancer - Enabling ultra low-latency, high performance at scale for applications.
 - Gateway load balancer - Enabling ease of deployment, high scale and enhanced availability for third party network virtual appliances.
- Application Gateway - Managing traffic to web applications and container workloads (Azure and Non-Azure)
 - Application Gateway - Load balancing HTTP/HTTPs traffic and supporting TLS/SSL offloading for modern applications that are VM-based or container-based, in cloud or hybrid cloud.
 - Application Gateway for Containers - Ideal for application load balancing HTTP/HTTPS/gRPC/WebSocket traffic to services running in AKS.
- Front Door CDN (Global Services) - Global or multi-regional HTTP/S load balancing; CDN services
includes caching and compression for static workloads, traffic acceleration for dynamic workloads,
advanced rules engine.
- Traffic Manager (Global Services discontinued)

#### 2.3.3.6 Connection VNETs via VNET peering

- can span subscription, can span Azure AD tenants

- you wish to have multiple subscription and/or use multiple regions you will have multiple networks

- VNET peering enables VNETS to be connected via Microsoft Backbone in the same OR DIFFERENT regions
(global peering)

- there is a small (QUESTION?) ingress and egress charge for traffic via network peering

- ip addresses CANNOT OVERLAP

```
VNET1 -> VNET2 <- VNET3 (VNET3 CANNOT talk with VNET1 or vv)

fix this with 

VNET1 -> VNET2 <- VNET3 
  |                |
  +----------------+
```

- peer are not transitive, but they can be (hub, next hop, UDR)
- User Defined Routing -> create route tables (override default routing defaults)

##### 2.3.3.6.1 Connecting to On-Prem

- Many internet services have external, internet facing endpoints, however ofter private connectivity is required
- There are number of options to connect to virtual networks
 - P2S (point to side) VPN Connects a specific device to a network
 - S2S (side to side) VPN Connects a network to a virtual network  
   - S2S VPN Gateway enable multiple VPN connections to different networks if route is not policy based

```
S2S = On-Prem VPN <-> Internet <-> VNET VPN Gateway
                      (ipsec)

Point to side is a device instead of a full net
+--------------------+  
| VNET               |
|+-------+  +-------+|
|| AZ gw |  | AZ gw ||
|+---|---+  +---|---+|
+----|----------|----+
     | \__  ___/|
     |   /  \   |
    VPN +    + VPN
       On Prem (redundancy)

 - ExpressRoute Private Peering Connects a network to a virtual network via peering location and 
   ExpressRoute Gateway (or at least mostly)
   - ExpressRoute circuits enable multiple virtual networks to be connected to a single circuit
     but vnet to vnet better via peering when practical
   - Most enterprises will leverage ExpressRoute which has the benefit of not going over the internet,
     consistent latency and can also provides optional Microsoft peering via router filter
```

### 2.3.4 Azure Monitor

Azure Monitor is a platform for collecting, analyzing, and acting on telemetry from your cloud and on-premises environments. It helps you understand how your applications are performing and proactively identify issues affecting them and the resources they depend on.
It allows us to select a VM or any other resource type across whatever scope and view its performance.


- Metrics
- Logs
- Alerts
- Cost
- Workbooks
- Activity Logs
- 
https://docs.microsoft.com/azure/azure-monitor/overview
https://www.youtube.com/watch?v=d1J9g8FKmlI&t=1s&ab_channel=Udacity

### 2.3.5 Active Directory (Entra ID)

https://www.youtube.com/watch?v=ixLQD60jR74&ab_channel=Udacity
https://learn.microsoft.com/en-us/entra/fundamentals/whatis

- Cloud based identity and access management service (User, groups and other entities)
- Connects directly to Office 365, Azure portal and sometimes to internal corporate AD
- Primarily used by IT admins and app developers
- Managed role based access control
- Groups can have users or more groups 
- Useful for permissions inheritance, granular control without managing individual users

```
       +--------------+
       | AAD          | (business or personal)
       |   o   o   o  |
       |  /A\ /B\ /C\ | A - Azure AD Tenant
       |   |   |   |  | B - Azure AD Connect (replicated from on-prem AD)
       |  / \ / \ / \ | C - Azure AD Guest User (B2B), microsoft account, gmail account
       +--------------+________________________
Trust  ___/     |     \         Trust           \________ Trust
 \__ / RBAC     |      \                      ___|____    RBAC/Policy
    |  Roles    |     +--------------+      /          \  Scopes
    |  Scopes   |     | Group        |     | Cloud App  |
+---------+     |     +--------------+      \__________/
| Sub     |              \
+-+-------+ +--------------+     \----------------+------------------+
  |         | Group        |      \                \                  \
  |         +--------------+    +--------------+  +--------------+  +--------------+
  |             |          \    | User         |  | User         |  | User         |
  |             |           \   +--------------+  +--------------+  +--------------+
  |         +--------------+  +--------------+
  |         | Group        |  | Group        |
  |         +--------------+  +--------------+
  |            \
  |            +------------------+
  |            | Root Tenant User |
  |            +------------------+
   \              \
    \            +-------------------+
     +-----------| Management Group  |
                 +-------------------+ ...
```


#### 2.3.5.1 Service Principal

- Requires app registration (Identity configuration in the azure AD tenant)
- App resides in the registering tenant (defined by one and only one application tenant,
  even if it's an multitenant app)
- Service Principals can have multi-tenant access
- Provide access on behalf of a user or an application
- Can be done through terraform
- Great to restrict access to resources without restricting users
- An app that does one thing over and over needs a tiny set of permissions to perform that funnction.
- least privilege principle

Tenants are organization-level, and typically are best thought of as "one per company"—that is, everyone with an @microsoft.com email would have an @microsoft.com account in the active directory tenant.

One option for managing Azure Active Directory is to use Azure AD sync(opens in a new tab) to ensure that your on-premises active directory is the same as the one in the cloud. This can allow us to unify everything under one identity. https://docs.microsoft.com/azure/active-directory/hybrid/how-to-connect-sync-whatis

App developers may also use Azure AD to implement single sign on, as described in the documentation(opens in a new tab). https://docs.microsoft.com/azure/active-directory/develop/

# 3. Azure DevOps

- It's cloud platform and language agnostic, it can be integrated with AWS, GCP and other clouds.

Given the standard workflow (1.4)
Code -> Test -> Package -> Deploy

Azure Pipelines is defined through `azure-pipelines.yaml` which is part of the code
and where the main part is defined in `steps`:

## 3.1 General Tips

- use stages
 - use code coverage and report stage (pytest-cov, Cobertura)
  - quality metrics enforcement
  - set code coverage policies (full code vs diff code)
 - use gates:
  - use threshold settings to define pass/fail conditions
  - use depedency scanning (OWASP) for finding vulnerable code
  - use security scanning like SAST and DAST
   - SAST Static Application Security Testing: SonarQube, WhiteSource Bolt, Microsoft Defender and  Snyk
   - DAST Dynamic Application Security Testing: Azure Web Application Firewall (Prevents XSS - SQL)
   - Conduct DAST regularly on live applications
  - use Quality Gates and threshold to prevent bad quality code to progress
  - use Governance Gates
   - Policy Definition and Enforcement (Azure Policy)

## 3.2 azure-pipelines.yaml
```yaml
trigger:
  - master

pool:
  vmImage: 'ubuntu-22.04'

variables:
  buildConfiguration: 'Release'

parameters:
- name: op
  type: string
  values:
    - init
    - deploy
    - delete
    - preview
steps:
  # run test
  - script: dotnet test
    displayName: Test
  # package application
  - script: dotnet build --configuration $(buildConfiguration)
    displayName: Build App
  # docker build img
  - script: docker build -t my-image:v1.0
    displayName: Build Image
  # push image to container repo
  - script: docker push my-image:v1.0
    displayName: Push Image
 # Alternative to script is Task
  - task: DotNetCustomTask@2
    inputs:
      command: 'integration_stest'
```
#
```yaml
# ....
# jobs wrap up set of steps
# use 2 separate set of jobs for let's say
# deploy in 2 diff opsys like win vs linux
jobs:
  - job: Win
    pool: #runs on agent: is computing infrastructure with
        #agent software installed on it
      vmImage: 'windows-latest'
    steps:
    #step1
    #step2
    #..
  - job: Linux
    pool: #from an agent or "enviroment"
      vmImage: 'ubuntu-latest'
    steps:
    #step1
    #step2
    #..
    # run steps in parallel like linters with diff env
```

## 3.3 Azure Vault, Secrets and Managed Identities


### 3.3.1 Secrets

- Things don't exist in isolation. Apps access resources, other REST apis. Etc
```
                        ______
                    _ /  REST  \ _                              +----------------+
            _______/  \__API___/   \_____   ______________     /| DevOps Tooling |
+--------+ /                              \/ Pipeline /    \__/ +----------------+
| App    |  Auth-Secret                    \__________\____/
+--------+ \________               __________/
                  +-\-------------/-+
                  | Resource        |
                  +-----------------+

            +-------+
  REQUEST  /          \
  TOKEN-> /    TOKEN   \_____  MANAGED IDENTIRY
         |        \ _ /  AAD  \ _                      
          \        /  \__IdP__/   \  _______
           +---------+             / Storage \
           | VM1 App | --------->  \_________/
           +---------+   ACCESS     RBAC VM1 Reader Role


                         _____  MANAGED IDENTIRY
                ______ /  AAD  \ _                      
               /       \__IdP__/   \  _________
           +---------+             / Key Vault \
           | VM1 App | ----MI--->  \___________/
           +---------+   ACCESS     RBAC Secret1 User
                \_____________________/
               (Chicken and Egg problem:
          Get access to the Key Vault via managed identity,
            Then get identity access to specific secrets)

- No island of secrets - instead store them in one place
```

### 3.3.2 Managed Identities

- Must be supported by the Azure service for the Azure Resources.

#### 3.3.2.1 System-Assigned Managed Identity

- Lifecycle: Tightly coupled with the lifecycle of the Azure resource it's associated with. If the resource is deleted, the identity is automatically deleted as well. 
- Creation: Created automatically when a specific Azure resource (like a VM or App Service) has the managed identity feature enabled. 
- Association: Can only be associated with a single Azure resource. 
- Use Cases: Best suited for scenarios where the identity is tightly linked to a single resource, and management overhead is minimal.

#### 3.3.2.2 User-Assigned Managed Identity

- Lifecycle: Created as a separate Azure resource and exists independently of any other resource. It needs to be explicitly deleted. 
- Creation: Created manually by the user through the Azure portal, CLI, or other methods. 
- Association: Can be associated with multiple Azure resources. 
- Use Cases: Suitable for scenarios where multiple resources need to share the same identity, or when the identity needs to persist even after the deletion of a specific resource. 

### 3.3.3 Azure Key Vault

- verions, rotation
- centrilized
- RBAC to each secret

#### 3.3.3.1 Secrets

- read, write, update

#### 3.3.3.2 Keys

- cripto Ops, once you create a key, that key can use to encrypt / decrypt (Symmetric)
- can't read once it's created or imported
- certificates

#### 3.3.3.3 Secrets


# 4. Azure Artefacts

Currently Azure Artefacts produce packages like:
Old fashion:
- dotnet nuget
- jar
- npm
- cargo
- pypi
Best way:
- docker -> container registry

# 5. Pipeline Stages
```yaml
jobs:
  - job: Build and Test
    steps:
      - task: Docker@2
        inputs:
          command: "buildAndPush"
          Dockerfile: '**/Dockerfile'age:v1.0 .
```
```yaml
jobs:
  - job: Deploy to Dev
    
```
Should be implemented as `stages`:

```yaml
stages: ##stage is a logical boundary in the pipeline
  - stage: Build
    jobs: ##each stage contain 1 or more jobs
      - job: TestAndBuild  #can't have space here
        steps:
        - task: DotNetCoreCLI@2
        #...
        - task: DotNetCoreCLI@2
        #...
        - task: Docker@2
        #...
  - stage: Deploy
    jobs:
      - deployment: "Deploy to development" ##specific job for deployment
        steps:
          - task: AzureWebApp@1
```
Usually do:
- Development
- Testing
- Production

# 5.1 Pipeline Templates

```yaml
#template (common code)
#  can exist for job, step or stage <- IMPORTANT
#  templates within templates (hierarchy)
paramenters:
  env: Dev

jobs:
  - job: Deploy
    environment: ${{ parameters.env }}
    steps:
      - task: AzureWebApp@1
        inputs:
          appName: app
          package: '${System.DefaultWorkingDrectory}/**/*.zip'
```

```yaml
- stage: Deploy Dev
  jobs:
    - template: /Deploy/Jobs/deploy.yml
      parameters:
        env: Dev
- stage: Test Dev
  jobs:
    - template: /Deploy/Jobs/deploy.yml
      parameters:
        env: Test
    #...
```
# 5.2 Environments

Part of Pipelines, enviroments isolate infrastructure like
- development
- production
- testing

- Once it gets deploy we can view the deployment history
- can be linked to the boards

# 5.3 Releases

Release pipelines is special pipeline used for Release only created via UI
https://www.youtube.com/watch?v=4BibQ69MD8c&t=1320s&ab_channel=TechWorldwithNana

                      CI Pipelines CI Scripted in YAML file
Release Pipelines  /
                   \
                      CD configured in UI (only)

How to enable Classic Release Pipelines:
https://www.youtube.com/watch?v=Jqep4EV8Bg4&list=PLgK9uIcbYj44AwKR6F8a1g-G5uGqqwzB2&index=9&t=110s&ab_channel=SkillBuilderZone (depracated: likely to be disabled)

Select a build pipeline artefact source.

# 5.4 Agent Pools

https://www.youtube.com/watch?v=Jqep4EV8Bg4&list=PLgK9uIcbYj44AwKR6F8a1g-G5uGqqwzB2&index=9&t=110s&ab_channel=SkillBuilderZone

# 5.5 Service Connections

Way to connect your azure devops (QUESTION: project or org ?) to a subscriptions or resource group.
There's an automatic default to connect. Old way: Service Principal (Automatic vs Manual).

```
20250601:
                   App Registration (Automatic - Recommended) - requires a service principal
                  /
Identity Type:   -- App Registration and Managed Indentity (Manual) - If you want to control app     registration or managed identity creation and Azure RBAC permissions
                  \
                   Managed Identity - If you can't create App Registration. This will configure workload identity federation on an existing Managed Identity.

             Workload Identity Federation
Credential: /
            \ 
             Secret

             Managed Group
            /
Scope Level -- Subscription
            \
             Machine Learning Workspace

https://www.youtube.com/watch?v=jGJxzctFaVw&list=PLgK9uIcbYj44AwKR6F8a1g-G5uGqqwzB2&index=9&ab_channel=SkillBuilderZone

az group create --location eastus --name rg_azdevops
az ad sp create-for-rbac -n sp_azdevops --role Contributor --scopes /subscriptions/[REDACTED]/resourceGroups/rg_azdevops_[REDACTED]
```

