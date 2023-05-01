Imports Microsoft.AspNetCore.Components.Web
Imports Microsoft.AspNetCore.Components.WebAssembly.Hosting

Namespace Blazor_WebAssembly_VisualBasic.Client
    Public Class Program
        Public Shared Async Function Main(ByVal args As String()) As Task
            Dim builder = WebAssemblyHostBuilder.CreateDefault(args)
            builder.RootComponents.Add(Of App)("#app")
            builder.RootComponents.Add(Of HeadOutlet)("head::after")

            builder.Services.AddHttpClient("Blazor_WebAssembly_VisualBasic.ServerAPI", Sub(client) client.BaseAddress = New Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler(Of BaseAddressAuthorizationMessageHandler)()

            ' Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(Function(sp) Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(Of Net.Http.IHttpClientFactory)(sp).CreateClient("Blazor_WebAssembly_VisualBasic.ServerAPI"))

            builder.Services.AddApiAuthorization()

            Await builder.Build().RunAsync()
        End Function
    End Class
End Namespace
