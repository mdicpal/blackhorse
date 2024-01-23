using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class FileDownloadAvailableResponse : SubResponse, ISubResponseType
    {
        public const string InvoiceDocument = "Invoice";
        public const string PayoutDocument = "PayoutDocument";
        public FileDownloadAvailableResponse() : base("File download available") {}
        public FileDownloadAvailableResponse(string url, string subject, string type) : base(subject, ResponseMessageStatus.Success)
        {
            Url = url;
            Type = type;
        }

        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.DocumentAvailable;
    }
}
