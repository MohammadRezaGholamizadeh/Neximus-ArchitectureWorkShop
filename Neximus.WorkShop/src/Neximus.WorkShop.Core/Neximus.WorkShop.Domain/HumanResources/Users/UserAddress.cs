﻿namespace Neximus.WorkShop.Domain.HumanResources.Users
{
    public class UserAddress
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
