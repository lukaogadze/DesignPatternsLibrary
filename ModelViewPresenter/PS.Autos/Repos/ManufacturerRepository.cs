using PS.Auto.Domain;

namespace PS.Auto.Repos
{
    public class ManufacturerRepository
    {
        private static readonly Repository<IManufacturer> repo;

        static ManufacturerRepository()
        {
            repo = new Repository<IManufacturer>();
        }

        public static Repository<IManufacturer> Instance
        {
            get { return repo; }
        }
    }
}