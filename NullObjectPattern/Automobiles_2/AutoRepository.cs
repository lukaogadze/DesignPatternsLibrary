using Automobiles.Autos;

namespace Automobiles
{
    public class AutoRepository
    {
        public AutomobileBase Find(string carName)
        {
            if (carName.Contains("mini"))
                return new MiniCooper();

            return AutomobileBase.NULL;
        }
    }
}