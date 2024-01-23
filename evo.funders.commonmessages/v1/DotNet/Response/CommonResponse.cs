using System;
using System.Collections.Generic;
using AzureFunderCommonMessages.DotNet.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace AzureFunderCommonMessages.DotNet.Response
{
    public class CommonResponse : CommonObject
    {
        public CommonResponse()
        {
            RawRequestResponseData = new();
            SubResponse = new();
        }

        public CommonResponse(BaseCommonRequest request)
        {
            QuoteId = request.QuoteId;
            FunderReference = new();
            FunderCode = request.FunderCode;
            RawRequestResponseData = new();
            SubResponse = new();
        }

        [JsonProperty("funderReference")]
        public FunderReference? FunderReference { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [JsonProperty("rawData")]
        public List<Data> RawRequestResponseData { get; set; }

        [JsonProperty("responseType")]
        public ResponseType ResponseType { get; set; }

        [JsonProperty("response")]
        public object SubResponse { get; set; }

        public void AddRequestData(object data, DataFormatType format = DataFormatType.JSON)
        {
            AddData(data, format, DirectionType.REQUEST);
        }

        public void AddResponseData(object data, DataFormatType format = DataFormatType.JSON)
        {
            AddData(data, format, DirectionType.RESPONSE);
        }

        private void AddData(object data, DataFormatType format, DirectionType direction)
        {
            bool isDataString = data is string;
            RawRequestResponseData.Add(new()
            {
                DataFormat = format,
                Timestamp = DateTime.UtcNow,
                Direction = direction,
                RawRequestResponse = isDataString ? data.ToString() : JsonConvert.SerializeObject(
                    data,
                    Formatting.None,
                    JsonSerializerSettings()
                )
            });
        }

        private static JsonSerializerSettings JsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>
                {
                    new Newtonsoft.Json.Converters.StringEnumConverter()
                }
            };
        }

    }
}
