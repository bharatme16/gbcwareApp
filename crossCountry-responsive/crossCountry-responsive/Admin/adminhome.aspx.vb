Public Class adminhome
    Inherits System.Web.UI.Page
    Dim objAccess As New CrossCountryDataAccess.dataAccess
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            getlabelBadges()
        End If
    End Sub


    Protected Sub ClaimsToReview_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tableOpenClaims As New DataTable
        ViewState("listClicked") = "open"
        Try
            tableOpenClaims = objAccess.getAllOpenClaimsList()
            If tableOpenClaims.Rows.Count >= 1 Then
                '   lblGridViewHeading.Text = "Open Claim List"
                gdupdate.DataSource = tableOpenClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub gdupdate_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdupdate.PageIndexChanging
        Dim dt As New DataTable
        If ViewState("listClicked") = "criticalClaim" Then
            dt = objAccess.getCriticalClaimsList()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "open" Then
            dt = objAccess.getAllOpenClaimsList()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "overdueClaim" Then
            dt = objAccess.getOverdueClaimsList()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "Claims to review" Then
            dt = objAccess.getClaimsToReview
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "monthlyClaims" Then
            dt = objAccess.getAllClaimsForMonth()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "TodaysClaims" Then
            dt = objAccess.getAllClaimsForToday()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        ElseIf ViewState("listClicked") = "10Days" Then
            dt = objAccess.getAll10DayOldClaims()
            gdupdate.PageIndex = e.NewPageIndex
            dt.DefaultView.Sort = ViewState("SortExpr").ToString
            gdupdate.DataSource = dt
            gdupdate.DataBind()
        End If
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
        If ViewState("listClicked") = "criticalClaim" Then
            dt = objAccess.getCriticalClaimsList()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "open" Then
            dt = objAccess.getAllOpenClaimsList()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "overdueClaim" Then
            dt = objAccess.getOverdueClaimsList()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "Claims to review" Then
            dt = objAccess.getClaimsToReview
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "monthlyClaims" Then
            dt = objAccess.getAllClaimsForMonth()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "TodaysClaims" Then
            dt = objAccess.getAllClaimsForToday()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
        ElseIf ViewState("listClicked") = "10Days" Then
            dt = objAccess.getAll10DayOldClaims()
            If dt.Rows.Count >= 1 Then
                ViewState("SortExpr") = sortExpression & direction
                dt.DefaultView.Sort = sortExpression & direction
                gdupdate.DataSource = dt
                gdupdate.DataBind()
            End If
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

    '10 Days Old Claims
    Protected Sub view10DaysOldClaims(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableOpenClaims As New DataTable
        ViewState("listClicked") = "10Days"
        Try
            tableOpenClaims = objAccess.getAll10DayOldClaims()
            If tableOpenClaims.Rows.Count >= 1 Then
                lblHeader.Text = "10 Days Old"
                gdupdate.DataSource = tableOpenClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Open Claims
    Protected Sub viewOpenClaims(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableOpenClaims As New DataTable
        ViewState("listClicked") = "open"
        Try
            tableOpenClaims = objAccess.getAllOpenClaimsList()
            If tableOpenClaims.Rows.Count >= 1 Then
                lblHeader.Text = "Open Claim List"
                gdupdate.DataSource = tableOpenClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Overdue Claims
    Protected Sub viewOverdueClaims(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableOverDueClaims As New DataTable
        ViewState("listClicked") = "overdueClaim"
        Try
            tableOverDueClaims = objAccess.getOverdueClaimsList()
            If tableOverDueClaims.Rows.Count >= 1 Then
                lblHeader.Text = "Overdue Claims List"
                gdupdate.DataSource = tableOverDueClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception
        End Try



    End Sub



    'Critical Claims
    Protected Sub viewCriticalClaims(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableCriticalClaims As New DataTable
        ViewState("listClicked") = "criticalClaim"
        Try
            tableCriticalClaims = objAccess.getCriticalClaimsList()
            If tableCriticalClaims.Rows.Count >= 1 Then
                lblHeader.Text = "Critical Claims List"
                gdupdate.DataSource = tableCriticalClaims
                gdupdate.DataBind()

            End If
        Catch ex As Exception

        End Try


    End Sub


    'Claims This Month
    Protected Sub viewClaimsThisMonth(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableAllMonthlyClaims As New DataTable
        Session("listClicked") = "monthlyClaims"
        Try
            tableAllMonthlyClaims = objAccess.getAllClaimsForMonth()
            If tableAllMonthlyClaims.Rows.Count >= 1 Then
                lblHeader.Text = "All Claims For This Month"
                gdupdate.DataSource = tableAllMonthlyClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub


    'Claims Today
    Protected Sub viewclaimsToday(ByVal sender As Object, ByVal e As System.EventArgs)
        ViewState("SortExpr") = "Carrier ASC"
        Dim tableTodaysClaims As New DataTable
        Session("listClicked") = "TodaysClaims"
        Try
            tableTodaysClaims = objAccess.getAllClaimsForToday()
            If tableTodaysClaims.Rows.Count >= 1 Then
                lblHeader.Text = "All Claims For Today"
                gdupdate.DataSource = tableTodaysClaims
                gdupdate.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'get badges
    Protected Sub getlabelBadges()
        lblOpenClaims.Text = objAccess.getAllOpenClaimsQuantity().Rows(0).Item(0)
        lblClaimsReview.Text = objAccess.getReportsToReview().Rows(0).Item(0)
        lblUnassignedClaims.Text = objAccess.getUnassignedClaimQty().Rows(0).Item(0)
        lblOverdueClaims.Text = objAccess.getOverDueClaimQty().Rows(0).Item(0)
        lblClaimsThisMonth.Text = objAccess.getAllClaimsForMonthQty().Rows(0).Item(0)
        lblCriticalClaims.Text = objAccess.getCriticalClaimQty().Rows(0).Item(0)
        lblClaimsToday.Text = objAccess.getAllClaimsForTodayQty().Rows(0).Item(0)
        lbl10DaysOld.Text = objAccess.get10DayOldClaimqty().Rows(0).Item(0)
        lblOverdueInvoices.Text = objAccess.getOverdueInvoiceQuantity().Rows(0).Item(0)
    End Sub

    Protected Sub viewClaimsToReview()
        Response.Redirect("~/Admin/claimReview.aspx")

    End Sub
End Class