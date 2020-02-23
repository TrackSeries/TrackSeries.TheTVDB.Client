using System.Collections.Generic;

namespace TrackSeries.TheTVDB.Client.Models
{
    public class Errors
    {
        public List<string> InvalidFilters { get; set; }

        public string InvalidLanguage { get; set; }

        public List<string> InvalidQueryParams { get; set; }
    }
}