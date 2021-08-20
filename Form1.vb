' Copyright innovaphone AG 1997 - 2011

Imports inno.pbx_wsdl


Public Class Form1
    ' the forms PBX link
    Dim pbxTimer As myPBX
    Dim pbxbroken As Boolean = True
    '    Dim ReSynch As Boolean = False

    Public pollActive As Integer = 0
    ' PBX access data
    Public Shared httpUser As String
    Public Shared httpPw As String
    Public Shared pbxUser As String
    Public Shared pbxUrl As String
    Public Shared DataLoaded As Boolean
    ' PBX runtime data
    Public pbxKey As Integer
    Public pbxSession As Integer
    Public pbxUserId As Integer
    Public Puser As Integer

    Public Shared Dbug As Boolean
    Public Shared Anz As String
    Public Shared CallStatus As Integer
    Public Shared XMLdummy As String
    Public Shared KWpath As String
    Public Shared xflag As Boolean
    Public Shared Ruhe As Integer
    Public Shared BLF(400, 4) As String
    Public Shared LampC As Integer
    Public Shared ctrl As Control
    Public Shared NurReg, MSize, AusL, Executive As Boolean
    Public Shared MinTN, MaxTN As Long
    Dim BLidle, BLsetup, BLcall, BLbusy, BLpresence, BLtrigger As System.Drawing.Color




    Public Sub addline(ByVal msg As String)
        dbgview.Items.Add(msg)
        dbgview.TopIndex = dbgview.Items.Count - 5
    End Sub

    ' Laden der konfigurationswerte aus Datei
    Public Sub Setup_Load()
        On Error Resume Next
        FileClose(1)
        FileOpen(1, "innoDynaBLF.txt", OpenMode.Append) ' so wird verhindert das es die Datei nicht gibt
        FileClose(1)
        Dim jn, rstr As String
        Dim pbxhanl, pbxhanl2 As String
        Dim fl, FarbeNr As Long
        pbxhanl = "" : pbxhanl2 = "" : Executive = False
        fl = FileLen("innoDynaBLF.txt")
        BLidle = Setup.CDidle.BackColor
        BLsetup = Setup.CDsetup.BackColor
        BLcall = Setup.CDcall.BackColor
        BLbusy = Setup.CDbusy.BackColor
        BLpresence = Setup.CDpresence.BackColor
        BLtrigger = Setup.CDtrigger.BackColor
        If fl = 0 Then ' Neue Datei, es gibt keine gültigen Konfig Daten
            Me.Tag = "1"
        Else
            FileOpen(1, "innoDynaBLF.txt", OpenMode.Input)
            Do
                rstr = LineInput(1)
                If Len(rstr) > 1 Then
                    jn = Mid(rstr, 1, 1)
                    rstr = Mid(rstr, 3, 50)
                    Select Case jn
                        Case "1" : pbxhanl = rstr : Setup.PBXtcpip.Text = rstr
                            If rstr = "" Then iBLF.SSetup.Tag = "1"
                        Case "2" : httpUser = rstr : Setup.AuthUser.Text = rstr
                        Case "3" : httpPw = rstr : Setup.AuthPass.Text = rstr
                        Case "4"
                            If rstr = "1" Then
                                NurReg = True : Setup.ReguserFlag.Checked = True
                            Else : NurReg = False : Setup.ReguserFlag.Checked = False
                            End If
                        Case "5"
                            If rstr = "1" Then
                                MSize = True : Setup.MaxSize.Checked = True
                            Else : MSize = False : Setup.MaxSize.Checked = False
                            End If
                        Case "6" : MinTN = Val(rstr) : Setup.HideFrom.Text = rstr
                        Case "7" : MaxTN = Val(rstr) : If MaxTN = 0 Then MaxTN = 99999999
                            Setup.HideTo.Text = rstr
                        Case "8" : pbxUser = rstr : Setup.PBXObj.Text = rstr
                        Case "9" : Setup.BLFname.Text = rstr
                            If rstr <> "" Then iBLF.Text = rstr Else iBLF.Text = "innovaphone CallMonitor " & My.Application.Info.Version.ToString
                        Case "A" : If rstr = "" Then rstr = "999999"
                            ' Setup.TrunkAc2.Text = rstr
                        Case "B" : If Val(rstr) = 0 Then
                                Executive = False : Setup.ExUser.Checked = False
                            Else
                                Executive = True : Setup.ExUser.Checked = True
                            End If
                        Case "C" 'Setup.XMLpath.Text = rstr
                        Case "D" 'KWpath = rstr : Setup.SDpath.Text = rstr
                        Case "E" : pbxhanl2 = rstr : Setup.PBX2.Text = rstr
                        Case "F" : If rstr = "" Then BLidle = Setup.CDidle.BackColor Else BLidle = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "G" : If rstr = "" Then BLsetup = Setup.CDsetup.BackColor Else BLsetup = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "H" : If rstr = "" Then BLcall = Setup.CDcall.BackColor Else BLcall = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "I" : If rstr = "" Then BLbusy = Setup.CDbusy.BackColor Else BLbusy = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "J" : If rstr = "" Then BLpresence = Setup.CDpresence.BackColor Else BLpresence = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "K" : Setup.CPRlist.Text = rstr
                        Case "L" : If rstr = "" Then BLtrigger = Setup.CDtrigger.BackColor Else BLtrigger = System.Drawing.Color.FromArgb(Val(rstr))
                        Case "M" : If Val(rstr) = 0 Then
                                Setup.Foreground.Checked = False
                            Else
                                Setup.Foreground.Checked = True
                            End If
                        Case Else
                    End Select
                End If
            Loop Until EOF(1)
        End If
        Setup.Cidle.BackColor = BLidle
        Setup.Csetup.BackColor = BLsetup
        Setup.Ccall.BackColor = BLcall
        Setup.Cbusy.BackColor = BLbusy
        Setup.Cpresence.BackColor = BLpresence
        Setup.Ctrigger.BackColor = BLtrigger
        If Me.Tag <> "1" Then
            If My.Computer.Network.Ping(pbxhanl, 2000) Then  ' Request time-out =2000 ms
                FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
                PrintLine(99, Now + " Event: PBX ping recieved on " + pbxhanl)
                FileClose(99)
            Else
                If pbxhanl2 <> "" Then
                    If My.Computer.Network.Ping(pbxhanl2, 2000) Then
                        FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
                        PrintLine(99, Now + " Event: PBX ping failed on " + pbxhanl + " but ping on " + pbxhanl2 + " successfull, starting with " + pbxhanl2)
                        FileClose(99)
                        pbxhanl = pbxhanl2
                    Else
                        FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
                        PrintLine(99, Now + " Event: PBX ping failed on " + pbxhanl + " and " + pbxhanl2 + "! Starting with " + pbxhanl)
                        FileClose(99)
                    End If
                End If
            End If
        End If
        TCPid.Text = pbxhanl
        If Me.Tag = "1" Then pbxUrl = "" Else pbxUrl = "http://" + pbxhanl + "/PBX0/user.soap"
        FileClose(1)
    End Sub

    Shared seq As Integer = 0

    Public Function initPollPbxLink() As myPBX

        Dim pbxPoll As myPBX
        pbxPoll = New myPBX(Me)
        pbxPoll.Url = pbxUrl
        pbxPoll.PreAuthenticate = True
        pbxPoll.Timeout = 2000
        pbxPoll.Credentials = New Net.NetworkCredential(httpUser, httpPw, "")
        pbxPoll.ConnectionGroupName = "poll" & seq.ToString
        seq = seq + 1
        Return pbxPoll

    End Function

    ' initalize pbx link on load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        On Error Resume Next
        Dim processes() As Process
        Dim instance As Process
        Dim process As New Process()
        Dim ProcToWatch As String
        Dim prcoCNT As Integer

        Timer1.Enabled = False
        LinkCheck.Enabled = False
        Setup.Visible = False
        UseWaitCursor = True
        FileClose(99)
        FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
        PrintLine(99, Now + " Event: Application start: " + Me.Text)
        FileClose(99)
        ' Form anzeigen
        Dim fl As Long
        Dim xpos, ypos As Integer
        fl = FileLen("DynaBLFPos.txt")
        If fl <> 0 Then ' Neue Datei, es gibt keine gültigen Konfig Daten
            iBLF.StartPosition = FormStartPosition.Manual
            FileClose(88)
            FileOpen(88, "DynaBLFPos.txt", OpenMode.Input)
            xpos = Val(LineInput(88))
            ypos = Val(LineInput(88))
            iBLF.Location = New Point(xpos, ypos)
            FileClose(88)
        Else
            iBLF.StartPosition = FormStartPosition.WindowsDefaultLocation
        End If
        iBLF.Show()
        '  iBLF.Location = New Point(xpos, ypos)
        Setup_Load()
        Timer1.Tag = ""
        Timer1.Enabled = True
        If pbxUrl = "" Then Exit Sub
        ' create the link
        pbxTimer = New myPBX(Me)
        pbxTimer.ConnectionGroupName = "timer"
        pbxTimer.Url = pbxUrl
        pbxTimer.PreAuthenticate = True
        pbxTimer.Timeout = 2000
        pbxTimer.Credentials = New Net.NetworkCredential(httpUser, httpPw, "")
        ' set BLF

        debugbot.Tag = True
        dbgview.Visible = True
        Me.Width = 684
        Me.Height = 585
        events.Width = 647
        events.Height = 110
        dbgview.Width = 647
        dbgview.Height = 374
        Dbug = True
        DBGcl.Visible = True
        pbxbroken = False
        reconnect()
        LinkCheck.Enabled = True
        UseWaitCursor = False

    End Sub


    ' Debug Taste toggeln
    Private Sub debugbot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles debugbot.Click
        If debugbot.Tag = True Then
            debugbot.Tag = False
            dbgview.Visible = False
            events.Width = 647
            events.Height = 500
            Dbug = False
            DBGcl.Visible = False
        Else
            debugbot.Tag = True
            dbgview.Visible = True
            Me.Width = 684
            Me.Height = 585
            events.Width = 647
            events.Height = 110
            dbgview.Width = 647
            dbgview.Height = 374
            Dbug = True
            DBGcl.Visible = True
        End If
    End Sub
    ' Debug Fenster löschen
    Private Sub DBGcl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGcl.Click
        dbgview.Items.Clear()
    End Sub
    ' 1 Sekunden Timer Event
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Tag = "1" Then
            Timer1.Tag = ""
            FileClose(88)
            FileOpen(88, "DynaBLFPos.txt", OpenMode.Output)
            PrintLine(88, Str(iBLF.Location.X))
            PrintLine(88, Str(iBLF.Location.Y))
            FileClose(88)
        End If
        ' iBLF.Text = "innovaphone BLF " + TimeOfDay
    End Sub
    ' Konfiguration wird eingelesen und das beschriftete Blatt dargestellt
    Private Sub Csetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Csetup.Click
        Setup_Load()
        Setup.Visible = True
    End Sub

    Private Sub reconnect()
        Dim result As Integer
        Dim zeitv As Double
        ' If Me.Tag <> "1" Then
        addline("tick(session=" & pbxSession & ", key=" & pbxKey & ")")
        If pbxSession <> 0 Then
            Try
                result = pbxTimer.Echo(pbxSession, pbxKey)
            Catch err As Exception
                addline(err.Message)
                result = 0
            End Try
        Else
            Me.pbxbroken = True
        End If

        If result = 0 Then ' Link zur PBX unterbrochen
            Me.pbxbroken = True
        End If
        Dim v700, v800, hw As String
        If Me.pbxbroken Then
            Dim started As Boolean = True
            Dim auslassen As Boolean = False
            Try
                LampC = 0
                iBLF.Show()
                iBLF.SSetup.Image = iBLF.Unreg.Image
                iBLF.SSetup.Image.Tag = "0"
                addline("           LOADING LINK")
                If pbxSession > 0 Then pbxTimer.End(pbxSession)
                Dim asdf, teiln, qwer, nummer, platz As String
                Dim zaeler, nachster As Integer
                pbxSession = pbxTimer.Initialize(pbxUser, "innovaphone CBLF", True, True, True, True, pbxKey)
                ' monitor a user
                hw = ""
                pbxUserId = pbxTimer.UserInitialize(pbxSession, pbxUser, True, True, hw)
                platz = ""
                asdf = "0" : teiln = "0" : qwer = "" : nummer = ""
                v700 = "0" : v800 = "0" : LampC = 0
                For x% = 1 To 40
                    zaeler = 1
                    ' For Each TN As pbx_wsdl.UserInfo In pbxTimer.FindUser(asdf, teiln, qwer, nummer, 10, nachster)
                    For Each TN As pbx_wsdl.UserInfo In pbxTimer.FindUser(asdf, v700, v800, teiln, qwer, nummer, 10, nachster)
                        Debug.Print(TN.e164, TN.dn, TN.h323, TN.type, TN.guid, TN.state, TN.active, TN.channel, TN.cfg, TN.presence)
                        Debug.Print(TN.h323)
                        auslassen = True : AusL = False
                        If Val(TN.e164) > MaxTN Then AusL = True
                        If Val(TN.e164) <= MinTN Then AusL = True
                        If TN.e164 <> "" And Mid(TN.e164, 1, 1) <> "*" And Mid(TN.e164, 1, 1) <> "#" And AusL = False Then
                            If Executive = True Then
                                If TN.type = "executive" Then TN.type = "ep"
                            End If
                            If (TN.type = "ep" Or TN.type = "gw") Then
                                If NurReg And TN.state <> 1 Then

                                Else
                                    LampC = LampC + 1
                                    BLF(LampC, 0) = TN.cn
                                    BLF(LampC, 1) = TN.e164
                                    BLF(LampC, 2) = TN.state
                                    BLF(LampC, 3) = TN.guid
                                    BLF(LampC, 4) = TN.dn
                                    auslassen = False
                                End If
                            End If
                        End If
                        zaeler = zaeler + 1
                        If auslassen = False Then
                            If TN.type = "ep" Or TN.type = "gw" Then
                                hw = ""
                                pbxUserId = pbxTimer.UserInitialize(pbxSession, TN.cn, True, True, hw)
                            End If
                            'End If
                        End If
                        platz = TN.cn
                    Next
                    If zaeler = 11 Then
                        teiln = platz
                        asdf = platz
                        v700 = platz : v800 = platz
                        auslassen = True

                    Else
                        Exit For
                    End If
                    ' For warten% = 1 To 1000 : Next
                    'zeitv = TimeOfDay
                    zeitv = Microsoft.VisualBasic.DateAndTime.Timer

                    Do
                    Loop Until (Val(Microsoft.VisualBasic.DateAndTime.Timer) - Val(zeitv)) > 0.2
                Next

                BubbleSort()
                AssignFiled()
                iBLF.SSetup.Image = iBLF.PReg.Image

                ' Teilnehmer speichern
                FileClose(1)
                FileOpen(1, "innoBLF.txt", OpenMode.Output)
                PrintLine(1, Str(LampC))
                For x% = 1 To LampC
                    PrintLine(1, BLF(x%, 0)) : PrintLine(1, BLF(x%, 1)) : PrintLine(1, BLF(x%, 2)) : PrintLine(1, BLF(x%, 3)) : PrintLine(1, BLF(x%, 4))
                Next
                PrintLine(1, "")
                FileClose(1)
                Me.dbgview.Tag = 1


            Catch
                addline("           LINK still broken")
                iBLF.SSetup.Image = iBLF.Unreg.Image
                iBLF.SSetup.Image.Tag = "0"
                started = False

            End Try
            If started Then
                pbxbroken = False
                Dim nextPoller As myPBX
                nextPoller = initPollPbxLink()
                nextPoller.startPolling()
            End If
        Else
            iBLF.SSetup.Image = iBLF.PReg.Image
            iBLF.SSetup.Image.Tag = "1"
            '   Puser = pbxTimer.UserInitialize(pbxSession, "Klaus Wallnofer", False)
            '  For Each TN As pbx_wsdl.UserInfo In pbxTimer.FindUser(asdf, teiln, qwer, nummer, 10, nachster)


            Ruhe = Ruhe + 1
            If Ruhe > 2 Then
                Ruhe = 0
                For Each ctrl As Control In iBLF.Panel1.Controls
                    If TypeOf ctrl Is Label Then
                        If ctrl.Visible = True Then
                            If ctrl.BackColor <> BLidle And ctrl.BackColor <> BLpresence And ctrl.BackColor <> BLtrigger Then ' es ist ein Control, sichtbar und nicht idle
                                ' ctrl.BackColor = BLidle  ************** HOTFix
                                Try
                                    Dim asdf, teiln, qwer, nummer As String
                                    Dim nachster As Integer
                                    asdf = ctrl.Tag : teiln = ctrl.Tag : v700 = ctrl.Tag : v800 = ctrl.Tag : qwer = "" : nummer = "" : hw = ""
                                    For Each TN As pbx_wsdl.UserInfo In pbxTimer.FindUser(asdf, v700, v800, teiln, qwer, nummer, 1, nachster)
                                        Debug.Print(TN.e164, TN.dn, TN.h323, TN.type, TN.guid, TN.state, TN.active, TN.channel)
                                        Debug.Print(TN.h323)
                                        pbxUserId = pbxTimer.UserInitialize(pbxSession, teiln, True, True, hw)
                                    Next
                                Catch
                                    addline("           LINK still broken")
                                    iBLF.SSetup.Image = iBLF.Unreg.Image
                                    iBLF.SSetup.Image.Tag = "0"
                                End Try
                            End If
                        End If
                    End If
                Next
            End If
        End If
        ' End If
    End Sub

    Delegate Sub threadentry(ByRef f As Form1)
    Sub AssignFiled()
        ' ordnet die Tabelle den Elementen zu und aktiviert die Lampen
        ctrl = iBLF.Panel1.Container
        Dim Lname As String
        Dim zeilen, spalten, hcnt As Integer

        For Each ctrl As Control In iBLF.Panel1.Controls
            If TypeOf ctrl Is Label Then
                If MSize = False Then
                    ctrl.Visible = False
                Else
                    ctrl.Visible = True
                End If
            End If
        Next
        For x% = 1 To LampC
            Lname = "LabelL" + LTrim(Str(x%))
            For Each ctrl As Control In iBLF.Panel1.Controls
                If TypeOf ctrl Is Label Then
                    If ctrl.Name = Lname Then
                        BLF(x%, 4) = ctrl.Name ' speichert den Control Namen im feld
                        ctrl.Text = BLF(x%, 1)
                        ctrl.Visible = True
                        iBLF.ToolTip1.SetToolTip(ctrl, BLF(x%, 1) + " " + BLF(x%, 0))
                        ctrl.Tag = BLF(x%, 0) 'cn in TAG
                        If BLF(x%, 2) = 0 Then
                            ctrl.ForeColor = Color.White
                        Else
                        End If
                        ctrl.BackColor = BLidle
                        Exit For
                    End If
                End If
            Next
        Next
        iBLF.Panel1.Width = 935
        iBLF.Panel1.Height = 511
        ' LampC = 241
        If MSize = False Then
            Select Case LampC
                Case 0 To 20 : zeilen = 1
                Case 21 To 40 : zeilen = 2
                Case 41 To 60 : zeilen = 3
                Case 61 To 80 : zeilen = 4
                Case 81 To 100 : zeilen = 5
                Case 101 To 120 : zeilen = 6
                Case 121 To 140 : zeilen = 7
                Case 141 To 160 : zeilen = 8
                Case 161 To 180 : zeilen = 9
                Case 181 To 200 : zeilen = 10
                Case 201 To 220 : zeilen = 11
                Case 221 To 240 : zeilen = 12
                Case 241 To 260 : zeilen = 13
                Case 261 To 280 : zeilen = 14
                Case 281 To 300 : zeilen = 15
                Case 301 To 320 : zeilen = 16
                Case 321 To 340 : zeilen = 17
                Case 341 To 360 : zeilen = 18
                Case 361 To 380 : zeilen = 19
                Case 381 To 400 : zeilen = 20
                Case Else
            End Select
            zeilen = 20 - zeilen
            hcnt = 511 - zeilen * 25
            If hcnt < 35 Then hcnt = 36
            ' in hcnt steht die erforderliche Dimension
            iBLF.Panel1.Height = hcnt
            iBLF.Height = iBLF.Panel1.Height + 80
            If zeilen = 19 Then spalten = LampC Else spalten = 20
            If spalten < 20 Then
                If spalten < 3 Then spalten = 3
                iBLF.Panel1.Width = 55 + (spalten - 1) * 46
            End If
            iBLF.Width = iBLF.Panel1.Width + 43
        End If
        iBLF.Fx.Tag = iBLF.Width
        iBLF.Fy.Tag = iBLF.Height
        Me.Visible = False
    End Sub
    Sub BubbleSort()
        Dim okloop As Boolean
        '  For x% = 1 To LampC
        'Debug.Print(BLF(x%, 1))
        'Debug.Print(BLF(x%, 3))
        'Next
        okloop = False
        For x% = 1 To LampC ' gleiche guid entfernen
            If BLF(x%, 3) = BLF(x% + 1, 3) Then
                For z% = x% To LampC
                    BLF(z%, 0) = BLF(z% + 1, 0) : BLF(z%, 1) = BLF(z% + 1, 1) : BLF(z%, 2) = BLF(z% + 1, 2) : BLF(z%, 3) = BLF(z% + 1, 3)
                Next
                If x% <= LampC Then LampC = LampC - 1
            End If
        Next
        Do While okloop = False
            okloop = True
            For x% = 1 To LampC
                If Val(BLF(x%, 1)) > Val(BLF(x% + 1, 1)) Then  ' unterer Wert größer
                    okloop = False
                    BLF(LampC + 1, 0) = BLF(x%, 0) : BLF(LampC + 1, 1) = BLF(x%, 1) : BLF(LampC + 1, 2) = BLF(x%, 2) : BLF(LampC + 1, 3) = BLF(x%, 3)
                    BLF(x%, 0) = BLF(x% + 1, 0) : BLF(x%, 1) = BLF(x% + 1, 1) : BLF(x%, 2) = BLF(x% + 1, 2) : BLF(x%, 3) = BLF(x% + 1, 3)
                    BLF(x% + 1, 0) = BLF(LampC + 1, 0) : BLF(x% + 1, 1) = BLF(LampC + 1, 1) : BLF(x% + 1, 2) = BLF(LampC + 1, 2) : BLF(x% + 1, 3) = BLF(LampC + 1, 3)
                End If
            Next
        Loop
        ' For x% = 1 To LampC
        ' Debug.Print(BLF(x%, 1))
        ' Debug.Print(BLF(x%, 3))
        ' Next
    End Sub
    Sub callReconnect(ByRef f As Form1)
        Dim i As Integer
        i = 1
        reconnect()
    End Sub

    Private Sub LinkCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkCheck.Tick
        Dim p As threadentry
        p = AddressOf callReconnect
        Me.Invoke(p, New Object() {Me})
    End Sub


    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub events_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles events.SelectedIndexChanged

    End Sub
End Class



' the PBX link
' we need a derived class to be able to handle the async events
Public Class myPBX

    ' derive from the auto-generated soap class
    Inherits pbx_wsdl.pbx
    ' link to form
    Dim form As Form1
    ' set cReg
    Dim cReg(200, 15) As String
    Public Shared KW As DataTable
    Public Shared row As DataRow
    Public Shared foundRows() As Data.DataRow
    Public Shared Amt1 As String
    Public Shared Amt2 As String
    Public Shared SpaltenName As String
    Dim Blatt As String
    Dim SpaltNummer As Integer
    Public Shared xmlPfad As String
    '  Public Shared ExcelDate As String
    Public Shared BLF(400, 7) As String
    Public Shared LampC As Integer
    Public Shared ctrl As Control
    Dim Handl(200, 2) As String
    Public Shared TopH As Integer
    Public Shared FirstStart As Boolean
    Dim BLidle, BLsetup, BLcall, BLbusy, BLpresence, BLtrigger As System.Drawing.Color


    ' constructor to save the form link
    Public Sub New(ByRef form As Form1)
        Me.form = form
        DataSet_read()
    End Sub

    Public Sub DataSet_read()
        If Me.form.dbgview.Tag <> 1 Then Exit Sub
        Dim lc As Integer
        Dim Record, cfw, cfwdest, xmlp As String
        Dim jn, rstr As String
        ctrl = iBLF.Panel1.Container
        Err.Clear()
        On Error Resume Next
        FileClose(1)
        FileOpen(1, "innoBLF.txt", OpenMode.Append) ' so wird verhindert das es die Datei nicht gibt
        FileClose(1)

        FileOpen(1, "innoBLF.txt", OpenMode.Input)
        'lampc=
        'For x% = 1 To LampC
        Record = LineInput(1)
        LampC = Val(Record)
        For lc = 1 To LampC
            BLF(lc, 0) = LineInput(1) 'cn
            BLF(lc, 1) = LineInput(1)  'e164
            BLF(lc, 2) = LineInput(1)  'state
            BLF(lc, 3) = LineInput(1)  ' guid
            BLF(lc, 4) = LineInput(1)  ' dn
            ' ,  5 presence
        Next
        FileClose(1)
        BLidle = Setup.Cidle.BackColor
        BLsetup = Setup.Csetup.BackColor
        BLcall = Setup.Ccall.BackColor
        BLbusy = Setup.Cbusy.BackColor
        BLpresence = Setup.Cpresence.BackColor
        BLtrigger = Setup.Ctrigger.BackColor
        FirstStart = True
        Exit Sub
        Err.Clear()
        On Error Resume Next
        Form1.DataLoaded = True

    End Sub

    ' setup an async Poll
    Public Sub startPolling()
        Me.form.addline("schedpollcb(session=" & Me.form.pbxSession & ", key=" & Me.form.pbxKey & ", #" & Me.form.pollActive.ToString & ")")
        Try
            Me.form.pollActive = Me.form.pollActive + 1
            Me.PollAsync(form.pbxSession)
        Catch e As Exception
            MsgBox("start poll failed: " + e.Message + " / " + e.InnerException.ToString)
            Me.form.pollActive = Me.form.pollActive - 1
        End Try
    End Sub

    Delegate Sub threadentry2(ByRef f As Form1, ByRef e As pbx_wsdl.PollCompletedEventArgs)

    ' handle an async Poll result
    Private Sub pollCB(ByVal sender As Object, ByVal e As pbx_wsdl.PollCompletedEventArgs) _
        Handles MyBase.PollCompleted
        Dim p As threadentry2
        p = AddressOf callPollResult
        Me.form.Invoke(p, New Object() {Me.form, e})
        Me.form.pollActive = Me.form.pollActive - 1
    End Sub

    Sub callPollResult(ByRef f As Form1, ByRef e As pbx_wsdl.PollCompletedEventArgs)
        Dim Anz As String
        Dim CallStatus As Long
        Dim job As Long
        Dim LNS As String
        Dim CFW, CFWdest, Xdummy As String
        Dim CFWstr As String
        Dim CFWdisp As String
        Dim CFU As String
        Dim DND As String
        Dim Db, cRo As String
        Dim info(1) As Array
        Dim Rstate As Integer
        Dim xmlp As Integer



        Me.form.addline("           pollCB")
        Me.form.addline("pollcb(session=" & Me.form.pbxSession & ", key=" & Me.form.pbxKey & ")")
        On Error GoTo fehler

        '    For Each TN As pbx_wsdl.CallInfo In pbxTimer.Calls(44, "Klaus Wallnofer")

        '    Next




        For Each ui As pbx_wsdl.UserInfo In e.Result.user
            Anz = "ui.e164=" + ui.e164 + " ui.dn=" + ui.dn + " ui.guid=" + ui.guid + " ui.h323=" + ui.h323 + " ui.type=" + ui.type
            If ui.state = 0 Then ' diseable
                For Each ctrl As Control In iBLF.Panel1.Controls
                    If ctrl.Visible Then
                        Xdummy = ctrl.Text
                        If InStr(ctrl.Text, ">") > 0 Then
                            Xdummy = Left(ctrl.Text, (InStr(ctrl.Text, ">") - 1))
                        End If
                        If Xdummy = ui.e164 Then
                            ctrl.ForeColor = Color.Navy
                        End If
                    End If
                Next
            End If
            If ui.cfg Then ' es hat sich was in der Konfig getan
                ' Debug.Print(ui.cfg)
                ' Hier den status merken und dann unten setzen, diseable = ctrl.ForeColor = Color.White, disabled = ctrl.ForeColor = Color.black
                CFW = "" : CFWdest = "" : xmlp = 0 : CFU = "" : DND = 22
                CFW = Admin("<show><user cn='" & ui.cn & "'/></show>")  '
                If InStr(CFW, "<presence") > 0 Then xmlp = InStr(Mid(CFW, InStr(CFW, "<presence"), 500), "/>")
                If xmlp > 2 Then CFWdest = Mid(CFW, InStr(CFW, "<presence") + 1, xmlp - 2)
                If Len(CFWdest) < 18 Then CFWdest = ""
                If InStr(CFW, "cfu") > 0 Then
                    CFU = Mid(CFW, InStr(CFW, "cfu"), 300)
                    If InStr(CFU, "><ep e164=") > 0 Then
                        CFU = Mid(CFU, InStr(CFU, "><ep e164=") + 11, 300)
                        If InStr(CFU, "/>") > 0 Then
                            CFU = " CFU-> " + Left(CFU, InStr(CFU, "/>") - 2)
                        End If
                    End If
                End If
                If InStr(CFWdest, ("a=" + Chr(34))) = 0 Then
                    CFWdest = ""
                Else

                End If
                ' If InStr(CFW, "<cd type=+'" & CFU & "'><ep e164=") > 0 Then xmlp = InStr(Mid(CFW, InStr(CFW, "<CFU"), 500), "/>")
                ' If xmlp > 2 Then CFU = Mid(CFW, InStr(CFW, "<CFU") + 1, xmlp - 2)
                ' If Len(CFU) < 18 Then CFU = ""

                For Each ctrl As Control In iBLF.Panel1.Controls
                    If ctrl.Visible Then
                        Xdummy = ctrl.Text
                        If InStr(ctrl.Text, ">") > 0 Then
                            Xdummy = Left(ctrl.Text, (InStr(ctrl.Text, ">") - 1))
                        End If
                        If Xdummy = ui.e164 Then
                            If InStr(ctrl.Text, ">") > 0 Then
                                ctrl.Text = Left(ctrl.Text, (InStr(ctrl.Text, ">") - 1))
                            End If

                            If InStr(ctrl.Text, ">") > 0 Then
                                ctrl.Text = Left(ctrl.Text, (InStr(ctrl.Text, ">") - 1))
                            End If
                            If ui.state = 1 Then
                                If CFWdest <> "" Then
                                    iBLF.ToolTip1.SetToolTip(ctrl, ctrl.Text + " " + ctrl.Tag + " -:- " + CFWdest + CFU)
                                    ctrl.BackColor = BLpresence
                                    ctrl.ForeColor = Color.Navy

                                    If Setup.CPRlist.Text <> "" Then
                                        For x% = 1 To LampC
                                            If BLF(x%, 1) = Val(ctrl.Text) Then
                                                BLF(x%, 5) = CFWdest
                                            End If
                                        Next

                                        If InStr(CFWdest, Setup.CPRlist.Text) Then
                                            ctrl.BackColor = BLtrigger
                                        End If
                                    End If
                                Else
                                    iBLF.ToolTip1.SetToolTip(ctrl, ctrl.Text + " " + ctrl.Tag + CFU)
                                    ctrl.BackColor = BLidle
                                    ctrl.ForeColor = Color.Black
                                End If
                                If CFU <> "" Then
                                    ctrl.Text = ctrl.Text + ">"
                                End If
                            End If
                        End If
                    End If
                Next


            End If
            If Me.form.debugbot.Tag Then Me.form.addline(Anz)
            ' Debug.Print(ui.state)
        Next
        ' Hier werden die Calls bearbeitet

        If FirstStart = True Then ' BLF status beim Ersteinsprung updaten
            For x% = 1 To LampC
                CFW = "" : CFWdest = "" : CFU = ""
                CFW = Admin("<show><user cn='" & BLF(x%, 0) & "'/></show>")  '
                If InStr(CFW, "cfu") > 0 Then
                    CFU = Mid(CFW, InStr(CFW, "cfu"), 300)
                    If InStr(CFU, "><ep e164=") > 0 Then
                        CFU = Mid(CFU, InStr(CFU, "><ep e164=") + 11, 300)
                        If InStr(CFU, "/>") > 0 Then
                            CFU = " CFU-> " + Left(CFU, InStr(CFU, "/>") - 2)
                        End If
                    End If
                End If
                If InStr(CFW, "<presence") > 0 Then
                    xmlp = InStr(Mid(CFW, InStr(CFW, "<presence"), 500), "/>")
                    If xmlp > 2 Then CFWdest = Mid(CFW, InStr(CFW, "<presence") + 1, xmlp - 2)
                    If Len(CFWdest) < 19 Then CFWdest = "" Else CFWdest = " -:- " + CFWdest
                    BLF(x%, 5) = CFWdest
                End If

                For Each ctrl As Control In iBLF.Panel1.Controls
                    If ctrl.Visible Then
                        If TypeOf ctrl Is Label Then ' wenn eine Control Besetztlampe 
                            If ctrl.Name = BLF(x%, 4) Then  ' und es der Teilnehmer ist
                                iBLF.ToolTip1.SetToolTip(ctrl, BLF(x%, 1) + " " + BLF(x%, 0) + CFWdest + CFU)
                                If Len(CFWdest) > 17 Then
                                    If InStr(CFWdest, ("a=" + Chr(34))) <> 0 Then
                                        ctrl.BackColor = BLpresence
                                        ctrl.ForeColor = Color.Navy
                                        If Setup.CPRlist.Text <> "" Then
                                            If InStr(CFWdest, Setup.CPRlist.Text) Then
                                                ctrl.BackColor = BLtrigger
                                            End If
                                        End If
                                    End If
                                End If
                                If CFU <> "" Then ctrl.Text = ctrl.Text + ">"
                            End If
                        End If
                    End If
                Next


            Next
            FirstStart = False
        End If

        For Each ci As pbx_wsdl.CallInfo In e.Result.call
            Dim wp As Integer
            Dim dp As Integer
            Dim hp As Integer
            Dim gabbage As Boolean
            Dim aTeil, bTeil, dgg As String

            Anz = "ci.msg=" + ci.msg + " ci.user=" + Str(ci.user) + " ci.call=" + Str(ci.call) + " ci.state=" + Str(ci.state) + " ci.reg=" + Str(ci.reg)
            Debug.Print(Anz)
            ' CFW = Admin("<show><user cn='Klaus Wallnofer'/></show>")
            If Me.form.debugbot.Tag Then Me.form.addline(Anz)
            For Each cr As pbx_wsdl.No In ci.No

                Anz = "cr.e164=" + cr.e164 + " cr.type=" + cr.type + " ci.cn=" + cr.cn + " ci.dn=" + cr.dn + " ci.h323=" + cr.h323
                ' Debug.Print(Anz)
                '               dgg = Str(ci.call) + " " + cr.e164 + " " + Str(ci.state) + " " + ci.msg
                gabbage = False : TopH = 200
                For hp = 0 To 199 ' suche Handl
                    If hp < TopH Then If Handl(hp, 0) = "" Then TopH = hp ' freien Platz merken
                    If Val(Handl(hp, 0)) = Val(ci.call) Then  ' Handel ist in Liste
                        If ci.msg = "r-ct" Then ' wenn ein reconnect dann neue Teilnehmer einschreiben
                            If Handl(hp, 2) = "" Then
                                Handl(hp, 2) = cr.e164
                            Else
                                Handl(hp, 2) = ""
                                Handl(hp, 1) = cr.e164
                            End If
                        Else  ' wenn kein reconnect dann Teilnehmer merken
                            If (Handl(hp, 1) = "" Or Handl(hp, 1) = cr.e164) Then Handl(hp, 1) = cr.e164 Else Handl(hp, 2) = cr.e164
                        End If
                        gabbage = True
                        Exit For
                    End If
                Next
                If gabbage = False Then ' keinen Handel gefunden, also neues anlegen
                    hp = TopH ' beim gemerken Pointer
                    Handl(hp, 0) = ci.call : Handl(hp, 1) = cr.e164
                End If
                Rstate = ci.state And &HF ' disconnect demaskieren
                If Rstate = 6 Or Rstate = 7 Then  ' wenn release Handel löschen
                    Handl(hp, 0) = "" : Handl(hp, 1) = "" : Handl(hp, 2) = ""
                End If
                'Debug.Print(dgg)
                If cr.e164 <> "" Then ' nur einn eine Teilnehmer Info kommt
                    For x% = 1 To LampC ' schauen ob es den TN im BLF gibt
                        If BLF(x%, 1) = cr.e164 Then
                            For Each ctrl As Control In iBLF.Panel1.Controls
                                If TypeOf ctrl Is Label Then ' wenn eine Control Besetztlampe 
                                    If ctrl.Name = BLF(x%, 4) Then  ' und es der Teilnehmer ist
                                        gabbage = False
                                        For hp = 0 To 199 ' Nachschauen ob es ein Handel gibt
                                            If Handl(hp, 1) = cr.e164 Or Handl(hp, 2) = cr.e164 Then
                                                gabbage = True
                                            End If
                                        Next
                                        If gabbage Then
                                            Select Case Rstate
                                                Case 1
                                                    ctrl.BackColor = BLsetup
                                                    ' If ctrl.ForeColor <> Color.Navy Then ctrl.ForeColor = Color.Black
                                                Case 4
                                                    ctrl.BackColor = BLcall
                                                    '  If ctrl.ForeColor <> Color.Navy Then ctrl.ForeColor = Color.White
                                                Case Else
                                                    ctrl.BackColor = BLbusy
                                                    ' If ctrl.ForeColor <> Color.Navy Then ctrl.ForeColor = Color.White
                                            End Select
                                        Else

                                            If ctrl.ForeColor = Color.Navy Then
                                                ctrl.BackColor = BLpresence
                                                If Setup.CPRlist.Text <> "" Then
                                                    If InStr(BLF(x%, 5), Setup.CPRlist.Text) Then
                                                        ctrl.BackColor = BLtrigger
                                                    End If
                                                End If
                                            Else
                                                ctrl.BackColor = BLidle
                                                If ctrl.ForeColor = Color.White Then
                                                    ' REM lassen  CFW = Admin("<show><user cn='" & cr.cn & "'/></show>")  '
                                                Else
                                                    ctrl.ForeColor = Color.Black
                                                End If
                                            End If
                                        End If
                                        Exit For
                                    End If
                                End If
                            Next
                        End If

                    Next
                End If


                If Me.form.debugbot.Tag Then Me.form.addline(Anz)
                ' Überprüfen ob es den Handel schon gibt
                For wp = 1 To 200 ' Schreibpointer suchen
                    If Val(cReg(wp, 0)) = Val(ci.call) Or cReg(wp, 2) = cr.e164 Or cReg(wp, 5) = cr.e164 Then
                        Exit For ' es gibt den Handel schon
                        If Val(cReg(wp, 0)) <> Val(ci.call) Then ' es ist ein anderes Handel
                            If cReg(wp, 2) = cr.e164 Then ' es ist der Teilnehmer
                                If Val(cReg(wp, 0)) <> 0 Then ' in 0 ist ein Handel
                                    '  MyBase.UserConnect(ci.call)
                                    '  MyBase.UserClear(ci.call, 16, info(1))
                                    '  MyBase.UserRetrieve(Val(cReg(wp, 0)))
                                    '  MyBase.UserConnect(Val(cReg(wp, 0)))
                                End If
                            End If
                        End If
                        Exit For ' es gibt den Handel schon
                    End If
                Next
                If wp > 199 Then ' kein Handel gefunden daher freie Position suchen
                    For wp = 1 To 199
                        If cReg(wp, 0) = "" Then
                            ' If Left(cr.e164, 1) = Amt1 Or Left(cr.e164, 1) = Amt2 Then ' das ist ein Amtsgespräch *****
                            'End If
                            Exit For ' freier Record 
                        End If
                    Next
                End If

                If wp < 200 Then  ' nur wenn es ein gültuges Handel gibt 
                    If ((ci.state And &H7F) = 6 Or (ci.state And &H7F) = 7) Or ci.state = 263 Then ' Handel löschen
                        If cr.e164 = "" And cr.type = "peer" Then
                            '    Debug.Print("3")
                        Else
                            If cr.type = "peer" And ci.state = 263 Then  ' legt in Rückfrage auf
                                For x% = 0 To 13
                                    cReg(wp, x%) = ""
                                Next
                            End If

                            If cr.type = "this" And Left(cReg(wp, 5), Len(Form1.XMLdummy)) = Form1.XMLdummy Then

                            Else
                                If ci.state = 7 Then
                                    '  Debug.Print(TimeOfDay + "----> " + ci.msg + cr.e164 + ":" + cReg(wp, 4) + ":")
                                    If ci.msg = "x-rel" Then 'And cReg(wp, 15) = "x-setup" Then   ' "x-setup"
                                        ' If cReg(wp, 4) <> "" And cr.e164 <> "" Then
                                        If cr.e164 <> "" Then
                                            'If Len(cr.e164) < 6 Then
                                            If cr.type = "this" Then
                                                '  CFW = " " : CFWdest = "" : CFWstr = ""
                                                ' CFW = Admin("<show><user cn='" & cReg(wp, 4) & "'/></show>")  'in reg4 ist der Name
                                                ' CFW = Admin("<show><user cn='" & cr.dn & "'/></show>")

                                                ' CFW = Admin("<show><user e164='1212'/></show>")
                                                '   If InStr(CFW, "user") = 0 Then ' kein user in der PBX
                                                ' CFWstr = "9"
                                                ' Else
                                                ' CFWstr = "0"
                                                ' If InStr(CFW, "cfu") Then
                                                'CFWdest = Mid(CFW, (InStr(CFW, "cfu") + 15), 20)
                                                ' CFWdest = Mid(CFW, (InStr(CFW, "cfu")), 300)
                                                ' If InStr(CFWdest, "><ep e164=") <> 5 Then
                                                ' CFWdest = Mid(CFWdest, 5, 300)
                                                ' If InStr(CFWdest, "cfu") > 0 Then
                                                ' CFWdest = Mid(CFWdest, (InStr(CFWdest, "cfu")), 50)
                                                ' End If
                                                ' End If
                                                '  If InStr(CFWdest, "><ep e164=") = 5 Then
                                                'CFWdest = Mid(CFWdest, 16, 20)
                                                'If InStr(CFWdest, "/") > 3 Then
                                                'CFWdest = "->" + Mid(CFWdest, 16, InStr(CFWdest, "/") - 2)
                                                ' CFWdest = "=" + Mid(CFWdest, 1, InStr(CFWdest, "/") - 2)
                                                'End If
                                                ' CFWstr = "2"
                                                ' Else
                                                '    CFWdest = ""
                                                ' End If
                                                ' End If
                                                ' If InStr(CFW, "dnd-ext") <> 0 Then
                                                'CFWstr = "1"
                                                'End If
                                                'End If
                                                ' CFW = CFWstr + cReg(wp, 2) + " " + cReg(wp, 4) + " " + CFWdest
                                                'CFW = CFWstr + cr.dn + " " + Mid(cr.e164, 2, 20) + " " + CFWdest ' Cordivari Hack
                                                ' write DND
                                                Err.Clear()
                                                ' On Error Resume Next
                                                '       FileClose(3)
                                                '      FileOpen(3, cr.e164 + "AS.TXT", OpenMode.Append, OpenShare.Shared)
                                                '     FileClose(3)
                                                'FileOpen(3, cr.e164 + "AS.TXT", OpenMode.Output, OpenShare.Default)
                                                '   Print(3, CFW)
                                                '   Debug.Print("CFW=" + CFW)
                                                '    FileClose(3)
                                                'If Err.Number <> 0 Then
                                                'FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
                                                '       PrintLine(99, Now + " Event:" + Str$(Err.Number) + " <" + Err.Description + "> R: write DND: writing file: " + xmlPfad + cReg(wp, 2) + "TB.TXT")
                                                '       FileClose(99)
                                                '    End If
                                                On Error GoTo fehler
                                                CFW = ""
                                            End If
                                        End If
                                    End If
                                End If
                                If Val(cReg(wp, 0)) = Val(ci.call) Then
                                    For x% = 0 To 13
                                        cReg(wp, x%) = ""
                                    Next
                                End If
                            End If
                        End If

                    Else    ' Handel beschreiben
                        cReg(wp, 0) = ci.call
                        If ci.state = 5 Or ci.state = 133 Then ' wenn Verbindung
                            For dp = 0 To 99
                                If (cReg(dp, 5) = cr.e164 And dp <> wp) Then
                                    For x% = 0 To 13
                                        cReg(dp, x%) = ""
                                    Next
                                End If
                            Next
                        End If
                        Select Case cr.type
                            Case "this"   ' eine Source info
                                cReg(wp, 1) = ci.state      ' type   Status
                                cReg(wp, 2) = cr.e164       ' type   Nummer
                                cReg(wp, 4) = cr.cn         ' type   Name
                                cReg(wp, 15) = ci.msg
                            Case "peer"     ' eine destination info
                                cReg(wp, 5) = cr.e164  ' peer1  Nummer         
                                cReg(wp, 6) = cr.cn    ' peer1  Name
                                cReg(wp, 7) = ci.state ' peer1  Status
                            Case "leg2"
                                cReg(wp, 8) = cr.e164  ' peer2  Nummer
                                cReg(wp, 9) = cr.cn    ' peer2  Name
                                cReg(wp, 10) = ci.state  ' peer2  Status
                            Case Else
                        End Select
                    End If
                End If
            Next
            Me.form.events.Items.Clear()
            ' Gültige Pointer suchen
            For lc% = 1 To 199
                If cReg(lc%, 0) <> "" And cReg(lc%, 2) <> "" Then   ' Wenn es ein CR gibt und einen TN gibt
                    Anz = cReg(lc%, 2) + " " + cReg(lc%, 4)
                    CallStatus = Val(cReg(lc%, 1))
                    Select Case CallStatus
                        Case 1 : Anz = Anz + " ^ "
                        Case 4 : Anz = Anz + " > "
                        Case 132 : Anz = Anz + " > "
                        Case 5 : Anz = Anz + " <> "
                        Case 133 : Anz = Anz + " <> "
                        Case 261 : Anz = Anz + " ~ "
                        Case 389 : Anz = Anz + " ^ "
                        Case Else
                            Anz = Anz + " " + Str$(CallStatus) + " "
                    End Select
                    Anz = Anz + cReg(lc%, 5) + " " + cReg(lc%, 6)
                    CallStatus = Val(cReg(lc%, 7))
                    Select Case CallStatus
                        Case 1 : Anz = Anz + "  "
                        Case 4 : Anz = Anz + "  "
                        Case 5 : Anz = Anz + "  "
                        Case 129 : Anz = Anz + "  "
                        Case 132 : Anz = Anz + " > "
                        Case 133 : Anz = Anz + "   "
                        Case 389 : Anz = Anz + " ~ "
                        Case 261 : Anz = Anz + " ~ "
                        Case Else
                            Anz = Anz + " " + Str$(CallStatus) + " "
                    End Select
                    If cReg(lc%, 8) <> "" Then Anz = Anz + " (" + cReg(lc%, 8) + cReg(lc%, 9) + ") "
                    Me.form.events.Items.Add(Anz)
                    Anz = "   CR" + Str(lc%) + ": " + cReg(lc%, 0) + "-" + cReg(lc%, 1) + "-" + cReg(lc%, 2) + "-" + cReg(lc%, 3) + "-" + cReg(lc%, 4) + "-" + cReg(lc%, 5) + "-" + cReg(lc%, 6) + "-" + cReg(lc%, 7) + "-" + cReg(lc%, 8) + "-" + cReg(lc%, 9) + "-" + cReg(lc%, 10) + "-" + cReg(lc%, 11)
                    If Me.form.debugbot.Tag Then
                        Me.form.addline(Anz)
                        If Me.form.dbgview.Items.Count > 500 Then ' falls irgend jemand das Ding mit DBG ein laufen lässt...
                            Me.form.dbgview.Items.Clear()
                        End If
                    End If
                End If
            Next
        Next
        ' schedule next async Poll

        Me.startPolling()
        Exit Sub

fehler:
        Me.form.addline("poll exception stopping polling")
        Me.form.addline("### Error: " + Str(Err.Number))
        Me.form.addline("### Error: " + Err.Description)
        Me.form.pbxSession = -1
        If Err.Number <> 0 Then
            FileOpen(99, "innoBLF_Event_Log.txt", OpenMode.Append, OpenShare.Shared)
            PrintLine(99, Now + " Event:" + Str$(Err.Number) + " <error in polling-routine (link not o.k.)")
            FileClose(99)
        End If

        Err.Clear()
        Resume Faussprung
Faussprung:

    End Sub

End Class


