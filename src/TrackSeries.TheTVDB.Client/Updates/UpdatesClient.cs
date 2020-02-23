using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Updates
{
    internal class UpdatesClient : BaseClient, IUpdatesClient
    {
        internal UpdatesClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
        }

        public async Task<TVDBResponse<List<Update>>> GetAsync(DateTime fromTime, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<List<Update>>>($"/updated/query?fromTime={fromTime.ToUnixEpochTime()}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<List<Update>>> GetAsync(DateTime fromTime, DateTime toTime, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<List<Update>>>($"/updated/query?fromTime={fromTime.ToUnixEpochTime()}&toTime={toTime.ToUnixEpochTime()}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
