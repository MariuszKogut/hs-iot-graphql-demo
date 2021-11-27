using Bogus;

namespace HS.IoT.Demo.DigitalTwin;

public class CellSimulation
{
    private readonly Faker<Cell> _cellFaker;
    private readonly Faker<Event> _eventsFaker;

    public CellSimulation()
    {
        Randomizer.Seed = new Random(8675309);

        var states = new[] { "running", "error", "stopped", "emgercency-stop" };

        _eventsFaker = new Faker<Event>()
            .RuleFor(x => x.Id, f => f.Commerce.Ean8())
            .RuleFor(x => x.EventState, f => f.PickRandom<EventState>())
            .RuleFor(x => x.EventType, f => f.PickRandom<EventType>());

        var energyConsumptionFaker = new Faker<EnergyConsumption>()
            .RuleFor(x => x.CurrentConsumption, f => f.Random.UShort())
            .RuleFor(x => x.CurrentVoltage, f => f.Random.UShort())
            .RuleFor(x => x.TotalConsumption, f => f.Random.UShort());

        var axleFaker = new Faker<Axle>()
            .RuleFor(x => x.CurrentPosition, f => f.Random.Int())
            .RuleFor(x => x.MovingSpeed, f => f.Random.Int())
            .RuleFor(x => x.IsMoving, f => f.Random.Bool());

        var manufacturerFaker = new Faker<Manufacturer>()
            .RuleFor(x => x.Name, (f) => f.Company.CompanyName());

        var robotFaker = new Faker<Robot>()
            .RuleFor(x => x.Manufacturer, () => manufacturerFaker.Generate())
            .RuleFor(x => x.EnergyConsumption, () => energyConsumptionFaker.Generate())
            .RuleFor(x => x.Axle1, () => axleFaker.Generate())
            .RuleFor(x => x.Axle2, () => axleFaker.Generate())
            .RuleFor(x => x.Axle3, () => axleFaker.Generate())
            .RuleFor(x => x.Axle4, () => axleFaker.Generate())
            .RuleFor(x => x.Axle5, () => axleFaker.Generate())
            .RuleFor(x => x.Axle6, () => axleFaker.Generate());

        _cellFaker = new Faker<Cell>()
            .RuleFor(x => x.EnergyConsumption, () => energyConsumptionFaker.Generate())
            .RuleFor(x => x.ExtractionRobot, () => robotFaker.Generate())
            .RuleFor(x => x.StorageRobot, () => robotFaker.Generate())
            .RuleFor(x => x.State, (f) => f.PickRandom(states))
            .RuleFor(x => x.LastUpdate, (f) => f.Date.Past())
            .RuleFor(x => x.Temperature, (f) => f.Random.Short())
            .RuleFor(x => x.Events, () => _eventsFaker.Generate(15).AsQueryable());
    }

    public Cell CreateCell() => _cellFaker.Generate();
    
    public IQueryable<Cell> CreateCells() => _cellFaker.Generate(100).AsQueryable();

    public List<Event> CreateEvents() => _eventsFaker.Generate(10).ToList();
}