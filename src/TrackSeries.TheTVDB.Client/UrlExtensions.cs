using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackSeries.TheTVDB.Client;

internal static class UrlExtensions
{
    internal static string ToQueryParams<T>(this T obj)
    {
        var parts = new List<string>();

        // Use modern reflection - GetProperties() is more efficient than GetTypeInfo().DeclaredProperties
        foreach (var propertyInfo in typeof(T).GetProperties().OrderBy(info => info.Name))
        {
            var value = propertyInfo.GetValue(obj);

            if (value != null)
            {
                parts.Add($"{propertyInfo.Name.ToCamelCase()}={Uri.EscapeDataString(value.ToString())}");
            }
        }

        return string.Join("&", parts);
    }

    internal static string ToCamelCase(this string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length == 1)
            return name?.ToLowerInvariant() ?? string.Empty;

        // Use span for better performance in .NET 8/9
#if NET8_0_OR_GREATER
        return string.Create(name.Length, name, (span, value) =>
        {
            value.AsSpan().CopyTo(span);
            span[0] = char.ToLowerInvariant(span[0]);
        });
#else
        // Fallback for .NET Standard 2.0
        var array = name.ToCharArray();
        array[0] = char.ToLowerInvariant(array[0]);
        return new string(array);
#endif
    }

    internal static string ToCamelCase(this Enum @enum)
    {
        return @enum.ToString().ToCamelCase();
    }
}
