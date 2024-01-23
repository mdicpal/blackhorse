using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class ServiceErrors : ErrorResponse, ISubResponseType
    {
        public ServiceErrors() : base() { }

        public ServiceErrors(string serviceName, List<string> errors) {
            Message = $"unable to connect to service ({serviceName})";
            Status = ResponseMessageStatus.Error;
            Errors = errors;
        }
        [JsonIgnore]
        public new ResponseType DefaultResponseType => ResponseType.ServiceErrors;
    }
}
