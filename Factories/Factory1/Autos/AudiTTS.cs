using System;

namespace Factory1.Autos
{
    public class AudiTTS : IAuto
    {
        public string Name
        {
            get { return "Audi TTS"; }
        }

        public void TurnOn()
        {
            Console.WriteLine("The Audi TTS is running, but there is an electrical fire.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The Audi TTS is off, but the dashboard is still smoking.");
        }
    }
}