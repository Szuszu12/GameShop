using GameShop.Models;

namespace GameShop.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        //public DateOnly OrderDate { get; set; }
        public decimal OrderCost { get; set; }
        // public ICollection<GameOrder> GameOrders { get; set; }
    }
}
