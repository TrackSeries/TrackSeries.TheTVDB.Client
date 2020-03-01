using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                var requestJson = JsonSerializer.Serialize(content, JsonSerializerOptionsProvider.Options);
                request.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            }

            var response = await SendAsync(request, cancellationToken);

            // Make sure the call was successful before we
            // attempt to process the response content
            response.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(IgnoreResponse))
            {
                return default;
            }
            else
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(stringContent, JsonSerializerOptionsProvider.Options);
            }
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default) 
        {
            // If we don't have a token we don't want to wait since we know we will get an unauthorized. 
            // Let's try to get a valid token first.
            if(string.IsNullOrEmpty(_context.Token))
            {
                await TryObtainValidTokenAsync(cancellationToken);
            }

            PrepareRequest(request);
            var response = await _client.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized && await TryObtainValidTokenAsync(cancellationToken))
            {
                request = CloneRequest(request);
                PrepareRequest(request);
                response = await _client.SendAsync(request, cancellationToken);
            }

            return response;
        }

        private async Task<bool> TryObtainValidTokenAsync(CancellationToken cancellationToken = default)
        {
            var authData = GetAuthorizationData();
            var content = new StringContent(JsonSerializer.Serialize(authData, JsonSerializerOptionsProvider.Options), Encoding.UTF8, "application/json");
            var authResponse = await _client.PostAsync("/login", content, cancellationToken);

            if (authResponse.IsSuccessStatusCode)
            {
                var token = await JsonSerializer.DeserializeAsync<TokenResponse>(await authResponse.Content.ReadAsStreamAsync(), JsonSerializerOptionsProvider.Options, cancellationToken);
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
