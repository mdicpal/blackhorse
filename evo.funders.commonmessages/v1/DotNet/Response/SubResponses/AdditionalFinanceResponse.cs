using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class AdditionalFinanceResponse : SubResponse, ISubResponseType
    {
        [JsonProperty("financeItems")]
        public List<AdditionalFinanceItem> FinanceItems { get; set; } = new();

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.AdditionalFinanceResponse;
    }
}
