Public Class MainScreen
    Dim myconnection As New SqlClient.SqlConnection
    Dim mycommand As New SqlClient.SqlCommand
    Dim myadapter As New SqlClient.SqlDataAdapter
    Dim mydt As New DataTable
    Dim r As New Random

    Private Sub clickloop(sender As Object, e As EventArgs)
        Dim b As PictureBox = CType(sender, PictureBox)
        GlobalVariables.ProductID = b.Tag
        Me.Hide()
        ProductInformation.Show()
    End Sub

    Private Sub btnProducts_MouseHover(sender As Object, e As EventArgs) Handles btnProducts.MouseHover
        btnProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnProducts.ForeColor = System.Drawing.Color.White
        btnProducts.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnProducts_MouseLeave(sender As Object, e As EventArgs) Handles btnProducts.MouseLeave
        btnProducts.BackColor = System.Drawing.Color.White
        btnProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnProducts.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnHistory_MouseHover(sender As Object, e As EventArgs) Handles btnHistory.MouseHover
        btnHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnHistory.ForeColor = System.Drawing.Color.White
        btnHistory.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnHistory_MouseLeave(sender As Object, e As EventArgs) Handles btnHistory.MouseLeave
        btnHistory.BackColor = System.Drawing.Color.White
        btnHistory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnHistory.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnShoppingCart_MouseHover(sender As Object, e As EventArgs) Handles btnShoppingCart.MouseHover
        btnShoppingCart.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnShoppingCart.ForeColor = System.Drawing.Color.White
        btnShoppingCart.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnShoppingCart_MouseLeave(sender As Object, e As EventArgs) Handles btnShoppingCart.MouseLeave
        btnShoppingCart.BackColor = System.Drawing.Color.White
        btnShoppingCart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnShoppingCart.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnAboutUs_MouseHover(sender As Object, e As EventArgs) Handles btnAboutUs.MouseHover
        btnAboutUs.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnAboutUs.ForeColor = System.Drawing.Color.White
        btnAboutUs.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnAboutUs_MouseLeave(sender As Object, e As EventArgs) Handles btnAboutUs.MouseLeave
        btnAboutUs.BackColor = System.Drawing.Color.White
        btnAboutUs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnAboutUs.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnHome_MouseHover(sender As Object, e As EventArgs) Handles btnHome.MouseHover
        btnHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnHome.ForeColor = System.Drawing.Color.White
        btnHome.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnHome_MouseLeave(sender As Object, e As EventArgs) Handles btnHome.MouseLeave
        btnHome.BackColor = System.Drawing.Color.White
        btnHome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnHome.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Me.Hide()
        HistoryScreen.Show()
    End Sub

    Private Sub btnShoppingCart_Click(sender As Object, e As EventArgs) Handles btnShoppingCart.Click
        Me.Hide()
        ShoppingCartScreen.Show()
    End Sub

    Private Sub btnAboutUs_Click(sender As Object, e As EventArgs) Handles btnAboutUs.Click
        Me.Hide()
        AboutUsScreen.Show()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Me.Hide()
        LoginScreen.Show()
    End Sub

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim picbox As PictureBox() = New PictureBox() {PictureBox2, PictureBox3, PictureBox4, PictureBox5, PictureBox6, PictureBox7, PictureBox8, PictureBox9, PictureBox10, PictureBox11, PictureBox12, PictureBox13, PictureBox14, PictureBox15, PictureBox16}
        myconnection.ConnectionString = GlobalVariables.ConnectionString
        myconnection.Open()
        mycommand = New SqlClient.SqlCommand
        mycommand.Parameters.Add("@id", SqlDbType.Int, 10, "id")

        For i As Integer = 1 To 15
            mycommand.Parameters("@id").Value = i
            mycommand.CommandText = "Select picture from products where id=@id"
            mycommand.Connection = myconnection
            mydt = New DataTable
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydt)

            picbox(i - 1).Image = My.Resources.ResourceManager.GetObject(mydt.Rows(0).Item(0).ToString)
        Next

        myconnection.Close()

        For i As Integer = 0 To 14
            AddHandler picbox(i).Click, AddressOf clickloop
        Next
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click

    End Sub
End Class