using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzureFunderCommonMessages.DotNet.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PayoutStatus
    {
        [EnumMember(Value = "Snagged")]
        Snagged,

        [EnumMember(Value = "With Funder")]
        WithFunder,

        [EnumMember(Value = "Checking")]
        Checking,

        [EnumMember(Value = "Paid Out")]
        PaidOut,

        [EnumMember(Value = "Declined")]
        Declined,
    }
}