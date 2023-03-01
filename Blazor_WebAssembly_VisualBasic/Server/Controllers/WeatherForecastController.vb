Imports Blazor_WebAssembly_VisualBasic.Shared
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc

<Authorize>
<ApiController>
<Route("[controller]")>
Public Class WeatherForecastController
    Inherits ControllerBase
    Private Shared ReadOnly Summaries As String() = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"}

    Private ReadOnly _logger As Microsoft.Extensions.Logging.ILogger(Of WeatherForecastController)

    Public Sub New(ByVal logger As Microsoft.Extensions.Logging.ILogger(Of WeatherForecastController))
        _logger = logger
    End Sub

    <HttpGet>
    Public Function [Get]() As IEnumerable(Of WeatherForecast)
        Return Enumerable.Range(1, 5).[Select](Function(index) New WeatherForecast With {
.[Date] = DateOnly.FromDateTime(Date.Now.AddDays(index)),
.TemperatureC = Random.Shared.Next(-20, 55),
.Summary = Summaries(Random.Shared.Next(Summaries.Length))
        }).ToArray()
    End Function
End Class
