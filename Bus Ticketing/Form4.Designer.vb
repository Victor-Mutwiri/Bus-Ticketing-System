<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dataGridViewBooking = New System.Windows.Forms.DataGridView()
        Me.btnLogOut = New System.Windows.Forms.Button()
        CType(Me.dataGridViewBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridViewBooking
        '
        Me.dataGridViewBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewBooking.Location = New System.Drawing.Point(34, 25)
        Me.dataGridViewBooking.Name = "dataGridViewBooking"
        Me.dataGridViewBooking.Size = New System.Drawing.Size(724, 351)
        Me.dataGridViewBooking.TabIndex = 0
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.Black
        Me.btnLogOut.Font = New System.Drawing.Font("Corbel", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.ForeColor = System.Drawing.Color.White
        Me.btnLogOut.Location = New System.Drawing.Point(350, 383)
        Me.btnLogOut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(120, 54)
        Me.btnLogOut.TabIndex = 64
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.dataGridViewBooking)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.dataGridViewBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dataGridViewBooking As DataGridView
    Friend WithEvents btnLogOut As Button
End Class
