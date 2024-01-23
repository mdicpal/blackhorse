using System;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response
{
    public class CommonStatusResponse : CommonResponse
    {
        [JsonProperty("response")]
        public new StatusResponse SubResponse { get; set; }
    }
}
