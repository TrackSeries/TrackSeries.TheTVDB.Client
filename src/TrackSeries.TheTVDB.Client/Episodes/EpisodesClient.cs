using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Episodes
{
    internal class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
        }

        public async Task<TVDBResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<EpisodeRecord>>($"/episodes/{episodeId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
