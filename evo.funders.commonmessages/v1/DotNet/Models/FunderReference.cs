using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class FunderReference
    {
        [JsonProperty("proposal", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Proposal { get; set; }

        [JsonProperty("application", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Application { get; set; }

        [JsonProperty("agreement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Agreement { get; set; }
    }
}