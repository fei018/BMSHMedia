using BMSHMedia.WebClient.Services;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace BMSHMedia.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<ApiCallerService>(op => { op.BaseAddress = new Uri("http://localhost:30002"); });

            builder.Services.AddBootstrapBlazor(op =>
            {
                op.ToastDelay = 4000;
                op.SupportedCultures = new List<string> { "zh-TW", "zh-CN", "en-US" };
                op.DefaultCultureInfo = "zh-TW";
            });

            builder.Services.ConfigureJsonLocalizationOptions(op =>
            {
                op.IgnoreLocalizerMissing = true;
                op.ResourcesPath = "Localization";
            });

            await builder.Build().RunAsync();
        }
    }
}
