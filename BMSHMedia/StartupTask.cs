using BMSHMedia.Helper;
using BMSHMedia.Portal.ViewModel.MediaVMs;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BMSHMedia
{
    public class StartupTask
    {
        public static void Run(IConfiguration config, IServiceCollection services)
        {
            SiteConfigInfo.SetSiteConfig(config.GetSection("AppSettings").GetSection("MediaRootPath").Value);

            var serviceProvider = services.BuildServiceProvider();

            MediaCacheHelper.SetCache(serviceProvider.GetRequiredService<IDistributedCache>());


        }
    }
}
