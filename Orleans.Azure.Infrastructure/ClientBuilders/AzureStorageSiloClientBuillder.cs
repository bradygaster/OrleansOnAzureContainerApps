using Microsoft.Extensions.Configuration;

namespace Orleans.Hosting
{
    internal class AzureStorageSiloClientBuillder : AzureSiloClientBuilder
    {
        public override void Build(IClientBuilder clientBuilder, IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString)))
            {
                var azureStorageConnectionString = configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString);
                clientBuilder.UseAzureStorageClustering(options =>
                {
                    options.ConnectionString = azureStorageConnectionString;
                });
            }

            base.Build(clientBuilder, configuration);
        }
    }
}
