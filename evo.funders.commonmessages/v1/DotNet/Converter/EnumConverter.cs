using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;
using AzureFunderCommonMessages.DotNet.Helpers;

namespace AzureFunderCommonMessages.DotNet.Converter
{
    public class EnumConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(T) || objectType == typeof(T?);

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            string value = serializer.Deserialize<string>(reader) ?? "";
            return EnumHelper.ValueToEnum<T>(value);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var typedValue = (T?)value;
            serializer.Serialize(writer, typedValue?.ToString());
        }

        public static readonly EnumConverter<T> Singleton = new();
    }
}
