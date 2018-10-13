using System;
using System.Collections.Generic;
using System.Linq;
using MVP.Manufacturers.List.Assemble;

namespace MVP.Manufacturers.List
{
    public class ManufacturerListPresenter
    {
        private readonly IManufacturerListView listView;

        public ManufacturerListPresenter(IManufacturerListView listView)
        {
            this.listView = listView;
        }

        public void Init()
        {
            ManufacturerListVM viewModel = GetViewModel();

            listView.Show(viewModel);
        }

        public void Sort(bool isSorted)
        {
            var vm = GetViewModel();
            if(!isSorted)
            {
                vm.Manufacturers = vm.Manufacturers.OrderBy(m => m.Name);
            }

            vm.IsSorted = !isSorted;

            listView.Show(vm);
        }

        private ManufacturerListVM GetViewModel()
        {
            var assembler = new ManufacturerListVMAssembler();

            return assembler.AssembleManufacturerListVM();
        }
    }


}
