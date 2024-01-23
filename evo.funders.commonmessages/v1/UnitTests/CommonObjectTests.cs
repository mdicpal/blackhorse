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
    using AzureFunderCommonMessages.DotNet.Response.SubResponses;

    public class CommonResponseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateCommonResponseFromRequestData()
        {
            ApplicationRequest request = new() {
                FunderCode = 1033,
                RequestType = RequestType.MakeApplication,
                QuoteId = 1
            };
            CommonResponse response = new(request);

            Assert.That(response, Is.InstanceOf<CommonResponse>());
            Assert.That(response.FunderReference, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response.SubResponse, Is.Not.Null);
                Assert.That(response.RawRequestResponseData, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.QuoteId, Is.EqualTo(request.QuoteId));
                Assert.That(response.FunderCode, Is.EqualTo(request.FunderCode));
                Assert.That(response.RawRequestResponseData, Is.Empty);
            });

            response.AddRequestData("test");
            Assert.That(response.RawRequestResponseData, Has.Count.EqualTo(1));

            response.AddResponseData("test");
            Assert.That(response.RawRequestResponseData, Has.Count.EqualTo(2));
        }

        [Test]
        public void CanCreateCommonResponseGenericsFromRequestData()
        {
            ApplicationRequest request = new() {
                FunderCode = 1033,
                RequestType = RequestType.MakeApplication,
                QuoteId = 1
            };
            CommonResponse<DocumentUploadResponse> response = new(request);

            Assert.That(response, Is.InstanceOf<CommonResponse<DocumentUploadResponse>>());
            Assert.That(response.FunderReference, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response.SubResponse, Is.Not.Null);
                Assert.That(response.RawRequestResponseData, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.QuoteId, Is.EqualTo(request.QuoteId));
                Assert.That(response.FunderCode, Is.EqualTo(request.FunderCode));
                Assert.That(response.RawRequestResponseData, Is.Empty);
            });

            response.AddRequestData("test");
            Assert.That(response.RawRequestResponseData, Has.Count.EqualTo(1));

            response.AddResponseData("test");
            Assert.That(response.RawRequestResponseData, Has.Count.EqualTo(2));
        }
    }
}