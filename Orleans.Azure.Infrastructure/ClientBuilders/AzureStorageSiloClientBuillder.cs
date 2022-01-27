using Microsoft.Extensions.Configuration;

namespace Orleans.Hosting
{
    internal class AzureStorageSiloClientBuillder : AzureSiloClientBuilder
    {
        public override void Build(IClientBuilder clientBuilder, IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.GetValue<string>(EnvironmentVariables.AzureStorageConnectionString)))
            {
                var azureStorageConnectionString = configuration.GetValue<string>(EnvironmentVariables.AzureStorageConnectionString);
                clientBuilder.UseAzureStorageClustering(options =>
                {
                    options.ConnectionString = azureStorageConnectionString;
                });
            }

            base.Build(clientBuilder, configuration);
        }
    }
}
