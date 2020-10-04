using FantasyAuction.Client.Services;
using FantasyAuction.Client.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FantasyAuction.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddSingleton<AlertService>();
            builder.Services.AddSingleton<SpinnerService>();

            builder.Services.AddScoped<SpinnerMessageHandler>();
            //builder.Services.AddScoped(s =>
            //{
            //    var accessTokenHandler = s.GetRequiredService<SpinnerMessageHandler>();
            //    accessTokenHandler.InnerHandler = new HttpClientHandler();
            //    var uriHelper = s.GetRequiredService<NavigationManager>();
            //    return new HttpClient(accessTokenHandler)
            //    {
            //        BaseAddress = new Uri(uriHelper.BaseUri)
            //    };
            //});
            
            await builder.Build().RunAsync();
        }
    }
}