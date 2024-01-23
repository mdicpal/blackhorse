using System;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Extensions
{
    public static class Serialize
    {
        public static string ToJson(this object self) => JsonConvert.SerializeObject(self, AzureFunderCommonMessages.DotNet.Helpers.Converter.Settings);
        public static T? FromJson<T>(this string json) where T : Serialisable
        {
            try
            {
                var instance = JsonConvert.DeserializeObject<T>(json, AzureFunderCommonMessages.DotNet.Helpers.Converter.Settings);
                if (instance is null)
                {
                    throw new JsonException();
                }
                return instance;
            }
            catch
            {
                return CreateErrorInstance<T>();
            }
        }
        public static T? FromJson<T>(this BinaryData jsonData) where T : Serialisable
        {
            return jsonData.ToString().FromJson<T>();
        }

        public static T? CreateErrorInstance<T>() where T : Serialisable
        {
            T? deserializedObject = (T?)Activator.CreateInstance(typeof(T));
            if (deserializedObject is not null)
            {
                var name = typeof(T).Name;
                deserializedObject.IsValidJson = false;
                deserializedObject.Errors.Add($"invalid request, json unable to deserialise to {name}");
            }
            return deserializedObject;
        }
    }
}
