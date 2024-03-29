// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using AzureFunderCommonMessages.DotNet.Request;
//
//    var welcome = Welcome.FromJson(jsonString);
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AzureFunderCommonMessages.DotNet.Request
{
    public class BaseCommonRequest : CommonObject
    {
        public BaseCommonRequest()
        {
            Data = new();
        }
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("requestType", Required = Required.Always)]
        public RequestType RequestType { get; set; }

    }
}
