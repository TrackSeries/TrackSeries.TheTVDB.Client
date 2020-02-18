using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackSeries.TheTVDB.Client.Serializer
{
    public class StringToNullableIntegerConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt32(out var value))
                {
                    return value;
                }
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                if (int.TryParse(reader.GetString(), out var value))
                {
                    return value;
                }
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
