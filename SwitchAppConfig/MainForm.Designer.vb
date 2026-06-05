<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtRutaConfig = New System.Windows.Forms.TextBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.btnDom = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.btnAplicarPersonalizado = New System.Windows.Forms.Button()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.btnRestaurarBackup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(12, 15)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(84, 13)
        Me.lblRuta.TabIndex = 0
        Me.lblRuta.Text = "Archivo .config:"
        '
        'txtRutaConfig
        '
        Me.txtRutaConfig.Location = New System.Drawing.Point(102, 12)
        Me.txtRutaConfig.Name = "txtRutaConfig"
        Me.txtRutaConfig.Size = New System.Drawing.Size(566, 20)
        Me.txtRutaConfig.TabIndex = 1
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(674, 10)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(98, 23)
        Me.btnExaminar.TabIndex = 2
        Me.btnExaminar.Text = "Examinar..."
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(12, 47)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(112, 13)
        Me.lblServidor.TabIndex = 3
        Me.lblServidor.Text = "Servidor personalizado:"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(130, 44)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(262, 20)
        Me.txtServidor.TabIndex = 4
        '
        'btnDom
        '
        Me.btnDom.Location = New System.Drawing.Point(15, 79)
        Me.btnDom.Name = "btnDom"
        Me.btnDom.Size = New System.Drawing.Size(180, 32)
        Me.btnDom.TabIndex = 5
        Me.btnDom.Text = "Poner en DOM"
        Me.btnDom.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.Location = New System.Drawing.Point(201, 79)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(191, 32)
        Me.btnCliente.TabIndex = 6
        Me.btnCliente.Text = "Poner en app01\vectorerp"
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'btnAplicarPersonalizado
        '
        Me.btnAplicarPersonalizado.Location = New System.Drawing.Point(398, 42)
        Me.btnAplicarPersonalizado.Name = "btnAplicarPersonalizado"
        Me.btnAplicarPersonalizado.Size = New System.Drawing.Size(180, 23)
        Me.btnAplicarPersonalizado.TabIndex = 7
        Me.btnAplicarPersonalizado.Text = "Aplicar personalizado"
        Me.btnAplicarPersonalizado.UseVisualStyleBackColor = True
        '
        'lstLog
        '
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.HorizontalScrollbar = True
        Me.lstLog.Location = New System.Drawing.Point(15, 126)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(757, 303)
        Me.lstLog.TabIndex = 8
        '
        'btnRestaurarBackup
        '
        Me.btnRestaurarBackup.Location = New System.Drawing.Point(584, 42)
        Me.btnRestaurarBackup.Name = "btnRestaurarBackup"
        Me.btnRestaurarBackup.Size = New System.Drawing.Size(188, 23)
        Me.btnRestaurarBackup.TabIndex = 9
        Me.btnRestaurarBackup.Text = "Restaurar desde .bak"
        Me.btnRestaurarBackup.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 450)
        Me.Controls.Add(Me.btnRestaurarBackup)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.btnAplicarPersonalizado)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.btnDom)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.lblServidor)
        Me.Controls.Add(Me.btnExaminar)
        Me.Controls.Add(Me.txtRutaConfig)
        Me.Controls.Add(Me.lblRuta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Switch App Config"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRuta As Label
    Friend WithEvents txtRutaConfig As TextBox
    Friend WithEvents btnExaminar As Button
    Friend WithEvents lblServidor As Label
    Friend WithEvents txtServidor As TextBox
    Friend WithEvents btnDom As Button
    Friend WithEvents btnCliente As Button
    Friend WithEvents btnAplicarPersonalizado As Button
    Friend WithEvents lstLog As ListBox
    Friend WithEvents btnRestaurarBackup As Button
End Class
