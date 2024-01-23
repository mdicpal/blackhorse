using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.DataTypes
{
    public class BankDetailsUpdateResponse: SubResponse, ISubResponseType
    {
        public BankDetailsUpdateResponse() : base("Bank Details Updated", ResponseMessageStatus.Success) { }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.BankDetailsUpdatedResponse;
    }
}
