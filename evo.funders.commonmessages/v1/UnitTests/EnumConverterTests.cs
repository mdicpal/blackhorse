using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet;
using AzureFunderCommonMessages.DotNet.Response;

namespace UnitTests
{
    public class EnumConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EnumSerializesToJsonAsString()
        {
            BaseCommonRequest request = new BaseCommonRequest()
            {
                FunderCode = 1033,
                RequestType = RequestType.MakeApplication,
                QuoteId = 1,
                Data = new()
            };
            string json = request.ToJson();
            Assert.That(json, Is.Not.Null);
            Assert.That(json, Does.Contain("MakeApplication"));
        }

        [Test]
        public void DeSerializesFromJsonAsEnum()
        {
            string json = "{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.Multiple(() =>
            {
                Assert.That(request.RequestType, Is.EqualTo(RequestType.MakeApplication));
                Assert.That(request.FunderCode, Is.EqualTo("V12"));
            });
        }

        [Test]
        public void EnumDoesntAcceptUnkownInJson()
        {
            string json = "{\"requestType\": \"UNKNOWN\", \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.That(request.Errors, Has.Count.AtLeast(1));
        }

        [Test]
        public void EnumDoesntAcceptIntValueInJson()
        {
            string json = "{\"requestType\": 1, \"quoteId\": 435742, \"funderCode\": \"V12\", \"data\": {}}";
            BaseCommonRequest? request = json.FromJson<BaseCommonRequest>();
            Assert.That(request, Is.Not.Null);
            Assert.That(request, Is.InstanceOf<BaseCommonRequest>());
            Assert.That(request.Errors, Has.Count.AtLeast(1));
        }

        [Test]
        public void TestEnumSerializesAsString()
        {
            var sut = new TestClass
            {
                Test = TestClass.MyEnum.Bar
            };
            var response = new CommonResponse();
            response.AddResponseData(sut);
            Assert.That(response.RawRequestResponseData[0].RawRequestResponse, Does.Contain("Bar"));
        }
    }

    public class TestClass
    {
        public enum MyEnum
        {
            Bar
        }

        public MyEnum Test { get; set; }
    }
}