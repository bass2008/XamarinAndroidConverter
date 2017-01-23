using System.Collections.Generic;
using Converter.Utils.JsonConverters;
using Newtonsoft.Json;

namespace Converter.Models.Json
{
    [JsonConverter(typeof(JsonRatesConverter))]
    public class JsonRates
    {
        public Dictionary<string, decimal> Fields { get; set; }
    }
}
