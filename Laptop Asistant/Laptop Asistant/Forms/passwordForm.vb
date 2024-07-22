Public Class passwordForm
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Harap Isi Password")
        Else
            Dim query As String = "SELECT COUNT(*) FROM [ref_setting_varchar] WHERE [key] = @key and [value] = @value"
            Dim connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                command.Parameters.AddWithValue("@key", "password")
                command.Parameters.AddWithValue("@value", TextBox1.Text)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                If count > 0 Then
                    settingForm.Show()
                    Me.Close()
                Else
                    MessageBox.Show("Password Salah")
                End If
            End Using
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "*"
        End If
    End Sub
End Class