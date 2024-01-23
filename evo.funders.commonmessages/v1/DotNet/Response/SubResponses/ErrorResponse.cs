using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class ErrorResponse : SubResponse, ISubResponseType
    {
        public ErrorResponse() : base("error", ResponseMessageStatus.Error)
        {
            Errors = new();
        }

        public ErrorResponse(string message, List<string> errors, ResponseMessageStatus status = ResponseMessageStatus.Error) : base(message, status)
        {
            Errors = errors;
        }

        [JsonProperty("errors")]
        public new List<string> Errors { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.Error;
    }
}
