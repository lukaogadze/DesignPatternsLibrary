namespace PS.Auto.Domain
{
    public interface IManufacturer : IEntity
    {
        string Name { get; }
        string Country { get; }
        string Description { get; }
    }
}