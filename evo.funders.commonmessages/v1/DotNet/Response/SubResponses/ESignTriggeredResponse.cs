using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class ESignTriggeredResponse : SubResponse, ISubResponseType
    {
        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.ESignTriggeredResponse;
    }
}
