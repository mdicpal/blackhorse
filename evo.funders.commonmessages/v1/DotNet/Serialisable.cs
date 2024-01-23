using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AzureFunderCommonMessages.DotNet
{
    public class Serialisable
    {

        public Serialisable()
        {
            Errors = new();
        }

        [JsonIgnore]
        public bool IsValid => Errors.Count == 0;

        [JsonIgnore]
        public bool IsValidJson { get; set; } = true;

        [JsonIgnore]
        public List<string> Errors { get; set; }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            Errors.Add(errorContext.Error.Message);
            errorContext.Handled = true;
        }

    }
}
