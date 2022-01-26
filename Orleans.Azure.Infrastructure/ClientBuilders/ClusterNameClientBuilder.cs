using Microsoft.Extensions.Configuration;
using Orleans.Configuration;

namespace Orleans.Hosting
{
    public class ClusterNameClientBuilder : AzureSiloClientBuilder
    {
        public override void Build(IClientBuilder clientBuilder, IConfiguration configuration)
        {
            var clusterId = string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.OrleansClusterName)) ? Defaults.ClusterName : configuration.GetValue<string>(EnvironentVariableKeys.OrleansClusterName);
            var serviceId = string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.OrleansServiceName)) ? Defaults.ServiceName : configuration.GetValue<string>(EnvironentVariableKeys.OrleansServiceName);

            clientBuilder.Configure<ClusterOptions>(clusterOptions =>
            {
                clusterOptions.ClusterId = clusterId;
                clusterOptions.ServiceId = serviceId;
            });

            base.Build(clientBuilder, configuration);
        }
    }
}
