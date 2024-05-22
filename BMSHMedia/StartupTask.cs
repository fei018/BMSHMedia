using BMSHMedia.DataAccess;
using BMSHMedia.ViewModel.MediaVMs;
using BMSHMedia.ViewModel.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

namespace BMSHMedia
{
    public class StartupTask
    {
        public static void Run(IConfiguration config, IServiceCollection services, IWebHostEnvironment env)
        {
            var serviceProvider = services.BuildServiceProvider();

            SiteConfigInfo.SetSiteConfig(config.GetSection("AppSettings").GetSection("MediaRootPath").Value);

            //ServerCacheHelper.SetCache(serviceProvider.GetRequiredService<IDistributedCache>());

            services.AddSingleton<MediaApiVM>();

            Task.Run(new MediaApiVM(serviceProvider.GetRequiredService<IMemoryCache>()).ScanAllAsync);

            services.AddScoped(sp => new BaseFormSubmitDbService(Path.Combine(env.ContentRootPath, config.GetSection("LiteDb_FormSubmit").Value)));
        }
    }
}
