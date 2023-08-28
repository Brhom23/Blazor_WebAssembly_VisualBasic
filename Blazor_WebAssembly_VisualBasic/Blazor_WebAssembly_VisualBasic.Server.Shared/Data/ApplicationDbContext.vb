Imports Blazor_WebAssembly_VisualBasic.Shared
Imports Duende.IdentityServer.EntityFramework.Options
Imports Microsoft.AspNetCore.ApiAuthorization.IdentityServer
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Options

Public Class ApplicationDbContext
    Inherits ApiAuthorizationDbContext(Of ApplicationUser)
    Public Sub New(ByVal options As DbContextOptions, ByVal operationalStoreOptions As IOptions(Of OperationalStoreOptions))
        MyBase.New(options, operationalStoreOptions)
    End Sub

    Public Property Movie As DbSet(Of Movie) '= default!

End Class
