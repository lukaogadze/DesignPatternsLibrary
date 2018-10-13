using Machine.Specifications;
using PS.Auto.Repos;

namespace PS.Autos.Specs.RepoSpecs
{
    public class With_initialized_repos
    {
        Establish context = () => RepositoryInitializer.Init();
    }
}
