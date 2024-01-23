using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class EnhancedBankingResponse : SubResponse, ISubResponseType
    {
        public EnhancedBankingResponse() : base("Enhanced banking check complete")
        {
            
        }
        public EnhancedBankingResponse(ResponseMessageStatus status) : base(
            "Enhanced banking check complete", status)
        {
        }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.EnhancedBankingResponse;
    }
}
