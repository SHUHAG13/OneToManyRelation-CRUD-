﻿namespace EF_Relations.Data
{
    public class CustomerAddressDto
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int CustomerId { get; set; }
    }
}
