using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Episodes;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Series
{
    /// <summary>
    /// Used for geting information about a specific series
    /// </summary>
    public interface ISeriesClient
    {
        /// <summary>
        /// <para>[GET /series/{id}/actors]</para>
        /// <para>Returns actors for the given series ID</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}]</para>
        /// <para>Returns a series records that contains all information known about a particular series.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Serie>> GetAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}]</para>
        /// <para>Returns a series records that contains all information known about a particular series.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Serie>> GetAsync(int seriesId, Action<SerieKeys> configurefilter, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/episodes]</para>
        /// <para>Returns episode records paginated with 100 results per page.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="page">The page you want to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<EpisodeRecord[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/episodes/query]</para>
        /// <para>Returns episode records paginated with 100 results per page.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="page">The page you want to retrieve.</param>
        /// <param name="query">The structure by which the records are queried.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<EpisodeRecord[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/episodes/summary]</para>
        /// <para>Returns a summary of the episodes and seasons available for the series.</para>
        /// <para>Note: Season "0" is for all episodes that are considered to be specials.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[HEAD /series/{id}]</para>
        /// <para>Returns header information only about the given series ID.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<IDictionary<string, IEnumerable<string>>> GetHeadersAsync(int seriesId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/images/query]</para>
        /// <para>Query images for the given series ID.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/images/query]</para>
        /// <para>Query images for the given series ID.</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQueryAlternative query, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /series/{id}/images]</para>
        /// <para>Returns a summary of the images for a particular series</para>
        /// </summary>
        /// <param name="seriesId">The series ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken = default);

    }
}
