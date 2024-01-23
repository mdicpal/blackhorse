using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response.SubResponses
{
    public class InvoiceAddressResponse : SubResponse, ISubResponseType
    {
        
        public InvoiceAddressResponse(string addressReference, string funderCode) : base($"{funderCode} have sent an address to use for the invoice")
        {
            AddressReference = addressReference;
        }
        
        [JsonProperty("addressReference")]
        public string AddressReference { get; set; }
        
        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.InvoiceAddressResponse;
    }
}