using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CompanyType 
    {
        Unset = 0,
        [EnumMember(Value = "Limited")]
        Limted,
        [EnumMember(Value = "Partnership")]
        Partnership,
        [EnumMember(Value = "Sole Trader")]
        SoleTrader
    }
}