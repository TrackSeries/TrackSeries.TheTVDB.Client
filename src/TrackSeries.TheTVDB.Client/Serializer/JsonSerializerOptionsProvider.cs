using System.Text.Json;

namespace TrackSeries.TheTVDB.Client.Serializer
{
    internal static class JsonSerializerOptionsProvider
    {
        private static JsonSerializerOptions _options;

        public static JsonSerializerOptions Options
        {
            get 
            {
                if(_options == null)
                {
                    _options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true,
                    };

                    _options.Converters.Add(new StringToNullableIntegerConverter());
                }

                return _options;
            }
        }

    }
}
