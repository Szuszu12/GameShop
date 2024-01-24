using Microsoft.EntityFrameworkCore;

namespace GameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        //public DateOnly OrderDate { get; set; }
        public decimal OrderCost { get; set; }

        //Jeden do wielu (   |   to jest po stronie jeden)
        //public Client Client { get; set; }
        //public ICollection<GameOrder> GameOrders { get; set; }
    }
}