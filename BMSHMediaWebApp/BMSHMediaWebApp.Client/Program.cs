using BMSHMediaWebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BMSHMediaWebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddHttpClient<ApiCallerService>(op => op.BaseAddress = new Uri("http://localhost:30002"));

            builder.Services.AddBootstrapBlazor();//(op =>
            //{
            //    op.ToastDelay = 4000;
            //    op.SupportedCultures = ["zh-TW", "zh-CN", "en-US"];
            //    op.DefaultCultureInfo = "zh-TW";
            //});

            //builder.Services.ConfigureJsonLocalizationOptions(op =>
            //{
            //    op.IgnoreLocalizerMissing = true;
            //    op.AdditionalJsonFiles = ["wwwroot\\Localization\\zh-TW.json"];
            //});

            await builder.Build().RunAsync();
        }
    }
}
