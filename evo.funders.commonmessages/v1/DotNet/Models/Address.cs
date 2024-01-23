using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Address
    {
        [JsonProperty("addressLine1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? AddressLine1 { get; set; } = "";

        [JsonProperty("addressLine2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? AddressLine2 { get; set; } = "";

        [JsonProperty("addressLine3", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? AddressLine3 { get; set; } = "";

        [JsonProperty("county", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? County { get; set; } = "";

        [JsonProperty("unit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? Unit { get; set; } = "";

        [JsonProperty("houseName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? HouseName { get; set; } = "";

        [JsonProperty("houseNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? HouseNumber { get; set; } = "";

        [JsonProperty("postcode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? Postcode { get; set; } = "";

        [JsonProperty("town", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string? Town { get; set; } = "";
    }
}