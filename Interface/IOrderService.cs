using ProvaPub.Models;

namespace ProvaPub.Interface
{
    public interface IOrderService
    {
        Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId);
    }
}
