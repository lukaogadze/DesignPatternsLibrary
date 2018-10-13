using PS.Auto.Domain;

namespace PS.Auto.Repos
{
    public class AutomobileRepository
    {
        private static readonly Repository<IAutomobile> repo;

        static AutomobileRepository()
        {
            repo = new Repository<IAutomobile>();
        }

        public static Repository<IAutomobile> Instance
        {
            get { return repo; }
        }
    }
}