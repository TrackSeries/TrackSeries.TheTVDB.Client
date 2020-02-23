using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Languages
{
    internal class LanguagesClient : BaseClient, ILanguagesClient
    {
        private readonly TVDBContext _context;

        internal LanguagesClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
            _context = context;
        }

        public async Task<TVDBResponse<List<Language>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<List<Language>>>("/languages", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<Language>>($"/languages/{languageId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task SetAsync(string languageAbbreviation, CancellationToken cancellationToken = default)
        {
            //TODO Check if the provided language is valid getting the list of languages 
            // and caching the list to avoid going to the server everytime we want to change the language
            _context.Language = languageAbbreviation;
            return Task.CompletedTask;
        }

        public Task SetAsync(Language language, CancellationToken cancellationToken = default)
        {
            return SetAsync(language.Abbreviation);
        }
    }
}
