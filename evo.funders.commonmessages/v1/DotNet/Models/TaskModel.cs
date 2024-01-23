using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Models
{
    public class TaskModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }
        
        [JsonProperty("taskAction", Required = Required.Always)]
        public TaskAction TaskAction { get; set; }

        [JsonProperty("label", Required = Required.Always)]
        public string Label { get; set; }
        
        [JsonProperty("description", Required = Required.AllowNull)]
        public string? Description { get; set; } = "";
        
        [JsonProperty("comments", Required = Required.AllowNull)]
        public List<string> Comments { get; set; }
        
        [JsonProperty("requiredDocuments", Required = Required.AllowNull)]
        public List<DocumentRequest> RequiredDocuments { get; set; }

    }
}