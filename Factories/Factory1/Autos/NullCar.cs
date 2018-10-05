namespace Factory1.Autos
{
    public class NullCar : IAuto
    {
        public string Name
        {
            get { return string.Empty; }
        }

        public void TurnOn()
        {
            
        }

        public void TurnOff()
        {
            
        }
    }
}