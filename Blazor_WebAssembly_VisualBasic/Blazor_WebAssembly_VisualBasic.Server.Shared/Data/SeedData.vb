Imports Blazor_WebAssembly_VisualBasic.Shared
Imports Duende.IdentityServer.EntityFramework.Options
Imports Microsoft.AspNetCore.Identity
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.DependencyInjection

Public Module SeedData
    Sub Initialize(ByVal serviceProvider As IServiceProvider)

        'Using context = New ApplicationDbContext(serviceProvider.GetRequiredService(Of DbContextOptions(Of ApplicationDbContext))(), Nothing)
        Using context = serviceProvider.GetService(Of ApplicationDbContext)()

            If context Is Nothing OrElse context.Movie Is Nothing Then
                Throw New ArgumentNullException("Null ApplicationDbContext")
            End If

            If context.Movie.Any Then
                Return
            End If

            context.Movie.AddRange(New Movie With {
                .Title = "When Harry Met Sally",
                .ReleaseDate = DateTime.Parse("1989-2-12"),
                .Genre = "Romantic Comedy",
                .Price = 7.99D
            }, New Movie With {
                .Title = "Ghostbusters ",
                .ReleaseDate = DateTime.Parse("1984-3-13"),
                .Genre = "Comedy",
                .Price = 8.99D
            }, New Movie With {
                .Title = "Ghostbusters 2",
                .ReleaseDate = DateTime.Parse("1986-2-23"),
                .Genre = "Comedy",
                .Price = 9.99D
            }, New Movie With {
                .Title = "Rio Bravo",
                .ReleaseDate = DateTime.Parse("1959-4-15"),
                .Genre = "Western",
                .Price = 3.99D
            })
            context.SaveChanges()
        End Using
    End Sub
End Module
