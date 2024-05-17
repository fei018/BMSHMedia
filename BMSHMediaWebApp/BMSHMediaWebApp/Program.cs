using BMSHMediaWebApp.Client.Services;
using BMSHMediaWebApp.Components;

namespace BMSHMediaWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddHttpClient<ApiCallerService>(op => op.BaseAddress = new Uri("http://localhost:30002"));

            builder.Services.AddBootstrapBlazor(op =>
            {
                op.ToastDelay = 4000;
                op.SupportedCultures = ["zh-TW", "zh-CN", "en-US"];
                op.DefaultCultureInfo = "zh-TW";
            });

            builder.Services.ConfigureJsonLocalizationOptions(op =>
            {
                op.IgnoreLocalizerMissing = true;
                op.ResourcesPath = "Resources";
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
