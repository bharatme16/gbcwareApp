Imports Microsoft.VisualBasic
Imports System.Web
Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net.Mail
Imports System.Data
Imports System.Net
'Imports iTextSharp.text.pdf
Imports System.Collections.Generic
Imports System.Linq
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports iTextSharp.text
'Imports Artem.Google.UI
'Imports net.symbility.www
'Imports CrossCountryDataAccess

Public Class mapManager
    'Get latitude and longitude by Address
    'Public Function AddressToLatLongGeocoder(ByVal address As String) As LatLng
    '    Dim wc As New WebClient
    '    Dim geocodeStream As Stream =
    '        wc.OpenRead("http://maps.googleapis.com/maps/api/geocode/xml?address=" & address & "&sensor=true")
    '    Dim latArray As New ArrayList
    '    Dim longArray As New ArrayList
    '    Dim xr As New XmlTextReader(geocodeStream)

    '    Try
    '        Dim ll As New LatLng
    '        While xr.Read()
    '            If xr.Name = "lat" Then
    '                latArray.Add(xr.ReadInnerXml)
    '                ' ll.Latitude = CDbl(xr.ReadInnerXml)
    '            End If
    '            If xr.Name = "lng" Then
    '                longArray.Add(xr.ReadInnerXml)
    '                '  ll.Longitude = CDbl(xr.ReadInnerXml)
    '            End If
    '        End While
    '        ll.Latitude = CDbl(latArray(0))
    '        ll.Longitude = CDbl(longArray(0))
    '        wc.Dispose()
    '        Return ll
    '    Catch
    '        Return Nothing
    '    End Try

    'End Function

    ''Get full address by latitude and longitude
    'Public Function latLongToZipCodeGeocoder(ByVal latitude As String, ByVal longitude As String) As String
    '    Dim geoCoderRequest As HttpWebRequest = Nothing
    '    Dim geoCoderResponse As HttpWebResponse = Nothing
    '    Dim geoCoderReader As StreamReader = Nothing
    '    Dim readAddress As String = Nothing
    '    Dim fullAddress As String = ""
    '    Try
    '        geoCoderRequest = DirectCast(WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&sensor=false"), HttpWebRequest)
    '        geoCoderResponse = DirectCast(geoCoderRequest.GetResponse(), HttpWebResponse)
    '        geoCoderReader = New StreamReader(geoCoderResponse.GetResponseStream())
    '        readAddress = geoCoderReader.ReadToEnd()
    '        geoCoderResponse.Close()
    '        If readAddress.Contains("ZERO_RESULTS") Then
    '            'Do nothing
    '        End If
    '        If readAddress.Contains("formatted_address") Then
    '            Dim start As Integer = readAddress.IndexOf("formatted_address") + 1
    '            Dim endIndex As Integer = readAddress.IndexOf(", USA")
    '            Dim AddStart As String = readAddress.Substring(start + 21)
    '            Dim EndStart As String = readAddress.Substring(endIndex)
    '            fullAddress = AddStart.Replace(EndStart, "")
    '        End If
    '    Catch ex As Exception
    '        Dim Message As String = "Error: " + ex.ToString()
    '    Finally
    '        If (geoCoderResponse IsNot Nothing) Then
    '            geoCoderResponse.Close()
    '        End If
    '    End Try
    '    Return fullAddress
    'End Function
End Class
