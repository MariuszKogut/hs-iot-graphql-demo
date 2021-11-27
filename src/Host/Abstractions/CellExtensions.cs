using HS.IoT.Demo.DigitalTwin;

namespace HS.IoT.Demo.Abstractions;

[ExtendObjectType(Name = nameof(Cell))]
[Obsolete]
public class CellExtensions
{
    [UseFiltering()]
    [UseSorting()]
    public IQueryable<Event> GetCellEvents([Service] CellSimulation cellSimulation, Cell cell) =>
        cellSimulation.CreateEvents().AsQueryable();
}
