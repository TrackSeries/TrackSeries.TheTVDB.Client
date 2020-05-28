using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Episodes
{
    internal class EpisodesClient : BaseClient, IEpisodesClient
    {
        private readonly TVDBClientOptions _options;

        public EpisodesClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
            _options = options.Value;
        }

        public async Task<TVDBResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            var response = await GetJsonAsync<TVDBResponse<EpisodeRecord>>($"/episodes/{episodeId}", cancellationToken)
                .ConfigureAwait(false);

            if (_options.ReturnCompleteUrlForImages && response.Data != null)
            {

                response.Data.Filename = ImageConverter.CheckAndConvertToCompleteUrl(response.Data.Filename);
            }

            return response;
        }
    }
}
