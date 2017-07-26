using System.Collections.Generic;
using AwesomeSerializer.ResolverBase;
using AwesomeSerializer.Serializers;
using WebApi.Entities;

namespace WebApi.Resolvers
{
    public class CategoryResolver : Resolver
    {
        protected override IEnumerable<IMemberSerialization> GetMemberNoSerialize()
        {
            return new List<IMemberSerialization>()
            {
                //In category controller, will serialize all properties except "AllowVisibilityInProducts" and "Products"
                new MemberSerialization<Category>(SerializeAction.NoSerialize, c=> c.AllowVisibilityInProducts, c=> c.Products),
            };
        }
    }
}