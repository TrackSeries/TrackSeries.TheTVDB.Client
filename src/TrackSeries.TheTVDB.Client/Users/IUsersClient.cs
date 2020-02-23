using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Users
{
    /// <summary>
    /// Used for working with the current user
    /// </summary>
    public interface IUsersClient
    {
        /// <summary>
        /// <para>[PUT /user/ratings/{itemType}/{itemId}/{itemRating}]</para>
        /// <para>Adds a rating to an episode.</para>
        /// </summary>
        /// <param name="episodeId">The ID of the episode to be rated.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[PUT /user/ratings/{itemType}/{itemId}/{itemRating}]</para>
        /// <para>Adds a rating to an image.</para>
        /// </summary>
        /// <param name="imageId">The ID of the image to be rated.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[PUT /user/ratings/{itemType}/{itemId}/{itemRating}]</para>
        /// <para>Adds a rating to an item.</para>
        /// </summary>
        /// <param name="itemType">An enumeration that represents the type of item to be rated. Can be  Series, Episode, Image</param>
        /// <param name="itemId">The ID of the item to be rated.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[PUT /user/ratings/{itemType}/{itemId}/{itemRating}]</para>
        /// <para>Adds a rating to a series.</para>
        /// </summary>
        /// <param name="seriesId">The ID of the series to be rated.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[PUT /user/favorites/{id}]</para>
        /// <para>Adds the supplied series to the user’s favorite’s list and returns the updated list.</para>
        /// </summary>
        /// <param name="seriesId">The ID of the series.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user]</para>
        /// <para>Returns basic information about the currently authenticated user.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<User>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/ratings/query]</para>
        /// <para>Returns the episode ratings for a given user.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> GetEpisodesRatingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/favorites]</para>
        /// <para>Returns the favorite series for a given user, will be a blank array if no favorites exist.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/ratings/query]</para>
        /// <para>Returns the image ratings for a given user.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> GetImagesRatingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/ratings]</para>
        /// <para>Returns the ratings for the given user.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> GetRatingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/ratings/query]</para>
        /// <para>Returns ratings for a given user that match the rating type.</para>
        /// </summary>
        /// <param name="type">An enumeration that represents the type of rating to be retrieved. Can be  Series, Episode, Image</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /user/ratings/query]</para>
        /// <para>Returns the series ratings for a given user.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<UserRatings>>> GetSeriesRatingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[DELETE /user/ratings/{itemType}/{itemId}]</para>
        /// <para>Removes the user rating from an episode.</para>
        /// </summary>
        /// <param name="episodeId">The ID of the episode.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[DELETE /user/favorites/{id}]</para>
        /// <para>Deletes the given series from the user’s favorite’s list and returns the updated list.</para>
        /// </summary>
        /// <param name="seriesId">The ID of the series.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[DELETE /user/ratings/{itemType}/{itemId}]</para>
        /// <para>Removes the user rating from an image.</para>
        /// </summary>
        /// <param name="imageId">The ID of the image.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[DELETE /user/ratings/{itemType}/{itemId}]</para>
        /// <para>Removes the user rating from an item.</para>
        /// </summary>
        /// <param name="itemType">An enumeration that represents the type of item to be rated. Can be  Series, Episode, Image</param>
        /// <param name="itemId">The ID of the item.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[DELETE /user/ratings/{itemType}/{itemId}]</para>
        /// <para>Removes the user rating from a series.</para>
        /// </summary>
        /// <param name="seriesId">The ID of the series.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken = default);
    }
}
