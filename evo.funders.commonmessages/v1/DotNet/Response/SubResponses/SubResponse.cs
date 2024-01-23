using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public abstract class SubResponse
    {
        protected SubResponse(string message = "Blank response created", ResponseMessageStatus status = ResponseMessageStatus.Success)
        {
            Message = message;
            Status = status;
        }

        [JsonProperty("status")]
        public ResponseMessageStatus Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
