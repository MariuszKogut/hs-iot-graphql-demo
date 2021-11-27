namespace HS.IoT.Demo.DigitalTwin;

public enum EventType
{
    Info,
    Warning,
    Error
}

public enum EventState
{
    Active,
    Acknowledged,
    ActiveAcknowledged,
    Inactive
}

public class Event
{
    public string? Id { get; set; }
    public EventType EventType { get; set; }
    public EventState EventState { get; set; }
}