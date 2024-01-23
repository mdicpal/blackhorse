using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class AdditionalDataObject
    {
        public AdditionalDataObject()
        {
            AdditionalData = new();
        }

        [JsonProperty("additionalData", Required = Required.Always)]
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}