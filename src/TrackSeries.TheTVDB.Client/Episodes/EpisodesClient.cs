using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Episodes
{
    internal class EpisodesClient : IEpisodesClient
    {
        private readonly HttpClient _client;

        public EpisodesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TVDBResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<EpisodeRecord>>($"/episodes/{episodeId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
