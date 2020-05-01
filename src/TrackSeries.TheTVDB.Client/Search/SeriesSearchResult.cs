using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Search
{

    public class SeriesSearchResult
    {
        public List<string> Aliases { get; set; }

        public string Banner { get; set; }
        public string FanArt { get; set; }
        public string Image { get; set; }
        public string Poster { get; set; }

        public string FirstAired { get; set; }

        public int Id { get; set; }

        public string Network { get; set; }

        public string Overview { get; set; }

        public string SeriesName { get; set; }

        public string Slug { get; set; }

        public string Status { get; set; }
    }
}
