using Microsoft.Extensions.Configuration;
using Orleans.Configuration;

namespace Orleans.Hosting
{
    public class ClusterNameSiloBuilder : AzureSiloBuilder
    {
        public override void Build(ISiloBuilder siloBuilder, IConfiguration configuration)
        {
            var clusterId = configuration.GetValue<string>(EnvironentVariableKeys.OrleansClusterName);
            var serviceId = configuration.GetValue<string>(EnvironentVariableKeys.OrleansServiceName);

            siloBuilder.Configure<ClusterOptions>(clusterOptions =>
            {
                clusterOptions.ClusterId = string.IsNullOrEmpty(clusterId) ? Defaults.ClusterName : clusterId;
                clusterOptions.ServiceId = string.IsNullOrEmpty(serviceId) ? Defaults.ServiceName : serviceId;
            });

            base.Build(siloBuilder, configuration);
        }
    }
}
