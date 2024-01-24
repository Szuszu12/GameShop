using GameShop.Models;

namespace GameShop.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrder(int id);
        bool OrderExists(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
        bool Save();
    }
}
