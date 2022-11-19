
Public Class Form1

    '========================= GLOBAL VARIABLES ======================================
    Dim A(3) As Integer
    Dim correctNumber As Integer
    Dim correctSpot As Integer
    Dim currentRow As Integer

    Sub InitialState()
        Module1.ClearAllLabel()
        Module1.DisableAllInput()
        Module1.ButtonsInitialState()
    End Sub

    '================================= FORM ONLOAD ======================================
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'On Load Disable other textbox rows
        InitialState()
    End Sub

    '========================= BUTTON START CLICKED ======================================
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'INITIALIZING COMPONENT STATES
        Button5.Enabled = False
        Button6.Enabled = True
        Button7.Enabled = True
        Module1.ClearAllLabel()
        Module1.ClearAllInput()
        Module1.HideArray()

        'INITIALZING ROW
        currentRow = 5

        'ENABLING THE CURRENT ROW
        For j = 0 To 3
            Module1.inputArr(currentRow - 1, j).Enabled = True
        Next

        Dim x As Integer
        Dim duplicateValue As Boolean

        'ASSIGN -1 IN ALL ITEM IN THE ARRAY
        A = Module1.InitalArr(A)

        For i = 0 To 3
Generate:
            duplicateValue = False
            x = Module1.GenerateNum()

            For j = 0 To 3
                If x = A(j) Then duplicateValue = True 'check if the no. already exist
            Next

            If duplicateValue = True Then GoTo Generate
            A(i) = x
        Next
    End Sub


    '========================= SUBMIT BUTTON ======================================
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim guessInput(3) As Integer
        correctSpot = 0     'RESET
        correctNumber = 0   'RESET


        For i = 0 To 3
            'ASSIGNING THE INPUT TO GUESSINPUT VAR
            guessInput(i) = Convert.ToInt32(Module1.inputArr(currentRow - 1, i).Text)
        Next

        For i = 0 To 3
            'CHEKING IF THE INPUT IS IN THE ARRAY
            If A.Contains(Convert.ToInt32(Module1.inputArr(currentRow - 1, i).Text)) Then
                correctNumber += 1
            End If
        Next

        For i = 0 To 3
            'CHEKING IF THE INPUT IS CORRECT IN ORDER
            If A(i) = guessInput(i) Then
                correctSpot += 1
            End If
        Next

        'ORIGINAL GAME
        'correctNumber -= correctSpot

        If correctSpot = 4 Then
            MsgBox("You have guessed the number")
            Module1.ButtonsInitialState()
            Module1.ClearAllInput()
            Module1.DisableAllInput()
            Module1.DisplayArray(A)
            Return
        End If

        Module1.rowLabel(currentRow - 1).Text = Convert.ToString(correctSpot) + " correct number(s) in place
         " + Convert.ToString(correctNumber) + " correct number(s)"

        Module1.rowLabel(currentRow - 1).Text = Convert.ToString(correctNumber) + " correct number(s)
        " + Convert.ToString(correctSpot) + " number(s) are in place"

        'ROW INPUT CONTROL
        If currentRow <> 1 Then
            For i = 0 To 3
                Module1.inputArr(currentRow - 1, i).Enabled = False
                Module1.inputArr(currentRow - 2, i).Enabled = True
            Next
            currentRow -= 1
        Else 'WHEN REACHED THE LAST ROW OF INPUT
            For i = 0 To 3
                Module1.inputArr(currentRow - 1, i).Enabled = False
                Button5.Enabled = True
                Button6.Enabled = False
                Button7.Enabled = False
                Module1.DisplayArray(A)
            Next
        End If

    End Sub

    '========================= STOP BUTTON ======================================
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Module1.ButtonsInitialState()
        Module1.ClearAllInput()
        Module1.DisableAllInput()
        Module1.DisplayArray(A)
    End Sub

End Class
