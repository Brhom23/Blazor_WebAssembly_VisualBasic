Public Class WeatherForecast
    Public Property [Date] As DateOnly

    Public Property TemperatureC As Integer

    Public Property Summary As String

    Public ReadOnly Property TemperatureF As Integer
        Get
            Return 32 + CInt(TemperatureC / 0.5556)
        End Get
    End Property
End Class
