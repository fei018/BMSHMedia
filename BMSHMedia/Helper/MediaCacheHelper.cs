using Microsoft.Extensions.Caching.Distributed;

namespace BMSHMedia.Helper
{
    public class MediaCacheHelper
    {
        public static IDistributedCache Cache { get; private set; }

        public static void SetCache(IDistributedCache cache)
        {
            Cache = cache;
        }
    }
}
