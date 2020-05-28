using System;

namespace TrackSeries.TheTVDB.Client
{
    internal static class ImageConverter
    {
        const string Schema = "https";
        const string Host = "artworks.thetvdb.com";
        const string Banners = "banners/";

        internal static string CheckAndConvertToCompleteUrl(string input)
        {
            if (string.IsNullOrEmpty(input) || input.StartsWith("http"))
            {
                return input;
            }

            if (!input.Contains(Banners))
            {
                input = Banners + input;
            }

            var builder = new UriBuilder(Schema, Host, -1, input);

            return builder.ToString();
        }
    }
}
