using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class DocumentRequest
    {
        [JsonProperty("fileType", Required = Required.Always)]
        public FileType FileType { get; set; }
        
        [JsonProperty("notes", Required = Required.AllowNull)]
        public string? Notes { get; set; }
    }
}