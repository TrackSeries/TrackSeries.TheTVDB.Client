using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client;
using TrackSeries.TheTVDB.Client.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTVDBClient(this IServiceCollection services, Action<TVDBClientOptions> configureOptions)
        {
            services.AddOptions();

            services.Configure(configureOptions);

            services.AddHttpClient<ITVDBClient, TVDBClient>((provider, client) =>
             {
                 var options = provider.GetService<IOptions<TVDBClientOptions>>().Value;
                 client.BaseAddress = new Uri(options.BaseAddress);
             })
            .AddHttpMessageHandler<TVDBDelegatingHandler>();

            services.AddScoped<TVDBTokenAccessor>();
            services.AddTransient<TVDBDelegatingHandler>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<TVDBClientOptions>, TVDBClientPostConfigureOptions>());

            return services;
        }
    }
}
