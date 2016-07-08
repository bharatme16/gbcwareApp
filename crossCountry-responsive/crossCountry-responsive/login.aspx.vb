Public Class login1
    Inherits System.Web.UI.Page
    Dim objAccess As New CrossCountryDataAccess.dataAccess
    '   Dim objClass As New CrossCountryDataAccess.IntegrityClass


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim roleTable As DataTable
        Dim userData As DataTable
        roleTable = objAccess.getRoleByUserName(txtUsername.Text, txtPassword.Text)
        userData = objAccess.getUsersDetailByEmail(txtUsername.Text)
        If roleTable.Rows.Count >= 1 Then
            Session("UserRole") = roleTable.Rows(0).Item("role_title")
            Session("EmailId") = txtUsername.Text
            objAccess.unLockUser(Session("EmailId"))
            Session("user_Id") = userData.Rows(0).Item("users_id")
            'Remember user name password as cookies
            '  rememberUserNamePassword()
            Try
                'Dim homePageUrl As String
                'homePageUrl = objClass.GetHomePage(Session("UserRole"))
                Response.Redirect("Default.aspx")
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class