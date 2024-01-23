using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class ValidationFailedResponse : ErrorResponse, ISubResponseType
    {
        public ValidationFailedResponse() : base() { }

        public ValidationFailedResponse(List<string> errors, ResponseMessageStatus status = ResponseMessageStatus.Error, string message = "validation failed") : base(message, errors, status) { }
        
        [JsonIgnore]
        public new ResponseType DefaultResponseType => ResponseType.ValidationErrors;
    }
}
