using ProxyDemo.Repositories;

namespace ProxyDemo.Model
{
    public class RemoteOrder : Order
    {
        public RemoteOrder(int id) : base(id)
        {
        }

        protected override void GetEntity()
        {
            this.OrderEntity = new RemoteOrderRepository().GetById(Id);
        }
    }
}