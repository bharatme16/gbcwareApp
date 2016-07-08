Imports System
Imports Artem.Google.UI
Imports System.Data
Imports System.Collections
Imports CrossCountryDataAccess
Imports System.Net
'Imports integrityAccess
Imports System.IO
Imports System.Xml
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class claimMap
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            populateClaimDropDowns()

        End If
        populateMarkers()
    End Sub


    Protected Sub populateClaimDropDowns()


        Dim dtClaim As New DataTable
        Dim daClaim As New daMap
        dtClaim = daClaim.getAssignedClaimByAdjusterEmailId(Session("EmailId"))
        Dim errormsg = ""


        'ddClaim.DataSource = dtClaim
        'ddClaim.DataBind()
        'GridView1.DataSource = dtClaim
        'GridView1.DataBind()
        Try
            With ddClaim
                .DataSource = dtClaim
                .DataTextField = "claim #"
                .DataValueField = "claim #"
                .DataBind()
            End With
            With ddclaim1
                .DataSource = dtClaim
                .DataValueField = "Address"
                .DataTextField = "Claim #"
                .DataBind()
            End With
            With ddclaim2
                .DataSource = dtClaim
                .DataValueField = "Address"
                .DataTextField = "Claim #"
                .DataBind()
            End With


            ddClaim.Items.Insert(0, "- Select Claim # -")
            ddclaim1.Items.Insert(0, "- Select Claim # -")
            ddclaim2.Items.Insert(0, "- Select Claim # -")
        Catch ex As Exception
        End Try



    End Sub

    Protected Sub populateMarkers()
        gbcmap.MapType = MapType.Terrain
        Dim dtClaim As New DataTable
        gbcmap.Markers.Clear()
        Dim daClaim As New daMap
        claimMarker.Markers.Clear()
        dtClaim = daClaim.getAssignedClaimByAdjusterEmailId(Session("EmailId"))
        For Each row As DataRow In dtClaim.Rows
            Dim address As String
            Dim title As String
            address = row.Item("Address")
            Dim claimNo = row.Item("Claim #").ToString
            title = "Claim #: " + claimNo + "/ " + "Insured: " + row.Item("Insured Name")
            Dim insured = row.Item("Insured Name")
            Dim Info = "<b> Claim #: </b> " + claimNo + "<br>" +
             "<b>Insured: </b>" + insured + "<br>" +
             "<b> Address: </b>" + address

            claimMarker.Markers.Add(New Artem.Google.UI.Marker() With
                                    {.Position = New LatLng(row.Item("Latitude"),
                                    row.Item("Longitude")), .Title = title, .Info = Info})

            Dim ll As New LatLng
            ll.Latitude = row.Item("Latitude")
            ll.Longitude = row.Item("Longitude")
            gbcmap.Center = ll
            With claimMarker
                .MarkerOptions.Draggable = False
                .MarkerOptions.Clickable = True
                .MarkerOptions.Animation = MarkerAnimation.Drop
            End With
        Next

    End Sub


    Protected Sub filterMarkersbyClaimId(ByVal claimNumber As String)
        gbcmap.MapType = MapType.Terrain
        Dim dtClaim As New DataTable

        gbcmap.Markers.Clear()
        claimMarker.Markers.Clear()
        Dim daClaim As New daMap
        dtClaim = daClaim.getAssignedClaimbyClaimIdandAdjusterEmailId(Session("EmailId"), claimNumber)


        For Each row As DataRow In dtClaim.Rows
            Dim address As String
            Dim title As String
            address = row.Item("Address")
            Dim claimNo = row.Item("Claim #").ToString
            title = "Claim #: " + claimNo + "/ " + "Insured: " + row.Item("Insured Name")
            Dim insured = row.Item("Insured Name")
            Dim Info = "<b> Claim #: </b> " + claimNo + "<br>" +
             "<b>Insured: </b>" + insured + "<br>" +
             "<b> Address: </b>" + address

            claimMarker.Markers.Add(New Artem.Google.UI.Marker() With
                                    {.Position = New LatLng(row.Item("Latitude"),
                                    row.Item("Longitude")), .Title = title, .Info = Info})

            Dim ll As New LatLng
            ll.Latitude = row.Item("Latitude")
            ll.Longitude = row.Item("Longitude")
            gbcmap.Center = ll
            With claimMarker
                .MarkerOptions.Draggable = False
                .MarkerOptions.Clickable = True
                .MarkerOptions.Animation = MarkerAnimation.Drop
            End With
        Next

    End Sub



    'Get Direction
    Protected Sub getDirection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles getDirection.Click
        Dim isValidateError As Boolean = False

        Dim dir As New GoogleDirections
        Dim startpt As New Location
        Dim waypt As New Location
        Dim endpt As New Location
        'startpt.Address = ddClaim1.Text
        'endpt.Address = ddClaim2.Text


        If ddclaim1.SelectedIndex = 0 And startClaimText.Text = String.Empty Then
            isValidateError = True
        End If

        If ddclaim2.SelectedIndex = 0 Then
            isValidateError = True
        End If

        If isValidateError = True Then

        Else
            gbcmap.Markers.Clear()
            claimMarker.Markers.Clear()
            If startClaimText.Text = "" Then
                startpt.Address = ddclaim1.Text
            Else
                startpt.Address = startClaimText.Text
            End If

            endpt.Address = ddclaim2.Text

            waypt.Address = "900 downtowner blvd, mobile, al"
            If IsNothing(startpt.Address) Or IsNothing(endpt.Address) Then
                Return
            End If
            dir.Origin = startpt
            dir.OptimizeWaypoints = True
            'dir.SuppressInfoWindows = True
            dir.Draggable = True
            dir.Destination = endpt
            dir.HideRouteList = False
            dir.RouteIndex = 1
            dir.ProvideRouteAlternatives = True
            dir.PanelID = "dirpanel"
            gbcmap.Directions.Add(dir)
        End If

    End Sub

    Public Function AddressToLatLongGeocoder(ByVal address As String) As LatLng
        Dim wc As New WebClient
        Dim geocodeStream As Stream =
            wc.OpenRead("http://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&sensor=true")

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

    Protected Sub btnViewALL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewALL.Click
        populateMarkers()
    End Sub


    Protected Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If ddClaim.SelectedIndex = 0 Then

        Else
            filterMarkersbyClaimId(ddClaim.Text)
        End If

    End Sub








End Class