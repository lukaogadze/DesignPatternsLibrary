using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PS.Auto.Domain;
using PS.Auto.Repos;

namespace MVP.Manufacturers.List.Assemble
{
    public class ManufacturerListVMAssembler
    {
        readonly Repository<IManufacturer> repository;

        public ManufacturerListVMAssembler()
            : this(ManufacturerRepository.Instance)
        {}

        public ManufacturerListVMAssembler(Repository<IManufacturer> repository)
        {
            this.repository = repository;
        }


        public ManufacturerListVM AssembleManufacturerListVM()
        {
            return new ManufacturerListVM()
            {
                Title = "Automobile Manufacturers",
                IsSorted = false,
                Manufacturers = AssembleManufacturers()
            };
        }

        IEnumerable<ManufacturerListVM.ManufacturerVM> AssembleManufacturers()
        {
            IList<ManufacturerListVM.ManufacturerVM> manufacturerVMs = new List<ManufacturerListVM.ManufacturerVM>();
            
            var manufacturersFromDomain = repository.ListAll();

            foreach (var manufacturer in manufacturersFromDomain)
            {
                var manufacturerVM = AssembleManufacturer(manufacturer);
                manufacturerVMs.Add(manufacturerVM);    
            }

            return manufacturerVMs;
        }

        ManufacturerListVM.ManufacturerVM AssembleManufacturer(IManufacturer manufacturer)
        {
            return new ManufacturerListVM.ManufacturerVM()
                                     {
                                         Id = manufacturer.Id,
                                         Name = manufacturer.Name,
                                         ListAutosUrl = "List.aspx?m=" + manufacturer.Id
                                     };
        }
    }
}
