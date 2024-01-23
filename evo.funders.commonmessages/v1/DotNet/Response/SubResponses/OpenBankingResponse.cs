using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class OpenBankingResponse : SubResponse, ISubResponseType
    {
        public OpenBankingResponse() : base("Funder requested the customer complete an OBL")
        {
            
        }
        public OpenBankingResponse(Uri uri, string funderCode) : base(
            $"{funderCode} have requested the customer complete an OBL - please text link to customer", ResponseMessageStatus.Success)
        {
            Uri = uri;
        }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.OpenBankingResponse;
    }
}
