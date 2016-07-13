'************************Imports************************
Imports System
Imports Artem.Google.UI
Imports System.Data
Imports System.Collections
Imports crossCountryDataAccess
Imports System.Net
'Imports integrityAccess
Imports System.IO
Imports System.Xml
Imports System.Web
Imports System.Web.UI
'Imports net.symbility.www

Public Class assignClaim
    Inherits System.Web.UI.Page

    Dim objAccess As New crossCountryDataAccess.dataAccess
    '   Dim objClass As New integrityAccess.IntegrityClass
    '  Dim objEmail As New integrityAccess.EmailCenter  'Email Center

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            'Dim name As String = "jqScript"
            'Dim url As String = "~/Scripts/jquery-1.3.2.js"
            'Dim type As Type = Me.GetType()

            ''Register jquery script
            'If Page.ClientScript.IsClientScriptIncludeRegistered(type, name) = False Then
            '    Page.ClientScript.RegisterClientScriptInclude(type, name, ResolveClientUrl(url))
            'End If

            'calling initmap javascript method
            If Page.ClientScript.IsStartupScriptRegistered(Me.GetType(), "initmap") = False Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "initmap", "MYMAP.init(30.709962, -88.044548, 12);", True)
            End If
            populatechooseClaimDropDown()
            populateStateDropDown() 'State drop down list
            populateAdjusterList()    'List of all adjuster  
            populateAdjusterWithClaims() 'Adjuster with Claims
            populateClaimRepList() 'Claim Rep List
            GetCarrierlist() 'Carrier List
            getLossTypeList() 'Loss Type List



        End If

    End Sub

    Protected Sub populatechooseClaimDropDown()
        ddlChooseClaim.Items.Add("All")
        ddlChooseClaim.Items.Add("Unassigned")

    End Sub

    Protected Sub populateStateDropDown()
        Dim dtState As New DataTable
        Dim da As New dataAccess
        dtState = da.getAllState()
        Dim errormsg = ""
        Try
            With ddlState
                .DataSource = dtState
                .DataTextField = "name_long"
                .DataValueField = "name_short"
                .DataBind()
                .Items.Insert(0, "Select State")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GetCarrierlist()
        Dim tableCarrierList As New DataTable
        tableCarrierList = objAccess.getCompanyList()
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

    ' Get lost type drop Down list
    Protected Sub getLossTypeList()
        Dim tableLossType As New DataTable
        tableLossType = objAccess.getLossType
        If tableLossType.Rows.Count >= 1 Then
            With ddlChooseLossType
                .DataSource = tableLossType
                .DataTextField = "Loss Type"
                .DataValueField = "Loss Type"
                .DataBind()
                .Items.Insert(0, "-Select Loss Type-")
            End With
        End If

    End Sub

    'Get list of Claim Reps
    Protected Sub populateClaimRepList()
        Dim da As New dataAccess
        Dim dtClaimRepList As New DataTable
        dtClaimRepList = da.getClaimRepDropDownMap
        If dtClaimRepList.Rows.Count >= 1 Then
            With ddlChooseClaimRep
                .DataSource = dtClaimRepList
                .DataTextField = "claim_Rep"
                .DataValueField = "E-mail"
                .DataBind()
                .Items.Insert(0, "- Select Claim Rep -")
            End With
        End If

    End Sub

    'Get list of adjuster with assigned claim
    Protected Sub populateAdjusterWithClaims()
        Dim da As New dataAccess
        Dim dtAdList As New DataTable
        dtAdList = da.getAdjusterDropDownMap()
        If dtAdList.Rows.Count >= 1 Then
            With ddlChooseAdjuster
                .DataSource = dtAdList
                .DataTextField = "Adjuster"
                .DataValueField = "E-mail"
                .DataBind()
                .Items.Insert(0, "- Select Adjuster -")
            End With
        End If

    End Sub

    'Get list of adjuster
    Protected Sub populateAdjusterList()
        Dim da As New dataAccess
        Dim dtAdList As New DataTable
        dtAdList = da.getAdjusterDropDown()
        If dtAdList.Rows.Count >= 1 Then
            With ddlAdjuster
                .DataSource = dtAdList
                .DataTextField = "Adjuster"
                .DataValueField = "E-mail"
                .DataBind()
                .Items.Insert(0, "- Select Adjuster -")
            End With
        End If

    End Sub

    Protected Function FilterMarker(ByVal dt As DataTable) As String

        Dim result As String = ""
        If dt.Rows.Count >= 1 Then
            Using str As New StringWriter()
                Using w As New XmlTextWriter(str)
                    w.WriteStartDocument()
                    w.WriteComment("xml for marker")
                    w.WriteStartElement("Markers")

                    'looping over each rows in the datatable.
                    For Each itemRow In dt.Rows
                        Dim claimNo = itemRow("Claim #").ToString
                        Dim insuredName = itemRow("Insured Name").ToString
                        Dim Address = itemRow("Address").ToString
                        Dim adjuster = itemRow("Adjuster").ToString
                        Dim Title = itemRow("Claim #").ToString
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

    ''assigns a claim on Symbility
    'Public Sub assignSymbilityClaim(ByVal claimNumber As String, ByVal adjusterEmail As String)

    '    Using symbilityConnect As New SymbilityClaimsService
    '        Dim claimIdSpec As New ClaimIDSpecification
    '        Dim companyIdSpec As New CompanyIDSpecification
    '        Dim assignCompanyId As New CompanyIDSpecification
    '        Dim userIdSpec As New UserIDSpecification
    '        Dim assigneeId As New UserIDSpecification
    '        Dim companyRole As New CompanyRole

    '        claimIdSpec.ClaimIDType = ClaimIDType.ClaimNumber
    '        claimIdSpec.ClaimID = claimNumber
    '        companyIdSpec.CompanyIDType = CompanyIDType.None
    '        companyIdSpec.CompanyID = String.Empty
    '        assignCompanyId.CompanyIDType = CompanyIDType.CompanyID

    '        Dim symbilityCompanyId As New DataTable
    '        symbilityCompanyId = objAccess.getSymbilityCompanyId(adjusterEmail)
    '        assignCompanyId.CompanyID = symbilityCompanyId.Rows(0).Item("company Id")


    '        userIdSpec.UserIDType = UserIDType.UserEmail
    '        userIdSpec.UserID = Session("EmailId")

    '        'assigneeId.UserIDType = net.symbility.staging.UserIDType.UserEmail
    '        'assigneeId.UserID = cmbAssign.Text

    '        'authentication header
    '        Dim MyAuthenticationHeader As New AuthenticationHeader
    '        Dim symbilityTable As New DataTable
    '        symbilityTable = objAccess.getSymbilityAuthenticationInfo()
    '        MyAuthenticationHeader.AccountNumber = symbilityTable.Rows(0).Item("apiAccountNumber")
    '        MyAuthenticationHeader.Password = symbilityTable.Rows(0).Item("apiPassword")

    '        symbilityConnect.Url = symbilityTable.Rows(0).Item("apiURL")
    '        symbilityConnect.UseDefaultCredentials = True

    '        symbilityConnect.AuthenticationHeaderValue = MyAuthenticationHeader
    '        If objClass.checkSymbilityAssignees(claimNumber, symbilityCompanyId.Rows(0).Item("company Id")) = True Then
    '            'Do nothing. User already assigned
    '        Else
    '            symbilityConnect.AddClaimAssignee(claimIdSpec, companyIdSpec, assignCompanyId, userIdSpec, companyRole.Assignee)
    '        End If
    '    End Using


    'End Sub

    'assigns claims to adjuster
    'Protected Sub btnAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssign.Click
    '    Dim isValidateError As Boolean = False
    '    Dim isClaimSelected As Boolean = False
    '    Dim userTable As New DataTable
    '    Dim adjusterTable As New DataTable


    '    userTable = objAccess.getUsersDetailByEmail(Session("EmailId"))
    '    'check if atleast one claim is selected
    '    For i As Integer = 0 To gdClaimCount.Rows.Count - 1
    '        Dim chkBoxCell As CheckBox = gdClaimCount.Rows(i).FindControl("assignCheckbox")
    '        If chkBoxCell.Checked = True Then
    '            isClaimSelected = True
    '            Exit For
    '        Else
    '            isClaimSelected = False
    '        End If
    '    Next

    '    If isClaimSelected = False Then
    '        isValidateError = True
    '        lblSelectAdjusterInfo.Text = "-No Claim Selected-"
    '    End If

    '    If ddlAdjuster.SelectedIndex = 0 Then
    '        lblSelectAdjusterInfo.Text = "-No adjuster selected-"
    '        isValidateError = True
    '    Else

    '    End If


    '    If isValidateError = True Then
    '        'Do nothing
    '    Else
    '        Dim claimList As New ArrayList

    '        lblSelectAdjusterInfo.Text = ""
    '        System.Threading.Thread.Sleep(2000)
    '        For i As Integer = 0 To gdClaimCount.Rows.Count - 1
    '            Dim chkBoxCell As CheckBox = gdClaimCount.Rows(i).FindControl("assignCheckbox")
    '            If chkBoxCell.Checked = True Then
    '                claimList.Add(gdClaimCount.Rows(i).Cells(2).Text)
    '                adjusterTable = objAccess.getUsersDetailByEmail(ddlAdjuster.Text)
    '                objAccess.assignAdjusterToClaim(gdClaimCount.Rows(i).Cells(2).Text, ddlAdjuster.Text)
    '                objAccess.insertClaimNotes(gdClaimCount.Rows(i).Cells(2).Text, "Claim was assigned to " + adjusterTable.Rows(0).Item("f_name") + " " + adjusterTable.Rows(0).Item("l_name"), userTable.Rows(0).Item("f_name") + " " + userTable.Rows(0).Item("l_name"), True)
    '                'adjustertable = objAccess.getAdjusterByClaimId(gdClaimCount.Rows(i).Cells(1).Text)
    '                'Assign / Unassign on Symbility
    '                'If objClass.checkSymbilityClaims(gdClaimCount.Rows(i).Cells(2).Text) = True Then
    '                '    'unassignSymbility(gdClaimCount.Rows(i).Cells(2).Text, adjustertable.Rows(0).Item("Email"))
    '                '    assignSymbilityClaim(gdClaimCount.Rows(i).Cells(2).Text, cbAdjuster.Text)
    '                'Else
    '                '    'Do nothing
    '                'End If
    '            Else
    '                'Do nothing
    '            End If
    '        Next

    '        If claimList.Count >= 1 Then
    '            lblSelectAdjusterInfo.Text = "The Claims " + [String].Join(", ", claimList.ToArray()) + " has been assigned to adjuster " + ddlAdjuster.Text + "."
    '            'objEmail.emailAssignedClaimToAdjuster(cbAdjuster.Text, [String].Join(", ", claimList.ToArray()), "")
    '        End If

    '        If Session("mapSelected") = "claimState" Then
    '            filterClaimByClaimAndState()
    '        ElseIf Session("mapSelected") = "Adjuster" Then

    '            populateAdjusterWithClaims()
    '        ElseIf Session("mapSelected") = "claimRep" Then
    '            filterClaimByClaimRep()
    '        ElseIf Session("mapSelected") = "Carrier" Then
    '            filterClaimByCarrier()
    '        ElseIf Session("mapSelected") = "lossType" Then
    '            filterClaimByLossType()
    '        ElseIf Session("mapSelected") = "search" Then
    '            searchClaims()
    '        End If
    '        populateAdjusterWithClaims()
    '    End If

    'End Sub

    Protected Sub runScript(ByVal stringMap As String)
        Dim result = stringMap
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearOverlays",
                                                "MYMAP.clearOverlays();", True)
        If result = "" Then
            lblMapInfo.Text = "-No Claims Found-"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "initmap", "MYMAP.init(30.709962, -88.044548, 12);", True)
        Else
            lblMapInfo.Text = ""
            'calling javascript function on partial postback to filter markers from the result
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "filterplacemark",
                                                "var filterresult='" + Server.HtmlDecode(result) + "';MYMAP.placemarkAjax(filterresult);", True)
        End If
    End Sub


    ''unassigns adjuster in symbility
    'Protected Sub unassignSymbility(ByVal claimNumber As String, ByVal adjusterEmail As String)

    '    Try

    '        'Dim adjusterInfo As New DataTable
    '        'adjusterInfo = objAccess.getAdjusterByClaimId(CInt(id))

    '        Using symbilityConnect As New SymbilityClaimsService
    '            Dim claimIdSpec As New ClaimIDSpecification
    '            Dim companyIdSpec As New CompanyIDSpecification
    '            Dim assignCompanyId As New CompanyIDSpecification
    '            Dim userIdSpec As New UserIDSpecification

    '            userIdSpec.UserIDType = UserIDType.UserEmail
    '            userIdSpec.UserID = Session("EmailId")

    '            claimIdSpec.ClaimIDType = ClaimIDType.ClaimNumber
    '            claimIdSpec.ClaimID = claimNumber
    '            companyIdSpec.CompanyIDType = CompanyIDType.None
    '            assignCompanyId.CompanyIDType = CompanyIDType.CompanyID

    '            Dim symbilityCompanyId As New DataTable
    '            symbilityCompanyId = objAccess.getSymbilityCompanyId(adjusterEmail)
    '            assignCompanyId.CompanyID = symbilityCompanyId.Rows(0).Item("Company Id")

    '            Dim MyAuthenticationHeader As New AuthenticationHeader
    '            Dim symbilityTable As New DataTable
    '            symbilityTable = objAccess.getSymbilityAuthenticationInfo()
    '            MyAuthenticationHeader.AccountNumber = symbilityTable.Rows(0).Item("apiAccountNumber")
    '            MyAuthenticationHeader.Password = symbilityTable.Rows(0).Item("apiPassword")

    '            symbilityConnect.Url = symbilityTable.Rows(0).Item("apiURL")
    '            symbilityConnect.UseDefaultCredentials = True

    '            symbilityConnect.AuthenticationHeaderValue = MyAuthenticationHeader
    '            symbilityConnect.RemoveClaimAssignee(claimIdSpec, companyIdSpec, assignCompanyId, userIdSpec)

    '        End Using
    '    Catch ex As Exception

    '    End Try


    'End Sub

    Protected Sub gdClaimCount_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gdClaimCount.PageIndexChanging
        Dim dt As New DataTable
        Dim da As New dataAccess
        dt = da.getUnAssignedClaimByState(Session("state"))
        Dim dv As New DataView(dt)
        gdClaimCount.DataSource = dv
        gdClaimCount.DataBind()
        gdClaimCount.PageIndex = e.NewPageIndex
        gdClaimCount.DataBind()
    End Sub

    'SORTING GRIDVIEW>>>>>>>>>>>>>
    Private Const ASCENDING As String = " ASC"
    Private Const DESCENDING As String = " DESC"

    Public Property GridViewSortDirection() As SortDirection
        Get
            If ViewState("sortDirection") Is Nothing Then
                ViewState("sortDirection") = SortDirection.Ascending
            End If

            Return DirectCast(ViewState("sortDirection"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("sortDirection") = value
        End Set
    End Property

    'Sorting Gridview
    Protected Sub GridView_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            SortGridView(sortExpression, DESCENDING)
        Else
            GridViewSortDirection = SortDirection.Ascending
            SortGridView(sortExpression, ASCENDING)
        End If
        'filterMarkersbyState(ddState.Text)
        'filterGridviewbyState(ddState.Text)
    End Sub

    Private Sub SortGridView(ByVal sortExpression As String, ByVal direction As String)
        Dim dt As New DataTable
        Dim objAccess As New dataAccess
        dt = objAccess.getUnassignedClaim()
        Dim dv As New DataView(dt)
        dv.Sort = sortExpression & direction
        gdClaimCount.DataSource = dv
        gdClaimCount.DataBind()
    End Sub

    'Filtered GridView Sorting
    Protected Sub GridViewCount_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression

        If GridViewSortDirection = SortDirection.Ascending Then
            GridViewSortDirection = SortDirection.Descending
            SortGridViewCount(sortExpression, DESCENDING)
        Else
            GridViewSortDirection = SortDirection.Ascending
            SortGridViewCount(sortExpression, ASCENDING)
        End If

    End Sub

    Private Sub SortGridViewCount(ByVal sortExpression As String, ByVal direction As String)
        Dim dt As New DataTable
        Dim objAccess As New dataAccess
        dt = objAccess.getUnassignedClaimCountbyState(Session("state"))
        Dim dv As New DataView(dt)
        dv.Sort = sortExpression & direction
        gdClaimCount.DataSource = dv
        gdClaimCount.DataBind()
    End Sub

    'Geo Coding
    Public Function AddressToLatLongGeocoder(ByVal address As String) As LatLng
        Dim wc As New WebClient
        Dim geocodeStream As Stream =
            wc.OpenRead("http://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&sensor=true")
        Dim str As String
        str = "http://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&sensor=true"
        Dim xr As New XmlTextReader(geocodeStream)

        Try
            Dim ll As New LatLng
            While xr.Read()
                If xr.Name = "lat" Then
                    ll.Latitude = CDbl(xr.ReadInnerXml)
                End If
                If xr.Name = "lng" Then
                    ll.Longitude = CDbl(xr.ReadInnerXml)
                End If
            End While

            wc.Dispose()
            Return ll
        Catch
            Return Nothing
        End Try

    End Function


    Protected Sub gdClaimCount_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdClaimCount.RowDataBound
        'Hide Id
        e.Row.Cells(1).Visible = False
        'e.Row.Cells(4).Visible = False
        'e.Row.Cells(6).Visible = False
        'e.Row.Cells(7).Visible = False
        e.Row.Cells(8).Visible = False
        e.Row.Cells(9).Visible = False
        'e.Row.Cells(3).Width = 150
        'e.Row.Cells(3).Wrap = True
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='skyblue'; this.style.cursor='pointer'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'")
        End If
    End Sub







    'Search Claim list
    Protected Sub searchClaims()
        Dim dtSearchClaim As New DataTable
        If txtSearchClaims.Text <> String.Empty Then
            dtSearchClaim = objAccess.searchAllClaims(txtSearchClaims.Text)
            If dtSearchClaim.Rows.Count >= 1 Then
                Session("mapSelected") = "search"
                lblMapInfo.Text = String.Empty
                Dim str As String = FilterMarker(dtSearchClaim)
                runScript(str)
                gdClaimCount.DataSource = dtSearchClaim
                gdClaimCount.DataBind()
                lblMapHeading.Text = "Search result for: " + txtSearchClaims.Text
                lblClaimCount.Text = "Claim Count: " + dtSearchClaim.Rows.Count.ToString

            Else
                Dim str As String = FilterMarker(dtSearchClaim)
                runScript(str)
                gdClaimCount.DataSource = Nothing
                gdClaimCount.DataBind()

                lblClaimCount.Text = "Claim Count: " + 0
            End If
        End If
    End Sub

    'Map load by Loss type
    Protected Sub filterClaimByLossType()
        Dim dtclaimList As New DataTable
        If ddlChooseLossType.SelectedIndex = 0 Then
        Else
            dtclaimList = objAccess.getAllClaimsByLossType(ddlChooseLossType.Text)
            If dtclaimList.Rows.Count >= 1 Then
                Session("mapSelected") = "lossType"
                Dim str As String = FilterMarker(dtclaimList)
                runScript(str)
                gdClaimCount.DataSource = dtclaimList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "All assigned claims for: " + ddlChooseLossType.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            Else
                Dim str As String = FilterMarker(dtclaimList)
                runScript(str)
                gdClaimCount.DataSource = Nothing
                gdClaimCount.DataBind()

                lblClaimCount.Text = "Claim Count: " + 0
            End If
        End If
    End Sub

    'Map load by Carrier 
    Protected Sub filterClaimByCarrier()
        Dim dtclaimList As New DataTable
        If ddlChooseCarrier.SelectedIndex = 0 Then
            'Do nothing
        Else
            dtclaimList = objAccess.getAllClaimsByCarrier(ddlChooseCarrier.Text)
            If dtclaimList.Rows.Count >= 1 Then
                Session("mapSelected") = "Carrier"
                Dim str As String = FilterMarker(dtclaimList)
                runScript(str)
                gdClaimCount.DataSource = dtclaimList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "All assigned claims for: " + ddlChooseCarrier.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            Else
                Dim str As String = FilterMarker(dtclaimList)
                gdClaimCount.DataSource = Nothing
                gdClaimCount.DataBind()
                runScript(str)
                lblClaimCount.Text = "Claim Count: " + 0
            End If
        End If
    End Sub

    'Map load by Claim Re
    Protected Sub filterClaimByClaimRep()
        Dim dtclaimList As New DataTable
        If ddlChooseClaimRep.SelectedIndex = 0 Then
        Else
            dtclaimList = objAccess.getAllClaimsByClaimRep(ddlChooseClaimRep.Text)
            If dtclaimList.Rows.Count >= 1 Then
                Session("mapSelected") = "claimRep"
                Dim str As String = FilterMarker(dtclaimList)
                runScript(str)
                gdClaimCount.DataSource = dtclaimList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "All assigned claims for: " + ddlChooseClaimRep.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            Else
                Dim str As String = FilterMarker(dtclaimList)
                gdClaimCount.DataSource = Nothing
                gdClaimCount.DataBind()
                runScript(str)
                lblClaimCount.Text = "Claim Count: " + 0
            End If
        End If
    End Sub

    'Map load by Adjuster
    Protected Sub filterClaimByAdjuster()
        Dim dtClaimList As New DataTable
        If ddlChooseAdjuster.SelectedIndex = 0 Then
        Else
            dtClaimList = objAccess.getAssignedClaimByAdjusterEmailId(ddlChooseAdjuster.Text)
            If dtClaimList.Rows.Count >= 1 Then
                Session("mapSelected") = "Adjuster"
                Dim str As String = FilterMarker(dtClaimList)
                runScript(str)
                gdClaimCount.DataSource = dtClaimList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "All assigned claims for: " + ddlChooseAdjuster.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            Else
                Dim str As String = FilterMarker(dtClaimList)
                gdClaimCount.DataSource = Nothing
                gdClaimCount.DataBind()
                runScript(str)
                lblClaimCount.Text = "Claim Count: " + 0
            End If
        End If
    End Sub

    'Map load by Claim and State
    Protected Sub filterClaimByClaimAndState()
        Dim isValidateError As Boolean = False
        Dim dtClaimsList As New DataTable
        Session("mapSelected") = "claimState"

        If ddlState.SelectedIndex = 0 Then
            If ddlChooseClaim.Text = "All" Then
                dtClaimsList = objAccess.getAllOpenClaimsList()
                Dim str As String = FilterMarker(dtClaimsList)
                runScript(str)
                gdClaimCount.DataSource = dtClaimsList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "ALL OPEN/REOPENED CLAIMS"
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            ElseIf ddlChooseClaim.Text = "Unassigned" Then
                dtClaimsList = objAccess.getUnassignedClaim()
                Dim str As String = FilterMarker(dtClaimsList)
                runScript(str)
                gdClaimCount.DataSource = dtClaimsList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "ALL Unassigned CLAIMS"
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            End If
        Else
            If ddlChooseClaim.Text = "All" Then
                dtClaimsList = objAccess.getAllOpenClaimsByState(ddlState.Text)
                Dim str As String = FilterMarker(dtClaimsList)
                runScript(str)
                gdClaimCount.DataSource = dtClaimsList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "ALL OPEN/REOPENED CLAIMS FOR : " + ddlState.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            ElseIf ddlChooseClaim.Text = "Unassigned" Then
                dtClaimsList = objAccess.getUnAssignedClaimByState(ddlState.Text)
                Dim str As String = FilterMarker(dtClaimsList)
                runScript(str)
                gdClaimCount.DataSource = dtClaimsList
                gdClaimCount.DataBind()
                lblMapHeading.Text = "ALL UNASSIGNED CLAIMS FOR : " + ddlState.Text
                lblClaimCount.Text = "Claim Count: " + gdClaimCount.Rows.Count.ToString
            End If
        End If
    End Sub

    'Filter Map by Claim and State
    Protected Sub btnFilterByClaimState_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilterByClaimState.Click
        filterClaimByClaimAndState()
    End Sub

    Protected Sub btnSearchClaims_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchClaims.Click
        searchClaims()
    End Sub

    Protected Sub btnFilterByAdjuster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilterByAdjuster.Click
        filterClaimByAdjuster()
    End Sub

    Protected Sub btnFilterByClaimRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilterByClaimRep.Click
        filterClaimByClaimRep()
    End Sub

    Protected Sub btnFilterByCarrier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilterByCarrier.Click
        filterClaimByCarrier()
    End Sub

    Protected Sub btnFilterByLossType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilterByLossType.Click
        filterClaimByLossType()
    End Sub



    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Dim isValidateError As Boolean = False
        Dim isClaimSelected As Boolean = False
        Dim userTable As New DataTable
        Dim adjusterTable As New DataTable


        userTable = objAccess.getUsersDetailByEmail(Session("EmailId"))
        'check if atleast one claim is selected
        For i As Integer = 0 To gdClaimCount.Rows.Count - 1
            Dim chkBoxCell As CheckBox = gdClaimCount.Rows(i).FindControl("assignCheckbox")
            If chkBoxCell.Checked = True Then
                isClaimSelected = True
                Exit For
            Else
                isClaimSelected = False
            End If
        Next

        If isClaimSelected = False Then
            isValidateError = True
            lblSelectAdjusterInfo.Text = "-No Claim Selected-"
        End If

        If ddlAdjuster.SelectedIndex = 0 Then
            lblSelectAdjusterInfo.Text = "-No adjuster selected-"
            isValidateError = True
        Else

        End If


        If isValidateError = True Then
            'Do nothing
        Else
            Dim claimList As New ArrayList

            lblSelectAdjusterInfo.Text = ""
            System.Threading.Thread.Sleep(2000)
            For i As Integer = 0 To gdClaimCount.Rows.Count - 1
                Dim chkBoxCell As CheckBox = gdClaimCount.Rows(i).FindControl("assignCheckbox")
                If chkBoxCell.Checked = True Then
                    claimList.Add(gdClaimCount.Rows(i).Cells(2).Text)
                    adjusterTable = objAccess.getUsersDetailByEmail(ddlAdjuster.Text)
                    objAccess.assignAdjusterToClaim(gdClaimCount.Rows(i).Cells(2).Text, ddlAdjuster.Text)
                    objAccess.insertClaimNotes(gdClaimCount.Rows(i).Cells(2).Text, "Claim was assigned to " + adjusterTable.Rows(0).Item("f_name") + " " + adjusterTable.Rows(0).Item("l_name"), userTable.Rows(0).Item("f_name") + " " + userTable.Rows(0).Item("l_name"), True)
                    'adjustertable = objAccess.getAdjusterByClaimId(gdClaimCount.Rows(i).Cells(1).Text)
                    'Assign / Unassign on Symbility
                    'If objClass.checkSymbilityClaims(gdClaimCount.Rows(i).Cells(2).Text) = True Then
                    '    'unassignSymbility(gdClaimCount.Rows(i).Cells(2).Text, adjustertable.Rows(0).Item("Email"))
                    '    assignSymbilityClaim(gdClaimCount.Rows(i).Cells(2).Text, cbAdjuster.Text)
                    'Else
                    '    'Do nothing
                    'End If
                Else
                    'Do nothing
                End If
            Next

            If claimList.Count >= 1 Then
                lblSelectAdjusterInfo.Text = "The Claims " + [String].Join(", ", claimList.ToArray()) + " has been assigned to adjuster " + ddlAdjuster.Text + "."
                'objEmail.emailAssignedClaimToAdjuster(cbAdjuster.Text, [String].Join(", ", claimList.ToArray()), "")
            End If

            If Session("mapSelected") = "claimState" Then
                filterClaimByClaimAndState()
            ElseIf Session("mapSelected") = "Adjuster" Then

                populateAdjusterWithClaims()
            ElseIf Session("mapSelected") = "claimRep" Then
                filterClaimByClaimRep()
            ElseIf Session("mapSelected") = "Carrier" Then
                filterClaimByCarrier()
            ElseIf Session("mapSelected") = "lossType" Then
                filterClaimByLossType()
            ElseIf Session("mapSelected") = "search" Then
                searchClaims()
            End If
            populateAdjusterWithClaims()
        End If
    End Sub
End Class