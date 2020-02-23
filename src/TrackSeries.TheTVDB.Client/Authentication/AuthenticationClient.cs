using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace TrackSeries.TheTVDB.Client.Authentication
{
    internal class AuthenticationClient : BaseClient, IAuthenticationClient
    {
        private readonly TVDBClientOptions _options;
        private readonly TVDBContext _context;

        public AuthenticationClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
            _options = options.Value;
            _context = context;
        }

        public async Task AuthenticateAsync(string username, string userKey, CancellationToken cancellationToken = default)
        {
            var auth = new AuthData
            {
                ApiKey = _options.ApiKey,
                UserKey = userKey,
                Username = username
            };

            var data = await PostJsonAsync<TokenResponse>("/login", auth, cancellationToken).ConfigureAwait(false);
            _context.UpdateTokenWithUserData(data.Token, userKey, username);
        }

        public void LogoutCurrentUser()
        {
            _context.RemoveCurrentUser();
        }

        public async Task RefreshTokenAsync(CancellationToken cancellationToken = default)
        {
            var data = await GetJsonAsync<TokenResponse>("/refresh_token", cancellationToken).ConfigureAwait(false);
            _context.UpdateToken(data.Token);
        }
    }
}