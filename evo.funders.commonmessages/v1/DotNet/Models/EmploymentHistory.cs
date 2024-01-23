using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class EmploymentHistory
    {
        public EmploymentHistory()
        {
            Address = new Address();
        }

        [JsonProperty("phoneNumber", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? PhoneNumber { get; set; } = "";

        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Address? Address { get; set; }

        [JsonProperty("company", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Company { get; set; } = "";

        [JsonProperty("employmentStatus", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string? EmploymentStatus { get; set; } = "";

        [JsonProperty("employmentType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? EmploymentType { get; set; } = "";

        [JsonProperty("jobTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? JobTitle { get; set; } = "";

        [JsonProperty("monthsAtCompany", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public long? MonthsAtCompany { get; set; } = 0;

        [JsonProperty("occupationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? OccupationType { get; set; } = "";

        [JsonProperty("orderNumber", Required = Required.Always)]
        public long OrderNumber { get; set; }

        [JsonProperty("yearsAtCompany", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? YearsAtCompany { get; set; } = 0;
    }
}