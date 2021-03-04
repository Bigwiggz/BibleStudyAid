using BibleStudyBWAUI.Configuration;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace BibleStudyBWAUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDA3MTQxQDMxMzgyZTM0MmUzME5iRTBaTkp6Slh1d3ZEK21YQjFXR3hid1l0TUVob08zVGRKVS9RMVJ4bzg9");
            var config = new ConfigurationSettings
            {
                WebBaseUrI = "https://localhost:5001",
            };

            

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
