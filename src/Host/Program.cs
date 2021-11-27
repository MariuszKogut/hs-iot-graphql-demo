using HS.IoT.Demo;
using HS.IoT.Demo.Abstractions;
using HS.IoT.Demo.DigitalTwin;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<CellSimulation>()
    .AddSingleton<DataGeneratorHostedService>()
    .AddHostedService<DataGeneratorHostedService>()
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddType<CellExtensions>()
    .AddFiltering()
    .AddSorting()
    .AddSubscriptionType<Subscription>();

var app = builder.Build();

app
    .UseRouting()
    .UseWebSockets()
    .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.Run();