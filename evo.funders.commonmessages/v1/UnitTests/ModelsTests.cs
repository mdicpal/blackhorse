using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using AzureFunderCommonMessages.DotNet;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types.ValueConstants;

namespace UnitTests
{
    public class ModelsTests
    {

        [Test]
        public void AddsErrorsToList()
        {
            string json = "{\"requestType\": \"MakeApplication\", \"quoteId\": 435742, \"funderCode\": \"V12\"}";
            var result = json.FromJson<ApplicationRequest>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Has.Count.AtLeast(1));
        }

        [Test]
        public void ResponseModelsInstantiate()
        {
            TestModel(new AdditionalFinanceResponse
            {
                FinanceItems = new List<AdditionalFinanceItem>
                {
                    new AdditionalFinanceItem
                    {
                        Label = "label",
                        Value = "123"
                    }
                }
            });
            TestModel<CommonResponse>();
            TestModel<Data>();
            TestModel<ErrorResponse>();
            TestModel<ESignCompletedResponse>();
            TestModel<ESignTriggeredResponse>();
            TestModel<ValidationFailedResponse>();
            TestModel(new FileDownloadAvailableResponse("test", "subject", "type"));
            TestModel(new EsignAvailableResponse("test"));
            TestModel(new OpenBankingResponse(new Uri("http://www.example.com/"), "Test Funder")); 
            TestModel(new CommunicationResponse("Test Message", CommunicationResponseTypes.SendSmsToCustomer , "Funder"));
            TestModel(new StatusResponse());
            TestModel(new StatusResponse(StatusResponseType.FunderResponseReceived, "message"));
            TestModel(new StatusResponse(StatusResponseType.FunderResponseReceived, "message")
            {
                Messages = new (){"Messages"},
                Conditions = new (){"Conditions"},
            });
            TestModel(new GenericResponse("test", "message"));
            TestModel(new EnhancedBankingResponse(ResponseMessageStatus.Success));
            TestModel(new TaskModel
            {
                Id = "1234",
                TaskAction = TaskAction.Created,
                Label = "Please sign and return the attached PCP agreement",
                Description = "Test",
                Comments = new List<string>()
                {
                    "I left a comment"
                },
                RequiredDocuments = new List<DocumentRequest>() {new DocumentRequest
                    {
                        FileType = FileType.DrivingLicence,
                        Notes = "Please return by some date"
                    }
                },

            });
        }

        [Test]
        public void TestDocumentUploadedModel()
        {
            var testData = new DocumentUploadedData
            {
                Files = new List<SecureFiles>{new()
                    {
                        FilePath = "foo",
                        ContainerName = "bar",
                        FileType = FileType.DrivingLicence
                    }
                },
                Message = "foo bar baz",
                Subject = "Foo",
                FromAddress = "test@example.com",
                ToAddresses = new List<string>{"test@example.com"}
            };
            
            TestModel(testData);
            
            TestModel(new DocumentUploadedRequest()
            {
                Data = testData
            });
        }

        [Test]
        public void RequestModelsInstantiate()
        {
            TestModel<BaseCommonRequest>();
            TestModel<ApplicationRequest>();
            TestModel<AdditionalData>();
            TestModel<GetEsign>();
            TestModel<ApplicationRequestData>();
            TestModel<ActivateQuote>();
            TestModel<CancelApplicationRequest>();
            TestModel<OpenBankingRequest>();
            TestModel(new InvoiceAddressResponse("foo", "bar"));
        }

        [Test]
        public void CommonResponseWithGenericsTest()
        {
            TestModel<CommonResponse<AdditionalFinanceResponse>>();
            TestModel<CommonResponse<AssetUpdateResponse>>();
            TestModel<CommonResponse<BankDetailsUpdateResponse>>();
            TestModel<CommonResponse<CommunicationResponse>>();
            TestModel<CommonResponse<DocumentUploadResponse>>();
            TestModel<CommonResponse<DrivingLicenceUpdateResponse>>();
            TestModel<CommonResponse<EnhancedBankingResponse>>();
            TestModel<CommonResponse<ErrorResponse>>();
            TestModel<CommonResponse<EsignAvailableResponse>>();
            TestModel<CommonResponse<FileDownloadAvailableResponse>>();
            TestModel<CommonResponse<FunderErrors>>();
            TestModel<CommonResponse<GenericResponse>>();
            TestModel<CommonResponse<OpenBankingResponse>>();
            TestModel<CommonResponse<ServiceErrors>>();
            TestModel<CommonResponse<StatusResponse>>();
            TestModel<CommonResponse<TaskResponse>>();
            TestModel<CommonResponse<ValidationFailedResponse>>();
            TestModel<CommonResponse<ESignCompletedResponse>>();
            TestModel<CommonResponse<ESignTriggeredResponse>>();
        }

        [Test]
        public void ModelsInstantiate()
        {
            TestModel<Address>();
            TestModel(new Applicant()
            {
                IsMainApplicant = false
            });
            TestModel<Asset>();
            TestModel<Bank>();
            TestModel<Company>();
            TestModel<Dealer>();
            TestModel<DispersalOption>();
            TestModel<EmploymentHistory>();
            TestModel<FinancialStatus>();
            TestModel<FunderFee>();
            TestModel(new FunderReference {
                Application = "application",
                Proposal = "proposal",
                Agreement = "agreement",
            });
            TestModel<MarketingPreference>();
            TestModel<Quote>();
            TestModel<ResidenceHistory>();
            TestModel<CommonObject>();
        }

        private static void TestModel<T>(T? model = default) {
            model ??= Activator.CreateInstance<T>();
            Assert.That(model, Is.Not.Null);
            Assert.That(model, Is.InstanceOf<T>());
            
            string? json = model.ToJson();
            Assert.That(json, Is.Not.Null);

            T? deserialised = JsonConvert.DeserializeObject<T>(json, Converter.Settings);
            Assert.That(deserialised, Is.Not.Null);

            string serialized = deserialised.ToJson();
            Assert.That(serialized, Is.Not.Null);

        }
    }
}