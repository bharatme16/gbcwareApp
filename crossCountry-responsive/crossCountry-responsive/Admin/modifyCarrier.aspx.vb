Public Class modifyCarrier
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

#Region "Properties"

    Private Property companyId As Integer
        Get
            If IsNothing(ViewState("companyId")) Then

                ViewState("companyId") = Request.QueryString("companyId")

            End If
            Return CInt(ViewState("companyId"))
        End Get
        Set(value As Integer)
            ViewState("companyId") = value
        End Set
    End Property

#End Region

    Public Sub loadContactDetail(ByVal companyId As Integer)
        Dim tableContactDetail As New DataTable

        Try
            tableContactDetail = objacess.getCompanyDetailByCompanyId(companyId)
            If tableContactDetail.Rows.Count >= 1 Then
                txtCarrierName.Text = tableContactDetail.Rows(0).Item("company_name")
                txtCarrierStreet.Text = tableContactDetail.Rows(0).Item("company_address")
                txtCity.Text = tableContactDetail.Rows(0).Item("company_city")
                ddlState.Text = tableContactDetail.Rows(0).Item("company_state")
                txtZip.Text = tableContactDetail.Rows(0).Item("company_zip")
                txtPrimaryPhone.Text = tableContactDetail.Rows(0).Item("company_phone")
                txtPrimaryEmail.Text = tableContactDetail.Rows(0).Item("company_email")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnYes.Visible = False
            btnNo.Visible = False
            loadContactDetail(companyId)
            lblConfirmation.Visible = False
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
            objacess.modifyCompany(companyId, txtCarrierName.Text, txtCarrierStreet.Text, txtCity.Text, ddlState.Text, txtZip.Text, txtPrimaryPhone.Text, txtPrimaryEmail.Text)

            Response.Redirect("~/Admin/carrierlist.aspx", False)

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnDeleteContact_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnYes.Visible = True
        btnNo.Visible = True
        btnDeleteContact.Visible = False
        btnSaveContact.Visible = False
        lblConfirmation.Text = "Are you sure you want to remove this carrier?"
        lblConfirmation.Visible = True
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objacess.deleteCompany(companyId)
            Response.Redirect("~/Admin/carrierList.aspx", False)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnYes.Visible = False
        btnNo.Visible = False
        btnDeleteContact.Visible = True
        btnSaveContact.Visible = True
    End Sub


End Class