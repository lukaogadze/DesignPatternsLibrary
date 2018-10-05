namespace DecoratorDemo.Objects.Component
{
    public abstract class Pizza
    {
        public string Description { get; protected set; }
        public abstract string GetDescription();
        public abstract decimal CalculateCost();
    }
}
