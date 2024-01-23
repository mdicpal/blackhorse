using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Request.DataTypes
{
    public class CancelApplicationRequestData
    {
        [JsonProperty("funderApplicationId", Required = Required.Default)]
        public string? FunderApplicationId { get; set; }
    }
}