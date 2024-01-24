using GameShop.Models;

namespace GameShop.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal OrderCost { get; set; }
    }
}
