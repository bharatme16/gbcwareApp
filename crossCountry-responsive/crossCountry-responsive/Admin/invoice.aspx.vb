Imports System.IO
Imports businessLibrary
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class invoice
    Inherits System.Web.UI.Page
    Dim objacess As New crossCountryDataAccess.dataAccess
    Dim objparameter As New paramaterManager
    Dim dt As New DataTable()


#Region "Properties"

    Private Property claimID As Integer
        Get
            If IsNothing(ViewState("claimID")) Then

                ViewState("claimID") = Request.QueryString("inV")

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
            loadClaimDetail(claimID)
            SetInitialRow(lblInvoiceType.Text)
            calculate_SubtotalTotal()
            NewInvoiceNumber(lblClaimNumber.Text)
            lblInvoiceDate.Text = DateTime.Now.ToString("MM\-dd\-yyyy")



        End If

    End Sub

    'Generate Invoice Number
    Protected Sub NewInvoiceNumber(ByVal claimNumber As String)
        Dim invoiceNumberTable As New DataTable
        Dim RevLetter As String

        Try
            invoiceNumberTable = objacess.getNextInvoiceNumber(claimNumber)
            If invoiceNumberTable.Rows.Count >= 1 Then
                RevLetter = invoiceNumberTable.Rows(0).Item("Rev Letter")
                lblInvoiceNumber.Text = objparameter.GenerateInvoiceNumber(lblClaimNumber.Text, RevLetter)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getCarrierDetail(ByVal carrierName As String)
        Dim carriertable As New DataTable

        Try
            carriertable = objacess.getCompanyDetailByCompanyName(carrierName)
            If carriertable.Rows.Count >= 1 Then
                lblCarrierStreetAddress.Text = carriertable.Rows(0).Item("company_address")
                lblCarrierCityStateZip.Text = carriertable.Rows(0).Item("company_city") + ", " + " " +
                carriertable.Rows(0).Item("company_state") + " " + carriertable.Rows(0).Item("company_zip")
                lblCarrierPhone.Text = carriertable.Rows(0).Item("company_phone")
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Load Claim Detail and Adjuster Name
    Private Sub loadClaimDetail(ByVal claimId As Integer)
        Dim tableClaimDetail As New DataTable
        Dim tableClaimAdjuster As New DataTable
        Dim tableCompanyDetail As New DataTable

        Try
            tableClaimAdjuster = objacess.getAdjusterByClaimId(claimId)
            tableClaimDetail = objacess.getClaimByClaimId(claimId)
            If tableClaimDetail.Rows.Count >= 1 Then
                lblClaimNumber.Text = tableClaimDetail.Rows(0).Item("claim_number")
                lblInsuredName.Text = tableClaimDetail.Rows(0).Item("insured_firstName") + " " + tableClaimDetail.Rows(0).Item("insured_lastName")
                lblInvoiceType.Text = tableClaimDetail.Rows(0).Item("insur_carrier")

                lblAttention.Text = tableClaimDetail.Rows(0).Item("rep_firstName") + " " + tableClaimDetail.Rows(0).Item("rep_lastName")
                lblLossDate.Text = tableClaimDetail.Rows(0).Item("date_loss")
                lblLossUnit.Text = tableClaimDetail.Rows(0).Item("Policy_type")
                lblLossType.Text = tableClaimDetail.Rows(0).Item("type_of_loss")
                lblPolicyNumber.Text = tableClaimDetail.Rows(0).Item("policy_number")
                If tableClaimAdjuster.Rows.Count >= 1 Then
                    lblAdjuster.Text = tableClaimAdjuster.Rows(0).Item("Name")
                Else
                    lblAdjuster.Text = "Unassigned"
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub





    'Set the initial Row
    Private Sub SetInitialRow(ByVal value As String)
        ' Split string based on spaces
        Dim words As String() = value.Split("-"c)
        Dim carrierName As String = words(0)
        Dim invoiceType As String = words(1)
        carrierName = carrierName.Trim()
        invoiceType = invoiceType.Trim()
        Dim invoiceTypeTable As New DataTable

        'Get Carrier Name
        lblCarrierName.Text = carrierName

        'Assign Expenses
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("item", GetType(String)))
        dt.Columns.Add(New DataColumn("description", GetType(String)))
        dt.Columns.Add(New DataColumn("price", GetType(String)))

        dr = dt.NewRow
        invoiceTypeTable = objacess.getInvoiceTypeForClaim(carrierName, invoiceType)
        If invoiceTypeTable.Rows.Count >= 1 Then
            dr("item") = invoiceTypeTable.Rows(0).Item("Company").ToString
            dr("Description") = invoiceTypeTable.Rows(0).Item("Description").ToString
            dr("Price") = invoiceTypeTable.Rows(0).Item("Fee").ToString
            dt.Rows.Add(dr)

            'Store the DataTable in ViewState
            ViewState("CurrentTable") = dt

            gridViewInvoice.DataSource = dt
            gridViewInvoice.DataBind()
        End If
        getCarrierDetail(carrierName)
        showCarrier(carrierName)

    End Sub

    'Carrier invoice list
    Protected Sub showCarrier(ByVal carrierName As String)
        Dim tableCarrierList As New DataTable
        tableCarrierList = objacess.getInvoiceTypeListByCarrier(carrierName)
        If tableCarrierList.Rows.Count >= 1 Then
            'With cmbInvoiceType
            '    .DataSource = tableCarrierList
            '    .DataTextField = "Invoice type"
            '    .DataValueField = "Invoice type"
            '    .DataBind()
            'End With

        End If
    End Sub

    'Adding new row 
    Private Sub AddNewRowToGrid(ByVal item As String, ByVal description As String, ByVal price As Double)
        Dim rowIndex As Integer = 0

        If ViewState("CurrentTable") IsNot Nothing Then
            Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
            Dim drCurrentRow As DataRow = Nothing

            'If row exist count the row
            If dtCurrentTable.Rows.Count > 0 Then
                rowIndex = dtCurrentTable.Rows.Count
            Else
                rowIndex = 0
            End If
            drCurrentRow = dtCurrentTable.NewRow()
            drCurrentRow("item") = item
            drCurrentRow("Description") = description
            drCurrentRow("Price") = price

            dtCurrentTable.Rows.Add(drCurrentRow)
            ViewState("CurrentTable") = dtCurrentTable

            gridViewInvoice.DataSource = dtCurrentTable
            gridViewInvoice.DataBind()
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        '  SetPreviousData()
    End Sub


    'Add New Expense to the List
    Protected Sub btnAddExpense_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim isvalidateError As Boolean = False

        If txtExpenseType.Text = String.Empty Then
            isvalidateError = True
        Else

        End If

        If txtDescription.Text = String.Empty Then
            isvalidateError = True

        Else

        End If
        If IsNumeric(txtPrice.Text) = False Then
            isvalidateError = True
        Else
        End If

        If isvalidateError = True Then

        Else
            Try
                AddNewRowToGrid(txtExpenseType.Text, txtDescription.Text, Math.Round(CDbl(txtPrice.Text), 2))
                calculate_SubtotalTotal()
                txtExpenseType.Text = String.Empty
                txtDescription.Text = String.Empty
                txtPrice.Text = String.Empty
            Catch ex As Exception

            End Try
        End If


    End Sub


    'calculate subtotal and total for the invoice
    Protected Sub calculate_SubtotalTotal()
        Dim subtotal As Double 'Subtotal
        Dim tax As Double ' Tax
        Dim total As Double 'Total


        If gridViewInvoice.Rows.Count >= 1 Then
            For Each rows As GridViewRow In gridViewInvoice.Rows
                subtotal = subtotal + rows.Cells.Item("2").Text
            Next
            tax = 0
            total = subtotal

            lblSubTotal.Text = subtotal
            lblTaxFees.Text = tax
            lblTotalAmount.Text = total
        Else
            tax = 0
            lblSubTotal.Text = 0
            lblTaxFees.Text = 0
            lblTotalAmount.Text = 0
        End If
    End Sub



    Protected Sub btnCreatePDF_Click(sender As Object, e As System.EventArgs) Handles btnCreatePDF.Click
        Try

            ' Create a Document object
            Dim document = New Document(PageSize.LETTER, 50, 50, 25, 25)

            ' Create a new PdfWrite object, writing the output to a MemoryStream
            Dim output = New MemoryStream()
            Dim pathToFolder As String = "~/Files/" + lblClaimNumber.Text + "/"

            Dim folderPath As String = Server.MapPath(pathToFolder) 'Actual Mapping to Folder

            If Not Directory.Exists(folderPath) = True Then
                ' Ensure the folder exists 
                Directory.CreateDirectory(folderPath)
            Else
                'Do nothing.
            End If

            'This is path for the file 
            Dim filePath = folderPath + lblInvoiceNumber.Text + ".pdf" 'Generate Pdf 

            Dim writer = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))
            document.Open()


            Dim titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD)
            Dim subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD)
            Dim boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD)
            Dim endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC)
            Dim bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL)


            ' add Company Logo in the upper left corner
            Dim logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/resources/crossCountry.png"))
            logo.SetAbsolutePosition(36, 700)
            logo.ScalePercent(10)
            document.Add(logo)

            Dim IntegrityInfo As New PdfPTable(1)
            IntegrityInfo.WidthPercentage = 30.0F
            IntegrityInfo.HorizontalAlignment = 2 'Right alignment

            ' Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
            ' IntegrityInfo.HorizontalAlignment = Element.ALIGN_RIGHT


            'Integrity Company Information
            Dim integrityName As New PdfPCell(New Phrase("Cross Country Adjusting", New Font(Font.TIMES_ROMAN, 8.0F, Font.BOLD)))
            Dim poBox As New PdfPCell(New Phrase("PO BOX 519", New Font(Font.TIMES_ROMAN, 8.0F, Font.NORMAL)))
            Dim Address As New PdfPCell(New Phrase("Pageland, SC 29728", New Font(Font.TIMES_ROMAN, 8.0F, Font.NORMAL)))
            Dim phone As New PdfPCell(New Phrase("Phone: 888-658-1828", New Font(Font.TIMES_ROMAN, 8.0F, Font.NORMAL)))
            Dim fax As New PdfPCell(New Phrase("Fax: 775-415-0184", New Font(Font.TIMES_ROMAN, 8.0F, Font.NORMAL)))

            integrityName.HorizontalAlignment = 2
            integrityName.Border = 0

            poBox.Border = 0
            poBox.HorizontalAlignment = 2

            Address.Border = 0
            Address.HorizontalAlignment = 2

            phone.Border = 0
            phone.HorizontalAlignment = 2

            fax.Border = 0
            fax.HorizontalAlignment = 2

            IntegrityInfo.AddCell(integrityName)
            IntegrityInfo.AddCell(poBox)
            IntegrityInfo.AddCell(Address)
            IntegrityInfo.AddCell(phone)
            IntegrityInfo.AddCell(fax)
            document.Add(IntegrityInfo)

            '

            'Add line break
            document.Add(New Phrase(Environment.NewLine))
            document.Add(New Phrase(Environment.NewLine))

            'Carrier Information
            Dim carrierInfo As New PdfPTable(1)
            carrierInfo.HorizontalAlignment = 0 'Right Alignment
            carrierInfo.WidthPercentage = 30.0F

            ' Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
            ' IntegrityInfo.HorizontalAlignment = Element.ALIGN_RIGHT

            'Get carriers Name
            Dim carrierName As New PdfPCell(New Phrase(lblCarrierName.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))

            'Get carriers street Address
            Dim CarrierStreetAddress As New PdfPCell(New Phrase(lblCarrierStreetAddress.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            'Carrier city State Zip
            Dim carrierCityStateZip As New PdfPCell(New Phrase(lblCarrierCityStateZip.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            'carrier Telephone
            Dim carrierPhone As New PdfPCell(New Phrase(lblCarrierPhone.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            'Get Claim Rep
            Dim attention As New PdfPCell(New Phrase("Attention: " + lblAttention.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            'Carrier Name
            carrierName.HorizontalAlignment = 0
            carrierName.Border = 0

            CarrierStreetAddress.HorizontalAlignment = 0
            CarrierStreetAddress.Border = 0

            carrierCityStateZip.Border = 0
            carrierCityStateZip.HorizontalAlignment = 0

            carrierPhone.Border = 0
            carrierPhone.HorizontalAlignment = 0

            attention.Border = 0
            attention.HorizontalAlignment = 0


            carrierInfo.AddCell(carrierName)
            carrierInfo.AddCell(CarrierStreetAddress)
            carrierInfo.AddCell(carrierCityStateZip)
            carrierInfo.AddCell(carrierPhone)
            carrierInfo.AddCell(attention)


            Dim invoiceInfo As New PdfPTable(1)
            invoiceInfo.WidthPercentage = 30.0F
            invoiceInfo.HorizontalAlignment = 2

            'Need to be changed
            Dim invoiceNumber As New PdfPCell(New Phrase("Invoice #: " + lblInvoiceNumber.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            Dim invoicedate As New PdfPCell(New Phrase("Invoice Date: " + DateTime.Now.ToString("MM\-dd\-yyyy"), New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            invoiceNumber.Border = 0
            invoiceNumber.HorizontalAlignment = 2

            invoicedate.Border = 0
            invoicedate.HorizontalAlignment = 2

            invoiceInfo.AddCell(invoiceNumber)
            invoiceInfo.AddCell(invoicedate)

            document.Add(invoiceInfo)
            document.Add(carrierInfo)
            document.Add(New Phrase(Environment.NewLine))

            Dim tableClaimHeader = New PdfPTable(1)
            tableClaimHeader.WidthPercentage = 100.0F
            tableClaimHeader.HorizontalAlignment = 1


            Dim claimHeader As New PdfPCell(New Phrase("CLAIM INFORMATION:", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            'claimHeader.BackgroundColor = Color.LIGHT_GRAY
            claimHeader.Border = 0
            claimHeader.BorderWidthBottom = 1.0F
            claimHeader.PaddingBottom = 5.0F
            tableClaimHeader.AddCell(claimHeader)
            document.Add(tableClaimHeader)

            '  document.Add(New Phrase(Environment.NewLine))


            Dim claimInformationTable = New PdfPTable(2)
            claimInformationTable.WidthPercentage = 50.0F
            claimInformationTable.HorizontalAlignment = 1

            'Insured Name
            Dim cellInsuredHeader As New PdfPCell(New Phrase("INSURED: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellInsured As New PdfPCell(New Phrase(lblInsuredName.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            cellInsured.Border = 0
            cellInsuredHeader.Border = 0

            cellInsured.PaddingBottom = 2.0F
            cellInsuredHeader.PaddingBottom = 2.0F

            cellInsuredHeader.HorizontalAlignment = 0
            cellInsured.HorizontalAlignment = 0

            '0=Left, 1=Centre, 2=Right

            claimInformationTable.AddCell(cellInsuredHeader)
            claimInformationTable.AddCell(cellInsured)


            'Insured Policy Number
            Dim cellInsurancePolicyHeader As New PdfPCell(New Phrase("INSURED POLICY #: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellInsurancePolicy As New PdfPCell(New Phrase(lblPolicyNumber.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellInsurancePolicy.Border = 0
            cellInsurancePolicyHeader.Border = 0

            cellInsurancePolicy.PaddingBottom = 2.0F
            cellInsurancePolicyHeader.PaddingBottom = 2.0F

            cellInsurancePolicy.HorizontalAlignment = 0
            cellInsurancePolicyHeader.HorizontalAlignment = 0

            '0=Left, 1=Centre, 2=Right
            claimInformationTable.AddCell(cellInsurancePolicyHeader)
            claimInformationTable.AddCell(cellInsurancePolicy)

            'OUR FILE #
            Dim cellOurFileHeader As New PdfPCell(New Phrase("OUR FILE #: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellOurFile As New PdfPCell(New Phrase(lblClaimNumber.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellOurFileHeader.Border = 0
            cellOurFile.Border = 0

            cellOurFileHeader.HorizontalAlignment = 0
            cellOurFile.HorizontalAlignment = 0
            cellOurFile.PaddingBottom = 2.0F
            cellOurFileHeader.PaddingBottom = 2.0F

            '0=Left, 1=Centre, 2=Right
            claimInformationTable.AddCell(cellOurFileHeader)
            claimInformationTable.AddCell(cellOurFile)

            'YOUR FILE #
            Dim cellYourFileHeader As New PdfPCell(New Phrase("YOUR FILE #: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellYourFile As New PdfPCell(New Phrase(lblClaimNumber.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellYourFileHeader.Border = 0
            cellYourFile.Border = 0

            cellYourFileHeader.HorizontalAlignment = 0
            cellYourFile.HorizontalAlignment = 0

            cellYourFile.PaddingBottom = 2.0F
            cellYourFileHeader.PaddingBottom = 2.0F
            '0=Left, 1=Centre, 2=Right

            claimInformationTable.AddCell(cellYourFileHeader)
            claimInformationTable.AddCell(cellYourFile)


            'ADJUSTER
            Dim cellAdjusterHeader As New PdfPCell(New Phrase("ADJUSTER: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellAdjuster As New PdfPCell(New Phrase(lblAdjuster.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellAdjusterHeader.Border = 0
            cellAdjuster.Border = 0

            cellAdjusterHeader.HorizontalAlignment = 0
            cellAdjuster.HorizontalAlignment = 0

            cellAdjuster.PaddingBottom = 2.0F
            cellAdjusterHeader.PaddingBottom = 2.0F
            '0=Left, 1=Centre, 2=Right

            claimInformationTable.AddCell(cellAdjusterHeader)
            claimInformationTable.AddCell(cellAdjuster)

            'LOSS DATE
            Dim cellLossDateHeader As New PdfPCell(New Phrase("LOSS DATE: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellLossDate As New PdfPCell(New Phrase(lblLossDate.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))

            cellLossDateHeader.Border = 0
            cellLossDate.Border = 0

            cellLossDateHeader.HorizontalAlignment = 0
            cellLossDate.HorizontalAlignment = 0

            cellLossDate.PaddingBottom = 2.0F
            cellLossDateHeader.PaddingBottom = 2.0F

            '0=Left, 1=Centre, 2=Right
            claimInformationTable.AddCell(cellLossDateHeader)
            claimInformationTable.AddCell(cellLossDate)

            'LOSS DATE
            Dim cellLossUnitHeader As New PdfPCell(New Phrase("LOSS UNIT: ", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            Dim cellLossUnit As New PdfPCell(New Phrase(lblLossUnit.Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellLossUnitHeader.Border = 0
            cellLossUnit.Border = 0

            cellLossUnitHeader.HorizontalAlignment = 0
            cellLossUnit.HorizontalAlignment = 0

            cellLossUnit.PaddingBottom = 2.0F
            cellLossUnitHeader.PaddingBottom = 2.0F

            '0=Left, 1=Centre, 2=Right
            claimInformationTable.AddCell(cellLossUnitHeader)
            claimInformationTable.AddCell(cellLossUnit)

            document.Add(claimInformationTable)
            document.Add(New Phrase(Environment.NewLine))

            Dim tableBillHeader = New PdfPTable(1)
            tableBillHeader.WidthPercentage = 100.0F
            Dim billHeader As New PdfPCell(New Phrase("BILLABLE ITEMS:", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            'billHeader.BackgroundColor = Color.LIGHT_GRAY
            billHeader.Border = 0
            billHeader.BorderWidthBottom = 2.0F

            billHeader.PaddingBottom = 5.0F
            tableBillHeader.AddCell(billHeader)

            document.Add(tableBillHeader)

            ' Create the Order Details table
            Dim orderDetailsTable = New PdfPTable(3)
            orderDetailsTable.WidthPercentage = 100.0F

            orderDetailsTable.HorizontalAlignment = 1
            ' orderDetailsTable.DefaultCell.HorizontalAlignment = 1
            'orderDetailsTable.SpacingBefore = 10
            'orderDetailsTable.SpacingAfter = 35
            orderDetailsTable.DefaultCell.Border = 0
            Dim billItem As New PdfPCell(New Phrase("ITEM", New Font(Font.BOLD, 10.0F, Font.BOLD)))
            Dim billDescription As New PdfPCell(New Phrase("DESCRIPTION", New Font(Font.BOLD, 10.0F, Font.BOLD)))
            Dim billPrice As New PdfPCell(New Phrase("PRICE ($)", New Font(Font.BOLD, 10.0F, Font.BOLD)))
            billItem.Border = 0
            billItem.BackgroundColor = Color.LIGHT_GRAY
            billItem.HorizontalAlignment = 1
            billItem.PaddingBottom = 5.0F
            billDescription.Border = 0
            'billDescription.BorderWidthBottom = 2.0F
            billDescription.BackgroundColor = Color.LIGHT_GRAY
            billDescription.PaddingBottom = 5.0F
            billPrice.Border = 0
            billPrice.HorizontalAlignment = 1
            'billPrice.BorderWidthBottom = 2.0F
            billPrice.BackgroundColor = Color.LIGHT_GRAY
            billPrice.PaddingBottom = 5.0F
            orderDetailsTable.AddCell(billItem)
            billDescription.HorizontalAlignment = 1
            orderDetailsTable.AddCell(billDescription)
            orderDetailsTable.AddCell(billPrice)

            '    orderDetailsTable.AddCell(New Phrase("ITEM", boldTableFont))
            'orderDetailsTable.AddCell(New Phrase("DESCRIPTION:", boldTableFont))
            'orderDetailsTable.AddCell(New Phrase("PRICE", boldTableFont))
            For i As Integer = 0 To gridViewInvoice.Rows.Count - 1
                Dim cell1 As New PdfPCell(New Phrase(gridViewInvoice.Rows(i).Cells(0).Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
                Dim cell2 As New PdfPCell(New Phrase(gridViewInvoice.Rows(i).Cells(1).Text, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
                Dim cell3 As New PdfPCell(New Phrase("$" + (Math.Round(Convert.ToDecimal(gridViewInvoice.Rows(i).Cells(2).Text), 2)).ToString, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
                cell1.HorizontalAlignment = 1
                cell2.HorizontalAlignment = 1
                cell3.HorizontalAlignment = 1
                cell1.Border = 0
                cell2.Border = 0
                cell3.Border = 0
                cell1.PaddingBottom = 3.0F
                cell2.PaddingBottom = 3.0F
                cell3.PaddingBottom = 3.0F
                orderDetailsTable.AddCell(cell1)
                orderDetailsTable.AddCell(cell2)
                orderDetailsTable.AddCell(cell3)
            Next


            Dim cellSubTotalHeader As New PdfPCell(New Phrase("SUBTOTAL:", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            cellSubTotalHeader.Colspan = 2
            cellSubTotalHeader.Border = 0
            cellSubTotalHeader.HorizontalAlignment = 2
            '0=Left, 1=Centre, 2=Right

            Dim cellSubTotal As New PdfPCell(New Phrase("$ " + (Math.Round(Convert.ToDecimal(lblSubTotal.Text), 2)).ToString, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellSubTotal.HorizontalAlignment = 1
            cellSubTotal.Border = 0
            cellSubTotalHeader.BorderWidthTop = 2.0F
            cellSubTotal.BorderWidthTop = 2.0F
            cellSubTotalHeader.PaddingTop = 10.0F
            cellSubTotal.PaddingTop = 10.0F
            orderDetailsTable.AddCell(cellSubTotalHeader)
            orderDetailsTable.AddCell(cellSubTotal)

            Dim cellTaxHeader As New PdfPCell(New Phrase("TAX & FEES:", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            cellTaxHeader.Colspan = 2
            cellTaxHeader.Border = 0
            cellTaxHeader.HorizontalAlignment = 2
            '0=Left, 1=Centre, 2=Right

            Dim cellTax As New PdfPCell(New Phrase("$ " + (Math.Round(Convert.ToDecimal(lblTaxFees.Text), 2)).ToString, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellTax.HorizontalAlignment = 1
            cellTax.Border = 0
            cellTaxHeader.PaddingTop = 2.0F
            cellTax.PaddingTop = 2.0F
            orderDetailsTable.AddCell(cellTaxHeader)
            orderDetailsTable.AddCell(cellTax)


            Dim cellTotalHeader As New PdfPCell(New Phrase("PAY THIS AMOUNT:", New Font(Font.TIMES_ROMAN, 10.0F, Font.BOLD)))
            cellTotalHeader.Colspan = 2
            cellTotalHeader.Border = 0
            cellTotalHeader.HorizontalAlignment = 2
            '0=Left, 1=Centre, 2=Right

            Dim cellTotal As New PdfPCell(New Phrase("$ " + (Math.Round(Convert.ToDecimal(lblTotalAmount.Text), 2)).ToString, New Font(Font.TIMES_ROMAN, 10.0F, Font.NORMAL)))
            cellTotal.HorizontalAlignment = 1
            cellTotal.Border = 0
            cellTotalHeader.PaddingTop = 2.0F
            cellTotal.PaddingTop = 2.0F
            orderDetailsTable.AddCell(cellTotalHeader)
            orderDetailsTable.AddCell(cellTotal)
            document.Add(orderDetailsTable)

            document.Add(New Phrase(Environment.NewLine))
            document.Add(New Phrase(Environment.NewLine))
            ' Add ending message
            Dim endingMessage = New Paragraph("If you have any questions, please contact us at 888-658-1828.", endingMessageFont)
            endingMessage.SetAlignment("Center")
            document.Add(endingMessage)


            document.Close()
            System.Threading.Thread.Sleep(2000)

            'Save Generated Invoice
            objacess.insertInvoiceDetails(lblInvoiceNumber.Text, Path.Combine(pathToFolder,
                                                lblInvoiceNumber.Text + ".pdf".ToString), False,
                                          DateTime.Now.ToString("MM\-dd\-yyyy"), lblClaimNumber.Text)

            'Insert Invoice Expense List
            For Each rows As GridViewRow In gridViewInvoice.Rows
                objacess.insertInvoiceExpenseList(lblInvoiceNumber.Text, rows.Cells(1).Text.ToString,
                                                  rows.Cells(2).Text.ToString)
            Next

            '   Dim fi As New FileInfo(filePath)

            'Save file path
            objacess.insertFilepath(lblClaimNumber.Text, "Invoice",
                                    Path.Combine(pathToFolder, lblInvoiceNumber.Text + ".pdf".ToString),
                                             "Invoice", lblInvoiceNumber.Text.ToString + ".pdf",
                                             "application/pdf")


            'Navigate

            Response.Redirect("ClaimDetail.aspx?ClaimID=" + claimID.ToString + "", False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class