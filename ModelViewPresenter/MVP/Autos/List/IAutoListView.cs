using System;
using System.Collections.Generic;

namespace MVP.Autos.List
{
    public interface IAutoListView
    {
        void SetManufacturersName(string name);
        void SetManufacturerId(Guid Id);
        void BindAutoList(IEnumerable<AutoListVM.AutoVM> autos);
    }

    public class AutoListPresenter
    {
        readonly IAutoListView view;
        readonly Guid manufacturerId;

        public AutoListPresenter(IAutoListView view, Guid manufacturerId)
        {
            this.view = view;
            this.manufacturerId = manufacturerId;
        }

        public void Init()
        {
            var assembler = new ViewModelAssembler();
            AutoListVM model = assembler.Assemble(manufacturerId);

            view.SetManufacturersName(model.ManufacturerName);
            view.SetManufacturerId(model.ManufacturerId);
            view.BindAutoList(model.Autos);
        }
    }

    public class AutoListVM
    {
        public string ManufacturerName { get; set; }
        public Guid ManufacturerId { get; set; }
        public IEnumerable<AutoVM> Autos { get; set; }

        public class AutoVM
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public Guid Id { get; set; }
        }
    }
}
