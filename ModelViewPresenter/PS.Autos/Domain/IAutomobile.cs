using PS.Auto.Domain.ValueObjects;

namespace PS.Auto.Domain
{
    public interface IAutomobile : IEntity
    {
        string Name { get; }
        string Model { get; }
        
        IManufacturer Manufacturer { get; }
        PerformanceStats PerfStats { get;}        

        string Notes { get; }
    }
}
