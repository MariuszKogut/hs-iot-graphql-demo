namespace HS.IoT.Demo.Abstractions;

public class Query
{
    public Cell GetCellData() => new()
    {
        State = "Running",
        Temperature = 471
    };
}