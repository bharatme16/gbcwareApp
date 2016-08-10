Imports System.IO
Imports businessLibrary

Public Class newUser
    Inherits System.Web.UI.Page

    Dim objacess As New CrossCountryDataAccess.dataAccess
    Dim objparameter As New paramaterManager

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
            bindStateList()
            loadRoles()
        End If
    End Sub


    Protected Sub loadRoles()
        Dim roleTable As DataTable
        roleTable = objacess.getRoleList()
        ' pnlChangeRole.Visible = True
        With ddlRollList
            .DataSource = roleTable
            .DataTextField = "Role"
            .DataValueField = "Role"
            .DataMember = "Role"
            .DataBind()
        End With
    End Sub

    Protected Sub btnSaveuser_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '*****************remove this and create real password generation**********************
        Dim password As String
        password = "1234"
        '**************************************************************************************
        Try
            Dim symbility As String
            If txtSymbilityId.Text = String.Empty Then
                symbility = "NA"
            Else
                symbility = txtSymbilityId.Text
            End If

            objacess.insertUsers(txtFirstName.Text, txtLastName.Text,
                                  txtStreet.Text, txtCity.Text,
                                  ddlstate.Text, txtZipCode.Text, txtPrimaryTelephone.Text,
                                  txtSecondaryTelephone.Text, txtEmail.Text, password, txtTitle.Text, symbility)
            objacess.assignUserRole(txtEmail.Text, ddlRollList.Text)
            Response.Redirect("~/Admin/userlist.aspx", False)
        Catch ex As Exception

        End Try
    End Sub
End Class