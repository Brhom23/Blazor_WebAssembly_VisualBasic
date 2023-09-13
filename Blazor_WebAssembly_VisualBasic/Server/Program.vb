Imports System.Formats
Imports System.Formats.Asn1.AsnWriter
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports Blazor_WebAssembly_VisualBasic.Server.Shared
Imports Duende.IdentityServer.AspNetIdentity
Imports Duende.IdentityServer.Services
Imports Microsoft.AspNetCore.Authentication
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Identity
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Class Program
    Public Shared Sub Main(ByVal args As String())

        Dim builder = WebApplication.CreateBuilder(args)

        ' Add services to the container.
        'Dim connectionString = If(builder.Configuration.GetConnectionString("DefaultConnection"), CSharpImpl.__Throw(Of String)(New InvalidOperationException("Connection string 'DefaultConnection' not found.")))
        Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        If connectionString & "" = "" Then
            Throw New InvalidOperationException("Connection string 'DefaultConnection' not found.")
        End If

        builder.Services.AddDbContext(Of ApplicationDbContext)(Sub(options) options.UseSqlServer(connectionString, Function(b) b.MigrationsAssembly("Blazor_WebAssembly_VisualBasic.Server.Identity")))
        builder.Services.AddDatabaseDeveloperPageExceptionFilter()

        builder.Services.AddDefaultIdentity(Of ApplicationUser)(
            Sub(options) options.SignIn.RequireConfirmedAccount = True).
            AddRoles(Of IdentityRole)().
            AddEntityFrameworkStores(Of ApplicationDbContext)()







        '        builder.Services.AddTransient<IProfileService, ProfileService>();
        '        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
        '        builder.Services.AddAuthentication().AddIdentityServerJwt();
        '        builder.Services.AddControllersWithViews();
        '        builder.Services.AddRazorPages();
        '        builder.Services.Configure<IdentityOptions>(options =>
        'options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);


        'builder.Services.AddIdentityServer().AddApiAuthorization(Of ApplicationUser, ApplicationDbContext)()
        builder.Services.AddIdentityServer().
            AddApiAuthorization(Of ApplicationUser, ApplicationDbContext)(
            Sub(options)
                options.IdentityResources("openid").UserClaims.Add("name")
                options.ApiResources.Single().UserClaims.Add("name")
                options.IdentityResources("openid").UserClaims.Add("role")
                options.ApiResources.Single().UserClaims.Add("role")
            End Sub)

        builder.Services.AddTransient(Of IProfileService, ProfileService)()
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role")
        builder.Services.AddAuthentication().AddIdentityServerJwt()
        builder.Services.AddControllersWithViews()
        builder.Services.AddRazorPages()
        builder.Services.Configure(Of IdentityOptions)(Sub(options) options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier)




        Dim app = builder.Build()



        Using scope = app.Services.CreateScope()
            Dim services = scope.ServiceProvider
            SeedData.Initialize(services)
        End Using


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


End Class


