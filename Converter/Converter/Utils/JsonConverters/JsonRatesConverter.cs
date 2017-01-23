using System;
using System.Collections.Generic;
using System.Globalization;
using Converter.Models.Json;
using Newtonsoft.Json;

namespace Converter.Utils.JsonConverters
{
    public class JsonRatesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JsonRates);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (JsonRates)value;

            writer.WriteStartObject();

            foreach (var item in obj.Fields)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteValue(item.Value);
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = existingValue as JsonRates ?? new JsonRates {Fields = new Dictionary<string, decimal>()};

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                var key = reader.Value.ToString();
                var value = reader.ReadAsString();
                decimal decimalValue;
                if(decimal.TryParse(value, NumberStyles.Any, new CultureInfo("en-US"), out decimalValue) == false) 
                    throw new FormatException($"The value {value } cannot be converted to an decimal");

                obj.Fields.Add(key, decimalValue);
            }

            return obj;
        }
    }
}
