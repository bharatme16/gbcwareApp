Imports System.IO
Imports System.Xml
Imports businessLibrary

Public Class claimDetail
    Inherits System.Web.UI.Page
    Dim objAccess As New crossCountryDataAccess.dataAccess
    Dim objPdfMerge As New pdfManager
    Dim dt As New DataTable()

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

            If Page.ClientScript.IsStartupScriptRegistered(Me.GetType(), "initmap") = False Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "initmap", "MYMAP.init(30.709962, -88.044548, 12);", True)
            End If
            getClaimDetail(claimID)
            loadNotes(claimID)
            bindContactsforNotes(claimID)
            loadAssociatedFiles(claimID)
            loadFileTypes()

            SetInitialRow()
            'calling initmap javascript method
            Dim str As String = FilterMarker()
            runScript(str)

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


    'add file button clicked
    Protected Sub btnAddFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim isValidateError As Boolean

        If GVAssociatedFiles.Rows.Count >= 1 Then
            'Attach files
            For i As Integer = 0 To GVAssociatedFiles.Rows.Count - 1
                Dim chkBoxCell As CheckBox = GVAssociatedFiles.Rows(i).FindControl("CheckBox1")
                If chkBoxCell.Checked = True Then
                    If File.Exists(Server.MapPath(GVAssociatedFiles.Rows(i).Cells(3).Text.ToString)) Then
                        If checkFileExtension(Server.MapPath(GVAssociatedFiles.Rows(i).Cells(3).Text.ToString)) = False Then
                            isValidateError = True
                            Exit For
                        End If
                        ' Mail.Attachments.Add(New Net.Mail.Attachment(Server.MapPath(GVAssociatedFiles.Rows(i).Cells(5).Text.ToString)))
                    End If
                End If
            Next
        End If
        If isValidateError = True Then
            Dim s As String = "Invalid file type is selected. Select "".pdf"" files only."
            '  integrityAccess.Alert.Show(s)
        Else
            If GVAssociatedFiles.Rows.Count >= 1 Then

                'Attach files
                For i As Integer = 0 To GVAssociatedFiles.Rows.Count - 1
                    Dim chkBoxCell As CheckBox = GVAssociatedFiles.Rows(i).FindControl("CheckBox1")
                    If chkBoxCell.Checked = True Then

                        If File.Exists(Server.MapPath(GVAssociatedFiles.Rows(i).Cells(3).Text.ToString)) Then
                            AddNewRowToGrid(GVAssociatedFiles.Rows(i).Cells(5).Text.ToString,
                                            GVAssociatedFiles.Rows(i).Cells(6).Text.ToString,
                                            GVAssociatedFiles.Rows(i).Cells(3).Text.ToString)
                            ' Mail.Attachments.Add(New Net.Mail.Attachment(Server.MapPath(GVAssociatedFiles.Rows(i).Cells(5).Text.ToString)))
                        End If
                      
                    End If
                Next

                For i As Integer = 0 To GVAssociatedFiles.Rows.Count - 1
                    Dim chkBoxCell As CheckBox = GVAssociatedFiles.Rows(i).FindControl("CheckBox1")
                    chkBoxCell.Checked = False
                Next
            End If
        End If

    End Sub




    'load associated files
    Sub loadAssociatedFiles(ByVal claimId As Integer)
        Dim dtAssociatedFiles As New DataTable

        Try
            dtAssociatedFiles = objAccess.getFilepathByClaimId(claimId, Session("UserRole"))
            If dtAssociatedFiles.Rows.Count >= 1 Then
                GVAssociatedFiles.DataSource = dtAssociatedFiles
                GVAssociatedFiles.DataBind()
                For Each rows As GridViewRow In GVAssociatedFiles.Rows
                    Dim btn As Button = rows.FindControl("btnStatus")
                    If rows.Cells.Item(11).Text = "Read" Then
                        btn.Text = "Unread"
                    Else
                        btn.Text = "Read"
                    End If
                Next
            Else
                GVAssociatedFiles.DataSource = Nothing
                GVAssociatedFiles.DataBind()
            End If
        Catch ex As Exception
        End Try

    End Sub



    'Merge Pdf File
    Protected Sub btnMergeFile_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim isValidator As Boolean = False 'Boolean Value to check for any message.
        Dim messageList As New ArrayList    'List to generate error alert.
        Dim fileNotSelected As Boolean = False 'Boolean to check if at least one file is selected
        lblMergeError.Text = ""

        'Check if atleast one file is selected
        If gvMergeFile.Rows.Count >= 2 Then

        Else
            isValidator = True
            messageList.Add("Select at least two files.")
        End If


        ''File is not selected
        'If fileNotSelected = True Then
        '    isValidator = True
        '    messageList.Add("Select at least one File.")
        'End If

        'File name is not provided
        If txtMergeFileName.Text = String.Empty Then
            isValidator = True
            messageList.Add("File Name is required.")
        End If

        'File Description is not provided
        If txtMergeFileDescription.Text = String.Empty Then
            isValidator = True
            messageList.Add("File Description is not provided.")
        End If

        If isValidator = True Then
            'ScriptManager.RegisterStartupScript(Me.pnlUploadFiles, Me.[GetType](), "showalert", "Error", True)
            'join all the alert message seperated by ";"
            Dim s = "Check these Error(s): " + String.Join(";  ", messageList.Cast(Of String)().ToArray())

            'Show Alert
            '  integrityAccess.Alert.Show(s)
            'Do nothing
        Else
            'Collection of path of the files to be merged.
            Dim arrayFiles As New ArrayList

            If gvMergeFile.Rows.Count >= 1 Then
                'Add files path to the list
                For i As Integer = 0 To gvMergeFile.Rows.Count - 1
                    'Dim chkBoxCell As CheckBox = GVAssociatedFiles.Rows(i).FindControl("CheckBox1")
                    ' If chkBoxCell.Checked = True Then
                    MsgBox(gvMergeFile.Rows(i).Cells(2).Text.ToString)
                    If File.Exists(Server.MapPath(gvMergeFile.Rows(i).Cells(2).Text.ToString)) Then
                        arrayFiles.Add(Server.MapPath(gvMergeFile.Rows(i).Cells(2).Text.ToString))
                    End If
                    'End If
                Next
            End If

            'Folder where merged files will be saved
            Dim pathToFolder As String = "~/Files/" + lblClaimNumber.Text + "/"

            'Actual path of the folder
            Dim folderPath As String = Server.MapPath(pathToFolder) 'Actual Mapping to Folder

            'Check if the directory exists
            If Not Directory.Exists(folderPath) = True Then
                ' Ensure the folder exists 
                Directory.CreateDirectory(folderPath)
            Else
                'Do nothing.
            End If

            'Get the file name for the merge file
            Dim filename As String = txtMergeFileName.Text
            ' filename = Replace(filename, "'", "").Replace("#", "").Replace("&", "")

            'This is path for the final output
            Dim filePath As String = folderPath + filename + ".pdf" 'Generate Pdf 

            'If same name is chosen for the file
            If File.Exists(filePath) = True Then
                lblMergeError.Text = "-File already exists. Rename the file and continue.-"
            Else
                'Call merge function 
                objPdfMerge.MergeFiles(filePath, arrayFiles)
                '   MsgBox(filesize)
                Try
                    'Add path of the final output to the database
                    'Note: the full path is not saved to the database
                    objAccess.insertFilepath(lblClaimNumber.Text, lblClaimNumber.Text + "_MergedFile", Path.Combine(pathToFolder, filename + ".pdf".ToString),
                                                              txtMergeFileDescription.Text, filename + ".pdf".ToString, "application/pdf")


                    'get the claim Id from the Query String
                    '  Dim id As String = DecryptQueryString(Request.QueryString("phyid"))

                    'Reload the files
                    loadAssociatedFiles(claimID)
                    '    lblFileUpload.Text = "File is sucessfully uploaded."

                    'Empty any text 
                    txtMergeFileName.Text = String.Empty
                    txtMergeFileDescription.Text = String.Empty
                    gvMergeFile.DataSource = Nothing
                    gvMergeFile.DataBind()
                    '     SetInitialRow()

                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    'Set the initial Row
    Private Sub SetInitialRow()
        '' Split string based on spaces
        'Dim words As String() = value.Split("-"c)
        'Dim carrierName As String = words(0)
        'Dim invoiceType As String = words(1)
        'carrierName = carrierName.Trim()
        'invoiceType = invoiceType.Trim()
        'Dim invoiceTypeTable As New DataTable

        'Get Carrier Name
        'lblCarrierName.Text = carrierName

        'Assign Expenses
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("fileDescription", GetType(String)))
        dt.Columns.Add(New DataColumn("fileName", GetType(String)))
        dt.Columns.Add(New DataColumn("filePath", GetType(String)))

        dr = dt.NewRow
        'invoiceTypeTable = objacess.getInvoiceTypeForClaim(carrierName, invoiceType)
        'If invoiceTypeTable.Rows.Count >= 1 Then
        '    dr("item") = invoiceTypeTable.Rows(0).Item("Company").ToString
        '    dr("Description") = invoiceTypeTable.Rows(0).Item("Description").ToString
        '    dr("Price") = invoiceTypeTable.Rows(0).Item("Fee").ToString
        '    dt.Rows.Add(dr)

        'Store the DataTable in ViewState
        ViewState("CurrentTable") = dt

        gvMergeFile.DataSource = dt
        gvMergeFile.DataBind()
        'End If
        'getCarrierDetail(carrierName)
        'showCarrier(carrierName)

    End Sub

    'Adding new row 
    Private Sub AddNewRowToGrid(ByVal FileDescription As String, ByVal fileName As String, ByVal filepath As String)
        Dim rowIndex As Integer = 0
        Dim duplicateFound As Boolean = False

        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing

            'If row exist count the row
            If dtCurrentTable.Rows.Count > 0 Then
                rowIndex = dtCurrentTable.Rows.Count
            Else
                rowIndex = 0
            End If
            If gvMergeFile.Rows.Count >= 1 Then
                For Each rows As GridViewRow In gvMergeFile.Rows
                    If fileName = rows.Cells.Item(1).Text Or filepath = rows.Cells.Item(2).Text Then
                        duplicateFound = True
                        Exit For
                    Else
                        duplicateFound = False
                    End If
                Next
            End If
            If duplicateFound = True Then
            Else
                drCurrentRow = dtCurrentTable.NewRow()
                drCurrentRow("fileDescription") = FileDescription
                drCurrentRow("fileName") = fileName
                drCurrentRow("filePath") = filepath

                dtCurrentTable.Rows.Add(drCurrentRow)
                ViewState("CurrentTable") = dtCurrentTable

                gvMergeFile.DataSource = dtCurrentTable
                gvMergeFile.DataBind()
            End If

        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        '  SetPreviousData()
    End Sub





    Protected Sub runScript(ByVal stringMap As String)
        Dim result = stringMap
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearOverlays",
                                                "MYMAP.clearOverlays();", True)
        If result = "" Then
            '  lblMapInfo.Text = "-No Claims Found-"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "initmap", "MYMAP.init(30.709962, -88.044548, 12);", True)
        Else
            '  lblMapInfo.Text = ""
            'calling javascript function on partial postback to filter markers from the result
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "filterplacemark",
                                                "var filterresult='" + Server.HtmlDecode(result) + "';MYMAP.placemarkAjax(filterresult);", True)
        End If
    End Sub


    'Get list of file types
    Protected Sub loadFileTypes()
        Dim tableFileTypes As New DataTable
        tableFileTypes = objAccess.getFileType()
        If tableFileTypes.Rows.Count >= 1 Then
            With cmbFileType
                .DataSource = tableFileTypes
                .DataTextField = "File Type"
                .DataValueField = "File Type"
                .DataBind()
            End With
        End If
    End Sub


    Protected Sub upload_Click(sender As Object, e As System.EventArgs)

        Dim isValidator As Boolean = False
        hidTAB.Value = "#Files"

        For Each xfiles As HttpPostedFile In ascFileUpload.PostedFiles

            Dim messageList As New ArrayList
            Dim fileName1 As String = Path.GetFileName(xfiles.FileName)
            Dim folderPath1 As String = "~/Files/" + lblClaimNumber.Text + "/"

            Dim folder1 As String = Server.MapPath(folderPath1)

            If ascFileUpload.HasFile = False Then
                isValidator = True
                messageList.Add("File is not Selected.")
            End If

            If txtDescription.Text = String.Empty Then
                isValidator = True
                messageList.Add("File description is not provided.")
            End If

            If CheckFileExists(Path.Combine(folder1, fileName1)) = True Then
                isValidator = True
                messageList.Add("The file with the name """ + fileName1 + """ already exists. Rename the file and try again.")
            End If


            If isValidator = True Then
                'ScriptManager.RegisterStartupScript(Me.pnlUploadFiles, Me.[GetType](), "showalert", "Error", True)
                Dim s = "Check these Error(s): " + String.Join("; ", messageList.Cast(Of String)().ToArray())
                '  integrityAccess.Alert.Show(s)
                'Do nothing
            Else
                'Dim fileSize As Integer
                'fileSize = ascFileUpload.PostedFile.ContentLength

                '  lblFileContentSize.Text = fileSize.ToString
                Dim fileName As String = Path.GetFileName(xfiles.FileName)
                fileName = Replace(fileName, "'", "").Replace("#", "").Replace("&", "")


                Dim folderPath As String = "~/Files/" + lblClaimNumber.Text + "/"

                Dim folder As String = Server.MapPath(folderPath)

                If Not Directory.Exists(folder) = True Then
                    ' Ensure the folder exists 
                    Directory.CreateDirectory(folder)
                Else
                    'Do nothing.
                End If

                Try
                    Try
                        objAccess.insertFilepath(lblClaimNumber.Text, cmbFileType.Text, Path.Combine(folderPath, fileName),
                                                                txtDescription.Text, fileName, xfiles.ContentType)
                    Catch ex As Exception
                        '   MsgBox(ex.ToString)
                    End Try


                    ' Save the file to the folder 
                    xfiles.SaveAs(Path.Combine(folder, fileName))


                    txtDescription.Text = String.Empty

                    '  Dim id As String = DecryptQueryString(Request.QueryString("phyid"))

                    'lblFilesize.Text = "File Size: " + ascFileUpload.PostedFile.ContentLength.ToString + " Byte"
                    'lblFileType.Text = "File Type: " + ascFileUpload.PostedFile.ContentType.ToString
                    'lblFileUpload.Text = "File is sucessfully uploaded."

                    ' Dim claimId As String = DecryptQueryString(Request.QueryString("phyid"))
                    ' Dim sClaimId As String = EncryptQueryString(claimId)
                    '   Response.Redirect("claimDetail.aspx?phyid=" + sClaimId + "")

                Catch ex As Exception

                End Try
                ' End If
            End If

        Next
        loadAssociatedFiles(claimID)


    End Sub

    'check files exist
    Public Function CheckFileExists(ByVal FilePath As String) As Boolean
        Dim fileObj As New IO.FileInfo(FilePath)
        Return fileObj.Exists
    End Function


    'check file extension
    Public Function checkFileExtension(ByVal filepath As String) As Boolean
        Dim fileExtension As String = System.IO.Path.GetExtension(filepath)
        If fileExtension = ".pdf" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function FilterMarker() As String
        Dim dt As New DataTable

        dt = objAccess.getClaimByClaimId(claimID)

        Dim result As String = ""
        If dt.Rows.Count >= 1 Then
            Using str As New StringWriter()
                Using w As New XmlTextWriter(str)
                    w.WriteStartDocument()
                    w.WriteComment("xml for marker")
                    w.WriteStartElement("Markers")

                    'looping over each rows in the datatable.
                    For Each itemRow In dt.Rows
                        Dim claimNo = itemRow("Claim_number").ToString
                        Dim insuredName = itemRow("insured_firstname").ToString + itemRow("insured_lastname").ToString
                        Dim Address = "NA"
                        Dim adjuster = "NA"
                        Dim Title = itemRow("Claim_number").ToString
                        Dim Lat_ = itemRow("latitude")
                        Dim Long_ = itemRow("longitude")
                        w.WriteStartElement("marker")
                        If True Then

                            w.WriteElementString("claimNo", claimNo)
                            w.WriteElementString("insuredName", insuredName)
                            w.WriteElementString("adjuster", adjuster)
                            w.WriteElementString("title", Title)
                            w.WriteElementString("address", Address)
                            w.WriteElementString("lat", Lat_)
                            w.WriteElementString("lng", Long_)

                        End If
                        w.WriteEndElement() 'End of marker element


                    Next

                    'End of xml
                    w.WriteEndElement() 'End of Markers element
                    w.WriteEndDocument()

                    'Results as String
                    result = str.ToString()


                End Using
            End Using


        Else
            'do Nothing
        End If


        Return result


    End Function

    Private Sub gvMergeFile_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvMergeFile.RowDeleting
        If e.RowIndex >= 0 Then
            Try
                dt = ViewState("CurrentTable")
                dt.Rows.RemoveAt(e.RowIndex)
                gvMergeFile.DataSource = dt
                gvMergeFile.DataBind()
            Catch ex As Exception

            End Try
        Else
            'Do nothing
        End If
    End Sub


    'generate invoice
    Protected Sub btnGenerateInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        Response.Redirect("invoice.aspx?inV=" + claimID.ToString + "")
    End Sub
End Class