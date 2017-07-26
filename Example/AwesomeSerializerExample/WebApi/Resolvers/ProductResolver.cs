using System.Collections.Generic;
using AwesomeSerializer.ResolverBase;
using AwesomeSerializer.Serializers;
using WebApi.Entities;

namespace WebApi.Resolvers
{
    public class ProductResolver : Resolver
    {
        protected override IEnumerable<IMemberSerialization> GetMemberNoSerialize()
        {
            return new List<IMemberSerialization>()
            {
                new MemberSerialization<Product>(SerializeAction.NoSerialize, p=> p.Price),
                new MemberSerialization<Category>(SerializeAction.NoSerialize, c=> c.Products, c=> c.OnlyVisibleInCategory),
            };
        }
    }
}