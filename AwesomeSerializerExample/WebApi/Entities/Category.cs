using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public Int32 Id { get; set; }

        public String Description { get; set; }

        public String AllowVisibilityInProducts { get; set; }

        public String OnlyVisibleInCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}