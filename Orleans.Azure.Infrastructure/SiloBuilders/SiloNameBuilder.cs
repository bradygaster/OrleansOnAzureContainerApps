﻿using Microsoft.Extensions.Configuration;
using Orleans.Configuration;

namespace Orleans.Hosting
{
    public class SiloNameBuilder : AzureSiloBuilder
    {
        public override void Build(ISiloBuilder siloBuilder, IConfiguration configuration)
        {
            var siloName = string.IsNullOrEmpty(
                configuration.GetValue<string>(EnvironentVariableKeys.OrleansSiloName)) 
                    ? Defaults.SiloName 
                    : configuration.GetValue<string>(EnvironentVariableKeys.OrleansSiloName);
            siloBuilder.Configure<SiloOptions>(options => options.SiloName = siloName);

            base.Build(siloBuilder, configuration);
        }
    }
}
