using System;

namespace Factory3.Autos
{
    public class BMW : IAuto
    {
        public BMW(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            
            Name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine("The " + Name + " is up and running with a mighty whiiiiiirrrrrr sound.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The " + Name + " is shutting down");
        }
    }
}
