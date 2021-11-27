using System.Reactive.Linq;
using HotChocolate.Subscriptions;
using HS.IoT.Demo.Abstractions;

namespace HS.IoT.Demo;

public class DataGeneratorHostedService : IHostedService
{
    private readonly ITopicEventSender _sender;
    private IDisposable? _disposable;

    public DataGeneratorHostedService(ITopicEventSender sender)
    {
        _sender = sender;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _disposable = Observable
            .Interval(TimeSpan.FromMilliseconds(250))
            .Select(_ => new Cell
            {
                State = "running",
                LastUpdate = DateTime.Now,
                Temperature = Random.Shared.NextDouble(),
                EnergyConsumption = Random.Shared.NextDouble()
            })
            .Do(async x => await _sender.SendAsync(nameof(Subscription.CellUpdated), x))
            .Subscribe();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _disposable?.Dispose();
        return Task.CompletedTask;
    }
}