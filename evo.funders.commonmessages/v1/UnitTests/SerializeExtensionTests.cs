using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet;

namespace UnitTests
{
    public class SerializeExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidJsonInvaludRequestTypeTest()
        {
            string json = "{\"requestType\": \"MakeApplication2\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}, \"version\": 1}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
        }

        [Test]
        public void ValidJsonTest()
        {
            string json = "{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}, \"version\": 1}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.Multiple(() =>
            {
                Assert.That(request.IsValid, Is.EqualTo(true));
                Assert.That(request.IsValidJson, Is.EqualTo(true));
            });
        }

        [Test]
        public void ValidJsonFromBinaryDataTest()
        {
            BinaryData json = BinaryData.FromString("{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}, \"version\": 1}");
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.Multiple(() =>
            {
                Assert.That(request.IsValid, Is.EqualTo(true));
                Assert.That(request.IsValidJson, Is.EqualTo(true));
            });
        }

        [Test]
        public void InValidJsonTest()
        {
            string json = "{{{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.That(request.Errors, Has.Count.AtLeast(1));
            Assert.Multiple(() =>
            {
                Assert.That(request.Errors[0], Is.EqualTo("invalid request, json unable to deserialise to BaseCommonRequest"));
                Assert.That(request.IsValid, Is.EqualTo(false));
                Assert.That(request.IsValidJson, Is.EqualTo(false));
            });
        }

        [Test]
        public void NullStringJsonTest()
        {
            string json = "null";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.That(request.Errors, Has.Count.AtLeast(1));
            Assert.Multiple(() =>
            {
                Assert.That(request.Errors[0], Is.EqualTo("invalid request, json unable to deserialise to BaseCommonRequest"));
                Assert.That(request.IsValid, Is.EqualTo(false));
                Assert.That(request.IsValidJson, Is.EqualTo(false));
            });
        }

        [Test]
        public void IsValidTests()
        {
            Serialisable testClass = new();
            Assert.That(testClass, Is.Not.Null);
            testClass.Errors.Clear();
            Assert.That(testClass.IsValid, Is.EqualTo(true));
            testClass.Errors.Add("error");
            Assert.Multiple(() =>
            {
                Assert.That(testClass.Errors, Has.Count.EqualTo(1));
                Assert.That(testClass.IsValid, Is.EqualTo(false));
            });
        }
    }
}