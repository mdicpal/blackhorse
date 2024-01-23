using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class FinancialStatus
    {
        [JsonProperty("affordability", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string? Affordability { get; set; } = "";

        [JsonProperty("affordabilityMonthlyMortgageRentContribution", Required = Required.Default,
            NullValueHandling = NullValueHandling.Include)]
        public long? AffordabilityMonthlyMortgageRentContribution { get; set; } = 0;

        [JsonProperty("affordabilityMonthlyOtherExpenditure", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public long? AffordabilityMonthlyOtherExpenditure { get; set; } = 0;

        [JsonProperty("affordabilityReason", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string? AffordabilityReason { get; set; } = "";

        [JsonProperty("annualGrossIncome", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public long? AnnualGrossIncome { get; set; } = 0;

        [JsonProperty("netMonthlyIncome", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public double? NetMonthlyIncome { get; set; } = 0;
    }
}