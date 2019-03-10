Public Class CustomMessageBox
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CustomMessageBox_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Ok_Button.Text = "Ok"
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.Visible = False
    End Sub
End Class