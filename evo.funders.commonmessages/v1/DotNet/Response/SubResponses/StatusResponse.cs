using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class StatusResponse : SubResponse, ISubResponseType
    {
        public StatusResponse()
        { }

        public StatusResponse(StatusResponseType applicationStatus, string message) : base(message, ResponseMessageStatus.Success)
        {
            ApplicationStatus = applicationStatus;
        }

        [JsonProperty("applicationStatus")]
        public StatusResponseType ApplicationStatus { get; set; }

        [JsonProperty("payoutStatus")]
        public PayoutStatus? PayoutStatus { get; set; }

        [JsonProperty("conditions")]
        public List<string> Conditions {get; set;} = new();

        [JsonProperty("messages")]
        public List<string> Messages {get; set;} = new();

        [JsonProperty("advance")]
        public double? Advance {get; set;}

        [JsonProperty("term")]
        public int? Term {get; set;}

        [JsonProperty("flatRate")]
        public double? FlatRate {get; set;}

        [JsonProperty("apr")]
        public double? Apr {get; set;}

        [JsonProperty("firstPayment")]
        public double? FirstPayment {get; set;}

        [JsonProperty("regularPayment")]
        public double? RegularPayment {get; set;}

        [JsonProperty("finalPayment")]
        public double? FinalPayment {get; set;}

        [JsonProperty("balloonValue")]
        public double? BalloonValue {get; set;}

        [JsonProperty("snags")]
        public List<string> Snags { get; set; } = new();
        
        [JsonProperty("upfrontFee")]
        public double? UpfrontFee { get; set; }

        [JsonProperty("tier")]
        public string? Tier { get; set; }
        
        [JsonProperty("expiryDate")]
        public string? ExpiryDate { get; set; }
        
        [JsonProperty("totalAmountRepayable")]
        public double? TotalAmountRepayable { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.StatusResponse;
    }
}
