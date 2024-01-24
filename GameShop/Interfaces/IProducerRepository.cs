﻿using GameShop.Models;

namespace GameShop.Interfaces
{
    public interface IProducerRepository
    {
        ICollection<Producer> GetProducers();
        Producer GetProducer(int id);
        //Producer GetProducerOfAGame(int producerId);
        //ICollection<Game> GetGameByProducer(int producerId);
        bool ProducerExists(int producerId);
        bool CreateProducer(Producer producer);
        bool UpdateProducer(Producer producer);
        bool DeleteProducer(Producer producer);
        bool Save();
    }
}
