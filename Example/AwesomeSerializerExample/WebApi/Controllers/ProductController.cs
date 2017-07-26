using System.Collections.Generic;
using System.Web.Http;
using WebApi.Entities;
using WebApi.Resolvers;

namespace WebApi.Controllers
{
    [AwesomeSerializer.Serializers.AwesomeSerializer(typeof(ProductResolver))]
    public class ProductController : ApiController
    {
        // GET: Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new List<Product>()
            {
                new Product() 
                {
                    Id = 1 , 
                    Price = 20.9M, 
                    Category = new Category() 
                    {
                        Id = 1 , 
                        Description = "Category One", 
                        AllowVisibilityInProducts = "Visible in product request", 
                        OnlyVisibleInCategory = "Only visible from category controller"
                    }
                },
                new Product() 
                { 
                    Id = 2 , 
                    Price = 0.9M, 
                    Category = new Category() 
                    { 
                        Id = 2 , 
                        Description = "Category Two", 
                        AllowVisibilityInProducts = "Visible in product request", 
                        OnlyVisibleInCategory = "Only visible from category controller"
                    }
                }
            };
        }
    }
}