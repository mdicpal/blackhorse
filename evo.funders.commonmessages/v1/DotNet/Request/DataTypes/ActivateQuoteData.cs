using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class ActivateQuoteData
    {
        [JsonProperty("funderApplicationId", Required = Required.Always)]
        public string FunderApplicationId { get; set; }
        
        [JsonProperty("funderQuoteId", Required = Required.Default)]
        public string? FunderQuoteId { get; set; } = "";
    }
}