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
13 - Convert Server.Shared Project To VB
14 - In Server.Shared folder deletet *.csproj, *.cs  files
15 - Rebulde Server.Shared.
16 - Delete Namespace line in vb code 
17 - 
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
18 - In Server.Identity project replace all "Blazor_WebAssembly_VisualBasic.Server.Models" to "Blazor_WebAssembly_VisualBasic.Server.Shared"
19 - Rebulde 
20 - in "Server" Project Right click -> add -> Project reference .
	Select 
		Server.Identity Project
		Server.Shared Project
		Shared Project
21 - On Server Project Double click Then delete line contian "Shared.csproj"
22 - Convert "Server" Project To VB
23 - Delete Namespaces line in vb code in Server project
24 - in Program.vb convert line 
		Dim connectionString = If(builder.Configuration.GetConnectionString("DefaultConnection")
	with
		Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        	If connectionString & "" = "" Then
        	    Throw New InvalidOperationException("Connection string 'DefaultConnection' not found.")
        	End If
25 - in Program.vb Delete CSharpImpl Class
26 - in "Server" project move all files in "Properties" folder to "My Project" folder.
28 - in "Server" project Delete "Properties" folder
29 - Rebulde "Server" project
30 - in "Client" Project Right click -> add -> Project reference .
	Select 
		Shared Project
31 - On "Client" Project Double click Then delete line contian "Shared.csproj"
32 - Rebulde "Client" Project

33 - In Solution add Class Library Visual Basic with name *.Client.Code "Blazor_WebAssembly_VisualBasic.Client.Code"
