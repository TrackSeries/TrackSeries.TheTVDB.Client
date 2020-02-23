﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TrackSeries.TheTVDB.Client;

namespace BasicTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddLogging(configure =>
            {
                configure.AddConsole();
            });

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(assembly: typeof(Program).Assembly)
                .Build();

            services.AddTVDBClient(options =>
            {
                options.ApiKey = configuration["ApiKey"];
            });

            var provider = services.BuildServiceProvider();

            var tvdb = provider.GetService<ITVDBClient>();

            var search = await tvdb.Search.SearchSeriesByNameAsync("sheldon");
            search = await tvdb.Search.SearchSeriesBySlugAsync("young-sheldon");

            var show = await tvdb.Series.GetAsync(328724);
            show = await tvdb.Series.GetAsync(328724, keys =>
            {
                keys
                .IncludeAdded()
                .IncludeSeriesName()
                .IncludeBanner()
                .IncludeId()
                .IncludeAirsDayOfWeek();
            });

            var episode = await tvdb.Episodes.GetAsync(6794892);

            await tvdb.Authentication.AuthenticateAsync(configuration["Username"], configuration["UserKey"]);

            var rating = await tvdb.Users.AddSeriesRatingAsync(328724, 10);
            //var favorite = await tvdb.Users.AddToFavoritesAsync(328724);

            // Game of Thrones with information in English
            var gameofthrones = await tvdb.Series.GetAsync(121361);

            var languages = await tvdb.Languages.GetAllAsync();
            var spanish = languages.Data.FirstOrDefault(l => l.Abbreviation == "es");

            // Game of Thrones with information in Spanish
            await tvdb.Languages.SetAsync(spanish);
            gameofthrones = await tvdb.Series.GetAsync(121361);

        }
    }
}
