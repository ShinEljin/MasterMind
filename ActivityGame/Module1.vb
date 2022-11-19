

Module Module1
    Public btnArr() As Button = {Form1.Button1, Form1.Button2, Form1.Button3, Form1.Button4}
    Public inputArr(,) As TextBox = {{Form1.TextBox1, Form1.TextBox2, Form1.TextBox3, Form1.TextBox4},
                                       {Form1.TextBox5, Form1.TextBox6, Form1.TextBox7, Form1.TextBox8},
                                       {Form1.TextBox9, Form1.TextBox10, Form1.TextBox11, Form1.TextBox12},
                                       {Form1.TextBox13, Form1.TextBox14, Form1.TextBox15, Form1.TextBox16},
                                       {Form1.TextBox17, Form1.TextBox18, Form1.TextBox19, Form1.TextBox20}
                                   }
    Public rowLabel() As Label = {Form1.Label2, Form1.Label3, Form1.Label4, Form1.Label5, Form1.Label6}


    Public Sub ClearAllInput()
        For i = 0 To 4
            For j = 0 To 3
                inputArr(i, j).Text = ""
            Next
        Next
    End Sub

    Public Sub EnableAllInput()
        For i = 0 To 4
            For j = 0 To 3
                inputArr(i, j).Enabled = True
            Next
        Next
    End Sub

    Public Sub DisableAllInput()
        For i = 0 To 4
            For j = 0 To 3
                inputArr(i, j).Enabled = False
            Next
        Next
    End Sub

    Public Sub ClearAllLabel()
        For i = 0 To 4
            rowLabel(i).Text = ""
        Next
    End Sub

    Public Sub DisplayArray(theArray() As Integer)
        For i = 0 To 3
            btnArr(i).Text = theArray(i)
        Next
    End Sub

    Public Sub HideArray()
        For i = 0 To 3
            btnArr(i).Text = "?"
        Next
    End Sub

    Public Sub ButtonsInitialState()
        Form1.Button5.Enabled = True 'START BUTTON
        Form1.Button6.Enabled = False 'STOP BUTTON
        Form1.Button7.Enabled = False 'SUBMIT BUTTON
    End Sub



    'Assign -1 to all values in the array
    Public Function InitalArr(theArray() As Integer) As Integer()
        Dim newArray(theArray.Length - 1) As Integer
        For i = 0 To theArray.Length - 1
            newArray(i) = -1 'inital values
        Next
        Return newArray
    End Function

    'Function that Generate num 1-6
    Public Function GenerateNum() As Integer
        Randomize()
        Return Rnd() * 4 + 1
    End Function

End Module
