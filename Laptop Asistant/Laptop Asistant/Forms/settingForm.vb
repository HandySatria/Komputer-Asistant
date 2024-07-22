Imports System.Data.OleDb
Imports Microsoft.Win32
Public Class settingForm
    Private adapter As OleDbDataAdapter
    Private table As DataTable
    Dim loadCode As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnToken.Click
        If btnToken.Text = "Edit" Then
            txtToken.Enabled = True
            btnToken.Text = "Simpan"
            btnToken.BackColor = Color.Turquoise
        Else
            saveSettingVarchar("token", txtToken.Text, True)
            token = txtToken.Text
            txtToken.Enabled = False
            btnToken.BackColor = Color.Wheat
            btnToken.Text = "Edit"
        End If
    End Sub

    Private Sub settingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNotif.Enabled = False
        txtPwd.Enabled = False
        txtToken.Enabled = False
        cboNotif.Enabled = False
        cboPwd.Enabled = False
        'cboStartUp.Enabled = False
        loadCode = 0
        DataGridView1.Enabled = False
        Try
            Dim query As String = "SELECT key, value FROM ref_setting_varchar"
            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    connection.Open()
                    Using reader As OleDbDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                If reader("key").ToString = "token" Then
                                    txtToken.Text = reader("value").ToString
                                ElseIf reader("key").ToString = "password" Then
                                    txtPwd.Text = reader("value").ToString
                                ElseIf reader("key").ToString = "notif" Then
                                    txtNotif.Text = reader("value").ToString
                                End If
                            End While
                        Else
                            MessageBox.Show("No rows found.")
                        End If
                    End Using
                End Using
                connection.Close()
            End Using

            query = "SELECT key, value FROM ref_setting_boolean"
            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    connection.Open()
                    Using reader As OleDbDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                If reader("key").ToString = "notif" Then
                                    cboNotif.Checked = reader("value")
                                ElseIf reader("key").ToString = "startup" Then
                                    cboStartUp.Checked = reader("value")
                                End If
                            End While
                        Else
                            MessageBox.Show("No rows found.")
                        End If
                    End Using
                End Using
                connection.Close()
            End Using

            query = "SELECT * FROM [m_user]"
            Try
                Using connection As New OleDbConnection(connectionString)
                    adapter = New OleDbDataAdapter(query, connection)
                    Dim builder As New OleDbCommandBuilder(adapter)

                    table = New DataTable()
                    adapter.Fill(table)
                    DataGridView1.DataSource = table

                    ' Sembunyikan kolom id_user di DataGridView
                    DataGridView1.Columns("ID").Visible = False
                    DataGridView1.Columns("password").Visible = False
                    DataGridView1.Columns("is_admin").Visible = False
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPwd_Click(sender As Object, e As EventArgs) Handles btnPwd.Click
        If btnPwd.Text = "Edit" Then
            txtPwd.Enabled = True
            cboPwd.Enabled = True
            btnPwd.Text = "Simpan"
            btnPwd.BackColor = Color.Turquoise
        Else
            saveSettingVarchar("password", txtPwd.Text, True)
            txtPwd.Enabled = False
            cboPwd.Enabled = False
            btnPwd.Text = "Edit"
            btnPwd.BackColor = Color.Wheat
        End If
    End Sub

    Private Sub btnNotif_Click(sender As Object, e As EventArgs) Handles btnNotif.Click
        If btnNotif.Text = "Edit" Then
            txtNotif.Enabled = True
            cboNotif.Enabled = True
            btnNotif.Text = "Simpan"
            btnNotif.BackColor = Color.Turquoise
        Else
            saveSettingVarchar("notif", txtNotif.Text, False)
            If cboNotif.Checked = True Then
                saveSettingBoolean("notif", True, True)
            Else
                saveSettingBoolean("notif", False, True)
            End If
            txtNotif.Enabled = False
            cboNotif.Enabled = False
            btnNotif.Text = "Edit"
            btnNotif.BackColor = Color.Wheat
            intervalNotif = txtNotif.Text

        End If
    End Sub


    Private Function saveSettingVarchar(ByVal key As String, ByVal value As String, ByVal isSuccessMessage As Boolean)
        Try
            Dim query As String = "UPDATE ref_setting_varchar SET [value] = @value WHERE [key] = @key"
            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    ' Gunakan parameter untuk nilai yang akan diupdate
                    command.Parameters.AddWithValue("@value", value)
                    command.Parameters.AddWithValue("@key", key)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            If isSuccessMessage Then
                MessageBox.Show("Update Berhasil")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function saveSettingBoolean(ByVal key As String, ByVal value As Boolean, ByVal isSuccessMessage As Boolean)
        Try
            Dim query As String = "UPDATE ref_setting_boolean SET [value] = @value WHERE [key] = @key"
            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    ' Gunakan parameter untuk nilai yang akan diupdate
                    command.Parameters.AddWithValue("@value", value)
                    command.Parameters.AddWithValue("@key", key)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            If isSuccessMessage Then
                MessageBox.Show("Update Berhasil")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        If btnUser.Text = "Edit" Then
            DataGridView1.Enabled = True
            btnUser.Text = "Simpan"
            btnUser.BackColor = Color.Turquoise
        Else
            SaveUserData()
            DataGridView1.Enabled = False
            btnUser.Text = "Edit"
            btnUser.BackColor = Color.Wheat
        End If
    End Sub


    Private Sub SaveUserData()
        Try
            Using connection As New OleDbConnection(connectionString)
                connection.Open()

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If IsNumeric(If(Not IsDBNull(row.Cells("id_telegram").Value) AndAlso row.Cells("id_telegram").Value IsNot Nothing, row.Cells("id_telegram").Value.ToString(), 1)) = False Then
                        MessageBox.Show("id telegram harus angka")
                        GoTo out
                    End If
                Next
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.IsNewRow Then Continue For

                    Dim ID As Integer = If(Not IsDBNull(row.Cells("ID").Value) AndAlso row.Cells("ID").Value IsNot Nothing, Convert.ToInt32(row.Cells("ID").Value), -1)
                    Dim id_telegram As String = If(Not IsDBNull(row.Cells("id_telegram").Value) AndAlso row.Cells("id_telegram").Value IsNot Nothing, row.Cells("id_telegram").Value.ToString(), "")
                    Dim nama_user As String = If(Not IsDBNull(row.Cells("nama_user").Value) AndAlso row.Cells("nama_user").Value IsNot Nothing, row.Cells("nama_user").Value.ToString(), "")
                    Dim password As String = If(Not IsDBNull(row.Cells("password").Value) AndAlso row.Cells("password").Value IsNot Nothing, row.Cells("password").Value.ToString(), "")

                    If ID <> -1 AndAlso String.IsNullOrEmpty(id_telegram) Then
                        ' DELETE operation
                        Dim deleteQuery As String = "DELETE FROM [m_user] WHERE [ID] = @ID"
                        Using command As New OleDbCommand(deleteQuery, connection)
                            command.Parameters.AddWithValue("@ID", ID)
                            command.ExecuteNonQuery()
                        End Using
                    ElseIf ID <> -1 Then
                        ' UPDATE operation
                        Dim updateQuery As String = "UPDATE [m_user] SET [id_telegram] = @id_telegram, [nama_user] = @nama_user, [password] = @password WHERE [ID] = @ID"
                        Using command As New OleDbCommand(updateQuery, connection)
                            command.Parameters.AddWithValue("@id_telegram", id_telegram)
                            command.Parameters.AddWithValue("@nama_user", nama_user)
                            command.Parameters.AddWithValue("@password", password)
                            command.Parameters.AddWithValue("@ID", ID)
                            command.ExecuteNonQuery()
                        End Using
                    ElseIf ID = -1 AndAlso String.IsNullOrEmpty(id_telegram) = False Then
                        ' INSERT operation
                        Dim insertQuery As String = "INSERT INTO [m_user] ([id_telegram], [nama_user], [password]) VALUES (@id_telegram, @nama_user, @password)"
                        Using command As New OleDbCommand(insertQuery, connection)
                            command.Parameters.AddWithValue("@id_telegram", id_telegram)
                            command.Parameters.AddWithValue("@password", password)
                            command.Parameters.AddWithValue("@nama_user", nama_user)
                            command.ExecuteNonQuery()
                        End Using
                    End If
                Next

                MessageBox.Show("Changes saved successfully!")
out:
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub AddApplicationToStartup()
        Try
            Dim appName As String = "MyApplication" ' Nama aplikasi Anda
            Dim appPath As String = Application.ExecutablePath ' Path executable aplikasi Anda
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            If Not IsApplicationInStartup() Then
                key.SetValue(appName, appPath)
                MsgBox("Aplikasi ditambahkan ke startup.")
            Else
                MsgBox("Aplikasi sudah ada di startup.")
            End If
        Catch ex As Exception
            MsgBox("Gagal menambahkan aplikasi ke startup: " & ex.Message)
        End Try
    End Sub

    Public Sub RemoveApplicationFromStartup()
        Try
            Dim appName As String = "MyApplication" ' Nama aplikasi Anda
            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

            If IsApplicationInStartup() Then
                key.DeleteValue(appName)
                MsgBox("Aplikasi dihapus dari startup.")
            Else
                MsgBox("Aplikasi tidak ditemukan di startup.")
            End If
        Catch ex As Exception
            MsgBox("Gagal menghapus aplikasi dari startup: " & ex.Message)
        End Try
    End Sub

    Public Function IsApplicationInStartup() As Boolean
        Dim appName As String = "MyApplication" ' Nama aplikasi Anda
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False)

        If key.GetValue(appName) IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cboPwd.CheckedChanged
        If cboPwd.Checked Then
            txtPwd.PasswordChar = ""
        Else
            txtPwd.PasswordChar = "*"
        End If
    End Sub

    Private Sub cboStartUp_CheckedChanged(sender As Object, e As EventArgs) Handles cboStartUp.CheckedChanged
        If loadCode = 1 Then
            If cboStartUp.Checked = True Then
                saveSettingBoolean("startup", True, True)
                AddApplicationToStartup()
            Else
                saveSettingBoolean("startup", False, True)
                RemoveApplicationFromStartup()
            End If
        End If
        loadCode = 1
    End Sub


End Class