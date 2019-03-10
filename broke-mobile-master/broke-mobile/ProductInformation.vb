Public Class ProductInformation
    Dim myconnection As New SqlClient.SqlConnection
    Dim mycommand As New SqlClient.SqlCommand
    Dim myadapter As New SqlClient.SqlDataAdapter
    Dim mydt As New DataTable

    Private Sub ProductInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add any initialization after the InitializeComponent() call.
        myconnection.ConnectionString = GlobalVariables.ConnectionString
        myconnection.Open()
        mycommand = New SqlClient.SqlCommand
        mycommand.Parameters.Add("@id", SqlDbType.Int, 10, "id")
        mycommand.Parameters("@id").Value = GlobalVariables.ProductID
        mycommand.CommandText = "Select manufacturer, model, description, operating_system, weight, price, device_storage, picture from products where id=@id"

        mycommand.Connection = myconnection
        mydt = New DataTable
        myadapter.SelectCommand = mycommand
        myadapter.Fill(mydt)
        PictureBox2.Image = My.Resources.ResourceManager.GetObject(mydt.Rows(0).Item(7).ToString)
        Label7.DataBindings.Add("Text", mydt, "manufacturer")
        Label8.DataBindings.Add("Text", mydt, "model")
        Label9.DataBindings.Add("Text", mydt, "operating_system")
        Label10.DataBindings.Add("Text", mydt, "device_storage")
        Label11.DataBindings.Add("Text", mydt, "weight")
        Label12.DataBindings.Add("Text", mydt, "price")
        RichTextBox1.DataBindings.Add("Text", mydt, "description")

        myconnection.Close()
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

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Me.Close()
        MainScreen.Show()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Me.Close()
        HistoryScreen.Show()
    End Sub

    Private Sub btnShoppingCart_Click(sender As Object, e As EventArgs) Handles btnShoppingCart.Click
        Me.Close()
        ShoppingCartScreen.Show()
    End Sub

    Private Sub btnAboutUs_Click(sender As Object, e As EventArgs) Handles btnAboutUs.Click
        Me.Close()
        AboutUsScreen.Show()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Me.Close()
        LoginScreen.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myinsert As New SqlClient.SqlCommand
        myconnection.Open()
        myinsert.Connection = myconnection
        myinsert.CommandText = "Insert into shopping_cart (user_id,product_id,quantity) Values (@userid,@productid,@quantity)"
        myinsert.Parameters.Add("@userid", SqlDbType.Int, 10, "user_id").Value = GlobalVariables.UserID
        myinsert.Parameters.Add("@productid", SqlDbType.Int, 10, "product_id").Value = GlobalVariables.ProductID
        myinsert.Parameters.Add("@quantity", SqlDbType.Int, 10, "quantity").Value = quantity.Text.ToString
        myinsert.ExecuteNonQuery()
        myadapter.InsertCommand = myinsert

        myconnection.Close()

        CustomMessageBox.Message.Text = "Added " & quantity.Text & " phones to Shopping Cart"
        CustomMessageBox.ShowDialog()
        quantity.Text = 1
    End Sub
End Class