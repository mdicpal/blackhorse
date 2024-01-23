using AzureFunderCommonMessages.DotNet.Converter;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace AzureFunderCommonMessages.DotNet.Helpers
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            TypeNameHandling = TypeNameHandling.None,
            Formatting = Formatting.Indented,
            Converters =
            {
                EnumConverter<RequestType>.Singleton,
                EnumConverter<DataFormatType>.Singleton,
                EnumConverter<ResponseType>.Singleton,
                EnumConverter<StatusResponseType>.Singleton,
                EnumConverter<DirectionType>.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
