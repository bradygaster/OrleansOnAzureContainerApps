using Orleans;
using Orleans.Hosting;
using OrleansOnContainerApps.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    var storageConnectionString = builder.Configuration.GetValue<string>(EnvironentVariableKeys.AzureStorageConnectionString);
    siloBuilder.HostSiloInAzure(builder.Configuration);
    siloBuilder.AddAzureTableGrainStorage(name: "visitorsStore", options => options.ConnectionString = storageConnectionString);
    siloBuilder.AddAzureTableGrainStorage(name: "activeVisitorsStore", options => options.ConnectionString = storageConnectionString);
    //siloBuilder.AddMemoryGrainStorage(name: "visitorsStore");
    //siloBuilder.AddMemoryGrainStorage(name: "activeVisitorsStore");
});

var app = builder.Build();
app.UseRouting();

app.MapGet("/", async (IGrainFactory grainFactory) =>
{
    var grain = grainFactory.GetGrain<IActiveVisitorsGrain>(Guid.Empty);
    return await grain.GetVisitors();
});

app.Run();
