using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Search
{
    internal class SearchClient : BaseClient, ISearchClient
    {
        private readonly TVDBClientOptions _options;

        public SearchClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
            _options = options.Value;
        }

        public Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesAsync(string value, SearchParameter parameterKey, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(value, parameterKey.ToString(), cancellationToken);
        }

        public async Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesAsync(string value, string parameterKey, CancellationToken cancellationToken = default)
        {
            var url = $"/search/series?{parameterKey.ToPascalCase()}={WebUtility.UrlEncode(value)}";
            var response = await GetJsonAsync<TVDBResponse<List<SeriesSearchResult>>>(url, cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages)
            {
                foreach (var result in response.Data)
                {
                    result.Image = ImageConverter.CheckAndConvertToCompleteUrl(result.Image);
                    result.Poster = ImageConverter.CheckAndConvertToCompleteUrl(result.Poster);
                    result.Banner = ImageConverter.CheckAndConvertToCompleteUrl(result.Banner);
                }
            }

            return response;
        }

        public Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(imdbId, SearchParameter.ImdbId, cancellationToken);
        }

        public Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(name, SearchParameter.Name, cancellationToken);
        }

        public Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(slug, SearchParameter.Slug, cancellationToken);
        }

        public Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByZap2ItIdAsync(string zap2ItId, CancellationToken cancellationToken = default)
        {
            return SearchSeriesAsync(zap2ItId, SearchParameter.Zap2itId, cancellationToken);
        }
    }
}
