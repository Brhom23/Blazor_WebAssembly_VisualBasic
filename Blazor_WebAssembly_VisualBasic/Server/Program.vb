Imports Blazor_WebAssembly_VisualBasic.Server.Shared
Imports Microsoft.AspNetCore.Authentication
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Class Program
    Public Shared Sub Main(ByVal args As String())
        Dim builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args)

        ' Add services to the container.
        'Dim connectionString = If(builder.Configuration.GetConnectionString("DefaultConnection"), CSharpImpl.__Throw(Of String)(New InvalidOperationException("Connection string 'DefaultConnection' not found.")))
        Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        If connectionString & "" = "" Then
            Throw New InvalidOperationException("Connection string 'DefaultConnection' not found.")
        End If

        builder.Services.AddDbContext(Of ApplicationDbContext)(Sub(options) options.UseSqlServer(connectionString))
        builder.Services.AddDatabaseDeveloperPageExceptionFilter()

        builder.Services.AddDefaultIdentity(Of ApplicationUser)(Sub(options) options.SignIn.RequireConfirmedAccount = True).AddEntityFrameworkStores(Of ApplicationDbContext)()

        builder.Services.AddIdentityServer().AddApiAuthorization(Of ApplicationUser, ApplicationDbContext)()

        Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(builder.Services).AddIdentityServerJwt()

        builder.Services.AddControllersWithViews()
        builder.Services.AddRazorPages()

        Dim app = builder.Build()

        ' Configure the HTTP request pipeline.
        If app.Environment.IsDevelopment() Then
            app.UseMigrationsEndPoint()
            app.UseWebAssemblyDebugging()
        Else
            app.UseExceptionHandler("/Error")
            ' The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts()
        End If

        app.UseHttpsRedirection()

        app.UseBlazorFrameworkFiles()
        app.UseStaticFiles()

        app.UseRouting()

        app.UseIdentityServer()
        app.UseAuthorization()


        app.MapRazorPages()
        app.MapControllers()
        app.MapFallbackToFile("index.html")

        app.Run()
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class
