# 1. Intro

- Versioned Infrastructure Declaration (declarative and NOT imperative)

Multiple versions of the Infrastructure that should be in version control

- Idempotency

The infrastructure should be able to be applied multiple times producing the same result (consistency)

- Self-Describing Infrastructure

Infrastructure is in the code that can be uderstood by devs

## 1.1 Terraform

- manages infra entire life cycle
- hashcorp's tool
- terraform CLI (command) for commands like:
   - init
   - plan
   - apply
   - destroy
- providers (third party cloud infra providers, provide API for infra provisioning)
   - AWS, Azure, GCP, Cloudflare, ETC

- why use terraform:
   - to replicate and modify infrastructure easily
   - to manage infra on multiple cloud platforms
   - easy to read
   - state file (dependencies between resources), allows you to track changed across
   - version control

- HCL Hashcorp Configuration Language
   - HCL DOES NOT support user-defined functions (only built-in funcs)

## 1.2 Other Benefits

- Easily recreate systems
- Repeatable Process
- Disposable Systems
- Design is always changing
- Generic Modules

# 2. tf basic commands

Normal workflow:

- write iac code
- init the dir (`terraform init`)
- apply your infrastructure (`terraform apply` (terraform run))


Simple example:

```hcl
terraform {
   required_providers {
      aws = {
         source  = "hashicorp/aws" # official aws provider from hashcorp (*)
         version = "~> 4.66" # (Tilde symbol) Allows version >= 4.66 and < 5.0
      }
   }

   ##
   # Another tilde example:
   #
   # ~> 1.14.3 would be >= 1.14.3 and < 1.15

   required_version = ">= 1.14.4"
}

# The below block configures the plugin
# IMPORTANT: A provider can only access
# the service that it is build for.

provider "aws" {
   region = "us-east-2"
}

# app_server is the terraform id (BLN block label name) of the
# resource aws_instance (BL: block label).

# BT(blk type)  BL          BLN
resource "aws_instance" "app_server" {
   ami           = "ami-0c7df786sdf3ghf0f" # debian server (only for east 2)
   instance_type = "t2.micro"

   tags = {
      name       = "lab01"
   }

}

(*) alternatively: community-based providers:
https://registry.terraform.io/providers/hashicorp/aws/latest/docs
https://registry.terraform.io/providers/databricks/databricks/latest/docs
https://registry.terraform.io/providers/cloudflare/cloudflare/latest/docs

```

More at:
- https://developer.hashicorp.com/terraform/docs
- https://developer.hashicorp.com/terraform/tutorials

JSON also possible, but not considered to be best practices.

Golden Images: images formatted and twicked to serve company's policies.
Ofter produced with packer.

## 2.1 use `-h` for the help system

`terraform -h init` or `terraform init -h`

## 2.2 init

This command will automatically download community-based providers plugins.
Use with `-upgrade` to upgrade dependencies, install the latest models etc.
It'll create the lock file: `.terraform.lock.hcl` to record the provider
selections it made during init. Next time `init` is ran, it'll reuse the
selections. (Don't manually modify the lock file).


## 2.3 fmt

## 2.4 validate

Use `-json` to produce a validation output readable by other systems (automation).


## 2.5 plan

Use `-out=infra1.plan` to record the plan file. It does not fix any code.

## 2.6 apply

Use `-replace=aws_resource...` to reestablish a resource.

## 2.7 destroy

# 3. Workflow

- write code (author stage, init, fmt)
- plan (validate, plan/dry-run)
- apply (makes changes to cloud infra + state files)

Work on your Project SCOPE.


# 4. Terraform state file

- represents a source of true for terraform's provisioned resources
- terraform (terraform.tfmain)
- machine readable file (not h)
- tracks changes to the infrastructure
- dependencies between resources
- can be local or remote (s3, gcs, azure blob storage, etc)

## 4.1 Backup state file

This is a backup of state file of when the infra was running.

# 5. Local vs Remote backend


# 6 tf advanced commands

## 6.1 show

Human-readable output of state or plan file.

## 6.2 output

Show output variables from state file. Use `-raw` to show things like
ip address for automation.

# 6.3 import

Import existing infra to tf state file.

# 6.4 taint

Mark a resource for recreation on next apply.

# 6.5 graph

Generate a visual graph of resources.

# 6.6 state

Use `state list` to list the resources.
Use `state show aws_key_pair.connector` for details on resource.




