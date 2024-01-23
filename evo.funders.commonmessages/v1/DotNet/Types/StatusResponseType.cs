using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusResponseType
    {
        [EnumMember(Value = "StartedOrchestration")]
        StartedOrchestration,
        [EnumMember(Value = "FunderResponseReceived")]
        FunderResponseReceived,
        [EnumMember(Value = "ApplicationWithFunder")]
        ApplicationWithFunder,
        [EnumMember(Value = "NoChange")]
        NoChange,
        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "Accepted")]
        Accepted,
        [EnumMember(Value = "CreditLimitAccepted")]
        CreditLimitAccepted,
        [EnumMember(Value = "ConditionalAccept")]
        ConditionalAccept,
        [EnumMember(Value = "Referred")]
        Referred,
        [EnumMember(Value = "Declined")]
        Declined,
        [EnumMember(Value = "CreditLimitDeclined")]
        CreditLimitDeclined,
        [EnumMember(Value = "Cancelled")]
        Cancelled,
        [EnumMember(Value = "NTU")]
        NTU,
        [EnumMember(Value = "Error")]
        Error,
        [EnumMember(Value = "ReceivedOK")]
        ReceivedOK,
        [EnumMember(Value = "MoreInfo")]
        MoreInfo,
        [EnumMember(Value = "DocsReceived")]
        DocsReceived,
        [EnumMember(Value = "PaidOut")]
        PaidOut,
        [EnumMember(Value = "ResubmitRequired")]
        ResubmitRequired,
        [EnumMember(Value = "NotSent")]
        NotSent,
        [EnumMember(Value = "PaidOutError")]
        PaidOutError,
        [EnumMember(Value = "CriticalError")]
        CriticalError,
        [EnumMember(Value = "PayoutPending")]
        PayoutPending,
        [EnumMember(Value = "PayoutWithFunder")]
        PayoutWithFunder,
        [EnumMember(Value = "PayoutReceived")]
        PayoutReceived,
        [EnumMember(Value = "PreApproved")]
        PreApproved,
        [EnumMember(Value = "ESignCompleted")]
        ESignCompleted,
        [EnumMember(Value = "AmendmentWithFunder")]
        AmendmentWithFunder,
        [EnumMember(Value = "Expired")]
        Expired
    }
}
