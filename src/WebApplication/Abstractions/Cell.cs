namespace HS.IoT.Demo.Abstractions;

public class Cell
{
    public string State { get; set; } = "Running";

    public DateTime LastUpdate { get; set; } = DateTime.Now;
    
    public double Temperature { get; set; } = 0;
    
    public double EnergyConsumption { get; set; } = 0;
}