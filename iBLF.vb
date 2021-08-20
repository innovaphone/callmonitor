Public Class iBLF
    Public Shared form1
    Dim pbxTimer As myPBX
    Dim wx As Array



    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub iBLF_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Setup.Foreground.Checked Then Me.TopMost = True Else Me.TopMost = False
    End Sub


    Private Sub iBLF_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged

    End Sub


    Private Sub iBLF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub iBLF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSetup.Click
        ' form1.Tag = "1"
        'form1.Setup_Load()
        Setup.Show()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub Setup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub iBLF_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        'Debug.Print(Me.Location.X)
        'Debug.Print(Me.Location.Y)
        '   Form1.Timer1.Tag = "1"
    End Sub


    Private Sub iBLF_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Me.Width = Fx.Tag
        Me.Height = Fy.Tag
        If Me.Width < 120 Then Me.Width = 120
        If Me.Height < 80 Then Me.Height = 80

    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub LabelL114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelL114.Click

    End Sub

    
End Class
