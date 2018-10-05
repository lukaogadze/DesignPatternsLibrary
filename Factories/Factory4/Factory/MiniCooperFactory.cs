using System;
using Factory4.Autos;
using Factory4.Autos.Mini;

namespace Factory4.Factory
{
    public class MiniCooperFactory : IAutoFactory
    {
        public IAutomobile CreateSportsCar()
        {
            var mini = new MiniCooper();

            mini.AddSportPackage();

            return mini;
        }

        public IAutomobile CreateLuxuryCar()
        {
            var mini = new MiniCooper();
            
            mini.AddLuxuryPackage();
            
            return mini;
        }

        public IAutomobile CreateEconomyCar()
        {
            return new MiniCooper();       
        }
    }
}
