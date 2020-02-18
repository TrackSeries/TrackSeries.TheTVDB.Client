using System;

namespace TrackSeries.TheTVDB.Client
{
    internal static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        internal static int ToUnixEpochTime(this DateTime time)
        {
            return (int)(time - Epoch).TotalSeconds;
        }
    }
}
