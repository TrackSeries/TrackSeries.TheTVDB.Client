using System;

namespace TrackSeries.TheTVDB.Client;

internal static class DateTimeExtensions
{
    internal static long ToUnixEpochTime(this DateTime time)
    {
        return new DateTimeOffset(time).ToUnixTimeSeconds();
    }
}
