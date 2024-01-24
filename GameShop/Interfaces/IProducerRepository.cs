using GameShop.Models;

namespace GameShop.Interfaces
{
    public interface IProducerRepository
    {
        ICollection<Producer> GetProducers();
        Producer GetProducer(int id);
        bool ProducerExists(int producerId);
        bool CreateProducer(Producer producer);
        bool UpdateProducer(Producer producer);
        bool DeleteProducer(Producer producer);
        bool Save();
    }
}
