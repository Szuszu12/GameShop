using AutoMapper;
using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models;

namespace GameShop.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly GameShopContext _context;
        private readonly IMapper _mapper;
        public ClientRepository(GameShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public bool ClientExists(int id)
        {
            return _context.Clients.Any(c => c.Id == id);
        }

        public bool CreateClient(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public Client GetClient(int id)
        {
            return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
        }

        //public Client GetClientOrder(int orderId)
        //{
        //    return _context.Orders.Where(o => o.Id == orderId).Select(c => c.Client).FirstOrDefault();
        //}

        public ICollection<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        //public ICollection<Order> GetOrdersFromClients(int clientId)
        //{
        //    return _context.Orders.Where(c => c.Client.Id == clientId).ToList();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClient(Client client)
        {
            _context.Update(client);
            return Save();
        }
    }
}
