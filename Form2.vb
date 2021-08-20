' Copyright innovaphone AG 1997 - 2011

Public Class Setup
    Dim Farbeidle, Farbesetup, Farbecall, Farbebusy, Farbepresence, Farbetrigger As String
    Dim SCidle, SCsetup, SCcall, SCbusy, SCpresence, SCtrigger As System.Drawing.Color
    

    ' Die Einstellungen wrden gespeichert
    Private Sub CAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CAS.Click
        MsgBox("Please start the application again to become changes effective!", MsgBoxStyle.Information, "Saved! Setup Note")
        Farbeidle = Me.Cidle.BackColor.ToArgb
        Farbesetup = Me.Csetup.BackColor.ToArgb
        Farbecall = Me.Ccall.BackColor.ToArgb
        Farbebusy = Me.Cbusy.BackColor.ToArgb
        Farbepresence = Me.Cpresence.BackColor.ToArgb
        FileClose(1)
        FileOpen(1, "innoDynaBLF.txt", OpenMode.Output)
        PrintLine(1, "1:" + PBXtcpip.Text)
        PrintLine(1, "2:" + AuthUser.Text)
        PrintLine(1, "3:" + AuthPass.Text)
        If Me.ReguserFlag.CheckState Then
            PrintLine(1, "4:1")
        Else
            PrintLine(1, "4:0")
        End If
        If Me.MaxSize.CheckState Then
            PrintLine(1, "5:1")
        Else
            PrintLine(1, "5:0")
        End If
        PrintLine(1, "6:" + HideFrom.Text)
        PrintLine(1, "7:" + HideTo.Text)
        PrintLine(1, "8:" + PBXObj.Text)
        PrintLine(1, "9:" + BLFname.Text)
        PrintLine(1, "A:")
        If Me.ExUser.CheckState Then
            PrintLine(1, "B:1")
        Else
            PrintLine(1, "B:0")
        End If
        PrintLine(1, "C:")
        PrintLine(1, "D:")
        PrintLine(1, "E:" + PBX2.Text)
        PrintLine(1, "F:" + Farbeidle)
        PrintLine(1, "G:" + Farbesetup)
        PrintLine(1, "H:" + Farbecall)
        PrintLine(1, "I:" + Farbebusy)
        PrintLine(1, "J:" + Farbepresence)
        PrintLine(1, "K:" + CPRlist.Text)
        PrintLine(1, "L:" + Farbetrigger)
        If Me.Foreground.CheckState Then
            PrintLine(1, "M:1")
        Else
            PrintLine(1, "M:0")
        End If
        PrintLine(1, "N:" + PBXport.Text)
        If Me.httpS.CheckState Then
            PrintLine(1, "O:1")
        Else
            PrintLine(1, "O0:")
        End If
        FileClose(1)
        Me.Hide()

    End Sub


    Private Sub Setup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Farbeidle = Me.Cidle.BackColor.ToArgb
        Farbesetup = Me.Csetup.BackColor.ToArgb
        Farbecall = Me.Ccall.BackColor.ToArgb
        Farbebusy = Me.Cbusy.BackColor.ToArgb
        Farbepresence = Me.Cpresence.BackColor.ToArgb
        Farbetrigger = Me.Ctrigger.BackColor.ToArgb
        CPRlist.Items.Add("")
        CPRlist.Items.Add("appointment")
        CPRlist.Items.Add("away")
        CPRlist.Items.Add("breakfast")
        CPRlist.Items.Add("busy")
        CPRlist.Items.Add("dinner")
        CPRlist.Items.Add("holiday")
        CPRlist.Items.Add("in-transit")
        CPRlist.Items.Add("looking-for-work")
        CPRlist.Items.Add("lunch")
        CPRlist.Items.Add("meal")
        CPRlist.Items.Add("meeting")
        CPRlist.Items.Add("on-the-phone")
        CPRlist.Items.Add("other")
        CPRlist.Items.Add("performance")
        CPRlist.Items.Add("permanent-absence")
        CPRlist.Items.Add("playing")
        CPRlist.Items.Add("presentation")
        CPRlist.Items.Add("shopping")
        CPRlist.Items.Add("sleeping")
        CPRlist.Items.Add("spectator")
        CPRlist.Items.Add("steering")
        CPRlist.Items.Add("travel")
        CPRlist.Items.Add("tv")
        CPRlist.Items.Add("unknown")
        CPRlist.Items.Add("vacation")
        CPRlist.Items.Add("working")
        CPRlist.Items.Add("worship")

    End Sub

    Private Sub DBGwin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Visible = True : Me.Show()
    End Sub

    
    
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub CAS_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CAS.VisibleChanged
        '  Form1.Tag = "0"
        ' iBLF.Tag = ""
    End Sub


    Private Sub Bidle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bidle.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Cidle.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Cidle.BackColor = MyDialog.Color
            SCidle = MyDialog.Color
            Farbeidle = SCidle.ToArgb
        End If
    End Sub

    Private Sub Bsetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsetup.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Csetup.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Csetup.BackColor = MyDialog.Color
            SCsetup = MyDialog.Color
            Farbesetup = SCsetup.ToArgb
        End If
    End Sub

    Private Sub Bcall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcall.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Ccall.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Ccall.BackColor = MyDialog.Color
            SCcall = MyDialog.Color
            Farbecall = SCcall.ToArgb
        End If
    End Sub

    Private Sub Bbusy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bbusy.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Cbusy.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Cbusy.BackColor = MyDialog.Color
            SCbusy = MyDialog.Color
            Farbebusy = SCbusy.ToArgb
        End If
    End Sub

    Private Sub Bpresence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bpresence.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Cpresence.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Cpresence.BackColor = MyDialog.Color
            SCpresence = MyDialog.Color
            Farbepresence = SCpresence.ToArgb
        End If
    End Sub

    Private Sub BReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReset.Click
        Me.Cidle.BackColor = Me.CDidle.BackColor
        Me.Csetup.BackColor = Me.CDsetup.BackColor
        Me.Ccall.BackColor = Me.CDcall.BackColor
        Me.Cbusy.BackColor = Me.CDbusy.BackColor
        Me.Cpresence.BackColor = Me.CDpresence.BackColor
        Me.Ctrigger.BackColor = Me.CDtrigger.BackColor
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub BTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTrigger.Click
        Dim MyDialog As New ColorDialog()
        MyDialog.AllowFullOpen = True
        MyDialog.Color = Me.Ctrigger.BackColor
        If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            Me.Ctrigger.BackColor = MyDialog.Color
            SCtrigger = MyDialog.Color
            Farbetrigger = SCtrigger.ToArgb
        End If
    End Sub

    
    Private Sub PBXtcpip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBXtcpip.TextChanged

    End Sub
End Class
