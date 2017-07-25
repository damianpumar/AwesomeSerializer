using System;
using System.Web.Http.Controllers;
using AwesomeSerializer.ContractResolvers.Formatters;
using AwesomeSerializer.ResolverBase;

namespace AwesomeSerializer.Serializers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AwesomeSerializerAttribute : Attribute, IControllerConfiguration
    {
        private readonly Type resolver;

        public AwesomeSerializerAttribute(Type resolver)
        {
            if (resolver.BaseType != typeof(Resolver))
                throw new ArgumentException("Must be Resolver type.");

            this.resolver = resolver;
        }

        public void Initialize(HttpControllerSettings controllerSettings,
                               HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Clear();

            controllerSettings.Formatters.Add(new CustomFormatter(this.resolver));
        }
    }
}