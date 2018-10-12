using System.Collections;

namespace LazyLoad.Ghosts
{
    public class Customer:DomainObject
    {
        public Customer(int id)
            : base(id)
        {
        }

        protected override void DoLoadLine(ArrayList dataRow)
        {
            throw new System.NotImplementedException();
        }

        protected override ArrayList GetDataRow()
        {
            throw new System.NotImplementedException();
        }
    }
}