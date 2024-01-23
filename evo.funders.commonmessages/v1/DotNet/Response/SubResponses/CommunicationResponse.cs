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
    public class CommunicationResponse : SubResponse, ISubResponseType
    {
        public CommunicationResponse() : base("Message to be forwarded onwards")
        {
            
        }
        public CommunicationResponse(string communicationMessage, CommunicationResponseTypes type, string sender = "") : base("Message to be forwarded onwards")
        {
            CommunicationMessage = communicationMessage;
            Sender = sender;
            Type = type;
        }

        [JsonProperty("communicationMessage")]
        public string CommunicationMessage { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("type")]
        public CommunicationResponseTypes Type { get; set; }

        [JsonIgnore]
        public ResponseType DefaultResponseType => ResponseType.CommunicationResponse;
    }
}
