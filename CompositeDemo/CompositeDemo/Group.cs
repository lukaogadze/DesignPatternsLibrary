using System.Collections.Generic;
using System.Linq;

namespace CompositeDemo
{
    public class Group : IParty
    {
        public string Name { get; set; }
        public List<IParty> Members { get; set; }

        public Group()
        {
            Members = new List<IParty>();
        }

        public int Gold
        {
            get => Members.Sum(x => x.Gold);
            
            set
            {
                var eachSplit = value / Members.Count;
                var leftOver = value % Members.Count;
                if (Members.Count == 0) return;
                Members[0].Gold += leftOver;
                foreach (var member in Members)
                {
                    member.Gold += eachSplit;
                }
            }
        }

        public void Stats()
        {
            foreach (var member in Members)
            {
                member.Stats();
            }
        }
    }
}
