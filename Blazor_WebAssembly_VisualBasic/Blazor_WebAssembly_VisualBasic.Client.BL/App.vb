Imports Blazored.LocalStorage
Imports Microsoft.AspNetCore.Components

Public Class App : Inherits ComponentBase
    <Inject()> Property LocalStorage As ILocalStorageService
    <Inject> Property NavigationManager As NavigationManager

    Protected isInitialized As Boolean 'لضمان عدم اظهار الصفحة الرئيسية قبل الإنتهاء من تحديد اللغة
    Protected Overrides Async Function OnInitializedAsync() As Task
        Try
            gLocalStorage = LocalStorage
            gNavigationManager = NavigationManager
            gApp = Me

            Await Set_Current_language()

        Catch ex As Exception

        End Try
        Await MyBase.OnInitializedAsync()
        isInitialized = True 'لضمان إكتمال التهيئة

    End Function
    Public Overloads Sub StateHasChanged()
        MyBase.StateHasChanged()
    End Sub

End Class
