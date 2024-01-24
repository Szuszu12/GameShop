﻿using GameShop.Models;

namespace GameShop.Dto
{
    public class ClientDto
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
       // public ICollection<Order> Orders { get; set; }

    }
}
