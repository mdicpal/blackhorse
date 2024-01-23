using AzureFunderCommonMessages.DotNet.Models;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class DocumentUploadedData
    {
        [JsonProperty("files", Required = Required.Always)]
        public List<SecureFiles> Files { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("fromAddress")]
        public string FromAddress { get; set; }
        
        [JsonProperty("toAddresses")]
        public List<string> ToAddresses { get; set; }
    }
}