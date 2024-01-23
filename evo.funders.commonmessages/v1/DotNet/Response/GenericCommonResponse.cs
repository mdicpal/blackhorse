using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response
{
    public class CommonResponse<T> : CommonResponse where T : SubResponse, ISubResponseType, new()
    {
        [JsonProperty("response")]
        public new T SubResponse { get; set; } = new();
        
        public CommonResponse() : base()
        {
            ResponseType = SubResponse.DefaultResponseType;
        }

        public CommonResponse(BaseCommonRequest request) : base(request)
        {
            ResponseType = SubResponse.DefaultResponseType;
        }
    }
}