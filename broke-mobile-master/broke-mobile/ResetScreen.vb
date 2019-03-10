Public Class ResetScreen
    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        Dim myconn As New SqlClient.SqlConnection
        Dim mycommand As New SqlClient.SqlCommand
        Dim myadapter As New SqlClient.SqlDataAdapter
        Dim mydt As New DataTable

        mydt = New DataTable
        myconn.ConnectionString = GlobalVariables.ConnectionString
        myconn.Open()
        mycommand = New SqlClient.SqlCommand

        mycommand.CommandText = "Select user_id from users where username = @username"
        mycommand.Parameters.Add("@username", SqlDbType.VarChar, 50)
        mycommand.Parameters("@username").Value = Username.Text
        mycommand.Connection = myconn
        myadapter.SelectCommand = mycommand
        myadapter.Fill(mydt)
        mycommand.CommandText = "Update users set password = 'Hello123'"
        myadapter.UpdateCommand = mycommand

        If (mydt.Rows.Count.ToString = 0) Then
            CustomMessageBox.Message.Text = "Username not found"
            CustomMessageBox.ShowDialog()
        Else
            Try
                mycommand.ExecuteNonQuery()
                CustomMessageBox.Message.Text = "A new password was sent to your email." & vbNewLine & "Your new password is Hello123"
            Catch ex As Exception
                CustomMessageBox.Message.Text = ex.Message
            Finally
                CustomMessageBox.ShowDialog()
                LoginScreen.Show()
                Me.Hide()
            End Try
        End If
    End Sub
End Class