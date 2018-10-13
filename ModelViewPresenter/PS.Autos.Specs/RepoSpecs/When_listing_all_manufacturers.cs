using System.Collections.Generic;
using Machine.Specifications;
using PS.Auto.Domain;
using PS.Auto.Repos;

namespace PS.Autos.Specs.RepoSpecs
{
    [Subject(typeof(AutomobileRepository))]
    public class When_listing_all_manufacturers : With_initialized_repos
    {
        Because of = () => manufacturers = ManufacturerRepository.Instance.ListAll();

        It Should_have_manufacturers_in_the_repo = () => manufacturers.ShouldNotBeEmpty();


        static IEnumerable<IManufacturer> manufacturers;
    }
}