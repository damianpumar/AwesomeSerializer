using System.Linq;
using AwesomeSerializer.ResolverBase;
using AwesomeSerializer.Serializers;

namespace AwesomeSerializer.Tests.Unit.CustomResolver
{
    public class DummyResolver : Resolver
    {
        protected override System.Collections.Generic.IEnumerable<IMemberSerialization> GetMemberNoSerialize()
        {
            return Enumerable.Empty<IMemberSerialization>();
        }
    }

    public class DummyNestedResolver : Resolver
    {
        protected override System.Collections.Generic.IEnumerable<IMemberSerialization> GetMemberNoSerialize()
        {
            this.IncludeNestedResolvers(typeof(DummyResolver));
            return Enumerable.Empty<IMemberSerialization>();
        }
    }
}
