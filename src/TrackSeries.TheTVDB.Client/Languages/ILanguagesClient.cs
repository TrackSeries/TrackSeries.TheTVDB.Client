using System.Threading;
using System.Threading.Tasks;
using TrackSeries.TheTVDB.Client.Models;

namespace TrackSeries.TheTVDB.Client.Languages
{
    /// <summary>
    /// Used for getting available languages and information about them
    /// </summary>
    public interface ILanguagesClient
    {
        /// <summary>
        /// <para>[GET /languages]</para>
        /// <para>Returns all available languages.</para> 
        /// <para>These language abbreviations can be used as a value for the <see cref="T:ITvDbClient.AcceptedLanguage"/> property.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /languages/{id}]</para>
        /// <para>Returns information about a particular language, given the language ID.</para>
        /// </summary>
        /// <param name="languageId">The language ID</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        Task<TVDBResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken = default);

    }
}
