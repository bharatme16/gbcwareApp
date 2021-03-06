﻿Imports System.Data

Public Class claimContactList
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindDropDown()
            'bindGridView()
        End If
    End Sub

    'select button pressed
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        bindGridView(ddlChooseCarrier.Text)
    End Sub

    'bind carrier drop down list
    Protected Sub bindDropDown()
        Dim tableCarrierList As New DataTable
        tableCarrierList = objacess.getCompanyList()
        If tableCarrierList.Rows.Count >= 1 Then
            With ddlChooseCarrier
                .DataSource = tableCarrierList
                .DataTextField = "Company"
                .DataValueField = "Company"
                .DataBind()
                .Items.Insert(0, "-Select Carrier-")
            End With
        End If

    End Sub

    'bind gridview
    Protected Sub bindGridView(ByVal carrier As String)
        Dim dtReports As New DataTable
        ViewState("carrier") = carrier

        Try
            dtReports = objacess.getContactListByCompany(carrier)
            If dtReports.Rows.Count >= 1 Then
                gdFiles.DataSource = dtReports
                gdFiles.DataBind()

            Else
                gdFiles.DataSource = dtReports
                gdFiles.DataBind()
            End If

        Catch ex As Exception
        End Try

    End Sub

    'Sort Records
    Protected Sub sortRecords(sender As Object, e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression
        Dim direction As String = String.Empty

        If SortDirection = SortDirection.Ascending Then
            SortDirection = SortDirection.Descending
            direction = " DESC"
        Else
            SortDirection = SortDirection.Ascending
            direction = " ASC"
        End If



        Dim dt As New DataTable

        dt = objacess.getContactListByCompany(ViewState("carrier").ToString)
        If dt.Rows.Count >= 1 Then
            ViewState("SortExpr") = sortExpression & direction
            dt.DefaultView.Sort = sortExpression & direction
            gdFiles.DataSource = dt
            gdFiles.DataBind()
        End If

    End Sub

    'Sort Direction
    Public Property SortDirection() As SortDirection
        Get
            If ViewState("SortDirection") Is Nothing Then
                ViewState("SortDirection") = SortDirection.Ascending
            End If
            Return DirectCast(ViewState("SortDirection"), SortDirection)
        End Get
        Set
            ViewState("SortDirection") = Value
        End Set
    End Property

    'paging
    Private Sub gdFiles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdFiles.PageIndexChanging
        Dim dt As New DataTable
        dt = objacess.getContactListByCompany(ViewState("carrier").ToString)
        gdFiles.PageIndex = e.NewPageIndex
        dt.DefaultView.Sort = ViewState("SortExpr").ToString
        gdFiles.DataSource = dt
        gdFiles.DataBind()
    End Sub
End Class