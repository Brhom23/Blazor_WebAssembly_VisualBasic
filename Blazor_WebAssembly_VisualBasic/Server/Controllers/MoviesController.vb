Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Blazor_WebAssembly_VisualBasic.Server.Shared
Imports Blazor_WebAssembly_VisualBasic.Shared
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.EntityFrameworkCore

<Route("api/[controller]")>
<ApiController>
Public Class MoviesController
    Inherits ControllerBase

    Private ReadOnly _context As ApplicationDbContext

    Public Sub New(ByVal context As ApplicationDbContext)
        _context = context
    End Sub

    <HttpGet>
    Public Async Function GetMovie() As Task(Of ActionResult(Of IEnumerable(Of Movie)))
        If _context.Movie Is Nothing Then
            Return NotFound()
        End If
        Dim lst = Await _context.Movie.ToListAsync
        Return Ok(lst)    ' .Movie.ToListAsync()
    End Function

    <HttpGet("{id}")>
    Public Async Function GetMovie(ByVal id As Integer) As Task(Of ActionResult(Of Movie))
        If _context.Movie Is Nothing Then
            Return NotFound()
        End If

        Dim movie = Await _context.Movie.FindAsync(id)

        If movie Is Nothing Then
            Return NotFound()
        End If

        Return movie
    End Function

    <HttpPut("{id}")>
    Public Async Function PutMovie(ByVal id As Integer, ByVal movie As Movie) As Task(Of IActionResult)
        If id <> movie.Id Then
            Return BadRequest()
        End If

        _context.Entry(movie).State = EntityState.Modified

        Try
            Await _context.SaveChangesAsync()
        Catch __unusedDbUpdateConcurrencyException1__ As DbUpdateConcurrencyException

            If Not MovieExists(id) Then
                Return NotFound()
            Else
                Throw
            End If
        End Try

        Return NoContent()
    End Function

    <HttpPost>
    Public Async Function PostMovie(ByVal movie As Movie) As Task(Of ActionResult(Of Movie))
        If _context.Movie Is Nothing Then
            Return Problem("Entity set 'WebApplicationAPIContext.Movie'  is null.")
        End If

        _context.Movie.Add(movie)
        Await _context.SaveChangesAsync()
        Return CreatedAtAction("GetMovie", New With {Key .id = movie.Id}, movie)
    End Function

    <HttpDelete("{id}")>
    Public Async Function DeleteMovie(ByVal id As Integer) As Task(Of IActionResult)
        If _context.Movie Is Nothing Then
            Return NotFound()
        End If

        Dim movie = Await _context.Movie.FindAsync(id)

        If movie Is Nothing Then
            Return NotFound()
        End If

        _context.Movie.Remove(movie)
        Await _context.SaveChangesAsync()
        Return NoContent()
    End Function

    Private Function MovieExists(ByVal id As Integer) As Boolean
        Return (_context.Movie?.Any(Function(e) e.Id = id)).GetValueOrDefault()
    End Function
End Class
