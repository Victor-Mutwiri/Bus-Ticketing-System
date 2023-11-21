Imports MySql.Data.MySqlClient

Public Class Form4
    Inherits System.Windows.Forms.Form

    Private conn As MySqlConnection

    Public Sub New()
        InitializeComponent()

        ' Initialize the database connection
        conn = New MySqlConnection("Data Source=localhost; database=busticketing;Username=root;Password=V36946027m")

        ' Set the DataGridView's DataSource to Nothing initially
        dataGridViewBooking.DataSource = Nothing

        ' Enable auto-generation of columns
        dataGridViewBooking.AutoGenerateColumns = True
    End Sub

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load data when the form is loaded
        LoadBookingData()
    End Sub

    Private Sub LoadBookingData()
        Try
            ' Open the database connection
            conn.Open()

            ' SQL query to retrieve all columns from the booking table
            Dim query As String = "SELECT * FROM booking"

            ' Create a MySqlCommand object
            Dim cmd As New MySqlCommand(query, conn)

            ' Create a DataAdapter to fill a DataTable
            Dim adapter As New MySqlDataAdapter(cmd)

            ' Create a DataTable to store the results
            Dim dataTable As New DataTable()

            ' Fill the DataTable with the results from the query
            adapter.Fill(dataTable)

            ' Bind the DataTable to the DataGridView
            dataGridViewBooking.DataSource = dataTable

            ' Refresh the DataGridView to reflect the loaded data
            dataGridViewBooking.Refresh()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            conn.Close()
        End Try
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class
