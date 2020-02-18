using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Authentication
{
    internal class AuthenticationClient : IAuthenticationClient
    {
        private readonly HttpClient _client;
        private readonly TVDBTokenAccessor _tokenAccessor;
        private readonly TVDBClientOptions _options;

        public AuthenticationClient(HttpClient client, TVDBTokenAccessor tokenAccessor, IOptions<TVDBClientOptions> options)
        {
            _client = client;
            _tokenAccessor = tokenAccessor;
            _options = options.Value;
        }

        public async Task AuthenticateAsync(string username, string userKey, CancellationToken cancellationToken = default)
        {
            var auth = new AuthData
            {
                ApiKey = _options.ApiKey,
                UserKey = userKey,
                Username = username
            };

            var data = await _client.PostJsonAsync<TokenResponse>("/login", auth, cancellationToken).ConfigureAwait(false);

            _tokenAccessor.Token = data.Token;
        }

        public async Task RefreshTokenAsync(CancellationToken cancellationToken = default)
        {
            var data = await _client.GetJsonAsync<TokenResponse>("/refresh_token", cancellationToken).ConfigureAwait(false);
            _tokenAccessor.Token = data.Token;
        }
    }
}