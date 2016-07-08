Public Class claimDetail
    Inherits System.Web.UI.Page
    Dim objAccess As New CrossCountryDataAccess.dataAccess

#Region "Properties"

    Private Property claimID As Integer
        Get
            If IsNothing(ViewState("claimID")) Then

                ViewState("claimID") = Request.QueryString("claimID")

            End If
            Return CInt(ViewState("claimID"))
        End Get
        Set(value As Integer)
            ViewState("claimID") = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getClaimDetail(claimID)
            loadNotes(claimID)
            bindContactsforNotes(claimID)
        End If
    End Sub


    Protected Sub getClaimDetail(ByVal claimId As Integer)
        Dim tableClaimDetail As New DataTable
        Dim tableClaimAdjuster As New DataTable

        Try
            tableClaimAdjuster = objAccess.getAdjusterByClaimId(claimId)
            tableClaimDetail = objAccess.getClaimByClaimId(claimId)

            '************checks due dates**********************
            Dim daysOver As Integer = objAccess.getOverdueDates(1).Rows(0).Item("_date")
            Dim dueDate As Date = DateAdd(DateInterval.Day, daysOver, tableClaimDetail.Rows(0).Item(18))
            lblDueDate.Text = dueDate
            If Date.Now > dueDate Then
                lblDueDate.Text = dueDate
                lblDueDate.ForeColor = Drawing.Color.Red
            End If

            If tableClaimDetail.Rows.Count >= 1 Then
                lblClaimNumber.Text = tableClaimDetail.Rows(0).Item("claim_number")
                lblClaimStatus.Text = tableClaimDetail.Rows(0).Item("Status")
                '   txtMergeFileName.Text = tableClaimDetail.Rows(0).Item("claim_number") + "_merge"
                '   txtMergeFileDescription.Text = tableClaimDetail.Rows(0).Item("claim_number") + "_merge"
                lblInsured.Text = tableClaimDetail.Rows(0).Item("insured_firstName") + " " + tableClaimDetail.Rows(0).Item("insured_lastName")
                lblCarrier.Text = tableClaimDetail.Rows(0).Item("insur_carrier")
                lblCarrierRep.Text = tableClaimDetail.Rows(0).Item("rep_firstName") + " " + tableClaimDetail.Rows(0).Item("rep_lastName")
                lblRepEmail.Text = tableClaimDetail.Rows(0).Item("rep_email")
                lblAddress.Text = tableClaimDetail.Rows(0).Item("insured_street") + " " + tableClaimDetail.Rows(0).Item("insured_city") + ", " + tableClaimDetail.Rows(0).Item("insured_state") + " " + tableClaimDetail.Rows(0).Item("insured_zip")
                objAccess.checkClaimClosed(claimId)
                objAccess.checkClaimCanceled(claimId)
                If tableClaimAdjuster.Rows.Count >= 1 Then
                    ' btnUnassign.Visible = True
                    lblAssignedAdjuster.ForeColor = Drawing.Color.Black
                    lblAssignedAdjuster.Text = tableClaimAdjuster.Rows(0).Item("Name")
                    ' lblReassignClaim.Text = "Click on adjuster's name to reassign claim."
                Else
                    ' btnUnassign.Visible = False
                    lblAssignedAdjuster.ForeColor = Drawing.Color.Red
                    lblAssignedAdjuster.Text = "Unassigned"
                    ' lblReassignClaim.Text = "Click on 'Unassigned' to assign claim."
                    '  btnReassign.Text = "Assign"
                End If

                If (objAccess.isClaimClosed = True) Or (objAccess.isClaimCanceled = True) Then
                    '  pnlUploadFiles.Enabled = False
                    '  lblUploadMessage.Text = "-Reopen the claim to upload file(s)-"
                    '  btnReopen.Visible = True
                    ' lblAssignedAdjuster.Text = tableClaimAdjuster.Rows(0).Item("Name")
                    '  lblReassignClaim.Text = "Claim is Closed and/or Canceled."
                    lblAssignedAdjuster.Enabled = True
                    '  btnClose.Visible = False
                    ' btnCancelClaim.Visible = False
                    ' btnCloseNoSend.Visible = False
                Else
                    ' pnlUploadFiles.Enabled = True
                    ' lblUploadMessage.Text = ""
                    ' btnClose.Visible = True
                    ' btnCancelClaim.Visible = True
                    '  btnCloseNoSend.Visible = True
                    lblAssignedAdjuster.Enabled = True
                End If

                lblLossType.Text = tableClaimDetail.Rows(0).Item("type_of_loss")
                If tableClaimDetail.Rows(0).Item("insur_primaryPhone") = String.Empty Then
                    lblPrimaryPhone.Text = "N/A"
                Else
                    lblPrimaryPhone.Text = tableClaimDetail.Rows(0).Item("insur_primaryPhone")
                End If
                If tableClaimDetail.Rows(0).Item("insur_altPhone") = String.Empty Then
                    lblAltPhone.Text = "N/A"
                Else
                    lblAltPhone.Text = tableClaimDetail.Rows(0).Item("insur_altPhone")
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub




    'Load Notes
    Private Sub loadNotes(ByVal claimId As Integer)
        Dim tableNotes As New DataTable
        Dim noteQuantity As New Integer
        Try
            tableNotes = objAccess.getNotes(claimId)
            If tableNotes.Rows.Count >= 1 Then
                Dim objstring As New StringBuilder
                For Each rows As DataRow In tableNotes.Rows
                    objstring.Append("<h5 class=""text-primary""><strong>" + rows.Item("user_name").ToString + "</strong></h5>")
                    objstring.Append("<p class=""text-info"">" + rows.Item("time_stamp").ToString + "</p>")
                    objstring.Append("<blockquote>")
                    Dim notes As String = rows.Item("notes").Replace(vbLf, "<br>")
                    objstring.Append("<h5>" + notes + "</h5>")
                    objstring.Append("</blockquote>")
                    objstring.Append("<hr>")
                Next
                Notes.InnerHtml = objstring.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub


    'bind note contacts
    Sub bindContactsforNotes(ByVal claimId As Integer)
        Dim dtContactsforNotes As New DataTable

        Try
            dtContactsforNotes = objAccess.getContactsForNotes(claimId)
            If dtContactsforNotes.Rows.Count >= 1 Then
                GVNoteRecipient.DataSource = dtContactsforNotes
                GVNoteRecipient.DataBind()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim counter As Integer = 0
        Dim isValidator As Boolean = False
        Dim contacts As New ArrayList
        ' Dim contactEmails As String
        Dim contactEmails As New ArrayList
        Dim repChecked As New Boolean
        If txtNewNote.Text = String.Empty Then
            isValidator = True
            lblNewNoteMsg.Text = "Note is required."
        Else
            lblNewNoteMsg.Text = ""
        End If

        If isValidator = True Then
            'Do nothing
        Else

            lblNewNoteMsg.Text = ""
            Dim userdata As New DataTable
            userdata = objAccess.getUsersDetailByEmail(Session("EmailId"))
            'gets names for selected contacts
            For i As Integer = 0 To GVNoteRecipient.Rows.Count - 1
                Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
                If chkBoxCell.Checked = True Then
                    contacts.Add(GVNoteRecipient.Rows(i).Cells.Item(1).Text.ToString)
                Else
                End If
            Next
            If contacts.Count < 1 Then
                contacts.Add("None")
            End If

            objAccess.insertClaimNotes(lblClaimNumber.Text,
                                       txtNewNote.Text + Environment.NewLine + Environment.NewLine + "Note Sent To: " + [String].Join(", ", contacts.ToArray()),
                                       userdata.Rows(0).Item("f_name") + " " + userdata.Rows(0).Item("l_name"), chkVisibleToClaimRep.Checked)
            'get claim detail for insured name for email
            'Get claim id
            Dim claimDetail As New DataTable
            Dim blindCopy As String = ""
            Dim recipients As String = ""
            claimDetail = objAccess.getClaimByClaimId(claimID)

            '******Send Email********
            'Add contacts to email
            For i As Integer = 0 To GVNoteRecipient.Rows.Count - 2
                Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
                If chkBoxCell.Checked = True Then
                    contactEmails.Add(GVNoteRecipient.Rows(i).Cells.Item(2).Text.ToString)
                Else
                End If
            Next

            'checks if claim rep selected
            For i As Integer = 0 To GVNoteRecipient.Rows.Count - 1
                Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
                If i = GVNoteRecipient.Rows.Count - 1 And chkBoxCell.Checked = False Then
                    repChecked = False
                    recipients = String.Join(";", contactEmails.Cast(Of String)().ToArray())
                    blindCopy = ""
                ElseIf i = GVNoteRecipient.Rows.Count - 1 And chkBoxCell.Checked = True Then
                    repChecked = True
                    blindCopy = String.Join(";", contactEmails.Cast(Of String)().ToArray())
                    recipients = GVNoteRecipient.Rows(i).Cells.Item(2).Text.ToString
                    Exit For
                End If
            Next

            'sends new note email
            objAccess.emailNewNote(recipients, Session("EmailId"), lblInsured.Text, lblClaimNumber.Text, txtNewNote.Text, blindCopy, repChecked)

            'Reload Notes
            loadNotes(claimID)
            txtNewNote.Text = String.Empty

            'Unselect Claim Rep
            For i As Integer = 0 To GVNoteRecipient.Rows.Count - 1
                Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
                If chkBoxCell.Checked = True Then
                    chkBoxCell.Checked = False
                Else
                End If
            Next
            lnkRepButton.Text = "Enable Claim Contact"

        End If
        chkVisibleToClaimRep.Checked = False
    End Sub


    'enable claim rep button clicked
    Protected Sub lnkRepButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkRepButton.Click

        For i As Integer = 0 To GVNoteRecipient.Rows.Count - 1
            Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
            If i = GVNoteRecipient.Rows.Count - 1 And chkBoxCell.Checked = False Then
                chkBoxCell.Checked = True
                lnkRepButton.Text = "Remove Claim Contact"
            ElseIf i = GVNoteRecipient.Rows.Count - 1 And chkBoxCell.Checked = True Then
                chkBoxCell.Checked = False
                lnkRepButton.Text = "Enable Claim Contact"
            End If
        Next

    End Sub


    'note gridview data bound
    Protected Sub GVNoteRecipient_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GVNoteRecipient.RowDataBound
        e.Row.Cells(2).Visible = False
        e.Row.Cells(1).Width = 150
        For i As Integer = 0 To GVNoteRecipient.Rows.Count - 1
            Dim chkBoxCell As CheckBox = GVNoteRecipient.Rows(i).FindControl("CheckBox1")
            If i = GVNoteRecipient.Rows.Count - 1 Then
                chkBoxCell.Enabled = False
            Else
                chkBoxCell.Enabled = True
            End If
        Next

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='skyblue'; this.style.cursor='pointer'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'")
        End If

    End Sub
End Class