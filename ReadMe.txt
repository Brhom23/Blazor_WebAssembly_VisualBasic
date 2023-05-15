 1 - In Visual Studio Menu -> Extensions -> Manage Extansions -> Code Converter (VB - C#) -> Download
 2 - close Visual Sttudio Then complet setup code converer. To convert project to vb Right click on project then select convert to VB
 3 - Create Project -> Blazor WebAssembly App
 4 - set
	* Authentication Type -> Indivdual Accounts
	* ASP.NET Cor Hosted
	* Progressiv Web Application
	* Do not use top-level statment
 5 - Convert Shared Project to VB.
 6 - In Shared folder deletet *.csproj, *.cs  files
 7 - In Solution add Razor Class Library c# with name *.Server.Identity 
 8 - In Solution add Class Library C# with name *.Server.Shared
	===============================Blazor_WebAssembly_VisualBasic.Server.Identity
 9 - Move Areas folder from Server Project to Server.Identity Project
10 - Move Pages folder from Server Project to Server.Identity Project
11 - Move Data folder from Server Project to Server.Shared Project
12 - Move Models folder from Server Project to Server.Shared Project
13 - Delete Migrations folder
14 - Convert Server.Shared Project To VB
15 - In Server.Shared folder deletet *.csproj, *.cs  files
16 - Rebulde Server.Shared.
17 - Delete Namespace line in vb code 
18 - 
add
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="7.0.2" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="7.0.2" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="7.0.2" />
    <PackageReference Include="Microsoft.AspNetCore.ApiAuthorization.IdentityServer" Version="7.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.2" />
  </ItemGroup>
in to 	*.Server.Identity.csproj
19 - In Server.Identity project replace all "Blazor_WebAssembly_VisualBasic.Server.Models" to "Blazor_WebAssembly_VisualBasic.Server.Shared"
20 - Rebulde 
21 - in "Server" Project Right click -> add -> Project reference .
	Select 
		Server.Identity Project
		Server.Shared Project
		Shared Project
22 - On Server Project Double click Then delete line contian "Shared.csproj"
23 - Convert "Server" Project To VB
24 - Delete Namespaces line in vb code in Server project
25 - in Program.vb convert line 
		Dim connectionString = If(builder.Configuration.GetConnectionString("DefaultConnection")
	to
		Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        	If connectionString & "" = "" Then
        	    Throw New InvalidOperationException("Connection string 'DefaultConnection' not found.")
        	End If
26 - in Program.vb convert line 
		builder.Services.AddDbContext(Of ApplicationDbContext)(Sub(options) options.UseSqlServer(connectionString))
		to
		builder.Services.AddDbContext(Of ApplicationDbContext)(Sub(options) options.UseSqlServer(connectionString, Function(b) b.MigrationsAssembly("Blazor_WebAssembly_VisualBasic.Server.Identity")))
	to perform the migration process
27 - in Program.vb Delete CSharpImpl Class
28 - in "Server" project move all files in "Properties" folder to "My Project" folder.
29 - in "Server" project Delete "Properties" folder
30 - Rebulde "Server" project
31 - in "Client" Project Right click -> add -> Project reference .
	Select 
		Shared Project
32 - On "Client" Project Double click Then delete line contian "Shared.csproj"
33 - Rebulde "Client" Project
34 - In Solution add Class Library Visual Basic with name *.Client.Code "Blazor_WebAssembly_VisualBasic.Client.Code"
35 - In Visual Studio, use the Package Manager Console to scaffold a new migration and apply it to the database:
		- In the Default Project drop-down list, choose "*.Server.Identity" Project
		- PM> Add-Migration CreateIdentitySchema
		- PM> Update-Database