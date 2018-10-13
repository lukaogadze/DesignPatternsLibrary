using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP.Manufacturers.List
{
    public class ManufacturerListVM
    {
        public string Title { get; set; }

        public IEnumerable<ManufacturerVM> Manufacturers { get; set; }

        public bool IsSorted { get; set; }

        public class ManufacturerVM
        {
            public string Name { get; set; }
            public string ListAutosUrl { get; set; }
            public Guid Id { get; set; }
        }
    }
}
