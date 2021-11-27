using HS.IoT.Demo.DigitalTwin;

namespace HS.IoT.Demo.Abstractions;

public class Query
{
    private readonly CellSimulation _cellSimulation;

    public Query(CellSimulation cellSimulation)
    {
        _cellSimulation = cellSimulation;
    }

    public Cell GetCell() => _cellSimulation.CreateCell();

    [UseFiltering()]
    [UseSorting()]
    public IQueryable<Cell> GetCells() => _cellSimulation.CreateCells();
}