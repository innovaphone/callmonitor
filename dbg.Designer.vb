<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dbg
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dbglv = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'dbglv
        '
        Me.dbglv.Location = New System.Drawing.Point(34, 55)
        Me.dbglv.Name = "dbglv"
        Me.dbglv.Size = New System.Drawing.Size(628, 338)
        Me.dbglv.TabIndex = 0
        Me.dbglv.UseCompatibleStateImageBehavior = False
        '
        'dbg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 443)
        Me.Controls.Add(Me.dbglv)
        Me.Name = "dbg"
        Me.Text = "dbg"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents dbglv As System.Windows.Forms.ListView
End Class
