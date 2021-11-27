namespace HS.IoT.Demo.Abstractions;

public class Subscription
{
    [Subscribe]
    public Cell CellUpdated([EventMessage] Cell cell) => cell;
}