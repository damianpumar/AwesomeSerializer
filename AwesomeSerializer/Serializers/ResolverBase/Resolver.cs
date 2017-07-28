using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AwesomeSerializer.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AwesomeSerializer.ResolverBase
{
    public abstract class Resolver : DefaultContractResolver
    {
        private readonly IEnumerable<IMemberSerialization> Serializations;
        private readonly List<Resolver> NestedResolvers;

        public Resolver()
        {
            this.NestedResolvers = new List<Resolver>();
            this.Serializations = this.GetMemberNoSerialize();
        }

        public static void CheckResolver(Type resolver)
        {
            if (resolver.BaseType != typeof(Resolver))
                throw new ArgumentException(string.Format("{0} must be Resolver type.", resolver.FullName));
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = (i) =>
            {
                return this.ShouldSerialize(this.Serializations, this.NestedResolvers, property, member);
            };

            return property;
        }

        protected Boolean ShouldSerialize(IEnumerable<IMemberSerialization> serializations, List<Resolver> nestedResolvers, JsonProperty property, MemberInfo member)
        {
            var members = serializations.Where(s => s.Type == member.DeclaringType);

            bool? declareted = this.DeclareSerialization(members, property);

            if (!declareted.HasValue)
            {
                foreach (var item in nestedResolvers)
                {
                    var nestedMembers = item.GetMemberNoSerialize().Where(s => s.Type == member.DeclaringType);
                    declareted = this.DeclareSerialization(nestedMembers, property);
                    if (declareted.HasValue)
                        break;
                }
            }

            return declareted.HasValue ? declareted.Value : true;
        }

        protected Boolean? DeclareSerialization(IEnumerable<IMemberSerialization> members, JsonProperty property)
        {
            foreach (var item in members)
            {
                if (item.Properties.Contains(property.PropertyName))
                    return item.Action == SerializeAction.Serialize;
            }

            return null;    
        }


        /// <summary>
        /// Add others resolvers to serialization criteria
        /// </summary>
        /// <param name="resolvers">typeof(Resolver)</param>
        protected void IncludeNestedResolvers(params Type[] resolvers)
        {
            foreach (var item in resolvers)
            {
                CheckResolver(item);
                this.NestedResolvers.Add(Activator.CreateInstance(item) as Resolver);
            }
        }

        protected abstract IEnumerable<IMemberSerialization> GetMemberNoSerialize();
    }
}