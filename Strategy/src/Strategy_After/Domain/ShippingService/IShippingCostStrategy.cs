
namespace Strategy_After.Domain.ShippingService
{
    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
}