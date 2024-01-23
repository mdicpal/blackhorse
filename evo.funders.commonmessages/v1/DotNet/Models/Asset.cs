using System;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Asset
    {
        public Asset()
        {
            RegistrationDate = new DateTimeOffset();
        }

        [JsonProperty("assetType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? AssetType { get; set; } = "";
        
        [JsonProperty("isCreditLimitVehicle")]
        public bool IsCreditLimitVehicle { get; set; } = false;

        [JsonProperty("capCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? CapCode { get; set; } = "";

        [JsonProperty("currentMileage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? CurrentMileage { get; set; } = 0;

        [JsonProperty("isNew", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNew { get; set; } = false;

        [JsonProperty("make", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Make { get; set; } = "";

        [JsonProperty("model", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Model { get; set; } = "";

        [JsonProperty("registrationDate")]
        public DateTimeOffset? RegistrationDate { get; set; }

        [JsonProperty("style", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Style { get; set; } = "";

        [JsonProperty("vin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Vin { get; set; } = "";

        [JsonProperty("vrm", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Vrm { get; set; } = "";
    }
}