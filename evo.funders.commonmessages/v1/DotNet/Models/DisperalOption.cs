using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class DispersalOption
    {
        [JsonProperty("amount", Required = Required.Always)]
        public long Amount { get; set; }

        [JsonProperty("isVatable", Required = Required.Always)]
        public bool IsVatable { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; } = "";
    }
}