using System;
using PS.Auto.Domain;
using PS.Auto.Domain.ValueObjects;

namespace PS.Auto.Entities
{
    public class Automobile : IAutomobile
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public string Model { get; internal set; }
        public IManufacturer Manufacturer { get; internal set; }
        public PerformanceStats PerfStats { get; internal set; }
        public string Notes { get; internal set; }
    }        
}
