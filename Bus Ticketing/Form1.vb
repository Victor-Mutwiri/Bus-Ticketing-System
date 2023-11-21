Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim conn As New MySqlConnection("Data Source=localhost; database=busticketing;Username=root;Password=V36946027m")
        conn.Open()
        Dim cmd As New MySqlCommand("Select *From login WHERE username=@username AND password=@password", conn)
        cmd.Parameters.AddWithValue("username", txtUsername.Text.Trim)
        cmd.Parameters.AddWithValue("password", txtPassword.Text.Trim)
        Dim reader As MySqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            Form4.Show()
            Me.Hide()
            Dim t As Control
            For Each t In Me.Controls
                If TypeOf t Is TextBox Then
                    t.Text = ""
                End If
            Next
        Else
            MsgBox("Incorrect Username or password")
            For Each t In Me.Controls
                If TypeOf t Is TextBox Then
                    t.Text = ""
                End If
            Next
        End If
        conn.Close()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class
