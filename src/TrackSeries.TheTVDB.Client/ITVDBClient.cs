using TrackSeries.TheTVDB.Client.Authentication;
using TrackSeries.TheTVDB.Client.Episodes;
using TrackSeries.TheTVDB.Client.Languages;
using TrackSeries.TheTVDB.Client.Search;
using TrackSeries.TheTVDB.Client.Series;
using TrackSeries.TheTVDB.Client.Updates;
using TrackSeries.TheTVDB.Client.Users;

namespace TrackSeries.TheTVDB.Client
{
    public interface ITVDBClient
    {
        IAuthenticationClient Authentication { get; }
        IEpisodesClient Episodes { get; }
        ILanguagesClient Languages { get; }
        ISearchClient Search { get; }
        ISeriesClient Series { get; }
        IUpdatesClient Updates { get; }
        IUsersClient Users { get; }
    }
}