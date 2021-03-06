﻿Public Class adjusterClaims
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess

#Region "Properties"

    Private Property adjusterId As Integer
        Get
            If IsNothing(ViewState("adjusterId")) Then

                ViewState("adjusterId") = Request.QueryString("adjusterId")

            End If
            Return CInt(ViewState("adjusterId"))
        End Get
        Set(value As Integer)
            ViewState("adjusterId") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindGridView()
        End If
    End Sub

    Protected Sub bindGridView()
        Dim dtReports As New DataTable

        Try
            dtReports = objacess.getAssignedClaimByAdjusterId(adjusterId)
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

        dt = objacess.getAssignedClaimByAdjusterId(adjusterId)
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



    Private Sub gdFiles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdFiles.PageIndexChanging
        Dim dt As New DataTable
        dt = objacess.getAssignedClaimByAdjusterId(adjusterId)
        gdFiles.PageIndex = e.NewPageIndex
        dt.DefaultView.Sort = ViewState("SortExpr").ToString
        gdFiles.DataSource = dt
        gdFiles.DataBind()
    End Sub

End Class