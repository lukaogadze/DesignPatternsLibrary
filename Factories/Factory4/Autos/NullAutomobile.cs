namespace Factory4.Autos
{
    public class NullAutomobile : IAutomobile
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