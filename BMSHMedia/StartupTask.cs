using BMSHMedia.ViewModel.MediaApiVMs;
using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.Extensions.Configuration;
using System.Text;

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
