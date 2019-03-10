Public Class LoginScreen
    Dim myTimer As New Timer()
    Dim randomGenerator As New Random()

    Private Sub LoginScreen_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Hide()
        SplashScreen.Close()
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        GlobalVariables.UserID = -1
        GlobalVariables.setLogin(False)

        Dim myconn As New SqlClient.SqlConnection
        Dim mycommand As New SqlClient.SqlCommand
        Dim myadapter As New SqlClient.SqlDataAdapter
        Dim mydt As New DataTable

        myconn.ConnectionString = GlobalVariables.ConnectionString
        myconn.Open()
        mycommand = New SqlClient.SqlCommand
        mycommand.CommandText = "Select user_id from users where username = @username and password = @password"
        mycommand.Parameters.Add("@username", SqlDbType.VarChar, 50)
        mycommand.Parameters("@username").Value = UsernameBox.Text
        mycommand.Parameters.Add("@password", SqlDbType.VarChar, 50)
        mycommand.Parameters("@password").Value = PasswordBox.Text
        mycommand.Connection = myconn

        mydt = New DataTable
        myadapter.SelectCommand = mycommand
        myadapter.Fill(mydt)

        If mydt.Rows.Count.ToString > 0 Then
            'opens main window'
            GlobalVariables.UserID = mydt.Rows(0).Item(0).ToString
            GlobalVariables.setLogin(True)

            MainScreen.Show()
            Hide()
        Else
            'shows wrong password'
            CustomMessageBox.Message.Text = "Wrong password"
            CustomMessageBox.Ok_Button.Text = "Try again"
            CustomMessageBox.Cancel_Button.Text = "Reset"
            CustomMessageBox.Cancel_Button.Visible = True

            If CustomMessageBox.ShowDialog() = DialogResult.Cancel Then
                Hide()
                ResetScreen.Show()
            End If
        End If
    End Sub

    Private Sub RegisterBtn_Click(sender As Object, e As EventArgs) Handles RegisterBtn.Click
        'opens register form'
        RegisterScreen.Show()
        Hide()
    End Sub

    Private Sub LoginScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        myTimer.Interval = 1000
        AddHandler myTimer.Tick, AddressOf HandleTimerTick
        myTimer.Start()
    End Sub

    Private Sub HandleTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim totalImages As Integer = 18
        totalImages += 1

        Dim leftImage As Integer = randomGenerator.Next(1, totalImages)
        Dim rightImage As Integer = randomGenerator.Next(1, totalImages)

        While leftImage.Equals(rightImage)
            If leftImage.Equals(totalImages) Then
                rightImage = randomGenerator.Next(1, totalImages)
            Else
                rightImage += 1
            End If
        End While

        PictureBox1.Image = My.Resources.ResourceManager.GetObject("image_" & leftImage)
        PictureBox2.Image = My.Resources.ResourceManager.GetObject("image_" & rightImage)
    End Sub
End Class