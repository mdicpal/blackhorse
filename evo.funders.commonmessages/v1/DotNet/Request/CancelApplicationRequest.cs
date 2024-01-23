using AzureFunderCommonMessages.DotNet.Request.DataTypes;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request
{
    public class CancelApplicationRequest : BaseCommonRequest
    {
        public CancelApplicationRequest()
        {
            Data = new CancelApplicationRequestData();
        }

        [JsonProperty("data", Required = Required.Always)]
        public new CancelApplicationRequestData Data { get; set; }
    }
}