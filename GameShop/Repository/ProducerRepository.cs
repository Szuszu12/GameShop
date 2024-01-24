using AutoMapper;
using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models;

namespace GameShop.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly GameShopContext _context;
        //private readonly IMapper _mapper;
        public ProducerRepository(GameShopContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;

        }

        public bool CreateProducer(Producer producer)
        {
            _context.Add(producer);
            return Save();
        }

        public bool DeleteProducer(Producer producer)
        {
            _context.Remove(producer);
            return Save();
        }

        //public ICollection<Game> GetGameByProducer(int producerId)
        //{
        //    return _context.Games.Where(p => p.Producer.Id == producerId).ToList();
        //}
        public Producer GetProducer(int producerId)
        {
            return _context.Producers.Where(p => p.Id == producerId).FirstOrDefault();
        }

        //public Producer GetProducerOfAGame(int gameId)
        //{
        //    return _context.Games.Where(g => g.Id == gameId).
        //        Select(p => p.Producer).FirstOrDefault();
        //}

        public ICollection<Producer> GetProducers()
        {
            return _context.Producers.ToList();
        }

        public bool ProducerExists(int producerId)
        {
            return _context.Producers.Any(p => p.Id == producerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProducer(Producer producer)
        {
            _context.Update(producer);
            return Save();
        }
    }
}
