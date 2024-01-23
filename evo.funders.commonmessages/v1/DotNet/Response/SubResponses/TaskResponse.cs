using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class TaskResponse : SubResponse, ISubResponseType
    {
        [JsonProperty("tasks", Required = Required.Always)]
        public List<TaskModel> Tasks { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.TaskResponse;
    }
}
