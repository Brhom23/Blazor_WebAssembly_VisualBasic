Imports IdentityModel
Imports Duende.IdentityServer.Models
Imports Duende.IdentityServer.Services

Public Class ProfileService
    Implements IProfileService

    Public Sub New()
    End Sub

    Public Async Function GetProfileDataAsync(ByVal context As ProfileDataRequestContext) As Task Implements IProfileService.GetProfileDataAsync
        Dim nameClaim = context.Subject.FindAll(JwtClaimTypes.Name)
        context.IssuedClaims.AddRange(nameClaim)
        Dim roleClaims = context.Subject.FindAll(JwtClaimTypes.Role)
        context.IssuedClaims.AddRange(roleClaims)
        Await Task.CompletedTask
    End Function

    Public Async Function IsActiveAsync(ByVal context As IsActiveContext) As Task Implements IProfileService.IsActiveAsync
        Await Task.CompletedTask
    End Function



End Class
