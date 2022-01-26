using Microsoft.Extensions.Configuration;

namespace Orleans.Hosting
{
    public class AzureApplicationInsightsSiloBuilder : AzureSiloBuilder
    {
        public override void Build(ISiloBuilder siloBuilder, IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.GetValue<string>(EnvironentVariableKeys.ApplicationInsightsInstrumentationKey)))
            {
                var azureMonitoringInstrumentationKey = configuration.GetValue<string>(EnvironentVariableKeys.ApplicationInsightsInstrumentationKey);
                siloBuilder
                    .AddApplicationInsightsTelemetryConsumer(configuration.GetValue<string>(EnvironentVariableKeys.ApplicationInsightsInstrumentationKey));
            }

            base.Build(siloBuilder, configuration);
        }
    }
}
