Public Class GlobalVariables
    Public Shared UserID As Integer = 0
    Public Shared ProductID As Integer = 1
    Public Shared ResourcesFolder As String = "C:\wamp\www\broke-mobile\broke-mobile\Resources\"
    Public Shared ConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\wamp\www\broke-mobile\broke-mobile\brokeMobileDB.mdf;Integrated Security=True;Connect Timeout=30"

    Public Sub setLogin(isLogged As Boolean)
        If isLogged Then
            AboutUsScreen.btnHome.Text = "Logout"
            HistoryScreen.btnHome.Text = "Logout"
            MainScreen.btnHome.Text = "Logout"
            ProductInformation.btnHome.Text = "Logout"
            ShoppingCartScreen.btnHome.Text = "Logout"
        Else
            AboutUsScreen.btnHome.Text = "Login"
            HistoryScreen.btnHome.Text = "Login"
            MainScreen.btnHome.Text = "Login"
            ProductInformation.btnHome.Text = "Login"
            ShoppingCartScreen.btnHome.Text = "Login"
        End If
    End Sub
End Class