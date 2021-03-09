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
using BibleStudyBWAUI.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BibleStudyBWAUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            
            var config = new ConfigurationSettings
            {
                WebBaseUrI = "https://localhost:5001",
            };

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var syncFusionKey=builder.Configuration["Syncfusion:ProjectUserKey"];
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncFusionKey);

            //Add SyncFusion
            builder.Services.AddSyncfusionBlazor();

            builder.RootComponents.Add<App>("#app");

            //Authentication
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
