Imports System.Security.Claims
Imports System.Text.Json
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Components.WebAssembly.Authentication
Imports Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal

Public Class CustomUserFactory
    Inherits AccountClaimsPrincipalFactory(Of RemoteUserAccount)

    Public Sub New(ByVal accessor As IAccessTokenProviderAccessor)
        MyBase.New(accessor)
    End Sub

    Public Overrides Function CreateUserAsync(ByVal account As RemoteUserAccount, ByVal options As RemoteAuthenticationUserOptions) As ValueTask(Of ClaimsPrincipal)
        Dim user = MyBase.CreateUserAsync(account, options)
        If user.Result.Identity IsNot Nothing AndAlso user.Result.Identity.IsAuthenticated Then


            If True Then
                Dim identity = CType(user.Result.Identity, ClaimsIdentity)
                Dim roleClaims = identity.FindAll(identity.RoleClaimType).ToArray()

                If roleClaims.Any() Then

                    For Each existingClaim In roleClaims
                        identity.RemoveClaim(existingClaim)
                    Next

                    Dim rolesElem = account.AdditionalProperties(identity.RoleClaimType)
                    If options.RoleClaim IsNot Nothing AndAlso
                            TypeOf rolesElem Is JsonElement Then
                        Dim roles As JsonElement = rolesElem

                        'CSharpImpl.__Assign(roles, TryCast(rolesElem, JsonElement)) IsNot Nothing Then


                        If True Then

                            If roles.ValueKind = JsonValueKind.Array Then

                                For Each role In roles.EnumerateArray()
                                    Dim roleValue = role.GetString()

                                    If Not String.IsNullOrEmpty(roleValue) Then
                                        identity.AddClaim(New Claim(options.RoleClaim, roleValue))
                                    End If
                                Next
                            Else
                                Dim roleValue = roles.GetString()

                                If Not String.IsNullOrEmpty(roleValue) Then
                                    identity.AddClaim(New Claim(options.RoleClaim, roleValue))
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return user
    End Function

End Class
