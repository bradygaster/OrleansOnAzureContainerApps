param location string = resourceGroup().location

param silo_image string
param client_image string
param dashboard_image string
param registry string
param registryUsername string

@secure()
param registryPassword string

module env 'environment.bicep' = {
  name: 'containerAppEnvironment'
  params: {
    location: location
  }
}

module storage 'storage.bicep' = {
  name: toLower('${resourceGroup().name}strg')
}

module silo 'container-app.bicep' = {
  name: 'silo'
  params: {
    location: location
    name: 'silo'
    containerAppEnvironmentId: env.outputs.id
    registry: registry
    registryPassword: registryPassword
    registryUsername: registryUsername
    repositoryImage: silo_image
    allowExternalIngress: true
    maxReplicas: 1
    envVars : [
      {
        name: 'ASPNETCORE_ENVIRONMENT'
        value: 'Development'
      }
      {
        name: 'ORLEANS_AZURE_STORAGE_CONNECTION_STRING'
        value: format('DefaultEndpointsProtocol=https;AccountName=${storage.outputs.storageName};AccountKey=${storage.outputs.accountKey};EndpointSuffix=core.windows.net')
      }
    ]
  }
}

module client 'container-app.bicep' = {
  name: 'client'
  params: {
    location: location
    name: 'client'
    containerAppEnvironmentId: env.outputs.id
    registry: registry
    registryPassword: registryPassword
    registryUsername: registryUsername
    repositoryImage: client_image
    allowExternalIngress: true
    maxReplicas: 1
    envVars : [
      {
        name: 'ASPNETCORE_ENVIRONMENT'
        value: 'Development'
      }
      {
        name: 'ORLEANS_AZURE_STORAGE_CONNECTION_STRING'
        value: format('DefaultEndpointsProtocol=https;AccountName=${storage.outputs.storageName};AccountKey=${storage.outputs.accountKey};EndpointSuffix=core.windows.net')
      }
    ]
  }
}

module dashboard 'container-app.bicep' = {
  name: 'dashboard'
  params: {
    location: location
    name: 'dashboard'
    containerAppEnvironmentId: env.outputs.id
    registry: registry
    registryPassword: registryPassword
    registryUsername: registryUsername
    repositoryImage: dashboard_image
    allowExternalIngress: true
    maxReplicas: 1
    envVars : [
      {
        name: 'ASPNETCORE_ENVIRONMENT'
        value: 'Development'
      }
      {
        name: 'ORLEANS_AZURE_STORAGE_CONNECTION_STRING'
        value: format('DefaultEndpointsProtocol=https;AccountName=${storage.outputs.storageName};AccountKey=${storage.outputs.accountKey};EndpointSuffix=core.windows.net')
      }
    ]
  }
}
