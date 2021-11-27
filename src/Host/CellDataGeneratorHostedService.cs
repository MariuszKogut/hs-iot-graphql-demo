using System.Reactive.Linq;
using HotChocolate.Subscriptions;
using HS.IoT.Demo.Abstractions;
using HS.IoT.Demo.DigitalTwin;

namespace HS.IoT.Demo;

public class DataGeneratorHostedService : IHostedService
{
    private readonly CellSimulation _cellSimulation;
    private readonly ITopicEventSender _sender;
    private IDisposable? _disposable;

    public DataGeneratorHostedService(CellSimulation cellSimulation, ITopicEventSender sender)
    {
        _cellSimulation = cellSimulation;
        _sender = sender;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _disposable = Observable
            .Interval(TimeSpan.FromMilliseconds(500))
            .Select(_ => _cellSimulation.CreateCell())
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