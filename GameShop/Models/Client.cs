namespace GameShop.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        //Jeden do wielu (   |   to jest po stronie wiele)
        //public ICollection<Order> Orders { get; set; }

    }
}