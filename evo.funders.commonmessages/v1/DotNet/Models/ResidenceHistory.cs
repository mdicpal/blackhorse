using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class ResidenceHistory
    {
        public ResidenceHistory()
        {
            Address = new Address();
        }

        [JsonProperty("address", Required = Required.Always)]
        public Address Address { get; set; }

        [JsonProperty("monthsAtAddress", Required = Required.Always)]
        public long MonthsAtAddress { get; set; }

        [JsonProperty("orderNumber", Required = Required.Always)]
        public long OrderNumber { get; set; }

        [JsonProperty("residentialStatusShortcode", Required = Required.AllowNull)]
        public string ResidentialStatusShortcode { get; set; } = "";

        [JsonProperty("yearsAtAddress", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long YearsAtAddress { get; set; }
    }
}