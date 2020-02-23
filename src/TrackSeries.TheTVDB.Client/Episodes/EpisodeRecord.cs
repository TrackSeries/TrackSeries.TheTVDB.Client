﻿using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Episodes
{
    public class EpisodeRecord
    {
        public int? AbsoluteNumber { get; set; }

        public int? AiredEpisodeNumber { get; set; }

        public int? AiredSeason { get; set; }

        public int? AiredSeasonID { get; set; }

        public int? AirsAfterSeason { get; set; }

        public int? AirsBeforeEpisode { get; set; }

        public int? AirsBeforeSeason { get; set; }

        public List<string> Directors { get; set; }

        public int? DvdChapter { get; set; }

        public string DvdDiscid { get; set; }

        public decimal? DvdEpisodeNumber { get; set; }

        public int? DvdSeason { get; set; }

        public string EpisodeName { get; set; }

        public string Filename { get; set; }

        public string FirstAired { get; set; }

        public List<string> GuestStars { get; set; }

        public int Id { get; set; }

        public string ImdbId { get; set; }

        public EpisodeLanguage Language { get; set; }

        public long LastUpdated { get; set; }

        public int? LastUpdatedBy { get; set; }

        public string Overview { get; set; }

        public string ProductionCode { get; set; }

        public int SeriesId { get; set; }

        public string ShowUrl { get; set; }

        public decimal? SiteRating { get; set; }

        public int? SiteRatingCount { get; set; }

        public string ThumbAdded { get; set; }

        public int? ThumbAuthor { get; set; }

        public string ThumbHeight { get; set; }

        public string ThumbWidth { get; set; }

        public List<string> Writers { get; set; }

        public string ContentRating { get; set; }

        public int IsMovie { get; set; }
    }
}