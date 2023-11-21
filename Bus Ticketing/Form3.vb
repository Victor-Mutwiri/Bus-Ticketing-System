Imports MySql.Data.MySqlClient

Public Class Form3
    Dim conn As New MySqlConnection("Data Source=localhost; database=busticketing;Username=root;Password=V36946027m")
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim cmd1 As New MySqlCommand("Insert into login(username, password)values(@username, @password)", conn)
        cmd1.Parameters.AddWithValue("username", txtUsername.Text)
        cmd1.Parameters.AddWithValue("password", txtPassword.Text)
        conn.Open()
        cmd1.ExecuteNonQuery()
        conn.Close()

        For Each t In Me.Controls
            If TypeOf t Is TextBox Then
                t.Text = ""
            End If
        Next

        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If txtPassword.Text.Length >= 45 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("Reduce characters")
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If txtUsername.Text.Length >= 25 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("Reduce characters")
            End If
        End If
    End Sub
End Class