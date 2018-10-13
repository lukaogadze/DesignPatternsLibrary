using System;
using System.Collections.Generic;
using System.Linq;
using PS.Auto.Domain;
using PS.Auto.Domain.ValueObjects;
using PS.Auto.Entities;

namespace PS.Auto.Repos
{
    public class RepositoryInitializer
    {
        public static void Init()
        {
            var manufacturerRepo = ManufacturerRepository.Instance;
            PopulateManufacturers(manufacturerRepo);

            var autoRepo = AutomobileRepository.Instance;
            PopulateAutos(autoRepo);
        }

        static void PopulateAutos(Repository<IAutomobile> autoRepo)
        {
            autoRepo.Save(CreateAutomobile("F-150", "XLT", "Loaded truck", new PerformanceStats(100, 10, 20), "Ford"));
            autoRepo.Save(CreateAutomobile("F-250", "XLT", "Loaded big truck", new PerformanceStats(100, 10, 20), "Ford"));
            autoRepo.Save(CreateAutomobile("F-350", "XLT", "Loaded huge truck", new PerformanceStats(100, 10, 20), "Ford"));
            autoRepo.Save(CreateAutomobile("Mustang", "Standard", "a cute little Mustang", new PerformanceStats(120, 6, 14), "Ford"));
            autoRepo.Save(CreateAutomobile("Mustang", "GT", "a fire-breathing Mustang", new PerformanceStats(180, 4.5, 10.2), "Ford"));
            autoRepo.Save(CreateAutomobile("328", "i", "economy BMW", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("328", "Ci", "convertible", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("330", "i", "standard beemer", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("330", "Ci", "convertible", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("335", "Xi", "all wheel drive", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("335", "Ci", "convertible", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("540", "i", "standard", new PerformanceStats(180, 4.5, 10.2), "BMW"));
            autoRepo.Save(CreateAutomobile("540", "Ci", "convertible", new PerformanceStats(180, 4.5, 10.2), "BMW"));
        }

        static void PopulateManufacturers(Repository<IManufacturer> manufacturerRepo)
        {
            manufacturerRepo.Save(CreateManufacturer("BMW", "Germany", "Bavarian Motorworks"));
            manufacturerRepo.Save(CreateManufacturer("Mini", "England", "Owned by BMW"));
            manufacturerRepo.Save(CreateManufacturer("Ford", "USA", "Found on Road Dead"));
            manufacturerRepo.Save(CreateManufacturer("Chevrolet", "USA", "Chevy"));
            manufacturerRepo.Save(CreateManufacturer("Toyota", "Japan", "The Lean King"));
            manufacturerRepo.Save(CreateManufacturer("Nissan", "Japan", "Nissan who?"));
            manufacturerRepo.Save(CreateManufacturer("Honda", "Japan", "Reliability personified"));
        }


        static IManufacturer CreateManufacturer(string name, string country, string description)
        {
            return new Manufacturer()
                       {
                           Country = country,
                           Description = description,
                           Id = Guid.NewGuid(),
                           Name = name
                       };
        }

        static IAutomobile CreateAutomobile(string name, string model, string notes, PerformanceStats perfStats, string manufacturerName)
        {
            var manufacturer = ManufacturerRepository.Instance.FindAll(m => m.Name == manufacturerName).FirstOrDefault();

            return new Automobile()
                       {
                           Id = Guid.NewGuid(),
                           Manufacturer = manufacturer,
                           Model = model,
                           Name = name,
                           Notes = notes,
                           PerfStats = perfStats
                       };
        }
    }
}
