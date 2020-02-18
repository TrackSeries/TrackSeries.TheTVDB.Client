using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Authentication;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client
{
    internal class TVDBDelegatingHandler : DelegatingHandler
    {
        private readonly TVDBClientOptions _options;
        private readonly ILogger<TVDBDelegatingHandler> _logger;
        private readonly TVDBTokenAccessor _tokenAccessor;

        public TVDBDelegatingHandler(
            IOptions<TVDBClientOptions> options,
            ILogger<TVDBDelegatingHandler> logger,
            TVDBTokenAccessor tokenAccessor)
        {
            _options = options.Value;
            _logger = logger;
            _tokenAccessor = tokenAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            SetAuthorization(request, _tokenAccessor.Token);
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logger.LogInformation("Unauthorized request. Trying to get valid token.");

                // Get token from TvDB
                var authData = new AuthData
                {
                    ApiKey = _options.ApiKey
                };

                var authRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_options.BaseAddress}/login"),
                    Content = new StringContent(JsonSerializer.Serialize(authData, JsonSerializerOptionsProvider.Options), Encoding.UTF8, "application/json")
                };

                var authResponse = await base.SendAsync(authRequest, cancellationToken);
                var token = await JsonSerializer.DeserializeAsync<TokenResponse>(await authResponse.Content.ReadAsStreamAsync(), JsonSerializerOptionsProvider.Options);

                if (!authResponse.IsSuccessStatusCode || string.IsNullOrEmpty(token.Token))
                {
                    _logger.LogInformation("Failed to get token.");
                    return response;
                }

                _logger.LogInformation("Got valid token. Retrying request.");

                _tokenAccessor.Token = token.Token;
                SetAuthorization(request, _tokenAccessor.Token);

                response = await base.SendAsync(request, cancellationToken);

                return response;
            }

            return response;
        }

        private static void SetAuthorization(HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
