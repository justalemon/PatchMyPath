using Newtonsoft.Json;
using PatchMyPath.Config;
using System;
using System.Globalization;

namespace PatchMyPath
{
    public class InstallConverter : JsonConverter<Install>
    {
        public override Install ReadJson(JsonReader reader, Type objectType, Install existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new Install((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, Install value, JsonSerializer serializer)
        {
            writer.WriteValue(value.GamePath);
        }
    }

    public class CultureConverter : JsonConverter<CultureInfo>
    {
        public override CultureInfo ReadJson(JsonReader reader, Type objectType, CultureInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new CultureInfo((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, CultureInfo value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Name);
        }
    }
}
