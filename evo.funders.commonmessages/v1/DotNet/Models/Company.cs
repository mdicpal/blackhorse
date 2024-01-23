using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Company
    {
        public Company()
        {
            Address = new Address();
        }

        [JsonProperty("accountNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? AccountNumber { get; set; } = "";

        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Address? Address { get; set; }

        [JsonProperty("companyNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? CompanyNumber { get; set; } = "";

        [JsonProperty("companyRole", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? CompanyRole { get; set; } = "";

        [JsonProperty("establishedMonth", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public long? EstablishedMonth { get; set; } = 0;

        [JsonProperty("establishedYear", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public long? EstablishedYear { get; set; } = 0;

        [JsonProperty("isVatRegistered", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVatRegistered { get; set; } = false;

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; } = "";

        [JsonProperty("nature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Nature { get; set; } = "";

        [JsonProperty("phone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; } = "";

        [JsonProperty("sortcode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Sortcode { get; set; } = "";

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; } = "";

        [JsonProperty("vatNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? VatNumber { get; set; } = "";
    }
}