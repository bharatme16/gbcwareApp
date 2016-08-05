Imports System.IO
Imports businessLibrary

Public Class modifyUser
    Inherits System.Web.UI.Page

    Dim objacess As New crossCountryDataAccess.dataAccess
    Dim objparameter As New paramaterManager

#Region "Properties"

    Private Property userID As Integer
        Get
            If IsNothing(ViewState("userId")) Then

                ViewState("userId") = Request.QueryString("userId")

            End If
            Return CInt(ViewState("userId"))
        End Get
        Set(value As Integer)
            ViewState("userId") = value
        End Set
    End Property

#End Region

    Public Sub loadUserDetail(ByVal userId As Integer)
        Dim tableUserDetail As New DataTable
        Dim tableRole As New DataTable

        Try
            tableUserDetail = objacess.getUsersDetailByUserId(userId)
            If tableUserDetail.Rows.Count >= 1 Then
                txtFirstName.Text = tableUserDetail.Rows(0).Item("f_name")
                txtLastName.Text = tableUserDetail.Rows(0).Item("l_name")
                txtStreet.Text = tableUserDetail.Rows(0).Item("_street")
                txtCity.Text = tableUserDetail.Rows(0).Item("_city")
                ddlstate.Text = tableUserDetail.Rows(0).Item("_state")
                txtZipCode.Text = tableUserDetail.Rows(0).Item("z_code")
                txtPrimaryTelephone.Text = tableUserDetail.Rows(0).Item("t_phone")
                txtSecondaryTelephone.Text = tableUserDetail.Rows(0).Item("alt_phone")
                txtEmail.Text = tableUserDetail.Rows(0).Item("e_mail")
                txtTitle.Text = tableUserDetail.Rows(0).Item("_title")
                Session("email") = tableUserDetail.Rows(0).Item("e_mail")
                txtSymbilityId.Text = tableUserDetail.Rows(0).Item("symbilityId")
                If CBool(tableUserDetail.Rows(0).Item("isLockedOut")) = True Then
                    lblUserStatus.Text = "Disabled"
                    btnLockUnlockUser.Text = "Unlock User"
                Else
                    lblUserStatus.Text = "Active"
                    btnLockUnlockUser.Text = "Lock User"
                End If
                If CBool(tableUserDetail.Rows(0).Item("isActive")) = True Then
                    lblAdjusterStatus.Text = "Active"
                    btnEnableDisable.Text = "Disable User"
                Else
                    lblAdjusterStatus.Text = "Disabled"
                    btnEnableDisable.Text = "Enable User"
                End If

                tableRole = objacess.getUserRoleByUserid(userId)
                If tableRole.Rows.Count >= 1 Then
                    lblCurrentRole.Text = tableRole.Rows(0).Item("role_title")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub bindStateList()
        Dim dtStateList As New DataTable
        dtStateList = objacess.getAllState()
        If dtStateList.Rows.Count >= 1 Then
            With ddlstate

                .DataSource = dtStateList
                .DataTextField = "name_short"
                .DataValueField = "name_short"
                .DataBind()

            End With
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadUserDetail(userID)
            bindStateList()
            loadRoles()
        End If
    End Sub


    Protected Sub loadRoles()
        Dim roleTable As DataTable
        roleTable = objacess.getRoleList()
        ' pnlChangeRole.Visible = True
        With ddlSelectRole
            .DataSource = roleTable
            .DataTextField = "Role"
            .DataValueField = "Role"
            .DataMember = "Role"
            .DataBind()
        End With
    End Sub

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        objacess.updateRole(ddlSelectRole.Text, userID)
        '   pnlChangeRole.Visible = False
        loadUserDetail(userID)

    End Sub



    Protected Sub btnLockUnlockUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnLockUnlockUser.Text = "Unlock User" Then
            objacess.unLockUser(txtEmail.Text)
            loadUserDetail(userID)
        Else
            objacess.lockUser(txtEmail.Text)
            loadUserDetail(userID)
        End If
    End Sub


    Protected Sub btnSaveuser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim symbility As String
            If txtSymbilityId.Text = String.Empty Then
                symbility = "NA"
            Else
                symbility = txtSymbilityId.Text
            End If
            objacess.modifyUsers(txtFirstName.Text, txtLastName.Text,
                                  txtStreet.Text, txtCity.Text,
                                  ddlstate.Text, txtZipCode.Text, txtPrimaryTelephone.Text,
                                  txtSecondaryTelephone.Text, Session("email"), txtEmail.Text, txtTitle.Text, symbility)
            Response.Redirect("~/Admin/userslist.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class