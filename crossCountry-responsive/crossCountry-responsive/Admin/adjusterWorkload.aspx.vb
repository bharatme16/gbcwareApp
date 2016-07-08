Public Class adjusterWorkload
    Inherits System.Web.UI.Page
    ' Dim objClass As New integrityAccess.IntegrityClass
    Dim objacess As New CrossCountryDataAccess.dataAccess
    Dim dt As New DataTable()
    Dim sort_direction As String = "Adjuster ASC"

    'Get Adjuster Work load list
    Sub bindAdjusterWorkLoad()
        dt.Columns.Add(New DataColumn("ID", GetType(String)))
        dt.Columns.Add(New DataColumn("Adjuster", GetType(String)))
        dt.Columns.Add(New DataColumn("assigned_claims", GetType(String)))
        dt.Columns.Add(New DataColumn("overdue_claims", GetType(String)))
        dt.Columns.Add(New DataColumn("average_days", GetType(String)))

        Dim AdjusterList As New DataTable

        AdjusterList = objacess.getAssignedAdjusterList()


        For i As Integer = 0 To AdjusterList.Rows.Count - 1
            Dim tableAssignedClaimQuantity As New DataTable
            Dim tableOverDueClaimQuantity As New DataTable
            Dim tableAverageDaysOpen As New DataTable
            Dim sumAverageDaysopen As Double = 0
            Dim claimCount As Double = 0
            Dim averageDays As Double = 0

            tableAssignedClaimQuantity = objacess.getAssignedClaimQuantityByAdjusterId(AdjusterList.Rows(i).Item("users_id"))
            tableOverDueClaimQuantity = objacess.getOverDueClaimQuantityByAdjusterId(AdjusterList.Rows(i).Item("users_id"))
            tableAverageDaysOpen = objacess.getClaimAverageDaysOpenByAdjusterId(AdjusterList.Rows(i).Item("users_id"))
            Dim assignedClaim As Integer = tableAssignedClaimQuantity.Rows(0).Item(0)
            Dim overdueClaim As Integer = tableOverDueClaimQuantity.Rows(0).Item(0)
            If tableAverageDaysOpen.Rows.Count >= 1 Then
                claimCount = tableAverageDaysOpen.Rows.Count
                For j As Integer = 0 To tableAverageDaysOpen.Rows.Count - 1
                    sumAverageDaysopen = sumAverageDaysopen + tableAverageDaysOpen.Rows(j).Item("Days Open")
                Next
                averageDays = FormatNumber((sumAverageDaysopen / claimCount), 2)
            End If
            Dim dr As DataRow = Nothing
            dr = dt.NewRow
            dr("ID") = AdjusterList.Rows(i).Item("users_id")
            dr("adjuster") = AdjusterList.Rows(i).Item("Adjuster")
            dr("assigned_claims") = assignedClaim
            dr("overdue_claims") = overdueClaim
            dr("average_days") = averageDays.ToString
            dt.Rows.Add(dr)
        Next
        dt.DefaultView.Sort = ViewState("SortExpr").ToString
        gridAdjusterWorkload.DataSource = dt
        gridAdjusterWorkload.DataBind()
    End Sub

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


        ViewState("SortExpr") = sortExpression & direction
        bindAdjusterWorkLoad()

    End Sub

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



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("userRole") <> "Admin" Then
        '    Response.Redirect("notAuthorized.aspx")
        'Else
        If Not IsPostBack Then
            Try
                ViewState("SortExpr") = sort_direction
                bindAdjusterWorkLoad()
            Catch ex As Exception
            End Try

            End If
        '  End If

    End Sub




    Protected Sub gridAdjusterWorkLoad_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAdjusterWorkload.RowDataBound
        'Dim sdoc As String
        'e.Row.Cells(0).Visible = False

        'sdoc = EncryptQueryString(e.Row.Cells(0).Text)
        'Dim adjusterName As String = EncryptQueryString(e.Row.Cells(1).Text)

        'Dim sclaimType1 As String = EncryptQueryString("assignClaims")
        'Dim sclaimType2 As String = EncryptQueryString("overdueClaims")


        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    e.Row.Cells(2).Attributes.Add("onmouseover", "this.style.backgroundColor='skyblue';this.style.cursor = 'pointer'")
        '    e.Row.Cells(3).Attributes.Add("onmouseover", "this.style.backgroundColor='skyblue';this.style.cursor = 'pointer'")
        '    e.Row.Cells(2).Attributes.Add("onmouseout", "this.style.backgroundColor='White'")
        '    e.Row.Cells(3).Attributes.Add("onmouseout", "this.style.backgroundColor='White'")
        '    e.Row.Cells(2).Attributes.Add("onClick", "goPage('adjusterClaims.aspx?adr=" + sdoc + "&con=" + sclaimType1 + "&nam=" + adjusterName + "');")
        '    e.Row.Cells(3).Attributes.Add("onClick", "goPage('adjusterClaims.aspx?adr=" + sdoc + "&con=" + sclaimType2 + "&nam=" + adjusterName + "');")
        'End If
    End Sub

    'Encrypt query string
    Public Function EncryptQueryString(ByVal strQueryString As String) As String
        'Call Encrypting class
        'Dim queryString As New integrityAccess.EncryptDecryptQueryString()
        Return ""
        '  Return queryString.Encrypt(strQueryString, "gbcwar12")
    End Function

End Class