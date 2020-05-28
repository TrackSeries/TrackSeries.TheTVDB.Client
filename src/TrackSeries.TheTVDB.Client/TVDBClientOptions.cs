namespace TrackSeries.TheTVDB.Client
{
    public class TVDBClientOptions
    {
        public string ApiKey { get; set; }
        internal string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public string AcceptedLanguage { get; set; } = "en";
        public bool ShareContextBetweenClients { get; set; } = false;

        /// <summary>
        /// When enabled, the images of all the models include the full url. 
        /// Ex: "https://artworks.thetvdb.com/banners/photo.png" instead of "photo.png"
        /// </summary>
        public bool ReturnCompleteUrlForImages { get; set; } = true; 
    }
}
