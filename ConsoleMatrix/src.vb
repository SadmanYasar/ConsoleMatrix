Module src
    Structure Vector2
        Dim x As Integer
        Dim y As Integer
    End Structure

    Dim Window As Vector2
    Dim ScreenData(20, 20) As String

    Sub MoveDown(ByVal x As Integer, ByVal y As Integer)
        ScreenData(x, y) = "   "
        If (y - 1 < 0) Then
            y = Window.y
        Else
            y = y - 1
        End If
        ScreenData(x, y) = " " + (Int(Rnd() * 9) + 1).ToString + " "
    End Sub

    Sub Update()
        Dim i, j As Integer
        For j = 0 To Window.y
            For i = 0 To Window.x
                If ScreenData(i, j) <> "   " Then
                    MoveDown(i, j)
                End If
            Next
        Next

    End Sub

    Sub Render()
        Console.CursorVisible = False
        Dim i, j As Integer
        For j = 0 To Window.y
            Console.SetCursorPosition(0, j)
            For i = 0 To Window.x
                Console.Write(ScreenData(i, j))
            Next
        Next

    End Sub

    Sub Main()
        Console.ForegroundColor = ConsoleColor.Green
        Window.x = ScreenData.GetLength(0) - 1
        Window.y = ScreenData.GetLength(1) - 1

        Dim i, j As Integer
        Const FPSTarget = 30
        Const MS_PER_UPDATE As Double = (1 / FPSTarget) * 1000

        i = 0
        j = 0

        'set randomized data value at given coordinates
        For j = 0 To Window.y
            For i = 0 To Window.x
                Dim x = Rnd()
                If (x > 0.5) Then
                    ScreenData(i, j) = " " + (Int(Rnd() * 9) + 1).ToString + " "
                Else
                    ScreenData(i, j) = "   "
                End If
            Next
        Next

        Dim lastTime = (DateTime.Now - DateTime.MinValue).TotalMilliseconds
        Dim lag As Double = 0.0

        'GAME LOOP
        While True
            Dim current = (DateTime.Now - DateTime.MinValue).TotalMilliseconds
            Dim elapsed = current - lastTime

            lastTime = current
            lag = lag + elapsed

            While lag >= MS_PER_UPDATE
                Update()
                lag = lag - MS_PER_UPDATE
            End While
            Render()
        End While
    End Sub

End Module

