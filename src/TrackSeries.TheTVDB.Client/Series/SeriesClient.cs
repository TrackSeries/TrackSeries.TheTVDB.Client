using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Episodes;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Series
{
    internal class SeriesClient : BaseClient, ISeriesClient
    {
        private readonly TVDBClientOptions _options;

        public SeriesClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
            _options = options.Value;
        }

        public async Task<TVDBResponse<List<Actor>>> GetActorsAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<List<Actor>>>($"/series/{seriesId}/actors", cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                foreach (var actor in response.Data)
                {
                    actor.Image = ImageConverter.CheckAndConvertToCompleteUrl(actor.Image);
                }
            }

            return response;

        }

        public async Task<TVDBResponse<Serie>> GetAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<Serie>>($"/series/{seriesId}").ConfigureAwait(false);

            if(_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                response.Data.Banner = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.Banner);
                response.Data.Poster = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.Poster);
                response.Data.FanArt = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.FanArt);
            }

            return response;
        }

        public async Task<TVDBResponse<Serie>> GetAsync(int seriesId, Action<SerieKeys> configureKeys, CancellationToken cancellationToken = default)
        {
            var keys = new SerieKeys();
            configureKeys(keys);
            var response = await GetJsonAsync<TVDBResponse<Serie>>($"/series/{seriesId}/filter?keys={keys}", cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                response.Data.Banner = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.Banner);
                response.Data.Poster = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.Poster);
                response.Data.FanArt = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.FanArt);
            }

            return response;
        }

        public async Task<TVDBResponse<List<EpisodeRecord>>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<List<EpisodeRecord>>>($"/series/{seriesId}/episodes?page={Math.Max(page, 1)}", cancellationToken).ConfigureAwait(false);

            if(_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                foreach (var episode in response.Data)
                {
                    episode.Filename = ImageConverter.CheckAndConvertToCompleteUrl(episode.Filename);
                }
            }

            return response;
        }

        public async Task<TVDBResponse<List<EpisodeRecord>>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<List<EpisodeRecord>>>($"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                foreach (var episode in response.Data)
                {
                    episode.Filename = ImageConverter.CheckAndConvertToCompleteUrl(episode.Filename);
                }
            }

            return response;
        }

        public async Task<TVDBResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<EpisodesSummary>>($"/series/{seriesId}/episodes/summary", cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDictionary<string, IEnumerable<string>>> GetHeadersAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            var response = await SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/series/{seriesId}"), cancellationToken);
            return response.Headers.ToDictionary(h => h.Key, x => x.Value);
        }

        public async Task<TVDBResponse<List<Image>>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken = default)
        {
           var response = await GetJsonAsync<TVDBResponse<List<Image>>>($"/series/{seriesId}/images/query?{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                foreach (var image in response.Data)
                {
                    image.FileName = ImageConverter.CheckAndConvertToCompleteUrl(image.FileName);
                }
            }

            return response;
        }

        public async Task<TVDBResponse<List<Image>>> GetImagesAsync(int seriesId, ImagesQueryAlternative query, CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<List<Image>>>($"/series/{seriesId}/images/query?{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {
                foreach (var image in response.Data)
                {
                    image.FileName = ImageConverter.CheckAndConvertToCompleteUrl(image.FileName);
                }
            }

            return response;
        }

        public async Task<TVDBResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<ImagesSummary>>($"/series/{seriesId}/images", cancellationToken).ConfigureAwait(false);
        }
    }
}
