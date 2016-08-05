Public Class search
    Inherits System.Web.UI.Page
    Dim objacess As New CrossCountryDataAccess.dataAccess
    Dim searchString As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    'select button pressed
    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Dim claimNumber As String
        Dim policyNumber As String
        Dim insuredName As String

        If txtClaimNumber.Text = String.Empty Then
            claimNumber = "NA"
        Else
            claimNumber = txtClaimNumber.Text
        End If
        If txtInsuredName.Text = String.Empty Then
            insuredName = "NA"
        Else
            insuredName = txtInsuredName.Text
        End If
        If txtPolicyNumber.Text = String.Empty Then
            policyNumber = "NA"
        Else
            policyNumber = txtPolicyNumber.Text
        End If

        bindGridView(insuredName, claimNumber, policyNumber)

    End Sub

    'bind gridview
    Protected Sub bindGridView(ByVal insuredName As String, ByVal claimNumber As String, ByVal policyNumber As String)
        Dim dtReports As New DataTable
        ViewState("claimNumber") = claimNumber
        ViewState("policyNumber") = policyNumber
        ViewState("insuredName") = insuredName

        Try
            dtReports = objacess.searchAllClaimsByCriteria(policyNumber, claimNumber, insuredName)
            If dtReports.Rows.Count >= 1 Then
                gdClaims.DataSource = dtReports
                gdClaims.DataBind()
            Else
                gdClaims.DataSource = dtReports
                gdClaims.DataBind()
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

        dt = objacess.searchAllClaimsByCriteria(ViewState("policyNumber").ToString, ViewState("claimNumber").ToString, ViewState("insuredName").ToString)
        If dt.Rows.Count >= 1 Then
            ViewState("SortExpr") = sortExpression & direction
            dt.DefaultView.Sort = sortExpression & direction
            gdClaims.DataSource = dt
            gdClaims.DataBind()
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
    Private Sub gdFiles_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdClaims.PageIndexChanging
        Dim dt As New DataTable
        dt = objacess.searchAllClaimsByCriteria(ViewState("policyNumber").ToString, ViewState("claimNumber").ToString, ViewState("insuredName").ToString)
        gdClaims.PageIndex = e.NewPageIndex
        dt.DefaultView.Sort = ViewState("SortExpr").ToString
        gdClaims.DataSource = dt
        gdClaims.DataBind()
    End Sub
End Class