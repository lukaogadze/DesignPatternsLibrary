using Factory3.Autos;

namespace Factory3.Factories
{
    class MiniCooperFactory : IAutoFactory
    {
        public IAuto CreateAutomobile()
        {
            var mini = new MiniCooper();
                mini.SetName("Mini Cooper S");
            
            return mini;
        }
    }
}