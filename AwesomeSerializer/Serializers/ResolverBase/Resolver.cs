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

        public Resolver()
        {
            this.Serializations = this.GetMemberNoSerialize();
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = (i) =>
            {
                return this.ShouldSerialize(this.Serializations, property, member);
            };

            return property;
        }

        protected Boolean ShouldSerialize(IEnumerable<IMemberSerialization> serializations, JsonProperty property, MemberInfo member)
        {
            var members = serializations.Where(s => s.Type == member.DeclaringType);

            foreach (var item in members)
            {
                if (item.Properties.Contains(property.PropertyName))
                    return item.Action == SerializeAction.Serialize;
            }

            return true;
        }

        protected abstract IEnumerable<IMemberSerialization> GetMemberNoSerialize();
    }
}