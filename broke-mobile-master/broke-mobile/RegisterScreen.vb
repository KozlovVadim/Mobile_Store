Public Class RegisterScreen
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myconn As New SqlClient.SqlConnection
        Dim mycommand As New SqlClient.SqlCommand
        Dim myadapter As New SqlClient.SqlDataAdapter
        Dim mydt As New DataTable
        Dim noErrors As Boolean

        mydt = New DataTable
        noErrors = False
        myconn.ConnectionString = GlobalVariables.ConnectionString
        myconn.Open()
        mycommand = New SqlClient.SqlCommand

        mycommand.CommandText = "Select user_id from users where username = @username"
        mycommand.Parameters.Add("@username", SqlDbType.VarChar, 50)
        mycommand.Parameters("@username").Value = Username.Text
        mycommand.Connection = myconn
        myadapter.SelectCommand = mycommand
        myadapter.Fill(mydt)

        If (Username.Text.Length < 3) Then
            CustomMessageBox.Message.Text = "Username should be at least 3 characters long"
            noErrors = True
        ElseIf (mydt.Rows.Count.ToString > 0) Then
            CustomMessageBox.Message.Text = "Username already in use"
            noErrors = True
        ElseIf Password.Text.Length < 6 Then
            CustomMessageBox.Message.Text = "Password should be at least 6 characters long"
            noErrors = True
        Else
            mycommand = New SqlClient.SqlCommand
            mycommand.CommandText = "Select user_id from users where email = @email"
            mycommand.Parameters.Add("@email", SqlDbType.VarChar, 50)
            mycommand.Parameters("@email").Value = Email.Text
            mycommand.Connection = myconn
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydt)
            noErrors = False

            If Email.Text.Equals("") Then
                CustomMessageBox.Message.Text = "Email address should not be empty"
                noErrors = True
            ElseIf Not Email.Text.Contains("@") Then
                CustomMessageBox.Message.Text = "Invalid Email"
                noErrors = True
            ElseIf (mydt.Rows.Count.ToString > 0) Then
                CustomMessageBox.Message.Text = "Email already in use"
                noErrors = True
            ElseIf Not Email.Text.Equals(Email2.Text) Then
                CustomMessageBox.Message.Text = "Emails dont match"
                noErrors = True
            Else
                noErrors = False
            End If
        End If

        If Not noErrors Then
            mycommand = New SqlClient.SqlCommand
            mycommand.Connection = myconn
            mycommand.CommandText = "insert into users(email, username, password) values (@email, @username, @password)"
            mycommand.Parameters.Add("@username", SqlDbType.VarChar, 50)
            mycommand.Parameters.Add("@password", SqlDbType.VarChar, 50)
            mycommand.Parameters.Add("@email", SqlDbType.VarChar, 50)
            mycommand.Parameters("@username").Value = Username.Text
            mycommand.Parameters("@password").Value = Password.Text
            mycommand.Parameters("@email").Value = Email.Text
            myadapter.InsertCommand = mycommand

            Try
                mycommand.ExecuteNonQuery()
                CustomMessageBox.Message.Text = "Account created"
            Catch ex As Exception
                CustomMessageBox.Message.Text = ex.Message
            Finally
                myconn.Close()
                Me.Hide()
                LoginScreen.Show()
            End Try
        End If

        CustomMessageBox.ShowDialog()
    End Sub
End Class