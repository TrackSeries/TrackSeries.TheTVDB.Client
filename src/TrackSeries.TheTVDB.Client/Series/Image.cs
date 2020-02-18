﻿namespace TrackSeries.TheTVDB.Client.Series
{
    public class Image
    {
        public string FileName { get; set; }

        public int Id { get; set; }

        public string KeyType { get; set; }

        public int? LanguageId { get; set; }

        public string Language { get; set; }

        public RatingsInfo RatingsInfo { get; set; }

        public string Resolution { get; set; }

        public string SubKey { get; set; }

        public string Thumbnail { get; set; }
    }
}