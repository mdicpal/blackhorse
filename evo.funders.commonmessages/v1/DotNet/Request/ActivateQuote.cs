using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request
{
    public class ActivateQuote : BaseCommonRequest
    {
        public ActivateQuote()
        {
            Data = new ActivateQuoteData();
        }
        
        [JsonProperty("data", Required = Required.Always)]
        public new ActivateQuoteData Data { get; set; }
    }
}