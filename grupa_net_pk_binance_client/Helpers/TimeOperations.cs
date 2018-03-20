using System;

namespace grupa_net_pk_binance_client.Helpers
{
    public class TimeOperations
    {
        public static string GetTimeStampUnixInMilliseconds()
        {
            var timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
            return timestamp.ToString();
        }
        public static string GetTimeStampUnixInSeconds()
        {
            var timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return timestamp.ToString();
        }
    }
}
