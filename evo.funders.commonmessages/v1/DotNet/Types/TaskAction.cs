using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet.Types
{
    
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskAction
    {
        [EnumMember(Value = "Created")]
        Created,
        [EnumMember(Value = "Updated")]
        Updated,
        [EnumMember(Value = "Completed")]
        Completed,
        [EnumMember(Value = "Deleted")]
        Deleted,
        [EnumMember(Value = "CommentCreated")]
        CommentCreated,
        [EnumMember(Value = "DocumentCreated")]
        DocumentCreated
    }
}