param resourceBaseName string = resourceGroup().name
param location string = resourceGroup().location

resource acr 'Microsoft.ContainerRegistry/registries@2021-09-01' = {
  name: '${resourceBaseName}acr'
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

output registryName string = acr.name
output loginServer string = acr.properties.loginServer
