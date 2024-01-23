using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class DocumentUploadResponse : SubResponse, ISubResponseType
    {
        public DocumentUploadResponse() : base("Documents Uploaded", ResponseMessageStatus.Success)
        {
            UploadedSuccessfully = new Dictionary<string, bool>();
        }

        [JsonProperty("documents")]
        public Dictionary<string, bool> UploadedSuccessfully { get; set; }
        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.DocumentUploadResponse;
    }
}