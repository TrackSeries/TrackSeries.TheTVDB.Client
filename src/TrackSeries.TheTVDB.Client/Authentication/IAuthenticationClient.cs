using System.Threading;
using System.Threading.Tasks;

namespace TrackSeries.TheTVDB.Client.Authentication
{
    public interface IAuthenticationClient
    {

        /// <summary>
        /// <para>[POST /login]</para>
        /// <para>Authenticates the user given an authentication data and retrieves a session token.</para> 
        /// <para>The session token is only valid for 24 hours, but the session can be extended by calling <see cref="RefreshTokenAsync(CancellationToken)" /></para>
        /// <para>Call once before calling any other method.</para>
        /// </summary>
        /// <param name="username">The Username needed for authentication.</param>
        /// <param name="userKey">The UserKey or Account Identifier found in the account page of your thetvdb.com profile</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task AuthenticateAsync(string username, string userKey, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>[GET /refresh_token]</para>
        /// <para>Returns a new session token that extends the current session by 24 hours.</para>
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task RefreshTokenAsync(CancellationToken cancellationToken = default);

        void LogoutCurrentUser();

    }
}
