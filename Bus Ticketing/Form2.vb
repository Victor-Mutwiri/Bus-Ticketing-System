Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form2
    Dim conn As New MySqlConnection("Data Source=localhost; database=busticketing;Username=root;Password=V36946027m")
    Private Sub load_data()
        ' conn.Open()
        ' Dim cmd1 As New MySqlCommand("Select passengerID, vehicle, destination, payment_mode, amount, tickets from booking", conn)
        ' Dim da As New MySqlDataAdapter
        ' da.SelectCommand = cmd1
        ' Dim dt As New DataTable
        ' dt.Clear()
        ' da.Fill(dt)
        ' DataGridView1.DataSource = dt
        ' conn.Close()
    End Sub
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim DTA As New MySqlDataAdapter

    Dim Server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "V36946027m"
    Dim database As String = "busticketing"

    Private bitmap As Bitmap

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        ' Create an instance of the next form
        Dim nextForm As New Form1()

        ' Show the next form and hide the current form
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        ' Validate ID length
        If txtID.Text.Length <> 8 Then
            MessageBox.Show("ID must be 8 digits long.")
            Return ' Exit the method if validation fails
        End If

        ' Validate phone number length
        If txtTel.Text.Length <> 10 Then
            MessageBox.Show("Phone number must be 10 digits long.")
            Return ' Exit the method if validation fails
        End If

        ' Validate that required fields are not empty
        If String.IsNullOrEmpty(txtName.Text) OrElse
        String.IsNullOrEmpty(cmbGender.Text) OrElse
        String.IsNullOrEmpty(txtTel.Text) OrElse
        String.IsNullOrEmpty(txtID.Text) OrElse
        String.IsNullOrEmpty(txtAmount.Text) OrElse
        String.IsNullOrEmpty(cmbVehicle.Text) OrElse
        String.IsNullOrEmpty(cmbDestination.Text) OrElse
        String.IsNullOrEmpty(cmbPaymentmethod.Text) OrElse
        String.IsNullOrEmpty(cmbTickets.Text) OrElse
        String.IsNullOrEmpty(cmbSchedule.Text) Then

            MessageBox.Show("Please fill in all required fields.")
            Return ' Exit the method if validation fails
        End If

        ' Continue with the insertion if the validation passes

        ' Insert into booking table
        Dim cmd2 As New MySqlCommand("Insert into booking(passengerID, vehicle, destination, payment_mode, amount, tickets)values(@passengerID, @vehicle, @destination, @payment_mode, @amount, @tickets)", conn)
        cmd2.Parameters.AddWithValue("passengerID", txtID.Text)
        cmd2.Parameters.AddWithValue("vehicle", cmbVehicle.Text)
        cmd2.Parameters.AddWithValue("destination", cmbDestination.Text)
        cmd2.Parameters.AddWithValue("payment_mode", cmbPaymentmethod.Text)
        cmd2.Parameters.AddWithValue("amount", txtAmount.Text)
        cmd2.Parameters.AddWithValue("tickets", cmbTickets.Text)
        conn.Open()
        cmd2.ExecuteNonQuery()
        conn.Close()

        ' Insert into passenger table
        Dim cmd3 As New MySqlCommand("Insert into passenger(Passenger_name, Gender, phone, passengerID)values(@Passenger_name, @Gender, @phone, @passengerID)", conn)
        cmd3.Parameters.AddWithValue("Passenger_name", txtName.Text)
        cmd3.Parameters.AddWithValue("Gender", cmbGender.Text)
        cmd3.Parameters.AddWithValue("phone", txtTel.Text)
        cmd3.Parameters.AddWithValue("passengerID", txtID.Text)
        conn.Open()
        cmd3.ExecuteNonQuery()
        conn.Close()

        ' Insert into trip table
        Dim cmd4 As New MySqlCommand("Insert into trip(destination, departure_time, vehicle)values(@destination, @departure_time, @vehicle)", conn)
        cmd4.Parameters.AddWithValue("destination", cmbDestination.Text)
        cmd4.Parameters.AddWithValue("departure_time", cmbSchedule.Text)
        cmd4.Parameters.AddWithValue("vehicle", cmbVehicle.Text)
        conn.Open()
        cmd4.ExecuteNonQuery()
        conn.Close()

        ' Query the database to get the bookingID
        Dim bookingID As String = GetBookingID()

        ' Display a popup message with booking details
        Dim bookingDetails As String = $"Booking ID: {bookingID}" & vbCrLf &
                                   $"Vehicle: {cmbVehicle.Text}" & vbCrLf &
                                   $"Destination: {cmbDestination.Text}" & vbCrLf &
                                   $"Payment Mode: {cmbPaymentmethod.Text}" & vbCrLf &
                                   $"Tickets: {cmbTickets.Text}" & vbCrLf &
                                   $"Amount: {txtAmount.Text}" & vbCrLf &
                                   $"Booking Date: {DateTime.Now.ToString("yyyy-MM-dd")}"

        MessageBox.Show(bookingDetails, "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Prompt the user to save the details to a text file
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt"
        saveFileDialog.Title = "Save Booking Details"
        saveFileDialog.FileName = $"Booking_{bookingID}.txt"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Save the booking details to the selected text file
            Try
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    writer.WriteLine(bookingDetails)
                End Using
                MessageBox.Show($"Booking details saved to {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show($"Error saving booking details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Clear values after insertion
        For Each t In Me.Controls
            If TypeOf t Is TextBox Then
                DirectCast(t, TextBox).Text = ""
            End If
        Next

        ' Clear combo box values
        cmbDestination.Text = ""
        cmbGender.Text = ""
        cmbPaymentmethod.Text = ""
        cmbSchedule.Text = ""
        cmbTickets.Text = ""
        cmbVehicle.Text = ""

        ' Reload data (if needed)
        load_data()
    End Sub

    Private Function GetBookingID() As String
        ' Query the database to get the latest bookingID
        ' You need to replace this with the actual query to retrieve the bookingID from the database
        ' For example, you might use SELECT MAX(bookingID) FROM booking
        ' Execute the query and return the result

        ' Replace the following line with the actual query to get the bookingID
        Dim query As String = "SELECT MAX(bookingID) FROM booking"
        Dim cmd As New MySqlCommand(query, conn)

        conn.Open()
        Dim result As Object = cmd.ExecuteScalar()
        conn.Close()

        ' Convert the result to string or handle null values appropriately
        Return If(result IsNot Nothing, result.ToString(), "N/A")
    End Function





    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim t As Control
        For Each t In Me.Controls
            If TypeOf t Is TextBox Then
                t.Text = ""
            End If
            cmbDestination.Text = ""
            cmbGender.Text = ""
            cmbPaymentmethod.Text = ""
            cmbSchedule.Text = ""
            cmbTickets.Text = ""
            cmbVehicle.Text = ""

        Next
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field accepts letters only")
        End If
        If txtName.Text.Length >= 70 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("Reduce characters")
            End If
        End If
    End Sub

    Private Sub txtTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field accepts numbers only")

        End If
        If txtTel.Text.Length > 10 And txtTel.Text.Length < 10 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("Phone number must have 10 digits")
            End If
        End If
    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field accepts numbers only")
        End If
        If txtID.Text.Length > 8 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("ID number cannot have more than 8 digits")
            End If
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If txtName.Text.Length >= 70 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
                MessageBox.Show("Reduce characters")
            End If
        End If
    End Sub

    Private Sub cmbDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestination.SelectedIndexChanged

    End Sub
End Class