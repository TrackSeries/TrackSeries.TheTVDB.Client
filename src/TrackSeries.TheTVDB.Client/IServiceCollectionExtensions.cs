using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using TrackSeries.TheTVDB.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTVDBClient(this IServiceCollection services, Action<TVDBClientOptions> configureOptions)
        {
            services.AddOptions();
            services.Configure(configureOptions);

            services.TryAddSingleton<TVDBContext>();

            services.AddHttpClient<ITVDBClient, TVDBClient>((provider, client) =>
            {
                var options = provider.GetService<IOptions<TVDBClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.thetvdb.v3.0.0");
            })
            .AddPolicyHandler(GetRetryPolicy());

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<TVDBClientOptions>, TVDBClientPostConfigureOptions>());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5);

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(delay);
        }
    }
}