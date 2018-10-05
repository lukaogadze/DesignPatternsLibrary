namespace Factory1.Autos
{
    public interface IAuto
    {
        string Name { get; }
        void TurnOn();
        void TurnOff();
    }
}