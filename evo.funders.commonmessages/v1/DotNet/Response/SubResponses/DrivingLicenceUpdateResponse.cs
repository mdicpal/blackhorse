using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response.DataTypes;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class DrivingLicenceUpdateResponse: SubResponse, ISubResponseType
    {
        public DrivingLicenceUpdateResponse() : base("Driving Licence Updated", ResponseMessageStatus.Success) { }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.DrivingLicenceUpdateResponse;
    }
}
