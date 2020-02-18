using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Search
{
    internal class SearchClient : ISearchClient
    {
        private readonly HttpClient _client;

        public SearchClient(HttpClient client)
        {
            _client = client;
        }

        public Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesAsync(string value, SearchParameter parameterKey, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(value, parameterKey.ToString(), cancellationToken);
        }

        public async Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesAsync(string value, string parameterKey, CancellationToken cancellationToken = default)
        {
            var url = $"/search/series?{parameterKey.ToPascalCase()}={WebUtility.UrlEncode(value)}";
            return await _client.GetJsonAsync<TVDBResponse<SeriesSearchResult[]>>(url, cancellationToken).ConfigureAwait(false);
        }

        public Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(imdbId, SearchParameter.ImdbId, cancellationToken);
        }

        public Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(name, SearchParameter.Name, cancellationToken);
        }

        public Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(slug, SearchParameter.Slug, cancellationToken);
        }

        public Task<TVDBResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(string zap2ItId, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(zap2ItId, SearchParameter.Zap2itId, cancellationToken);
        }
    }
}
