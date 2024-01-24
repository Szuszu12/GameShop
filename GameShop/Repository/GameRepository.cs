using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models;

namespace GameShop.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameShopContext _context;
        public GameRepository(GameShopContext context ) 
        {
            _context = context; 
        }

        public bool CreateGame(Game game)
        {
            _context.Add(game);
            return Save();
        }

        public bool CreateGame(/*int producerId,*/ int categoryId, Game game)
        {
            //var producer = _context.Producers.Where(p => p.Id == producerId).FirstOrDefault();
            var category = _context.Categories.Where(o => o.Id == categoryId).FirstOrDefault();

            //var gameProducer = new Producer()
            //{
            //    ProducerName = producer,
            //    Game = game,
            //};

            //_context.Add(producer);

            //var gameCategory = new GameCategory()
            //{
            //    Category = category,
            //    Game = game,
            //};

            //_context.Add(gameCategory);

            _context.Add(game);

            return Save();
        }

        public bool DeleteGame(Game game)
        {
            _context.Remove(game);
            return Save();
        }

        public bool GameExists(int gameId)
        {
            return _context.Games.Any(g => g.Id == gameId);
        }

        public Game GetGame(int id)
        {
            return _context.Games.Where(g => g.Id == id).FirstOrDefault();
        }

        public Game GetGame(string title)
        {
            return _context.Games.Where(g => g.Title == title).FirstOrDefault();
        }

        /*public decimal GetGameOrderClient(int clientId)
        {
            var clientOrder = _context.Orders.Where(c => c.Client.Id == clientId);

            if (clientOrder.Count() <= 0)
                return 0;

            return ((decimal)clientOrder.Sum(o => o.OrderCost) / clientOrder.Count());
        }*/

        public ICollection<Game> GetGames() 
        {
            return _context.Games.OrderBy(g => g.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGame(int categoryId, Game game)
        {
            _context.Update(game);
            return Save();
        }
    }
}
