using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Languages
{
    /// <summary>
    /// Used for getting available languages, information about them and setting the language requested
    /// </summary>
    public interface ILanguagesClient
    {
        /// <summary>
        /// <para>[GET /languages]</para>
        /// <para>Returns all available languages.</para> 
        /// <para>These language abbreviations can be used as a value for <see cref="SetAsync(string, CancellationToken)"/>.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<List<Language>>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /languages/{id}]</para>
        /// <para>Returns information about a particular language, given the language ID.</para>
        /// </summary>
        /// <param name="languageId">The language ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the language that will be used to request information.
        /// </summary>
        /// <param name="languageAbbreviation">The language Abbreviation</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task SetAsync(string languageAbbreviation, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the language that will be used to request information.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task SetAsync(Language language, CancellationToken cancellationToken = default);

    }
}
