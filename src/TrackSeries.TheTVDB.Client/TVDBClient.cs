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
        public TVDBClient(HttpClient client, TVDBTokenAccessor tokenAccessor, IOptions<TVDBClientOptions> options)
        {
            Series = new SeriesClient(client);
            Search = new SearchClient(client);
            Episodes = new EpisodesClient(client);
            Updates = new UpdatesClient(client);
            Languages = new LanguagesClient(client);
            Users = new UsersClient(client);
            Authentication = new AuthenticationClient(client, tokenAccessor, options);
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
