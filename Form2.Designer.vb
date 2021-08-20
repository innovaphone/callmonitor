<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setup))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PBXtcpip = New System.Windows.Forms.TextBox
        Me.AuthUser = New System.Windows.Forms.TextBox
        Me.AuthPass = New System.Windows.Forms.TextBox
        Me.PBX2 = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CAS = New System.Windows.Forms.Button
        Me.PBXObj = New System.Windows.Forms.TextBox
        Me.ReguserFlag = New System.Windows.Forms.CheckBox
        Me.MaxSize = New System.Windows.Forms.CheckBox
        Me.HideFrom = New System.Windows.Forms.TextBox
        Me.HideTo = New System.Windows.Forms.TextBox
        Me.BLFname = New System.Windows.Forms.TextBox
        Me.BReset = New System.Windows.Forms.Button
        Me.Bsetup = New System.Windows.Forms.Button
        Me.Bbusy = New System.Windows.Forms.Button
        Me.Bcall = New System.Windows.Forms.Button
        Me.Bpresence = New System.Windows.Forms.Button
        Me.Bidle = New System.Windows.Forms.Button
        Me.ExUser = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTrigger = New System.Windows.Forms.Button
        Me.CPRlist = New System.Windows.Forms.ComboBox
        Me.Foreground = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Ctrigger = New System.Windows.Forms.Label
        Me.CDtrigger = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.CDpresence = New System.Windows.Forms.Label
        Me.CDsetup = New System.Windows.Forms.Label
        Me.CDbusy = New System.Windows.Forms.Label
        Me.CDcall = New System.Windows.Forms.Label
        Me.CDidle = New System.Windows.Forms.Label
        Me.Cpresence = New System.Windows.Forms.Label
        Me.Csetup = New System.Windows.Forms.Label
        Me.Cbusy = New System.Windows.Forms.Label
        Me.Ccall = New System.Windows.Forms.Label
        Me.Cidle = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.PBXport = New System.Windows.Forms.TextBox
        Me.httpS = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "User"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Standby PBX"
        '
        'PBXtcpip
        '
        Me.PBXtcpip.HideSelection = False
        Me.PBXtcpip.Location = New System.Drawing.Point(108, 9)
        Me.PBXtcpip.Name = "PBXtcpip"
        Me.PBXtcpip.Size = New System.Drawing.Size(123, 20)
        Me.PBXtcpip.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.PBXtcpip, "TCP/IP adress of yor PBX (example: 172.16.88.99)")
        '
        'AuthUser
        '
        Me.AuthUser.Location = New System.Drawing.Point(107, 61)
        Me.AuthUser.Name = "AuthUser"
        Me.AuthUser.Size = New System.Drawing.Size(124, 20)
        Me.AuthUser.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.AuthUser, "Name of the user in the PBX (example= ""admin""). Note: This is the ""normal"" PBX us" & _
                "ername for administration")
        '
        'AuthPass
        '
        Me.AuthPass.Location = New System.Drawing.Point(107, 87)
        Me.AuthPass.Name = "AuthPass"
        Me.AuthPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.AuthPass.Size = New System.Drawing.Size(124, 20)
        Me.AuthPass.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.AuthPass, "Enter Password of the user (example: ""IP6000""). Note: this is the password for th" & _
                "e admin user")
        '
        'PBX2
        '
        Me.PBX2.Location = New System.Drawing.Point(108, 35)
        Me.PBX2.Name = "PBX2"
        Me.PBX2.Size = New System.Drawing.Size(123, 20)
        Me.PBX2.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.PBX2, "TCP/IP adress of yor Standby PBX (example: 172.16.88.199) Note: switching from ac" & _
                "tive to standby only on missed ping in startup")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.ReshowDelay = 20
        '
        'CAS
        '
        Me.CAS.Location = New System.Drawing.Point(29, 613)
        Me.CAS.Name = "CAS"
        Me.CAS.Size = New System.Drawing.Size(121, 27)
        Me.CAS.TabIndex = 13
        Me.CAS.Text = "Save and exit"
        Me.ToolTip1.SetToolTip(Me.CAS, "Note: Changes executed only if You restart the application")
        Me.CAS.UseVisualStyleBackColor = True
        '
        'PBXObj
        '
        Me.PBXObj.Location = New System.Drawing.Point(108, 114)
        Me.PBXObj.Name = "PBXObj"
        Me.PBXObj.Size = New System.Drawing.Size(123, 20)
        Me.PBXObj.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.PBXObj, "name of the SOAP user in the PBX (example: ""_TAPI_""). Note: if not present create" & _
                " a dummy user in the PBX (for example ""SOAP"") .")
        '
        'ReguserFlag
        '
        Me.ReguserFlag.Location = New System.Drawing.Point(23, 166)
        Me.ReguserFlag.Name = "ReguserFlag"
        Me.ReguserFlag.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReguserFlag.Size = New System.Drawing.Size(208, 23)
        Me.ReguserFlag.TabIndex = 7
        Me.ReguserFlag.Text = "Show only registrated  user"
        Me.ReguserFlag.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ReguserFlag, "if checked the CallMonitor shows only registrated endpoints in the moment of the " & _
                "startup.  ")
        Me.ReguserFlag.UseVisualStyleBackColor = True
        '
        'MaxSize
        '
        Me.MaxSize.Location = New System.Drawing.Point(24, 195)
        Me.MaxSize.Name = "MaxSize"
        Me.MaxSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MaxSize.Size = New System.Drawing.Size(207, 23)
        Me.MaxSize.TabIndex = 8
        Me.MaxSize.Text = "Show all Lamps"
        Me.MaxSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.MaxSize, "Shows always a 400 user lamp filed (no automatic size adaptation)  ")
        Me.MaxSize.UseVisualStyleBackColor = True
        '
        'HideFrom
        '
        Me.HideFrom.Location = New System.Drawing.Point(140, 295)
        Me.HideFrom.Name = "HideFrom"
        Me.HideFrom.Size = New System.Drawing.Size(90, 20)
        Me.HideFrom.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.HideFrom, "do not display numbers up to this number")
        '
        'HideTo
        '
        Me.HideTo.Location = New System.Drawing.Point(140, 317)
        Me.HideTo.Name = "HideTo"
        Me.HideTo.Size = New System.Drawing.Size(90, 20)
        Me.HideTo.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.HideTo, "do not display numbers higher then this number")
        '
        'BLFname
        '
        Me.BLFname.Location = New System.Drawing.Point(107, 140)
        Me.BLFname.Name = "BLFname"
        Me.BLFname.Size = New System.Drawing.Size(123, 20)
        Me.BLFname.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.BLFname, "Name of the CallMonitor, usefully when more Fields are displayed")
        '
        'BReset
        '
        Me.BReset.Location = New System.Drawing.Point(165, 39)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(85, 24)
        Me.BReset.TabIndex = 20
        Me.BReset.Text = "Reset to ->"
        Me.ToolTip1.SetToolTip(Me.BReset, "Reset al lamp colors to the default value")
        Me.BReset.UseVisualStyleBackColor = True
        '
        'Bsetup
        '
        Me.Bsetup.Location = New System.Drawing.Point(6, 68)
        Me.Bsetup.Name = "Bsetup"
        Me.Bsetup.Size = New System.Drawing.Size(85, 24)
        Me.Bsetup.TabIndex = 19
        Me.Bsetup.Text = "Setup"
        Me.ToolTip1.SetToolTip(Me.Bsetup, "Set the color of a lamp in setup status")
        Me.Bsetup.UseVisualStyleBackColor = True
        '
        'Bbusy
        '
        Me.Bbusy.Location = New System.Drawing.Point(6, 125)
        Me.Bbusy.Name = "Bbusy"
        Me.Bbusy.Size = New System.Drawing.Size(85, 24)
        Me.Bbusy.TabIndex = 18
        Me.Bbusy.Text = "Busy"
        Me.ToolTip1.SetToolTip(Me.Bbusy, "Set the color of a lamp in busy status")
        Me.Bbusy.UseVisualStyleBackColor = True
        '
        'Bcall
        '
        Me.Bcall.Location = New System.Drawing.Point(6, 96)
        Me.Bcall.Name = "Bcall"
        Me.Bcall.Size = New System.Drawing.Size(85, 24)
        Me.Bcall.TabIndex = 17
        Me.Bcall.Text = "Call"
        Me.ToolTip1.SetToolTip(Me.Bcall, "Set the color of a lamp in call status")
        Me.Bcall.UseVisualStyleBackColor = True
        '
        'Bpresence
        '
        Me.Bpresence.Location = New System.Drawing.Point(6, 155)
        Me.Bpresence.Name = "Bpresence"
        Me.Bpresence.Size = New System.Drawing.Size(85, 24)
        Me.Bpresence.TabIndex = 22
        Me.Bpresence.Text = "Presence"
        Me.ToolTip1.SetToolTip(Me.Bpresence, "Set the color of a lamp with presence status")
        Me.Bpresence.UseVisualStyleBackColor = True
        '
        'Bidle
        '
        Me.Bidle.Location = New System.Drawing.Point(6, 38)
        Me.Bidle.Name = "Bidle"
        Me.Bidle.Size = New System.Drawing.Size(85, 24)
        Me.Bidle.TabIndex = 23
        Me.Bidle.Text = "Idle"
        Me.ToolTip1.SetToolTip(Me.Bidle, "Set the color of a lamp in idle status")
        Me.Bidle.UseVisualStyleBackColor = True
        '
        'ExUser
        '
        Me.ExUser.Location = New System.Drawing.Point(24, 224)
        Me.ExUser.Name = "ExUser"
        Me.ExUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ExUser.Size = New System.Drawing.Size(207, 23)
        Me.ExUser.TabIndex = 35
        Me.ExUser.Text = "Show Executive user"
        Me.ExUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ExUser, "Shows also Executive user in the BLF")
        Me.ExUser.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(227, 613)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 27)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Exit (no save)"
        Me.ToolTip1.SetToolTip(Me.Button1, "Note: Exit setup without saving")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTrigger
        '
        Me.BTrigger.Location = New System.Drawing.Point(6, 185)
        Me.BTrigger.Name = "BTrigger"
        Me.BTrigger.Size = New System.Drawing.Size(85, 24)
        Me.BTrigger.TabIndex = 34
        Me.BTrigger.Text = "Trigger Pr."
        Me.ToolTip1.SetToolTip(Me.BTrigger, "Set the color of a lamp with presence activity as defined ")
        Me.BTrigger.UseVisualStyleBackColor = True
        '
        'CPRlist
        '
        Me.CPRlist.FormattingEnabled = True
        Me.CPRlist.Location = New System.Drawing.Point(165, 188)
        Me.CPRlist.Name = "CPRlist"
        Me.CPRlist.Size = New System.Drawing.Size(86, 21)
        Me.CPRlist.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.CPRlist, "Define the status where the trigger color should be shown")
        '
        'Foreground
        '
        Me.Foreground.Location = New System.Drawing.Point(24, 253)
        Me.Foreground.Name = "Foreground"
        Me.Foreground.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Foreground.Size = New System.Drawing.Size(207, 23)
        Me.Foreground.TabIndex = 37
        Me.Foreground.Text = "Hold in foreground"
        Me.Foreground.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Foreground, "If checked the monitor will be always in foreground")
        Me.Foreground.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Query User"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Hide user higher then"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Hide user up to"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Monitor name"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.CPRlist)
        Me.Panel1.Controls.Add(Me.Ctrigger)
        Me.Panel1.Controls.Add(Me.CDtrigger)
        Me.Panel1.Controls.Add(Me.BTrigger)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.CDpresence)
        Me.Panel1.Controls.Add(Me.CDsetup)
        Me.Panel1.Controls.Add(Me.CDbusy)
        Me.Panel1.Controls.Add(Me.CDcall)
        Me.Panel1.Controls.Add(Me.CDidle)
        Me.Panel1.Controls.Add(Me.Cpresence)
        Me.Panel1.Controls.Add(Me.Csetup)
        Me.Panel1.Controls.Add(Me.Cbusy)
        Me.Panel1.Controls.Add(Me.Ccall)
        Me.Panel1.Controls.Add(Me.Bidle)
        Me.Panel1.Controls.Add(Me.Bpresence)
        Me.Panel1.Controls.Add(Me.BReset)
        Me.Panel1.Controls.Add(Me.Cidle)
        Me.Panel1.Controls.Add(Me.Bsetup)
        Me.Panel1.Controls.Add(Me.Bbusy)
        Me.Panel1.Controls.Add(Me.Bcall)
        Me.Panel1.Location = New System.Drawing.Point(29, 353)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 245)
        Me.Panel1.TabIndex = 34
        '
        'Ctrigger
        '
        Me.Ctrigger.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Ctrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ctrigger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Ctrigger.Location = New System.Drawing.Point(97, 186)
        Me.Ctrigger.Name = "Ctrigger"
        Me.Ctrigger.Size = New System.Drawing.Size(52, 23)
        Me.Ctrigger.TabIndex = 36
        Me.Ctrigger.Text = "123"
        Me.Ctrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CDtrigger
        '
        Me.CDtrigger.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.CDtrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDtrigger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDtrigger.Location = New System.Drawing.Point(256, 186)
        Me.CDtrigger.Name = "CDtrigger"
        Me.CDtrigger.Size = New System.Drawing.Size(52, 23)
        Me.CDtrigger.TabIndex = 35
        Me.CDtrigger.Text = "123"
        Me.CDtrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 25)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Lamp colors"
        '
        'CDpresence
        '
        Me.CDpresence.BackColor = System.Drawing.Color.White
        Me.CDpresence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDpresence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDpresence.Location = New System.Drawing.Point(256, 156)
        Me.CDpresence.Name = "CDpresence"
        Me.CDpresence.Size = New System.Drawing.Size(52, 23)
        Me.CDpresence.TabIndex = 32
        Me.CDpresence.Text = "123"
        Me.CDpresence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CDsetup
        '
        Me.CDsetup.BackColor = System.Drawing.Color.Yellow
        Me.CDsetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDsetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDsetup.Location = New System.Drawing.Point(256, 69)
        Me.CDsetup.Name = "CDsetup"
        Me.CDsetup.Size = New System.Drawing.Size(52, 23)
        Me.CDsetup.TabIndex = 31
        Me.CDsetup.Text = "123"
        Me.CDsetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CDbusy
        '
        Me.CDbusy.BackColor = System.Drawing.Color.Green
        Me.CDbusy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDbusy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDbusy.Location = New System.Drawing.Point(256, 126)
        Me.CDbusy.Name = "CDbusy"
        Me.CDbusy.Size = New System.Drawing.Size(52, 23)
        Me.CDbusy.TabIndex = 30
        Me.CDbusy.Text = "123"
        Me.CDbusy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CDcall
        '
        Me.CDcall.BackColor = System.Drawing.Color.Red
        Me.CDcall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDcall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDcall.Location = New System.Drawing.Point(256, 99)
        Me.CDcall.Name = "CDcall"
        Me.CDcall.Size = New System.Drawing.Size(52, 23)
        Me.CDcall.TabIndex = 29
        Me.CDcall.Text = "123"
        Me.CDcall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CDidle
        '
        Me.CDidle.BackColor = System.Drawing.Color.Silver
        Me.CDidle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CDidle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CDidle.Location = New System.Drawing.Point(256, 40)
        Me.CDidle.Name = "CDidle"
        Me.CDidle.Size = New System.Drawing.Size(52, 23)
        Me.CDidle.TabIndex = 28
        Me.CDidle.Text = "123"
        Me.CDidle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cpresence
        '
        Me.Cpresence.BackColor = System.Drawing.Color.White
        Me.Cpresence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cpresence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Cpresence.Location = New System.Drawing.Point(97, 155)
        Me.Cpresence.Name = "Cpresence"
        Me.Cpresence.Size = New System.Drawing.Size(52, 23)
        Me.Cpresence.TabIndex = 27
        Me.Cpresence.Text = "123"
        Me.Cpresence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Csetup
        '
        Me.Csetup.BackColor = System.Drawing.Color.Yellow
        Me.Csetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Csetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Csetup.Location = New System.Drawing.Point(97, 68)
        Me.Csetup.Name = "Csetup"
        Me.Csetup.Size = New System.Drawing.Size(52, 23)
        Me.Csetup.TabIndex = 26
        Me.Csetup.Text = "123"
        Me.Csetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cbusy
        '
        Me.Cbusy.BackColor = System.Drawing.Color.Green
        Me.Cbusy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cbusy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Cbusy.Location = New System.Drawing.Point(97, 125)
        Me.Cbusy.Name = "Cbusy"
        Me.Cbusy.Size = New System.Drawing.Size(52, 23)
        Me.Cbusy.TabIndex = 25
        Me.Cbusy.Text = "123"
        Me.Cbusy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ccall
        '
        Me.Ccall.BackColor = System.Drawing.Color.Red
        Me.Ccall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ccall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Ccall.Location = New System.Drawing.Point(97, 98)
        Me.Ccall.Name = "Ccall"
        Me.Ccall.Size = New System.Drawing.Size(52, 23)
        Me.Ccall.TabIndex = 24
        Me.Ccall.Text = "123"
        Me.Ccall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cidle
        '
        Me.Cidle.BackColor = System.Drawing.Color.Silver
        Me.Cidle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cidle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Cidle.Location = New System.Drawing.Point(97, 40)
        Me.Cidle.Name = "Cidle"
        Me.Cidle.Size = New System.Drawing.Size(52, 23)
        Me.Cidle.TabIndex = 19
        Me.Cidle.Text = "123"
        Me.Cidle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(237, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Port"
        Me.ToolTip1.SetToolTip(Me.Label8, "PBX Port, leave blank if standard")
        '
        'PBXport
        '
        Me.PBXport.HideSelection = False
        Me.PBXport.Location = New System.Drawing.Point(269, 9)
        Me.PBXport.Name = "PBXport"
        Me.PBXport.Size = New System.Drawing.Size(79, 20)
        Me.PBXport.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.PBXport, "Port of yor PBX, leave blank if standard (example: 8000 , do not enter "":"")")
        '
        'httpS
        '
        Me.httpS.Location = New System.Drawing.Point(237, 32)
        Me.httpS.Name = "httpS"
        Me.httpS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.httpS.Size = New System.Drawing.Size(111, 23)
        Me.httpS.TabIndex = 40
        Me.httpS.Text = "https"
        Me.httpS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.httpS, "check if https is used")
        Me.httpS.UseVisualStyleBackColor = True
        '
        'Setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 652)
        Me.ControlBox = False
        Me.Controls.Add(Me.httpS)
        Me.Controls.Add(Me.PBXport)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Foreground)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ExUser)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BLFname)
        Me.Controls.Add(Me.HideTo)
        Me.Controls.Add(Me.HideFrom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MaxSize)
        Me.Controls.Add(Me.ReguserFlag)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PBXObj)
        Me.Controls.Add(Me.CAS)
        Me.Controls.Add(Me.PBX2)
        Me.Controls.Add(Me.AuthPass)
        Me.Controls.Add(Me.AuthUser)
        Me.Controls.Add(Me.PBXtcpip)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(390, 680)
        Me.MinimumSize = New System.Drawing.Size(390, 680)
        Me.Name = "Setup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Setup CallMonitor v1.22"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PBXtcpip As System.Windows.Forms.TextBox
    Friend WithEvents AuthUser As System.Windows.Forms.TextBox
    Friend WithEvents AuthPass As System.Windows.Forms.TextBox
    Friend WithEvents PBX2 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CAS As System.Windows.Forms.Button
    Friend WithEvents PBXObj As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ReguserFlag As System.Windows.Forms.CheckBox
    Friend WithEvents MaxSize As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HideFrom As System.Windows.Forms.TextBox
    Friend WithEvents HideTo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BLFname As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BReset As System.Windows.Forms.Button
    Friend WithEvents Cidle As System.Windows.Forms.Label
    Friend WithEvents Bsetup As System.Windows.Forms.Button
    Friend WithEvents Bbusy As System.Windows.Forms.Button
    Friend WithEvents Bcall As System.Windows.Forms.Button
    Friend WithEvents CDpresence As System.Windows.Forms.Label
    Friend WithEvents CDsetup As System.Windows.Forms.Label
    Friend WithEvents CDbusy As System.Windows.Forms.Label
    Friend WithEvents CDcall As System.Windows.Forms.Label
    Friend WithEvents CDidle As System.Windows.Forms.Label
    Friend WithEvents Cpresence As System.Windows.Forms.Label
    Friend WithEvents Csetup As System.Windows.Forms.Label
    Friend WithEvents Cbusy As System.Windows.Forms.Label
    Friend WithEvents Ccall As System.Windows.Forms.Label
    Friend WithEvents Bidle As System.Windows.Forms.Button
    Friend WithEvents Bpresence As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ExUser As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Ctrigger As System.Windows.Forms.Label
    Friend WithEvents CDtrigger As System.Windows.Forms.Label
    Friend WithEvents BTrigger As System.Windows.Forms.Button
    Friend WithEvents CPRlist As System.Windows.Forms.ComboBox
    Friend WithEvents Foreground As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PBXport As System.Windows.Forms.TextBox
    Friend WithEvents httpS As System.Windows.Forms.CheckBox
End Class
