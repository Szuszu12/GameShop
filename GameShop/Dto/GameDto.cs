using GameShop.Models;

namespace GameShop.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public string PEGI { get; set; }
    }
}
