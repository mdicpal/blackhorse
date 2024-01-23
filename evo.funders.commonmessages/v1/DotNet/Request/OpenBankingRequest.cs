using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request
{
    public class OpenBankingRequest : BaseCommonRequest
    {
        public OpenBankingRequest()
        {
            Data = new OpenBankingRequestData();
        }
        
        [JsonProperty("data", Required = Required.Always)]
        public new OpenBankingRequestData Data { get; set; }
    }
}