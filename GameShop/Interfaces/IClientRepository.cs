using GameShop.Models;

namespace GameShop.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        //Client GetClientOrder(int orderId);
        //ICollection<Order> GetOrdersFromClients(int clientId);
        bool ClientExists(int id);
        bool CreateClient(Client client);
        bool UpdateClient(Client client);
        bool DeleteClient(Client client);
        bool Save();
    }
}
