using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CommunicationResponseTypes
    {
        [EnumMember (Value = "SendSmsToCustomer")]
        SendSmsToCustomer,
        [EnumMember (Value = "SendPayoutPendingPdfToDealer")]
        SendPayoutPendingPdfToDealer,
    }
}