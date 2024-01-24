﻿using GameShop.Models;

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
        //public int CategoryId { get; set; }
        //public Producer Producer { get; set; }
        // public ICollection<GameOrder> GameOrders { get; set; }
        //public ICollection<Review> Reviews { get; set; }
        //public ICollection<GameCategory> GameCategories { get; set; }
    }
}