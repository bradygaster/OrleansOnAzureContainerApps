# Orleans Silo + Client on Azure Container Apps

This repository contains a simple solution with an Orleans Silo and an Orleans Client project. Both are deployed to an Azure Container Apps environment, using Azure Storage clustering. The folders off of the root are described below:

* Orleans.Azure.Infrastructure - an experimental project designed to support hosting Orleans Silos in Azure App Service or Container Apps with little wire-up.
* OrleansOnContainerApps.Abstractions - project containing the Grain interfaces.
* OrleansOnContainerApps.Grains - project containing the Grain implementations.
* OrleansOnContainerApps.Silo - a simple ASP.NET Core project that hosts the Orleans silo.
* OrleansOnContainerApps.Client - a simple ASP.NET Core Razor project that serves as a client to the silo and provides a simple user interface.
* ```deploy``` folder - this folder contains a series of [Azure Bicep](http://aka.ms/bicep) templates that can be used to create the application and deploy it.
* ```setup.ps1``` - this file is a one-stop way for you to deploy the app to your own Azure subscription so you can try the scenario. 

## Prerequisites

* .NET 6.0
* The Azure CLI
* An Azure subscription
* Docker
* PowerShell *(GitHub Actions will replace this prerequisite soon)*

To install the Azure Container Apps CLI commands until they are pre-installed in the Azure CLI, as documented in the [Azure Container Apps official docs](https://docs.microsoft.com/azure/container-apps/get-started?tabs=bash), execute this command:

```bash
az extension add --source https://workerappscliextension.blob.core.windows.net/azure-cli-extension/containerapp-0.2.0-py2.py3-none-any.whl
```

## Setup

1. Clone this repository.
2. Sign in to your Azure subscription using the `az login` command.
3. If you have more than 1 Azure subscription, make sure you're targeting the *right* Azure subscription by using the `az account show` and `az account set -s <subscription-id>` commands.
4. From the root of this repository, run `./setup.ps1`. 

## Topology diagram

The resultant application is an Azure Container Environment-hosted set of containers - the `silo`, and the `client` Razor Pages front-end.

![Topology diagram](static/topology.png)
