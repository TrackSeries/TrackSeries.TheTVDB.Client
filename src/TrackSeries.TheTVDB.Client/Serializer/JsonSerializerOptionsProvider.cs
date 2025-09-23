using System;
using System.Text.Json;

namespace TrackSeries.TheTVDB.Client.Serializer;

internal static class JsonSerializerOptionsProvider
{
    private static readonly Lazy<JsonSerializerOptions> _options = new(() =>
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        options.Converters.Add(new StringToNullableIntegerConverter());
        return options;
    });

    public static JsonSerializerOptions Options => _options.Value;
}
