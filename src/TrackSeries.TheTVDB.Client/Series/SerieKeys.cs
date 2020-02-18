using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Series
{
    public class SerieKeys
    {
        private readonly HashSet<string> _enabledKeys;

        internal SerieKeys()
        {
            _enabledKeys = new HashSet<string>();
        }

        public SerieKeys IncludeBanner()
        {
            _enabledKeys.Add("banner");
            return this;
        }

        public SerieKeys IncludeStatus()
        {
            _enabledKeys.Add("status");
            return this;
        }

        public SerieKeys IncludeGenre()
        {
            _enabledKeys.Add("genre");
            return this;
        }

        public SerieKeys IncludeRating()
        {
            _enabledKeys.Add("rating");
            return this;
        }

        public SerieKeys IncludeNetworkId()
        {
            _enabledKeys.Add("networkId");
            return this;
        }

        public SerieKeys IncludeOverview()
        {
            _enabledKeys.Add("overview");
            return this;
        }

        public SerieKeys IncludeImdbId()
        {
            _enabledKeys.Add("imdbId");
            return this;
        }

        public SerieKeys IncludeZap2itId()
        {
            _enabledKeys.Add("zap2itId");
            return this;
        }

        public SerieKeys IncludeAdded()
        {
            _enabledKeys.Add("added");
            return this;
        }

        public SerieKeys IncludeAirsDayOfWeek()
        {
            _enabledKeys.Add("airsDayOfWeek");
            return this;
        }

        public SerieKeys IncludeAirsTime()
        {
            _enabledKeys.Add("airsTime");
            return this;
        }

        public SerieKeys IncludeSiteRating()
        {
            _enabledKeys.Add("siteRating");
            return this;
        }

        public SerieKeys IncludeAliases()
        {
            _enabledKeys.Add("aliases");
            return this;
        }

        public SerieKeys IncludeSeriesId()
        {
            _enabledKeys.Add("seriesId");
            return this;
        }

        public SerieKeys IncludeFirstAired()
        {
            _enabledKeys.Add("firstAired");
            return this;
        }

        public SerieKeys IncludeRuntime()
        {
            _enabledKeys.Add("runtime");
            return this;
        }

        public SerieKeys IncludeLastUpdated()
        {
            _enabledKeys.Add("lastUpdated");
            return this;
        }

        public SerieKeys IncludeSiteRatingCount()
        {
            _enabledKeys.Add("siteRatingCount");
            return this;
        }

        public SerieKeys IncludeId()
        {
            _enabledKeys.Add("id");
            return this;
        }

        public SerieKeys IncludeSeriesName()
        {
            _enabledKeys.Add("seriesName");
            return this;
        }

        public SerieKeys IncludeNetwork()
        {
            _enabledKeys.Add("network");
            return this;
        }

        public SerieKeys IncludeAddedBy()
        {
            _enabledKeys.Add("addedBy");
            return this;
        }

        public override string ToString()
        {
            return string.Join(",", _enabledKeys);
        }
    }
}
