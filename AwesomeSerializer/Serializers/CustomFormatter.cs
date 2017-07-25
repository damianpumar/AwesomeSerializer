using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using AwesomeSerializer.ResolverBase;
using Newtonsoft.Json;

namespace AwesomeSerializer.ContractResolvers.Formatters
{
    public class CustomFormatter : JsonMediaTypeFormatter
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;

        private readonly Resolver resolver;

        public CustomFormatter(Type resolver)
            : this()
        {
            this.resolver = Activator.CreateInstance(resolver) as Resolver;
        }

        public CustomFormatter()
        {
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None
            };

            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(
           Type type,
           HttpRequestMessage request,
           MediaTypeHeaderValue mediaType)
        {
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = jsonSerializerSettings
            };

            if (this.resolver != null)
                formatter.SerializerSettings.ContractResolver = resolver;

            return formatter;
        }
    }
}