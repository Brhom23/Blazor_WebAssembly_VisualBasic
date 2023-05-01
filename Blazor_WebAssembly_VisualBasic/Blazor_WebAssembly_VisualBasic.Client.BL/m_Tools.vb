
Public Module m_Tools

    Dim mCurrent_language As SByte = -1

    Public Function L(Of T)(ParamArray A() As T) As T
        Try
            Return A(mCurrent_language)
        Catch ex As Exception
        End Try
        Try
            If mCurrent_language = -1 Then
                mCurrent_language = 0
                Return A(mCurrent_language)
            ElseIf A.Length = 0 Then
                'Return Nothing
            ElseIf A.Length < mCurrent_language + 1 Then
                Return A(0)
            End If
        Catch ex As Exception
        End Try
    End Function
    ''' <summary>
    ''' تحديد اللغة من الخازن المحلي
    ''' </summary>
    Async Function Set_Current_language() As Task
        Try
            mCurrent_language = Await gLocalStorage.GetItemAsync(Of SByte)(APP_NAME & "LANGUAGE")

        Catch ex As Exception
            mCurrent_language = 0
        End Try
    End Function
    Function Get_Current_language() As SByte
        Return mCurrent_language
    End Function
    Sub Set_Current_language(pCurrent_language As SByte)
        mCurrent_language = pCurrent_language
        Try
            gLocalStorage.SetItemAsync(APP_NAME & "LANGUAGE", mCurrent_language)
            'استخدمت المعامل الثاني لكي يتم تحميل الموقع من جديد وليس المكون فقط
            gNavigationManager.NavigateTo("", True)
        Catch ex As Exception

        End Try
    End Sub

End Module
