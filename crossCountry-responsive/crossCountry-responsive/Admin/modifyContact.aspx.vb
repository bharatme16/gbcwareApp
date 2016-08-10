Public Class modifyContact
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

#Region "Properties"

    Private Property contactId As Integer
        Get
            If IsNothing(ViewState("contactId")) Then

                ViewState("contactId") = Request.QueryString("contactId")

            End If
            Return CInt(ViewState("contactId"))
        End Get
        Set(value As Integer)
            ViewState("contactId") = value
        End Set
    End Property

#End Region

    Public Sub loadContactDetail(ByVal repId As Integer)
        Dim tableContactDetail As New DataTable

        Try
            tableContactDetail = objacess.getRepById(repId)
            If tableContactDetail.Rows.Count >= 1 Then
                txtFirstName.Text = tableContactDetail.Rows(0).Item("First Name")
                txtLastName.Text = tableContactDetail.Rows(0).Item("Last Name")
                lblCarrier.Text = tableContactDetail.Rows(0).Item("Carrier")
                txtEmail.Text = tableContactDetail.Rows(0).Item("Email")


            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnYes.Visible = False
            btnNo.Visible = False
            loadContactDetail(contactId)
            lblConfirmation.Visible = False
        End If

    End Sub

    Protected Sub btnSaveContact_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objacess.updateRep(contactId, txtFirstName.Text, txtLastName.Text, lblCarrier.Text, txtEmail.Text)

            Response.Redirect("~/Admin/claimContactlist.aspx", False)

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnDeleteContact_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        btnYes.Visible = True
        btnNo.Visible = True
        btnDeleteContact.Visible = False
        btnSaveContact.Visible = False
        lblConfirmation.Text = "Are you sure you want to remove this contact?"
        lblConfirmation.Visible = True
    End Sub

    Protected Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            objacess.deleteRep(contactId)
            Response.Redirect("~/Admin/claimContactList.aspx", False)
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