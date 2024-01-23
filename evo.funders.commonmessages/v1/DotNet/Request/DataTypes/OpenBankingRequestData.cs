using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class OpenBankingRequestData
    {
        
        [JsonProperty("funderApplicationId", Required = Required.Always)]
        public string FunderApplicationId { get; set; }
    }
}