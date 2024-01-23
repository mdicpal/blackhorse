using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponseMessageStatus
    {
        [EnumMember(Value = "Success")]
        Success,
        [EnumMember(Value = "Error")]
        Error
    }
}
