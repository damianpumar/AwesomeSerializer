using System.Net.Http;
using System.Net.Http.Formatting;
using AwesomeSerializer.ContractResolvers.Formatters;
using AwesomeSerializer.Tests.Unit.CustomResolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace AwesomeSerializer.Tests.Unit
{
    [TestClass]
    public class CustomFormatterTests
    {
        [TestClass]
        public class Constructor_Without_Arguments : CustomFormatterTests
        {
            private CustomFormatter Target;

            [TestInitialize]
            public void Initialize()
            {
                this.Target = new CustomFormatter();
            }

            [TestClass]
            public class Method_GetPerRequestFormatterInstance : Constructor_Without_Arguments
            {
                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_Obtain_MediaTypeFormatter_Typeof_JsonMediaTypeFormatter()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null);

                    //Assert
                    Assert.IsInstanceOfType(result, typeof(JsonMediaTypeFormatter));
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_ReferenceLoopHandling_Ignore()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.ReferenceLoopHandling, ReferenceLoopHandling.Ignore);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_PreserveReferencesHandling_None()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.PreserveReferencesHandling, PreserveReferencesHandling.None);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Default_Resolver()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.IsNull(result.SerializerSettings.ContractResolver);
                }
            }
        }

        [TestClass]
        public class Constructor_With_Type_Arguments : CustomFormatterTests
        {
            private CustomFormatter Target;

            [TestInitialize]
            public void Initialize()
            {
                this.Target = new CustomFormatter(typeof(DummyResolver));
            }

            [TestClass]
            public class Method_GetPerRequestFormatterInstance : Constructor_With_Type_Arguments
            {
                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_Obtain_MediaTypeFormatter_Typeof_JsonMediaTypeFormatter()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null);

                    //Assert
                    Assert.IsInstanceOfType(result, typeof(JsonMediaTypeFormatter));
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_ReferenceLoopHandling_Ignore()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.ReferenceLoopHandling, ReferenceLoopHandling.Ignore);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_PreserveReferencesHandling_None()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.PreserveReferencesHandling, PreserveReferencesHandling.None);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Your_Resolver()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.IsInstanceOfType(result.SerializerSettings.ContractResolver, typeof(DummyResolver));
                }
            }
        }

        [TestClass]
        public class Constructor_Nested_With_Type_Arguments : CustomFormatterTests
        {
            private CustomFormatter Target;

            [TestInitialize]
            public void Initialize()
            {
                this.Target = new CustomFormatter(typeof(DummyNestedResolver));
            }

            [TestClass]
            public class Method_GetPerRequestFormatterInstance : Constructor_Nested_With_Type_Arguments
            {
                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_Obtain_MediaTypeFormatter_Typeof_JsonMediaTypeFormatter()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null);

                    //Assert
                    Assert.IsInstanceOfType(result, typeof(JsonMediaTypeFormatter));
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_ReferenceLoopHandling_Ignore()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.ReferenceLoopHandling, ReferenceLoopHandling.Ignore);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Media_Type_Formatter_With_Setting_PreserveReferencesHandling_None()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.AreEqual(result.SerializerSettings.PreserveReferencesHandling, PreserveReferencesHandling.None);
                }

                [TestMethod]
                public void When_CustomFormatrer_Was_Created_Without_Arguments_Obtain_Your_Resolver()
                {
                    //Arrange

                    //Act
                    var result = this.Target.GetPerRequestFormatterInstance(null, Mock.Of<HttpRequestMessage>(), null) as JsonMediaTypeFormatter;

                    //Assert
                    Assert.IsInstanceOfType(result.SerializerSettings.ContractResolver, typeof(DummyNestedResolver));
                }
            }
        }
    }
}
