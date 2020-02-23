using System;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Languages;

namespace TrackSeries.TheTVDB.Client
{
    internal class TVDBClientPostConfigureOptions : IPostConfigureOptions<TVDBClientOptions>
    {
        public void PostConfigure(string name, TVDBClientOptions options)
        {
            if (string.IsNullOrEmpty(options.ApiKey))
            {
                throw new InvalidOperationException("ApiKey must be configured.");
            }

            if(!Uri.TryCreate(options.BaseAddress, UriKind.Absolute, out var _))
            {
                options.BaseAddress = "http://api.thetvdb.com";
            }

            if (string.IsNullOrEmpty(options.AcceptedLanguage))
            {
                options.AcceptedLanguage = "en";
            }
        }
    }
}