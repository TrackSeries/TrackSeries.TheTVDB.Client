using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TrackSeries.TheTVDB.Client
{
    internal static class UrlExtensions
    {
        internal static string ToQueryParams<T>(this T obj)
        {
            var parts = new List<string>();

            foreach (var propertyInfo in typeof(T).GetTypeInfo().DeclaredProperties.OrderBy(info => info.Name))
            {
                var value = propertyInfo.GetValue(obj);

                if (value != null)
                {
                    parts.Add($"{propertyInfo.Name.ToPascalCase()}={Uri.EscapeDataString(value.ToString())}");
                }
            }

            return string.Join("&", parts);
        }

        internal static string ToPascalCase(this string name)
        {
            var array = name.ToCharArray();

            array[0] = char.ToLower(array[0]);

            return new string(array);
        }

        internal static string ToPascalCase(this Enum @enum)
        {
            return @enum.ToString().ToPascalCase();
        }
    }
}
