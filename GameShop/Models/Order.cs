using Microsoft.EntityFrameworkCore;

namespace GameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal OrderCost { get; set; }
    }
}