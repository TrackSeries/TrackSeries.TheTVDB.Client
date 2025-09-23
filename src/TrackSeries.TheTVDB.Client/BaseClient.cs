using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using TrackSeries.TheTVDB.Client.Authentication;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client
{
    internal abstract class BaseClient
    {
        private readonly HttpClient _client;
        private readonly TVDBClientOptions _options;
        private readonly TVDBContext _context;

        private const string AuthorizationScheme = "Bearer";

        protected BaseClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Sends a GET request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task<T> GetJsonAsync<T>(string requestUri, CancellationToken cancellationToken = default)
            => SendJsonAsync<T>(HttpMethod.Get, requestUri, null, cancellationToken);
            
        /// <summary>
        /// Sends a DELETE request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task<T> DeleteJsonAsync<T>(string requestUri, CancellationToken cancellationToken = default)
            => SendJsonAsync<T>(HttpMethod.Delete, requestUri, null, cancellationToken);
            
        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task PostJsonAsync(string requestUri, object content, CancellationToken cancellationToken = default)
            => SendJsonAsync(HttpMethod.Post, requestUri, content, cancellationToken);

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task<T> PostJsonAsync<T>(string requestUri, object content, CancellationToken cancellationToken = default)
            => SendJsonAsync<T>(HttpMethod.Post, requestUri, content, cancellationToken);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        protected Task PutJsonAsync(string requestUri, object content, CancellationToken cancellationToken = default)
            => SendJsonAsync(HttpMethod.Put, requestUri, content, cancellationToken);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <param name="cancellationToken"></param>
        protected Task PutJsonAsync(string requestUri, CancellationToken cancellationToken = default)
            => PutJsonAsync(requestUri, null, cancellationToken);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task<T> PutJsonAsync<T>(string requestUri, CancellationToken cancellationToken = default)
            => PutJsonAsync<T>(requestUri, null, cancellationToken);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected Task<T> PutJsonAsync<T>(string requestUri, object content, CancellationToken cancellationToken = default)
            => SendJsonAsync<T>(HttpMethod.Put, requestUri, content, cancellationToken);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        protected Task SendJsonAsync(HttpMethod method, string requestUri, object content, CancellationToken cancellationToken = default)
            => SendJsonAsync<IgnoreResponse>(method, requestUri, content, cancellationToken);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        protected async Task<T> SendJsonAsync<T>(
            HttpMethod method, string requestUri, object content,
            CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(method, requestUri);

            if (content != null)
            {
                request.Content = JsonContent.Create(content, options: JsonSerializerOptionsProvider.Options);
            }

            var response = await SendAsync(request, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(IgnoreResponse))
            {
                return default;
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<T>(JsonSerializerOptionsProvider.Options, cancellationToken).ConfigureAwait(false);
            }
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default) 
        {
            // If we don't have a token we don't want to wait since we know we will get an unauthorized. 
            // Let's try to get a valid token first.
            if(string.IsNullOrEmpty(_context.Token))
            {
                await TryObtainValidTokenAsync(cancellationToken).ConfigureAwait(false);
            }

            PrepareRequest(request);
            var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized && await TryObtainValidTokenAsync(cancellationToken).ConfigureAwait(false))
            {
                request = CloneRequest(request);
                PrepareRequest(request);
                response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            return response;
        }

        private async Task<bool> TryObtainValidTokenAsync(CancellationToken cancellationToken = default)
        {
            var authData = GetAuthorizationData();
            
            var authResponse = await _client.PostAsJsonAsync("/login", authData, JsonSerializerOptionsProvider.Options, cancellationToken).ConfigureAwait(false);

            if (authResponse.IsSuccessStatusCode)
            {
                var token = await authResponse.Content.ReadFromJsonAsync<TokenResponse>(JsonSerializerOptionsProvider.Options, cancellationToken).ConfigureAwait(false);
                _context.UpdateToken(token.Token);
            }

            return authResponse.IsSuccessStatusCode;
        } 

        private void PrepareRequest(HttpRequestMessage request)
        {
            SetLanguage(request, _context.Language ?? _options.AcceptedLanguage);
            SetAuthorization(request, _context.Token);
        }

        private AuthData GetAuthorizationData()
        {
            return new AuthData
            {
                ApiKey = _options.ApiKey,
                UserKey = _context.UserKey,
                Username = _context.Username
            };
        }

        private static void SetLanguage(HttpRequestMessage request, string language)
        {
            request.Headers.Add(HeaderNames.AcceptLanguage, language);
        }

        private static void SetAuthorization(HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(AuthorizationScheme, token);
        }

        private static HttpRequestMessage CloneRequest(HttpRequestMessage request)
        {
            return new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = request.Content
            };
        }

        class IgnoreResponse { }
    }
}
