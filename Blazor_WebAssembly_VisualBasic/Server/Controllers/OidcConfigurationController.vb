Imports Microsoft.AspNetCore.ApiAuthorization.IdentityServer
Imports Microsoft.AspNetCore.Mvc

Public Class OidcConfigurationController
    Inherits Controller
    Private ReadOnly _logger As Microsoft.Extensions.Logging.ILogger(Of OidcConfigurationController)

    Public Sub New(ByVal clientRequestParametersProvider As IClientRequestParametersProvider, ByVal logger As Microsoft.Extensions.Logging.ILogger(Of OidcConfigurationController))
        Me.ClientRequestParametersProvider = clientRequestParametersProvider
        _logger = logger
    End Sub

    Public ReadOnly Property ClientRequestParametersProvider As IClientRequestParametersProvider

    <HttpGet("_configuration/{clientId}")>
    Public Function GetClientRequestParameters(
    <FromRoute> ByVal clientId As String) As IActionResult
        Dim parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId)
        Return MyBase.Ok(parameters)
    End Function
End Class