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
