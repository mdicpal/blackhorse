using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class FunderFee
    {
        [JsonProperty("back", Required = Required.Always)]
        public long Back { get; set; }

        [JsonProperty("front", Required = Required.Always)]
        public long Front { get; set; }

        [JsonProperty("frontSpecial", Required = Required.Always)]
        public bool FrontSpecial { get; set; }

        [JsonProperty("frontSpread", Required = Required.Always)]
        public long FrontSpread { get; set; }

        [JsonProperty("interestSpread", Required = Required.Always)]
        public bool InterestSpread { get; set; }

        [JsonProperty("maxAdvance", Required = Required.Always)]
        public long MaxAdvance { get; set; }

        [JsonProperty("monthlyAddition", Required = Required.Always)]
        public long MonthlyAddition { get; set; }
    }
}