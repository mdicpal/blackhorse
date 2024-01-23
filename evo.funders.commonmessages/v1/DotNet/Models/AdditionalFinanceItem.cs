using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class AdditionalFinanceItem
    {
        [JsonProperty("label")]
        public string? Label { get; set; }
        
        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}