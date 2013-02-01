namespace System
{
    public static class FineTimeSpan
    {
        // TODO: Should I expose this as TicksPerMicrosecond, like other public fields on TimeSpan?
        private const int MicrosecondsPerMillisecond = 1000;

        public static double TotalMicroseconds(this TimeSpan timespan)
        {
            var milliseconds = timespan.Ticks / (double)TimeSpan.TicksPerMillisecond;
            var microseconds = milliseconds * MicrosecondsPerMillisecond;
            return microseconds;
        }

        /// <summary>
        /// TimeSpan rounds fractional milliseconds to 1, this method takes you through 
        /// ticks to get a fine time span.
        /// </summary>
        public static TimeSpan FromMicroseconds(double microseconds)
        {
            var milliseconds = microseconds / MicrosecondsPerMillisecond;
            var ticks = (long)(TimeSpan.TicksPerMillisecond * milliseconds);
            return TimeSpan.FromTicks(ticks);
        }

        /// <summary>
        /// TimeSpan rounds fractional milliseconds to 1, this method takes you through 
        /// ticks to get a fine time span.
        /// </summary>
        public static TimeSpan FromMilliseconds(double milliseconds)
        {
            var ticks = (long)(TimeSpan.TicksPerMillisecond * milliseconds);
            return TimeSpan.FromTicks(ticks);
        }
    }
}