using System;

namespace WebApi.Entities
{
    public class Product
    {
        public Int32 Id { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        public Category Category { get; set; }
    }
}