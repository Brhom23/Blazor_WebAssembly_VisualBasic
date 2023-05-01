using Blazor_WebAssembly_VisualBasic.Client;
using Blazor_WebAssembly_VisualBasic.Client.BL;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Blazor_WebAssembly_VisualBasic.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("brm-"+typeof(App).Assembly);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //builder.RootComponents.Add<HeadOutlet>("head::after");
            //builder.Services.AddApiAuthorization();
            await App_Program.AppMain(builder);

            //builder.Services.AddHttpClient("Blazor_WebAssembly_VisualBasic.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            //    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //// Supply HttpClient instances that include access tokens when making requests to the server project
            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Blazor_WebAssembly_VisualBasic.ServerAPI"));

            //builder.Services.AddBlazoredLocalStorage();
            
                        //await builder.Build().RunAsync();
        }
    }
}




//using Blazor_WebAssembly_VisualBasic.Client.BL;
//namespace Blazor_WebAssembly_VisualBasic.Client
//{
//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            await App_Program.AppMain(args: args);
//        }
//    }
//}