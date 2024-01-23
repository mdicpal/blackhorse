using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Types;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class FunderErrors : ErrorResponse, ISubResponseType
    {
        public new ResponseType DefaultResponseType => ResponseType.FunderErrors;
        public FunderErrors() : base() { }

        public FunderErrors(List<string> errors, string message = "funder returned errors") : base(message, errors, ResponseMessageStatus.Error) { }
    }
}
