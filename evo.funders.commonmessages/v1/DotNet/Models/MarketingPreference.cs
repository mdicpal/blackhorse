using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class MarketingPreference
    {
        [JsonProperty("optInEmail", Required = Required.Always)]
        public bool OptInEmail { get; set; }

        [JsonProperty("optInPhone", Required = Required.Always)]
        public bool OptInPhone { get; set; }

        [JsonProperty("optInPost", Required = Required.Always)]
        public bool OptInPost { get; set; }

        [JsonProperty("optInSms", Required = Required.Always)]
        public bool OptInSms { get; set; }
    }
}