Public Class ShoppingCartScreen
    Private Sub btnProducts_MouseHover(sender As Object, e As EventArgs)
        btnProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnProducts.ForeColor = System.Drawing.Color.White
        btnProducts.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnProducts_MouseLeave(sender As Object, e As EventArgs)
        btnProducts.BackColor = System.Drawing.Color.White
        btnProducts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnProducts.Size = New System.Drawing.Size(100, 50)
    End Sub

    Private Sub btnHistory_MouseHover(sender As Object, e As EventArgs)
        btnHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(252, Byte), Integer))
        btnHistory.ForeColor = System.Drawing.Color.White
        btnHistory.Size = New System.Drawing.Size(110, 60)
    End Sub

    Private Sub btnHistory_MouseLeave(sender As Object, e As EventArgs)
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
        Me.Hide()
        MainScreen.Show()
    End Sub
    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Me.Hide()
        HistoryScreen.Show()
    End Sub
    Private Sub btnAboutUs_Click(sender As Object, e As EventArgs) Handles btnAboutUs.Click
        Me.Hide()
        AboutUsScreen.Show()
    End Sub
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Me.Hide()
        LoginScreen.Show()
    End Sub
End Class