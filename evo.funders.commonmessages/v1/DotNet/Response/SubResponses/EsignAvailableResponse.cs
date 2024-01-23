using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.DataTypes
{
    public class EsignAvailableResponse : SubResponse, ISubResponseType
    {
        public EsignAvailableResponse() :  base("Esign Available"){}
        public EsignAvailableResponse(string esignUrl ) : base("Esign Available", ResponseMessageStatus.Success)
        {
            Url = esignUrl;
        }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlRequired")]
        public bool? UrlRequired { get; set; } = true;

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.EsignResponse;
    }
}