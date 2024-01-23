using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class ApplicationRequestData
    {
        public ApplicationRequestData()
        {
            Applicants = new();
            Asset = new();
            Dealer = new();
            DispersalOptions = new();
            FunderFees = new();
            Quote = new();
        }
        [JsonProperty("applicants", Required = Required.Always)]
        public List<Applicant>? Applicants { get; set; }

        [JsonProperty("asset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Asset? Asset { get; set; }

        [JsonProperty("dealer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dealer? Dealer { get; set; }

        [JsonProperty("dispersalOptions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<DispersalOption>? DispersalOptions { get; set; }

        [JsonProperty("funderFees", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<FunderReference>? FunderFees { get; set; }

        [JsonProperty("quote", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Quote? Quote { get; set; }
    }
}
