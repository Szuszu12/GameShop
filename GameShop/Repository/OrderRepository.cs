using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models;

namespace GameShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private GameShopContext _context;
        public OrderRepository(GameShopContext context)
        {
            _context = context;
        }

        public bool CreateOrder(Order order)
        {
            //var gameOrderEntity = _context.Games.Where(g => g.Id == gameId).FirstOrDefault();
            ////var client = _context.Orders.Where(c => c.Id == clientId).FirstOrDefault();

            //var gameOrder = new GameOrder()
            //{
            //    Game = gameOrderEntity,
            //    Order = order,
            //};

            //_context.Add(gameOrder);

            //var clientOrder = new ClientOrder()
            //{
            //    Client = client,
            //    Order = order,
            //};

            //_context.Add(clientOrder);

            _context.Add(order);

            return Save();
        }

        public bool DeleteOrder(Order order)
        {
            _context.Remove(order);
            return Save();
        }

        //public ICollection<Game> GetGameByOrder(int orderId)
        //{
        //    return _context.GameOrders.Where(e => e.OrderId == orderId).Select(c => c.Game).ToList();
        //}

        public Order GetOrder(int id)
        {
            return _context.Orders.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOrder(Order order)
        {
            _context.Update(order);
            return Save();
        }
    }
}
