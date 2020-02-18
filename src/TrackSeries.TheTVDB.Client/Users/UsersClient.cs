using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;
using TrackSeries.TheTVDB.Client.Serializer;

namespace TrackSeries.TheTVDB.Client.Users
{
    internal class UsersClient : IUsersClient
    {
        private readonly HttpClient _client;

        internal UsersClient(HttpClient client)
        {
            _client = client;
        }

        public Task<TVDBResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public Task<TVDBResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
        }

        public async Task<TVDBResponse<UserRatings[]>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken = default)
        {
            return await _client
                .PutJsonAsync<TVDBResponse<UserRatings[]>>($"/user/ratings/{itemType.ToPascalCase()}/{itemId}/{rating}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client
                .PutJsonAsync<TVDBResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<User>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TVDBResponse<User>>("/user", cancellationToken).ConfigureAwait(false);
        }

        public Task<TVDBResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<UserFavorites>>("/user/favorites", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Image, cancellationToken);
        }

        public async Task<TVDBResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<UserRatings[]>>("/user/ratings", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TVDBResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TVDBResponse<UserRatings[]>>($"/user/ratings/query?itemType={type.ToPascalCase()}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TVDBResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public async Task<TVDBResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client
                .DeleteJsonAsync<TVDBResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken = default)
        {
            await _client
                .DeleteAsync($"/user/ratings/{itemType.ToPascalCase()}/{itemId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }
    }
}
