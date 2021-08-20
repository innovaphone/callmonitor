<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.events = New System.Windows.Forms.ListView
        Me.debugbot = New System.Windows.Forms.Button
        Me.dbgview = New System.Windows.Forms.ListBox
        Me.DBGcl = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Csetup = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LinkCheck = New System.Windows.Forms.Timer(Me.components)
        Me.TCPid = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'events
        '
        Me.events.Location = New System.Drawing.Point(14, 37)
        Me.events.Name = "events"
        Me.events.Size = New System.Drawing.Size(647, 129)
        Me.events.TabIndex = 0
        Me.events.UseCompatibleStateImageBehavior = False
        Me.events.View = System.Windows.Forms.View.List
        '
        'debugbot
        '
        Me.debugbot.Location = New System.Drawing.Point(371, 5)
        Me.debugbot.Name = "debugbot"
        Me.debugbot.Size = New System.Drawing.Size(54, 26)
        Me.debugbot.TabIndex = 2
        Me.debugbot.Text = "Debug"
        Me.ToolTip1.SetToolTip(Me.debugbot, "toggle display mode for debugging")
        Me.debugbot.UseVisualStyleBackColor = True
        Me.debugbot.Visible = False
        '
        'dbgview
        '
        Me.dbgview.FormattingEnabled = True
        Me.dbgview.Location = New System.Drawing.Point(14, 181)
        Me.dbgview.Name = "dbgview"
        Me.dbgview.Size = New System.Drawing.Size(647, 368)
        Me.dbgview.TabIndex = 3
        Me.dbgview.Visible = False
        '
        'DBGcl
        '
        Me.DBGcl.Location = New System.Drawing.Point(547, 5)
        Me.DBGcl.Name = "DBGcl"
        Me.DBGcl.Size = New System.Drawing.Size(54, 26)
        Me.DBGcl.TabIndex = 4
        Me.DBGcl.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.DBGcl, "clear the debug window")
        Me.DBGcl.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Csetup
        '
        Me.Csetup.Location = New System.Drawing.Point(607, 5)
        Me.Csetup.Name = "Csetup"
        Me.Csetup.Size = New System.Drawing.Size(54, 26)
        Me.Csetup.TabIndex = 9
        Me.Csetup.Text = "Setup"
        Me.ToolTip1.SetToolTip(Me.Csetup, "Set the parameter of the application (restart after to activate)")
        Me.Csetup.UseVisualStyleBackColor = True
        Me.Csetup.Visible = False
        '
        'LinkCheck
        '
        Me.LinkCheck.Interval = 10000
        '
        'TCPid
        '
        Me.TCPid.AutoSize = True
        Me.TCPid.Location = New System.Drawing.Point(227, 557)
        Me.TCPid.Name = "TCPid"
        Me.TCPid.Size = New System.Drawing.Size(36, 13)
        Me.TCPid.TabIndex = 12
        Me.TCPid.Text = "TCPid"
        Me.TCPid.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 574)
        Me.Controls.Add(Me.TCPid)
        Me.Controls.Add(Me.Csetup)
        Me.Controls.Add(Me.DBGcl)
        Me.Controls.Add(Me.dbgview)
        Me.Controls.Add(Me.debugbot)
        Me.Controls.Add(Me.events)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "innovaphone CallMonitor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend Shadows WithEvents events As System.Windows.Forms.ListView
    Friend WithEvents debugbot As System.Windows.Forms.Button
    Friend WithEvents dbgview As System.Windows.Forms.ListBox
    Friend WithEvents DBGcl As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Csetup As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LinkCheck As System.Windows.Forms.Timer
    Friend WithEvents TCPid As System.Windows.Forms.Label
End Class
