using System.Collections.Generic;
using System.Web.Http;
using WebApi.Entities;
using WebApi.Resolvers;

namespace WebApi.Controllers
{
    [AwesomeSerializer.Serializers.AwesomeSerializer(typeof(CategoryResolver))]
    public class CategoryController : ApiController
    {
        // GET: Product
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return new List<Category>()
            {
                new Category() { Id = 1, Description = "Category One", OnlyVisibleInCategory = "Visible!" , AllowVisibilityInProducts = "No visible"}
            };
        }
    }
}