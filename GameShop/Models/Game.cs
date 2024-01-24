namespace GameShop.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public string PEGI { get; set; }
        //public Producer Producer { get; set; }
        //public int CategoryId { get; set; }
        //public ICollection<GameOrder> GameOrders { get; set; }
        //public ICollection<GameCategory> GameCategories { get; set; }
    }
}