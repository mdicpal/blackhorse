using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;

namespace UnitTests
{
    public class ErrorResponseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddsErrorsToList()
        {
            string json = "{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\"}";
            var result = json.FromJson<ApplicationRequest>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Has.Count.AtLeast(1));
        }

        [Test]
        public void ErrorResponse()
        {
            ErrorResponse initialObject = new("message", new List<string>() { "error" });
            Assert.That(initialObject, Is.Not.Null);
            Assert.That(initialObject, Is.InstanceOf<ErrorResponse>());
            Assert.Multiple(() =>
            {
                Assert.That(initialObject.Errors, Does.Contain("error"));
                Assert.That(initialObject.Status, Is.EqualTo( ResponseMessageStatus.Error ));
                Assert.That(initialObject.Message, Is.EqualTo("message"));
            });

            initialObject = new("message", new List<string>() { "error" }, ResponseMessageStatus.Error);
            Assert.That(initialObject.Status, Is.EqualTo(ResponseMessageStatus.Error));
        }

        [Test]
        public void ValidationErrorResponse()
        {
            ValidationFailedResponse initialObject = new(new List<string>() { "error" });
            Assert.That(initialObject, Is.Not.Null);
            Assert.That(initialObject, Is.InstanceOf<ValidationFailedResponse>());
            Assert.Multiple(() =>
            {
                Assert.That(initialObject.Errors, Does.Contain("error"));
                Assert.That(initialObject.Status, Is.EqualTo(ResponseMessageStatus.Error));
                Assert.That(initialObject.Message, Is.EqualTo("validation failed"));
            });

            initialObject = new(new List<string>() { "error" }, ResponseMessageStatus.Error, "message");
            Assert.Multiple(() =>
            {
                Assert.That(initialObject.Status, Is.EqualTo(ResponseMessageStatus.Error));
                Assert.That(initialObject.Message, Is.EqualTo("message"));
            });
        }



        [Test]
        public void FunderErrorsResponse()
        {
            FunderErrors initialObject = new(new List<string>() { "error" });
            Assert.That(initialObject, Is.Not.Null);
            Assert.That(initialObject, Is.InstanceOf<FunderErrors>());
            Assert.Multiple(() =>
            {
                Assert.That(initialObject.Errors, Does.Contain("error"));
                Assert.That(initialObject.Status, Is.EqualTo(ResponseMessageStatus.Error));
                Assert.That(initialObject.Message, Is.EqualTo("funder returned errors"));
            });

            initialObject = new();
            Assert.That(initialObject, Is.InstanceOf<FunderErrors>());
        }

        [Test]
        public void ServiceErrorsResponse()
        {
            ServiceErrors initialObject = new("funder", new List<string>() { "error" });
            Assert.That(initialObject, Is.Not.Null);
            Assert.That(initialObject, Is.InstanceOf<ServiceErrors>());
            Assert.Multiple(() =>
            {
                Assert.That(initialObject.Errors, Does.Contain("error"));
                Assert.That(initialObject.Status, Is.EqualTo(ResponseMessageStatus.Error));
                Assert.That(initialObject.Message, Is.EqualTo("unable to connect to service (funder)"));
            });

            initialObject = new();
            Assert.That(initialObject, Is.InstanceOf<ServiceErrors>());
        }
    }
}