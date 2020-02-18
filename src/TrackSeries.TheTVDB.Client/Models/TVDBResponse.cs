namespace TrackSeries.TheTVDB.Client.Models
{
    public class TVDBResponse<TData>
    {
        public TData Data { get; set; }

        public Errors Errors { get; set; }

        public Links Links { get; set; }
    }
}