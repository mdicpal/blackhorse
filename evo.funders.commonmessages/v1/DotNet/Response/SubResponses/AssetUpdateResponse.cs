using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class AssetUpdateResponse: SubResponse, ISubResponseType
    {
        public AssetUpdateResponse() : base("Asset Updated", ResponseMessageStatus.Success) { }
        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.AssetUpdatedResponse;
    }
}
