using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Series
{
    public class Serie
    {
        public string Added { get; set; }

        public int? AddedBy { get; set; }

        public string AirsDayOfWeek { get; set; }

        public string AirsTime { get; set; }

        public List<string> Aliases { get; set; }

        public string Banner { get; set; }

        public string FirstAired { get; set; }

        public List<string> Genre { get; set; }

        public int Id { get; set; }

        public string ImdbId { get; set; }

        public long LastUpdated { get; set; }

        public string Network { get; set; }

        public string NetworkId { get; set; }

        public string Overview { get; set; }

        public string Rating { get; set; }

        public string Runtime { get; set; }

        /// <summary>
        /// <para>TV.com ID</para>
        /// <para>Don't confuse with the Id property.</para>
        /// <para>Usually it is an integer, but there is nothing stopping users of http://thetvdb.com from changing it into any value. 
        /// This has happened before.</para>
        /// </summary>
        public string SeriesId { get; set; }
        public string SeriesName { get; set; }
        public decimal? SiteRating { get; set; }
        public int? SiteRatingCount { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }
        public string Zap2itId { get; set; }
        public int? Season { get; set; }
        public string Poster { get; set; }
        public string FanArt { get; set; }
        public string Language { get; set; }
    }
}