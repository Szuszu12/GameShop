using GameShop.Models;

namespace GameShop.Interfaces
{
    public interface IGameRepository
    {
        ICollection<Game> GetGames();
        Game GetGame(int id);
        Game GetGame(string title);
        bool GameExists(int gameId);
        bool CreateGame(Game game);
        bool UpdateGame(int categoryId, Game game);
        bool DeleteGame(Game game);
        bool Save();
    }
}
