using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class GuaranteedFutureValueResponse : SubResponse, ISubResponseType
    {
        public GuaranteedFutureValueResponse(ResponseMessageStatus status = ResponseMessageStatus.Success, string message = "Sent guaranteed future value request") : base(message, status) { }
        
        [JsonProperty("guaranteedFutureValue")]
        public double? GuaranteedFutureValue { get; set; }
        
        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.GuaranteedFutureValueResponse;
    }
}
