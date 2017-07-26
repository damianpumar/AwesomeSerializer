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
}
