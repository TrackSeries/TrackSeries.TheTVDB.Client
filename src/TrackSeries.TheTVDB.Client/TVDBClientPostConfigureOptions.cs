using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace TrackSeries.TheTVDB.Client
{
    internal class TVDBClientPostConfigureOptions : IPostConfigureOptions<TVDBClientOptions>
    {
        private readonly IConfiguration _configuration;

        public TVDBClientPostConfigureOptions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PostConfigure(string name, TVDBClientOptions options)
        {
            Initialize(options);

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

        private void Initialize(TVDBClientOptions options)
        {
            //If there's no ApiKey let's try to read values from Configuration
            if (string.IsNullOrEmpty(options.ApiKey))
            {
                var newOptions = _configuration.GetSection(nameof(TVDBClientOptions)).Get<TVDBClientOptions>();
                options.ApiKey = newOptions.ApiKey;
                options.AcceptedLanguage = newOptions.AcceptedLanguage;
                options.ReturnCompleteUrlForImages = newOptions.ReturnCompleteUrlForImages;
                options.ShareContextBetweenClients = newOptions.ShareContextBetweenClients;
            }
        }
    }
}