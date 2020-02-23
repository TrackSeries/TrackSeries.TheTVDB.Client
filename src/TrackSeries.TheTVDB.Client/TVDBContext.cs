namespace TrackSeries.TheTVDB.Client
{
    internal class TVDBContext
    {
        public string Token { get; private set; }
        public string Language { get; set; }
        internal string UserKey { get; private set; }
        internal string Username { get; private set; }

        internal void UpdateToken(string token)
        {
            Token = token;
        }

        internal void UpdateTokenWithUserData(string token, string userKey, string username)
        {
            UserKey = userKey;
            Username = username;
            UpdateToken(token);
        }

        internal void RemoveCurrentUser()
        {
            Token = string.Empty;
            UserKey = string.Empty;
            Username = string.Empty;
        }
    }
}
