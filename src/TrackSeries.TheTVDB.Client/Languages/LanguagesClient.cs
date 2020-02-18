using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Languages
{
    internal class LanguagesClient : ILanguagesClient
    {
        private readonly HttpClient _client;

        internal LanguagesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TVDBResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<Language[]>>("/languages", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<Language>>($"/languages/{languageId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
