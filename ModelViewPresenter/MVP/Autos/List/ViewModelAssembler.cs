using System;
using System.Collections.Generic;
using PS.Auto.Domain;
using PS.Auto.Repos;

namespace MVP.Autos.List
{
    public class ViewModelAssembler
    {
        public AutoListVM Assemble(Guid manufacturerId)
        {
            var vm = new AutoListVM();
            vm.ManufacturerId = manufacturerId;
            vm.ManufacturerName = ManufacturerRepository.Instance.Find(manufacturerId).Name;


            var autos = AutomobileRepository.Instance.FindAll(a => a.Manufacturer.Id == manufacturerId);
            vm.Autos = Assemble(autos);

            return vm;
        }

        IEnumerable<AutoListVM.AutoVM> Assemble(IEnumerable<IAutomobile> autos)
        {
            IList<AutoListVM.AutoVM> autoVms = new List<AutoListVM.AutoVM>();
            
            foreach (var auto in autos)
            {
                autoVms.Add(AssembleAutoVM(auto));
            }

            return autoVms;
        }

        AutoListVM.AutoVM AssembleAutoVM(IAutomobile auto)
        {
            return new AutoListVM.AutoVM()
                             {
                                 Id = auto.Id,
                                 Model = auto.Model,
                                 Name = auto.Name
                             };
        }
    }
}