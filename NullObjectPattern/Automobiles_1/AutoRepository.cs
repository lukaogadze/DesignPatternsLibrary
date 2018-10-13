using System;
using System.Collections;
using System.Collections.Generic;
using Automobiles.Autos;

namespace Automobiles
{
    public class AutoRepository
    {
        readonly List<IAutomobile> autos;

        public AutoRepository()
        {
            autos = new List<IAutomobile>
                        {
                            new MiniCooper(), 
                            new BMW335XI()
                        };
        }

        public IEnumerable<IAutomobile> FindAllByName(string name)
        {
            return autos.FindAll(a => a.Name.ToLower().Contains(name.ToLower()));
        }

        public IAutomobile Find(Guid id)
        {
            return autos.Find(a => a.Id == id);
        }
    }
}