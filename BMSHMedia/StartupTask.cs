using BMSHMedia.DataAccess;
using BMSHMedia.Helper;
using BMSHMedia.ViewModel.MediaVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BMSHMedia
{
    public class StartupTask
    {
        public static void Run(IConfiguration config, IServiceCollection services , IWebHostEnvironment env)
        {
            SiteConfigInfo.SetSiteConfig(config.GetSection("AppSettings").GetSection("MediaRootPath").Value);

            var serviceProvider = services.BuildServiceProvider();

            ServerCacheHelper.SetCache(serviceProvider.GetRequiredService<IDistributedCache>());

            Task.Run(MediaApiVM.ScanAllAsync);

            services.AddScoped(s => new LiteDbContext(env.ContentRootPath));
        }
    }
}
