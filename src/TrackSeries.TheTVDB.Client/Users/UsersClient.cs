using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Users
{
    internal class UsersClient : BaseClient, IUsersClient
    {
        internal UsersClient(HttpClient client, IOptions<TVDBClientOptions> options, TVDBContext context) : base(client, options, context)
        {
        }

        public Task<TVDBResponse<List<UserRatings>>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public Task<TVDBResponse<List<UserRatings>>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
        }

        public async Task<TVDBResponse<List<UserRatings>>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken = default)
        {
            return await PutJsonAsync<TVDBResponse<List<UserRatings>>>($"/user/ratings/{itemType.ToPascalCase()}/{itemId}/{rating}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<List<UserRatings>>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await PutJsonAsync<TVDBResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<User>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<User>>("/user", cancellationToken).ConfigureAwait(false);
        }

        public Task<TVDBResponse<List<UserRatings>>> GetEpisodesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<UserFavorites>>("/user/favorites", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<List<UserRatings>>> GetImagesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Image, cancellationToken);
        }

        public async Task<TVDBResponse<List<UserRatings>>> GetRatingsAsync(CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<List<UserRatings>>>("/user/ratings", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<List<UserRatings>>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken = default)
        {
            return await GetJsonAsync<TVDBResponse<List<UserRatings>>>($"/user/ratings/query?itemType={type.ToPascalCase()}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<List<UserRatings>>> GetSeriesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await DeleteJsonAsync<TVDBResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken = default)
        {
            await SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"/user/ratings/{itemType.ToPascalCase()}/{itemId}"), cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }
    }
}
