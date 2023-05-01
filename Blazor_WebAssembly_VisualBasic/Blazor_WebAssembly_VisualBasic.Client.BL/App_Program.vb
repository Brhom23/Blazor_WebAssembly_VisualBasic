Imports System.Net.Http
Imports Blazored.LocalStorage
Imports Microsoft.AspNetCore.Components.Web
Imports Microsoft.AspNetCore.Components.WebAssembly.Authentication
Imports Microsoft.AspNetCore.Components.WebAssembly.Hosting
Imports Microsoft.Extensions.DependencyInjection
Public Module App_Program
    Public Async Function AppMain(builder As WebAssemblyHostBuilder) As Task
        'Dim builder = WebAssemblyHostBuilder.CreateDefault(args)
        'builder.RootComponents.Add(Of App)("#app")
        builder.RootComponents.Add(Of HeadOutlet)("head::after")
        builder.Services.AddHttpClient("Blazor_WebAssembly_VisualBasic.ServerAPI",
                                       Sub(Client) Client.BaseAddress = New Uri(builder.HostEnvironment.BaseAddress)).
                                       AddHttpMessageHandler(Of BaseAddressAuthorizationMessageHandler)()
        '// Supply HttpClient instances that include access tokens when making requests to the server project
        builder.Services.AddScoped(Function(sp) sp.GetRequiredService(Of IHttpClientFactory)().CreateClient("Blazor_WebAssembly_VisualBasic.ServerAPI"))
        builder.Services.AddApiAuthorization()
        builder.Services.AddBlazoredLocalStorage()
        'Dim s = builder.HostEnvironment.BaseAddress
        'Console.WriteLine(s)
        Await builder.Build().RunAsync()
    End Function
End Module
