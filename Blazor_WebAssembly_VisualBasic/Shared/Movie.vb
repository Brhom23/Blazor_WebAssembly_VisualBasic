Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
'الصفحة التي تحتوي على  Validation
'https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/validation?view=aspnetcore-8.0&tabs=visual-studio

Public Class Movie
    Property Id As Integer

    <StringLength(60, MinimumLength:=3)>
    <Required>
    Property Title As String

    <DataType(DataType.Date)>
    <Range(GetType(DateTime), "1/1/1966", "1/1/2090")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Property ReleaseDate As DateTime

    <RegularExpression("^[A-Z]+[a-zA-Z\s]*$")>
    <Required>
    <StringLength(30)>
    Property Genre As String

    <RegularExpression("^[A-Z]+[a-zA-Z0-9""'\s-]*$")>
    <StringLength(5)>
    <Required>
    Property Rating As String = String.Empty

    <Range(0, 1000)>
    <DataType(DataType.Currency)>
    <Column(TypeName:="decimal(18, 2)")>
    Property Price As Decimal
End Class
