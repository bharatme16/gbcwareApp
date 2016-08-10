Public Class newCarrier
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindStateList()
        End If
    End Sub

    Protected Sub bindStateList()
        Dim dtStateList As New DataTable
        dtStateList = objacess.getAllState()
        If dtStateList.Rows.Count >= 1 Then
            With ddlState

                .DataSource = dtStateList
                .DataTextField = "name_short"
                .DataValueField = "name_short"
                .DataBind()
            End With
        End If
    End Sub

    Protected Sub btnSaveContact_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objacess.addNewCompany(txtCarrierName.Text, txtCarrierStreet.Text, txtCity.Text, ddlState.Text, txtZip.Text, txtPrimaryPhone.Text, txtPrimaryEmail.Text)

            Response.Redirect("~/Admin/carrierlist.aspx", False)

        Catch ex As Exception

        End Try
    End Sub

End Class