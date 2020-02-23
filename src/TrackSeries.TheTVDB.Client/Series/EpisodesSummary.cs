using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Series
{
    public class EpisodesSummary
    {
        public string AiredEpisodes { get; set; }

        public List<string> AiredSeasons { get; set; }

        public string DvdEpisodes { get; set; }

        public List<string> DvdSeasons { get; set; }
    }
}