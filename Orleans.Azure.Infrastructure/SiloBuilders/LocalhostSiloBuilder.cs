using Microsoft.Extensions.Configuration;

namespace Orleans.Hosting
{
    internal class LocalhostSiloBuilder : AzureSiloBuilder
    {
        public override void Build(ISiloBuilder siloBuilder, IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString)) &&
                string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.OrleansSiloPort)) &&
                string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.OrleansGatewayPort)) &&
                string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.WebAppsPrivateIPAddress)) &&
                string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.WebAppsPrivatePorts)))
                // check for other clustering configurations, and if none are found...)
            {
                siloBuilder.UseLocalhostClustering();
            }

            base.Build(siloBuilder, configuration);
        }
    }
}