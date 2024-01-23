using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class GenericResponse : SubResponse, ISubResponseType
    {
        public GenericResponse() : base("Generic Response"){}
        public GenericResponse(string response, string message) : base(message, ResponseMessageStatus.Success)
        {
            Response = response;
        }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.GenericResponse;
    }
}