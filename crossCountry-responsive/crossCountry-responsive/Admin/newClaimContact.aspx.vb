Public Class newClaimContact
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

    Protected Sub bindCarrierList()
        Dim dtCarrierList As New DataTable
        dtCarrierList = objacess.getCompanyList()
        If dtCarrierList.Rows.Count >= 1 Then
            With ddlCarrier
                .DataSource = dtCarrierList
                .DataTextField = "Company"
                .DataValueField = "Company"
                .DataBind()
            End With
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            bindCarrierList()

        End If

    End Sub

    Protected Sub btnSaveContact_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objacess.insertClaimContact(txtEmail.Text, txtFirstName.Text, txtLastName.Text, ddlCarrier.Text)

            Response.Redirect("~/Admin/claimContactlist.aspx", False)

        Catch ex As Exception

        End Try
    End Sub

End Class