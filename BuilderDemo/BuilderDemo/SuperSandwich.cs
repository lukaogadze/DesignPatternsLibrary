using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderDemo
{
    class SuperSandwichBuilder : SandwichBuilder
    {
        public override void PrepareBread()
        {
            throw new NotImplementedException();
        }

        public override void ApplyMeatAndCheese()
        {
            throw new NotImplementedException();
        }

        public override void ApplyVegetables()
        {
            throw new NotImplementedException();
        }

        public override void AddCondiments()
        {
            throw new NotImplementedException();
        }
    }
}
