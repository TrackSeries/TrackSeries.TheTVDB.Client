using System.Net.Http;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Authentication;
using TrackSeries.TheTVDB.Client.Episodes;
using TrackSeries.TheTVDB.Client.Languages;
using TrackSeries.TheTVDB.Client.Search;
using TrackSeries.TheTVDB.Client.Series;
using TrackSeries.TheTVDB.Client.Updates;
using TrackSeries.TheTVDB.Client.Users;

namespace TrackSeries.TheTVDB.Client
{
    public class TVDBClient : ITVDBClient
    {
        public TVDBClient(
            HttpClient client, IOptions<TVDBClientOptions> options)
        {
            var context = new TVDBContext();

            Series = new SeriesClient(client, options, context);
            Search = new SearchClient(client, options, context);
            Episodes = new EpisodesClient(client, options, context);
            Updates = new UpdatesClient(client, options, context);
            Languages = new LanguagesClient(client, options, context);
            Users = new UsersClient(client, options, context);
            Authentication = new AuthenticationClient(client, options, context);
        }

        public ISeriesClient Series { get; }
        public ISearchClient Search { get; }
        public IEpisodesClient Episodes { get; }
        public IUpdatesClient Updates { get; }
        public ILanguagesClient Languages { get; }
        public IUsersClient Users { get; }
        public IAuthenticationClient Authentication { get; }
    }
}
