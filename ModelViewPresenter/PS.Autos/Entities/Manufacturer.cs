using System;
using PS.Auto.Domain;

namespace PS.Auto.Entities
{
    public class Manufacturer : IManufacturer
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public string Country { get; internal set; }
        public string Description { get; internal set; }
    }
}
