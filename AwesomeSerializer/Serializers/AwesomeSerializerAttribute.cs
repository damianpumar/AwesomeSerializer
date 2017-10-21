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
            Resolver.CheckResolver(resolver);

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