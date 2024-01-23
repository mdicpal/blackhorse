using System;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Response
{
    public class Data
    {
        [JsonProperty("type")]
        public DirectionType Direction { get; set; }

        [JsonProperty("dataFormat")]
        public DataFormatType DataFormat { get; set; } = DataFormatType.JSON;

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [JsonProperty("rawData")]
        public string? RawRequestResponse { get; set; }
    }
}