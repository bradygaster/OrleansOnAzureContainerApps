using Microsoft.Extensions.Configuration;

namespace Orleans.Hosting
{
    public class TableStorageSiloBuilder : AzureSiloBuilder
    {
        public override void Build(ISiloBuilder siloBuilder, IConfiguration configuration)
        {
            var azureStorageConnectionString = string.Empty;

            if (!string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString)))
            {
                azureStorageConnectionString = configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString);
            }

            if(!string.IsNullOrEmpty(azureStorageConnectionString))
            {
                siloBuilder
                    .UseAzureStorageClustering(storageOptions => storageOptions.ConnectionString = azureStorageConnectionString)
                    .AddAzureTableGrainStorageAsDefault(tableStorageOptions =>
                    {
                        tableStorageOptions.ConnectionString = azureStorageConnectionString;
                        tableStorageOptions.UseJson = true;
                    });
            }

            base.Build(siloBuilder, configuration);
        }
    }
}
