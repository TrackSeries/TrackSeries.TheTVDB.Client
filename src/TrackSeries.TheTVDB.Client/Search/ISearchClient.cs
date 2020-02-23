using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Search
{
    /// <summary>
    /// Used for searching for a particular series by name, imdb ID or Zap2It ID
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on the following parameters.</para>
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <param name="parameterKey">An enum used for searching for series with <see cref="T:ISearchClient.SearchSeriesAsync"/>,
        /// each value represents a property by which the search is performed</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesAsync(
            string value,
            SearchParameter parameterKey,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on the following parameters.</para>
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <param name="parameterKey">Search parameter as a string.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesAsync(
            string value,
            string parameterKey,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on their imdb ID</para>
        /// </summary>
        /// <param name="imdbId">The imdb ID of the series</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on their name</para>
        /// </summary>
        /// <param name="name">The series name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on their Zap2It ID</para>
        /// </summary>
        /// <param name="zap2ItId">The Zap2It ID of the series</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesByZap2ItIdAsync(string zap2ItId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /search/series]</para>
        /// <para>Returns a series search result based on their series slug.</para>
        /// </summary>
        /// <param name="slug">The slug of the series</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<SeriesSearchResult>>> SearchSeriesBySlugAsync(string slug, CancellationToken cancellationToken = default);

    }
}
