using Microsoft.Extensions.Caching.Distributed;

namespace BMSHMedia.Helper
{
    public class ServerCacheHelper
    {
        public static IDistributedCache Cache { get; private set; }

        public static void SetCache(IDistributedCache cache)
        {
            Cache = cache;
        }
    }
}
