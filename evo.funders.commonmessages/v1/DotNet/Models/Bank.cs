using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Bank
    {
        public Bank()
        {
            Address = new Address();
        }

        [JsonProperty("accountName", Required = Required.AllowNull)]
        public string AccountName { get; set; } = "";

        [JsonProperty("accountNumber", Required = Required.AllowNull)]
        public string AccountNumber { get; set; } = "";

        [JsonProperty("address", Required = Required.AllowNull)]
        public Address Address { get; set; }

        [JsonProperty("bankName", Required = Required.AllowNull)]
        public string BankName { get; set; } = "";

        [JsonProperty("months", Required = Required.AllowNull)]
        public string Months { get; set; } = "";

        [JsonProperty("sortCode", Required = Required.AllowNull)]
        public string SortCode { get; set; } = "";

        [JsonProperty("years", Required = Required.AllowNull)]
        public string Years { get; set; } = "";
    }
}