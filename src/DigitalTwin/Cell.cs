namespace HS.IoT.Demo.DigitalTwin;

public class Cell
{
    public string State { get; set; } = "Running";

    public DateTime LastUpdate { get; set; } = DateTime.Now;

    public short Temperature { get; set; } = 0;

    public EnergyConsumption? EnergyConsumption { get; set; }

    public Robot? ExtractionRobot { get; set; }

    public Robot? StorageRobot { get; set; }

    [UseFiltering]
    [UseSorting]
    public IQueryable<Event>? Events { get; set; }
}

