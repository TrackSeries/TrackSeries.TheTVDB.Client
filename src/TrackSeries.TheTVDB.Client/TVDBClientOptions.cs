namespace TrackSeries.TheTVDB.Client
{
    public class TVDBClientOptions
    {
        public string ApiKey { get; set; }
        internal string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public string AcceptedLanguage { get; set; } = "en";
    }
}
