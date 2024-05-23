using BMSHMedia.ViewModel.MediaVMs;
using BMSHMedia.ViewModel.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BMSHMedia
{
    public class StartupTask
    {
        public static void Add(IConfiguration config, IServiceCollection services, IWebHostEnvironment env)
        {
            var serviceProvider = services.BuildServiceProvider();

            MediaConfigInfo.SetSiteConfig(config.GetSection("AppSettings").GetSection("MediaRootPath").Value);

            //ServerCacheHelper.SetCache(serviceProvider.GetRequiredService<IDistributedCache>());

            services.AddSingleton<MediaApiVM>();

            
        }
    }
}
