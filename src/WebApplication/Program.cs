using HS.IoT.Demo;
using HS.IoT.Demo.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<DataGeneratorHostedService>()
    .AddHostedService<DataGeneratorHostedService>()
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddSubscriptionType<Subscription>();

var app = builder.Build();

app
    .UseRouting()
    .UseWebSockets()
    .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.Run();