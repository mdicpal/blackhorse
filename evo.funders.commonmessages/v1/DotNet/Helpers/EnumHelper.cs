using AzureFunderCommonMessages.DotNet.Converter;
using AzureFunderCommonMessages.DotNet.Types;
using Newtonsoft.Json;

namespace AzureFunderCommonMessages.DotNet.Helpers
{
    public static class EnumHelper
    {
        public static object ValueToEnum<T>(string value)
        {
            try
            {
                return ParseEnumValue<T>(value);
            }
            catch
            {
                throw ThrowNotOneOfError<T>();
            }
        }
        private static object ParseEnumValue<T>(string value)
        {
            object enumValue = Enum.Parse(typeof(T), value);
            bool isDefined = Enum.IsDefined(typeof(T), enumValue);
            bool isNumber = int.TryParse(value, out _);
            bool isValidType = !isNumber;

            if (!isDefined || enumValue is null || !isValidType)
            {
                throw new JsonException();
            }
            return enumValue;
        }

        private static JsonException ThrowNotOneOfError<T>()
        {
            return GetEnumLabelException<T>();          
        }

        private static JsonException GetEnumLabelException<T>()
        {
            string[] allowed = Enum.GetNames(typeof(T));
            return InstantiateException<T>(allowed);
        }

        private static JsonException InstantiateException<T>(string[] allowed)
        {
            var name = typeof(T).Name;
            return new JsonException($"{name} not one of [{string.Join(", ", allowed)}]");
        }
    }
}
