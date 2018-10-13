using System.Collections.Generic;
using Machine.Specifications;
using PS.Auto.Domain;
using PS.Auto.Repos;

namespace PS.Autos.Specs.RepoSpecs
{
    [Subject(typeof (AutomobileRepository))]
    public class When_listing_all_autos : With_initialized_repos
    {
        Because of = () => autos = AutomobileRepository.Instance.ListAll();

        It Should_have_autos_in_the_repo = () => autos.ShouldNotBeEmpty();


        static IEnumerable<IAutomobile> autos;
    }
}