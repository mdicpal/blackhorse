using System;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class Quote
    {
        public Quote()
        {
            QuoteDate = new DateTimeOffset();
        }

        [JsonProperty("annualMileage", Required = Required.Default,
            NullValueHandling = NullValueHandling.Include)]
        public long? AnnualMileage { get; set; }

        [JsonProperty("isDistanceSold", Required = Required.Always)]
        public bool IsDistanceSold { get; set; }

        [JsonProperty("apr", Required = Required.Always)]
        public double Apr { get; set; }

        [JsonProperty("balloonValue", Required = Required.Always)]
        public double BalloonValue { get; set; }

        [JsonProperty("deposit", Required = Required.Always)]
        public double Deposit { get; set; }

        [JsonProperty("financeType", Required = Required.Always)]
        public string? FinanceType { get; set; } = "";

        [JsonProperty("flatRate", Required = Required.Always)]
        public double FlatRate { get; set; }

        [JsonProperty("isBusinessQuote", Required = Required.Always)]
        public bool IsBusinessQuote { get; set; }

        [JsonProperty("isVehicleVatQualifying", Required = Required.Always)]
        public bool IsVehicleVatQualifying { get; set; } = true;

        [JsonProperty("partExchange", Required = Required.Always)]
        public double PartExchange { get; set; }

        [JsonProperty("quoteDate", Required = Required.Always)]
        public DateTimeOffset QuoteDate { get; set; }

        [JsonProperty("settlement", Required = Required.Always)]
        public double Settlement { get; set; }

        [JsonProperty("term", Required = Required.Always)]
        public long Term { get; set; }

        [JsonProperty("vehicleCashPrice", Required = Required.Always)]
        public double VehicleCashPrice { get; set; }

        [JsonProperty("settlementMonthlyAmount")]
        public double SettlementMonthlyAmount  { get; set; }

        [JsonProperty("equifaxCountyCourtJudgments")]
        public int EquifaxCountyCourtJudgments  { get; set; }

        [JsonProperty("equifaxDefaults")]
        public int EquifaxDefaults  { get; set; }

        [JsonProperty("experianCountyCourtJudgments")]
        public int ExperianCountyCourtJudgments { get; set; }

        [JsonProperty("experianDefaults")]
        public int ExperianDefaults { get; set; }

        public double GetAdvance()
        {
            return VehicleCashPrice + Settlement - Deposit - PartExchange;
        }

        public bool IsSettlementMonthlyAmountSet() => SettlementMonthlyAmount > 0;
    }
}