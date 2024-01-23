/*
 * This module creates the resources required by the function itself
 *
 * Key Vault secrets
 * App Configuration values
 * ServiceBus Subscriptions
 * App Service plan
 * Function
 * EventGrid Subscription
 *
 * calls a sub module to add the API endpoints in the separate API RG
 *
*/
/*
 * DEPENDENCIES
 *
 * evo-core
 *
 */
@description('What environment are you deploying to (dev/stg/prod)?')
@allowed([
  'prod'
  'stg'
  'dev'
])
param environmentName string = 'dev'

@description('Name of git branch')
param branchName string

@description('Name of the service you are deploying.')
param serviceName string

@description('Major version of the service (1, 2, 3 etc)')
param apiMajorVersion int

@description('Name of the vertical you are deploying into.')
param capability string

@description('Do not set, calculated internally.')
param location string = resourceGroup().location

@description('Specifies a JSON array of secrets to create/overwrite [{"name":"","value":""}].')
param secrets array

@description('Specifies a JSON array of app settings to create/overwrite [{"name":"","value":""}].')
param appSettings array

@description('Specifies a JSON array of feature flags to create/overwrite [{"name":"","enabled":"", "filter": "{}"}].')
param featureFlags array

@description('APIM Key to use')
@secure()
param apimKey string

@description('Specifies which resources should be run pre function deploy or post function deploy.')
@allowed([
  'pre'
  'post'
])
param deployStage string = 'pre'

param allowedIps array = []

var environmentConfigurationMap = {
  prod: {
    function: {
      minimumElasticInstanceCount: 3
      vnetRouteAllEnabled: true
      functionsRuntimeScaleMonitoringEnabled: true
      webVnetRouteAll: 1
    }
    sqlDatabase: {
      sku: {
        name: 'GP_S_Gen5'
        tier: 'GeneralPurpose'
        family: 'Gen5'
        capacity: 1
      }
      zoneRedundant: true
      requestedBackupStorageRedundancy: 'Geo'
      isLedgerOn: false
    }
    serviceBus: {
      defaultMessageTimeToLive: 'P1M'
    }
  }
  stg: {
    function: {
      minimumElasticInstanceCount: null
      vnetRouteAllEnabled: false
      functionsRuntimeScaleMonitoringEnabled: false
      webVnetRouteAll: 0
    }
    sqlDatabase: {
      sku: {
        name: 'GP_S_Gen5'
        tier: 'GeneralPurpose'
        family: 'Gen5'
        capacity: 1
      }
      zoneRedundant: false
      requestedBackupStorageRedundancy: 'Local'
      isLedgerOn: false
    }
    serviceBus: {
      defaultMessageTimeToLive: 'PT12H'
    }
  }
  dev: {
    function: {
      minimumElasticInstanceCount: null
      vnetRouteAllEnabled: false
      functionsRuntimeScaleMonitoringEnabled: false
      webVnetRouteAll: 0
    }
    sqlDatabase: {
      sku: {
        name: 'GP_S_Gen5'
        tier: 'GeneralPurpose'
        family: 'Gen5'
        capacity: 1
      }
      zoneRedundant: false
      requestedBackupStorageRedundancy: 'Local'
      isLedgerOn: false
    }
    serviceBus: {
      defaultMessageTimeToLive: 'PT12H'
    }
  }
}

var env = '${environmentName}' == 'dev' && startsWith(toLower('${branchName}'), 'evo') ? replace(toLower('${branchName}'), '-', '') : toLower(environmentName)

/* created in evo.subscription module */
resource serviceRoleDefiniton 'Microsoft.Authorization/roleDefinitions@2018-01-01-preview' existing = {
  name: guid(subscription().id, 'evo-services-rd-${environmentName}')
}

/*
 * These are created in the evo-core module so simply assume they exist
 */
resource apiManagement 'Microsoft.ApiManagement/service@2021-12-01-preview' existing = {
  name: 'evo-core-apim-${environmentName}'
  scope: resourceGroup('evo-core-rg-${environmentName}')
}
resource appInsights 'Microsoft.Insights/components@2020-02-02-preview' existing = {
  name: 'evo-core-appi-${environmentName}'
  scope: resourceGroup('evo-core-rg-${environmentName}')
}
resource functionPrivateDnsZone 'Microsoft.Network/privateDnsZones@2020-06-01' existing = {
  name: 'privatelink.azurewebsites.net'
  scope: resourceGroup('evo-core-rg-${environmentName}')
}
resource coreKeyVault 'Microsoft.KeyVault/vaults@2019-09-01' existing = {
  name: 'evo-core-k-${environmentName}-evolve'
  scope: resourceGroup('evo-core-rg-${environmentName}')
}

/*
 * These are created in the vertical's module
 */
resource virtualNetwork 'Microsoft.Network/virtualNetworks@2019-11-01' existing = {
  name: 'evo-${capability}-vnet-${env}'

  resource defaultSubnet 'subnets' existing = {
    name: 'default'
  }
  resource funcFrontEndSubnet 'subnets' existing = {
    name: 'func-fe'
  }
  resource aspBackend1Subnet 'subnets' existing = {
    name: 'func-be1'
  }
  resource mssqlSubnet 'subnets' existing = {
    name: 'mssql'
  }
}
resource functionStorage 'Microsoft.Storage/storageAccounts@2021-02-01' existing = {
  name: '${capability}${uniqueString(resourceGroup().id, 'func')}'
}
resource keyVault 'Microsoft.KeyVault/vaults@2019-09-01' existing = {
  name: length('evo-${capability}-k-${env}') > 24 ? substring('evo-${capability}-k-${env}', 0, 24) : 'evo-${capability}-k-${env}'
}
resource configStore 'Microsoft.AppConfiguration/configurationStores@2021-03-01-preview' existing = {
  name: 'evo-${capability}-appcs-${env}'
}
resource sqlServer 'Microsoft.Sql/servers@2021-05-01-preview' existing = {
  name: 'evo-${capability}-sql-${env}-0'
}
resource appServicePlan 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'evo-${capability}-asp-${env}-0'
}
resource secureStorage 'Microsoft.Storage/storageAccounts@2021-09-01' existing = {
  name: '${capability}${uniqueString(resourceGroup().id, 'secure')}'
}
resource serviceBus 'Microsoft.ServiceBus/namespaces@2021-11-01' existing = {
  name: 'evo-${capability}-sbus-${env}'

  resource funderIntegrationTopic 'topics@2021-11-01' existing = {
    name: 'funderintegration'
  }

  resource funderIntegrationStagingTopic 'topics@2021-11-01' existing = {
    name: 'funderintegration-staging'
  }
}

/*
 * Create new components starts here...
 *
  */
resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-05-01-preview' = if (deployStage == 'pre') {
  name: 'evo-${capability}-db-${env}-${serviceName}'
  parent: sqlServer
  location: location
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    maxSizeBytes: 2147483648
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    zoneRedundant: environmentConfigurationMap[environmentName].sqlDatabase.zoneRedundant
    readScale: 'Disabled'
    requestedBackupStorageRedundancy: environmentConfigurationMap[environmentName].sqlDatabase.requestedBackupStorageRedundancy
    isLedgerOn: environmentConfigurationMap[environmentName].sqlDatabase.isLedgerOn
    maintenanceConfigurationId: subscriptionResourceId('Microsoft.Maintenance/publicMaintenanceConfigurations', 'SQL_Default')
    autoPauseDelay: (environmentName == 'prod') ? -1 : 60
  }
  sku: environmentConfigurationMap[environmentName].sqlDatabase.sku

  resource longTermRetention 'backupLongTermRetentionPolicies' = if (environmentName == 'prod') {
    name: 'default'
    properties: {
      weeklyRetention: 'P12W'
      monthlyRetention: 'P12M'
      yearlyRetention: 'P7Y'
      weekOfYear: 13
    }
  }

  resource shortTermRetention 'backupShortTermRetentionPolicies' = if (environmentName == 'prod') {
    name: 'default'
    properties: {
      retentionDays: 14
      diffBackupIntervalInHours: 12
    }
  }

  resource auditing 'auditingSettings@2021-11-01-preview' = {
    name: 'default'
    properties: {
      state: 'Enabled'
      isAzureMonitorTargetEnabled: true
    }
  }
}

resource sqlDatabaseDiagnostics 'Microsoft.Insights/diagnosticSettings@2021-05-01-preview' = if (deployStage == 'pre' && branchName == '') {
  name: 'evo-${capability}-db-${env}-diag'
  scope: sqlDatabase
  properties: {
    workspaceId: appInsights.properties.WorkspaceResourceId
    logs: [
      {
        category: null
        categoryGroup: 'allLogs'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
      {
        category: null
        categoryGroup: 'audit'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
    metrics: [
      {
        category: 'AllMetrics'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
  }
}

resource MakeApplicationSubscription 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  name: 'makeApplicationSubscriptionAutoMoney-v${apiMajorVersion}'
  parent: serviceBus::funderIntegrationTopic
  properties: {
    maxDeliveryCount: 10
    lockDuration: 'PT30S'
    defaultMessageTimeToLive: environmentConfigurationMap[environmentName].serviceBus.defaultMessageTimeToLive
  }
  resource Rule 'rules@2021-11-01' = {
    name: 'filter'
    properties: {
      sqlFilter: {
        sqlExpression: 'requestType = \'MakeApplication\' AND funderCode = \'BLACKHORSE\''
      }
    }
  }
}

resource MakeApplicationSubscriptionStaging 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  name: 'makeApplicationSubscriptionAutoMoney-v${apiMajorVersion}'
  parent: serviceBus::funderIntegrationStagingTopic
  properties: {
    maxDeliveryCount: 10
    lockDuration: 'PT30S'
    defaultMessageTimeToLive: environmentConfigurationMap[environmentName].serviceBus.defaultMessageTimeToLive
  }
  resource Rule 'rules@2021-11-01' = {
    name: 'filter'
    properties: {
      sqlFilter: {
        sqlExpression: 'requestType = \'MakeApplication\' AND funderCode = \'BLACKHORSE\''
      }
    }
  }
}

// Used by the QA team, only required in dev
resource QASubscription 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = if (environmentName == 'dev') {
  name: 'autoMoneyTestSubscription-v${apiMajorVersion}'
  parent: serviceBus::funderIntegrationTopic
  properties: {
    maxDeliveryCount: 10
    lockDuration: 'PT30S'
    defaultMessageTimeToLive: environmentConfigurationMap[environmentName].serviceBus.defaultMessageTimeToLive
  }
  resource Rule 'rules@2021-11-01' = {
    name: 'filter'
    properties: {
      sqlFilter: {
        sqlExpression: 'requestType = \'Response\' AND funderCode = \'BLACKHORSE\''
      }
    }
  }
}

var ipSecurityRestrictions = [for (allowedIp, i) in allowedIps: {
  ipAddress: '${allowedIp}/32'
  action: 'Allow'
  priority: i
  name: 'Allow ${allowedIp}'
  description: 'Allow ${allowedIp}'
}]

resource function 'Microsoft.Web/sites@2021-03-01' = if (deployStage == 'pre') {
  name: 'evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}'
  location: location
  kind: 'functionapp,linux'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    enabled: true
    serverFarmId: appServicePlan.id
    reserved: true
    clientAffinityEnabled: false
    httpsOnly: true
    virtualNetworkSubnetId:  environmentName != 'prod' ? null : virtualNetwork::aspBackend1Subnet.id
    siteConfig: {
      numberOfWorkers: 1
      linuxFxVersion: 'DOTNET|6.0'
      acrUseManagedIdentityCreds: false
      alwaysOn: false
      http20Enabled: false
      functionAppScaleLimit: 0
      minimumElasticInstanceCount: environmentConfigurationMap[environmentName].function.minimumElasticInstanceCount
      ftpsState: 'Disabled'
      scmIpSecurityRestrictionsUseMain: true
      vnetRouteAllEnabled: environmentConfigurationMap[environmentName].function.vnetRouteAllEnabled
      functionsRuntimeScaleMonitoringEnabled: environmentConfigurationMap[environmentName].function.functionsRuntimeScaleMonitoringEnabled
      httpLoggingEnabled: true
      netFrameworkVersion: 'v4.0'
      localMySqlEnabled: false

      // In production the Private Endpoint will override these ipSecurityRestrictions
      ipSecurityRestrictions: union(ipSecurityRestrictions, [{
        ipAddress: 'Any'
        action: 'Deny'
        priority: 2147483647
        name: 'Deny All'
        description: 'Deny All'
      }])

      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${functionStorage.name};AccountKey=${functionStorage.listKeys().keys[0].value};EndpointSuffix=core.windows.net'
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${functionStorage.name};AccountKey=${functionStorage.listKeys().keys[0].value};EndpointSuffix=core.windows.net'
        }
        {
          name: 'WEBSITE_CONTENTSHARE'
          value: '__PROD_WEBSITE_CONTENTSHARE__'
        }
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
        {
          name: 'AzureFunctionsWebHost__hostid'
          value: replace(guid(toLower('evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}')), '-', '')
        }
        {
          name: 'WEBSITE_ADD_SITENAME_BINDINGS_IN_APPHOST_CONFIG'
          value: '1'
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~4'
        }
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: appInsights.properties.InstrumentationKey
        }
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsights.properties.ConnectionString
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet'
        }
        {
          name: 'WEB_VNET_ROUTE_ALL'
          value: environmentConfigurationMap[environmentName].function.webVnetRouteAll
        }
        {
          name: 'AppConfigEndpoint'
          value: configStore.properties.endpoint
        }
        {
          name: 'KeyVaultEndpoint'
          value: keyVault.properties.vaultUri
        }
        {
          name: 'SecureStorage'
          value: secureStorage.name
        }
        {
          name: 'APIM_KEY'
          value: apimKey
        }
        {
          name: 'APIM_BASEURL'
          value: environmentName == 'prod' ? 'https://api.evolutionfunding.com' : environmentName == 'stg' ? 'https://api-qa.evolutionfunding.com' : 'https://api-dev.evolutionfunding.com'
        }
        // Add app setting specific to your function here
        {
          name: 'INTRODUCER_ID'
          value: 'D0E4C51BFD294B0680B3BC70850428E0'
        }
        {
          name: 'ARRANGER_ID'
          value: 'D0E4C51BFD294B0680B3BC70850428E0'
        }
        {
          name: 'SUPPLIER_ID'
          value: 'D0E4C51BFD294B0680B3BC70850428E0'
        }
        {
          name: 'INSTANCE_STORE_URL'
          value: '/internal/api/funders/instancestore/v1'
        }
        {
          name: 'FUNDER_URL'
          value: '/funders/auto-money/v1'
        }
        {
          name: 'OUTLET'
          value: 'EVOFUNDING'
        }
        {
          name: 'MakeApplicationSubscription'
          value: MakeApplicationSubscription.name
        }
        {
          name: 'ServiceBusConnectionString'
          value: 'Endpoint=sb://${serviceBus.name}.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=${listKeys('${serviceBus.id}/AuthorizationRules/RootManageSharedAccessKey', serviceBus.apiVersion).primaryKey}'
        }
        {
          name: 'DATABASE_URL'
          value: 'server=tcp:${sqlServer.properties.fullyQualifiedDomainName};database=${sqlDatabase.name};Authentication=Active Directory Managed Identity'
        }
        {
          name: 'TopicName'
          value: serviceBus::funderIntegrationTopic.name
        }
        {
          name: 'TaskHubName'
          value: '${serviceName}prod'
        }
        {
          name: 'x-lbg-major-dealerId'
          value: 25000000 
        }
        {
          name: 'x-lbg-minor-dealerId'
           value: environmentName == 'prod' ? 59150105 : environmentName == 'stg' ? 57076700 : 57076700
        }
      ]
      connectionStrings: []
    }
  }

  resource logs 'config' = {
    name: 'logs'
    properties: {
      applicationLogs: {
          fileSystem: {
            level: 'Verbose'
          }
        }
        detailedErrorMessages: {
          enabled: true
        }
        failedRequestsTracing: {
          enabled: true
        }
        httpLogs: {
          fileSystem: {
            enabled: true
            retentionInDays: 1
            retentionInMb: 35
          }
        }
    }
  }

  resource stagingSlot 'slots@2021-03-01' = {
    name: '${serviceName}-v${apiMajorVersion}-stg'
    location: location
    kind: 'functionapp,linux'
    identity: {
      type: 'SystemAssigned'
    }
    properties: {
      enabled: true
      serverFarmId: appServicePlan.id
      reserved: true
      clientAffinityEnabled: false
      httpsOnly: true
      virtualNetworkSubnetId: environmentName != 'prod' ? null : virtualNetwork::aspBackend1Subnet.id
      siteConfig: {
        numberOfWorkers: 1
        linuxFxVersion: 'DOTNET|6.0'
        acrUseManagedIdentityCreds: false
        alwaysOn: false
        http20Enabled: false
        functionAppScaleLimit: 0
        minimumElasticInstanceCount: environmentConfigurationMap[environmentName].function.minimumElasticInstanceCount
        ftpsState: 'Disabled'
        scmIpSecurityRestrictionsUseMain: true
        vnetRouteAllEnabled: environmentConfigurationMap[environmentName].function.vnetRouteAllEnabled
        functionsRuntimeScaleMonitoringEnabled: environmentConfigurationMap[environmentName].function.functionsRuntimeScaleMonitoringEnabled
        httpLoggingEnabled: true
        netFrameworkVersion: 'v4.0'
        localMySqlEnabled: false

        // In production the Private Endpoint will override these ipSecurityRestrictions
        ipSecurityRestrictions: union(ipSecurityRestrictions, [{
          ipAddress: 'Any'
          action: 'Deny'
          priority: 2147483647
          name: 'Deny All'
          description: 'Deny All'
        }])

        appSettings: [
          {
            name: 'AzureWebJobsStorage'
            value: 'DefaultEndpointsProtocol=https;AccountName=${functionStorage.name};AccountKey=${functionStorage.listKeys().keys[0].value};EndpointSuffix=core.windows.net'
          }
          {
            name: 'WEBSITE_RUN_FROM_PACKAGE'
            value: '1'
          }
          {
            name: 'AzureFunctionsWebHost__hostid'
            value: replace(guid(toLower('evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}-stg')), '-', '')
          }
          {
            name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
            value: 'DefaultEndpointsProtocol=https;AccountName=${functionStorage.name};AccountKey=${functionStorage.listKeys().keys[0].value};EndpointSuffix=core.windows.net'
          }
          {
            name: 'WEBSITE_CONTENTSHARE'
            value: '__STAGING_WEBSITE_CONTENTSHARE__'
          }
          {
            name: 'WEBSITE_ADD_SITENAME_BINDINGS_IN_APPHOST_CONFIG'
            value: '1'
          }
          {
            name: 'FUNCTIONS_EXTENSION_VERSION'
            value: '~4'
          }
          {
            name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
            value: appInsights.properties.InstrumentationKey
          }
          {
            name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
            value: appInsights.properties.ConnectionString
          }
          {
            name: 'FUNCTIONS_WORKER_RUNTIME'
            value: 'dotnet'
          }
          {
            name: 'WEB_VNET_ROUTE_ALL'
            value: environmentConfigurationMap[environmentName].function.webVnetRouteAll
          }
          {
            name: 'AppConfigEndpoint'
            value: configStore.properties.endpoint
          }
          {
            name: 'KeyVaultEndpoint'
            value: keyVault.properties.vaultUri
          }
          {
            name: 'SecureStorage'
            value: secureStorage.name
          }
          {
            name: 'APIM_KEY'
            value: apimKey
          }
          {
            name: 'APIM_BASEURL'
            value: environmentName == 'prod' ? 'https://api.evolutionfunding.com' : environmentName == 'stg' ? 'https://api-qa.evolutionfunding.com' : 'https://api-dev.evolutionfunding.com'
          }
          // Add app setting specific to your function here
          {
            name: 'INTRODUCER_ID'
            value: 'D0E4C51BFD294B0680B3BC70850428E0'
          }
          {
            name: 'ARRANGER_ID'
            value: 'D0E4C51BFD294B0680B3BC70850428E0'
          }
          {
            name: 'SUPPLIER_ID'
            value: 'D0E4C51BFD294B0680B3BC70850428E0'
          }
          {
            name: 'INSTANCE_STORE_URL'
            value: '/internal/api/funders/instancestore/v1'
          }
          {
            name: 'FUNDER_URL'
            value: '/funders/auto-money/v1'
          }
          {
            name: 'OUTLET'
            value: 'EVOFUNDING'
          }
          {
            name: 'MakeApplicationSubscription'
            value: MakeApplicationSubscriptionStaging.name
          }
          {
            name: 'ServiceBusConnectionString'
            value: 'Endpoint=sb://${serviceBus.name}.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=${listKeys('${serviceBus.id}/AuthorizationRules/RootManageSharedAccessKey', serviceBus.apiVersion).primaryKey}'
          }
          {
            name: 'DATABASE_URL'
            value: 'server=tcp:${sqlServer.properties.fullyQualifiedDomainName};database=${sqlDatabase.name};Authentication=Active Directory Managed Identity'
          }
          {
            name: 'TopicName'
            value: serviceBus::funderIntegrationStagingTopic.name
          }
          {
            name: 'TaskHubName'
            value: '${serviceName}stg'
          }
        ]
        connectionStrings: []
      }
    }
  }
}

resource functionDiagnostics 'Microsoft.Insights/diagnosticSettings@2021-05-01-preview' = if (deployStage == 'pre' && branchName == '') {
  name: 'evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}-diag'
  scope: function
  properties: {
    workspaceId: appInsights.properties.WorkspaceResourceId
    logs: [
      {
        category: null
        categoryGroup: 'allLogs'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
      {
        category: null
        categoryGroup: 'audit'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
    metrics: [
      {
        category: 'AllMetrics'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
  }
}

resource functionSlotDiagnostics 'Microsoft.Insights/diagnosticSettings@2021-05-01-preview' = if (deployStage == 'pre' && branchName == '') {
  name: 'evo-${capability}-func-${environmentName}-${serviceName}-v${apiMajorVersion}-staging-diag'
  scope: function::stagingSlot
  properties: {
    workspaceId: appInsights.properties.WorkspaceResourceId
    logs: [
      {
        category: null
        categoryGroup: 'allLogs'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
      {
        category: null
        categoryGroup: 'audit'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
    metrics: [
      {
        category: 'AllMetrics'
        enabled: true
        retentionPolicy: {
          enabled: false
          days: 0
        }
      }
    ]
  }
}

resource functionStickyAppSettings 'Microsoft.Web/sites/config@2021-03-01' = if (deployStage == 'pre') {
  name: 'slotConfigNames'
  parent: function
  properties: {
    appSettingNames: [
      'AzureFunctionsWebHost__hostid'
      'TopicName'
      'TaskHubName'
    ]
  }
}

resource functionPrivateEndpoint 'Microsoft.Network/privateEndpoints@2021-03-01' = if (environmentName == 'prod' && deployStage == 'pre') {
  name: 'evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}-pe'
  location: location
  dependsOn: [
    function
  ]
  properties: {
    subnet: {
      id: virtualNetwork::funcFrontEndSubnet.id
    }
    privateLinkServiceConnections: [
      {
        name: 'evo-${capability}-func-${env}-${serviceName}-plsc'
        properties: {
          privateLinkServiceId: function.id
          groupIds: [
            'sites'
          ]
        }
      }
    ]
  }

  resource dnsLink 'privateDnsZoneGroups@2021-03-01' = {
    name: 'functionLink'
    properties: {
      privateDnsZoneConfigs: [
        {
          name: 'functionLink'
          properties: {
            privateDnsZoneId: functionPrivateDnsZone.id
          }
        }
      ]
    }
  }
}

// dont check for pre or post as this runs always
resource functionStagingPrivateEndpoint 'Microsoft.Network/privateEndpoints@2021-03-01' = if (environmentName == 'prod') {
  name: 'evo-${capability}-func-${env}-${serviceName}-v${apiMajorVersion}-staging-pe'
  location: location
  dependsOn: [
    function
    function::stagingSlot
  ]
  properties: {
    subnet: {
      id: virtualNetwork::funcFrontEndSubnet.id
    }
    privateLinkServiceConnections: [
      {
        name: 'evo-${capability}-func-${env}-${serviceName}-staging-plsc'
        properties: {
          privateLinkServiceId: function.id
          groupIds: [
            'sites-${serviceName}-v${apiMajorVersion}-stg'
          ]
        }
      }
    ]
  }

  resource dnsLink 'privateDnsZoneGroups@2021-03-01' = {
    name: 'functionLink'
    properties: {
      privateDnsZoneConfigs: [
        {
          name: 'functionLink'
          properties: {
            privateDnsZoneId: functionPrivateDnsZone.id
          }
        }
      ]
    }
  }
}

// grant the function's system identity the correct role definition within this resourceGroup
resource roleAssignment 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = if (deployStage == 'pre') {
  name: guid(resourceGroup().id, function.name)
  scope: resourceGroup()
  properties: {
    principalId: function.identity.principalId
    roleDefinitionId: serviceRoleDefiniton.id
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignmentStaging 'Microsoft.Authorization/roleAssignments@2020-08-01-preview' = if (deployStage == 'pre') {
  name: guid(resourceGroup().id, function::stagingSlot.name)
  scope: resourceGroup()
  properties: {
    principalId: function::stagingSlot.identity.principalId
    roleDefinitionId: serviceRoleDefiniton.id
    principalType: 'ServicePrincipal'
  }
}
