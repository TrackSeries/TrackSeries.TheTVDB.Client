using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Updates
{
    internal class UpdatesClient : IUpdatesClient
    {
        private readonly HttpClient _client;

        internal UpdatesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TVDBResponse<Update[]>> GetAsync(DateTime fromTime, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<Update[]>>($"/updated/query?fromTime={fromTime.ToUnixEpochTime()}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<Update[]>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<Update[]>>($"/updated/query?fromTime={fromTime.ToUnixEpochTime()}&toTime={toTime.ToUnixEpochTime()}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
