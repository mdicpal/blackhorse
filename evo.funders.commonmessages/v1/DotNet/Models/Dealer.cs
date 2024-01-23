using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Dealer
    {
        [JsonProperty("commissionType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CommissionType { get; set; } = "";

        [JsonProperty("dealerCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DealerCode { get; set; } = "";

        [JsonProperty("dealerGroupCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? DealerGroupCode { get; set; } = "";

        [JsonProperty("dealerId", Required = Required.Always)]
        public string DealerId { get; set; } = "";

        [JsonProperty("dealerPackageCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DealerPackageCode { get; set; } = "";

        [JsonProperty("groupId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? GroupId { get; set; } = "";

        [JsonProperty("isMccWeblead", Required = Required.Always)]
        public bool IsMccWeblead { get; set; }
        
        [JsonProperty("comparisonProvider")]
        public string ComparisonProvider { get; set; }
    }
}