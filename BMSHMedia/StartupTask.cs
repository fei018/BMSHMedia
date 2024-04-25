using BMSHMedia.Portal.ViewModel.MediaApiVMs;
using BMSHMedia.Portal.ViewModel.MediaVMs;
using Microsoft.Extensions.Configuration;

namespace BMSHMedia
{
    public class StartupTask
    {
        public static void Run(IConfiguration config)
        {
            SiteConfigInfo.SetSiteConfig(config.GetSection("AppSettings").GetSection("MediaRootPath").Value);

            MediaApiVM.ScanAllAsync().Wait();
        }
    }
}
