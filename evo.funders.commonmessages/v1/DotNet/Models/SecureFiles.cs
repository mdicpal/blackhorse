using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class SecureFiles
    {
        [JsonProperty("filePath", Required = Required.Always)]
        public string FilePath { get; set; }
        
        [JsonProperty("containerName", Required = Required.Always)]
        public string ContainerName { get; set; }
        
        [JsonProperty("fileType")]
        public FileType? FileType { get; set; }
        
        [JsonProperty("taskId")]
        public string? TaskId { get; set; }
    }
}