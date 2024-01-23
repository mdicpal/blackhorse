using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request
{
    public class DocumentUploadedRequest : BaseCommonRequest
    {
        public DocumentUploadedRequest()
        {
            Data = new DocumentUploadedData();
        }
        
        [JsonProperty("data", Required = Required.Always)]
        public new DocumentUploadedData Data { get; set; }
    }
}