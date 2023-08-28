Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Movie
    Public Property Id As Integer
    Public Property Title As String
    <DataType(DataType.Date)>
    Public Property ReleaseDate As DateTime
    Public Property Genre As String
    <Column(TypeName:="decimal(18,2)")>
    Public Property Price As Decimal
End Class
