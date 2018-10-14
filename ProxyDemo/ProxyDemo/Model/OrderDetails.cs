using ProxyDemo.Repositories;

namespace ProxyDemo.Model
{
    public class OrderDetails
    {
        private readonly int _id;

        public OrderDetails()
        {
            
        }
        public OrderDetails(int id)
        {
            _id = id;
            var orderDetailsEntity = new OrderDetailsRepository().GetById(id);
            this.Name = orderDetailsEntity.Name;
            this.Price = orderDetailsEntity.Price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}