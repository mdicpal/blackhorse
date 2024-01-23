using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet
{
    public class CommonObject : Serialisable
    {
        [JsonProperty("funderCode", Required = Required.Always)]
        public object FunderCode { get; set; }

        [JsonProperty("quoteId", Required = Required.Always)]
        public int QuoteId { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        public int Version { get; set; } = 1;
    }
}
