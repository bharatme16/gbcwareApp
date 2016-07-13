Imports System.IO

Public Class crossCountryFiles
    Inherits System.Web.UI.Page
#Region "Properties"

    Private Property filepath As String
        Get
            If IsNothing(ViewState("filepath")) Then

                ViewState("filepath") = Request.QueryString("filepath")

            End If
            Return CInt(ViewState("claimID"))
        End Get
        Set(value As String)
            ViewState("filepath") = value
        End Set
    End Property

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim spath As String = filepath
        If spath = "No files" Then
            '   lblFileNotFound.Text = "No File Found."
        Else

            Dim fullpath = Path.GetFullPath(Server.MapPath(spath))
            Dim name = Path.GetFileName(fullpath)
            Dim ext = Path.GetExtension(fullpath)
            Dim type As String = ""
            If Not IsDBNull(ext) Then
                ext = LCase(ext)
            End If

            Select Case ext
                Case ".htm", ".html"
                    type = "text/HTML"
                Case ".txt"
                    type = "text/plain"
                Case ".doc", ".rtf"
                    type = "Application/msword"
                Case ".csv", ".xls"
                    type = "Application/x-msexcel"
                Case ".pdf"
                    type = "Application/pdf"
                Case Else
                    type = "text/plain"
            End Select

            'For Pdf Files
            If type = "Application/pdf" Then
                Response.ContentType = type
                Response.Flush()
                Response.WriteFile(Server.MapPath(spath))
                Response.[End]()
                Session("path") = Nothing

                'For other Files
            Else
                Response.ContentType = "application/octet-stream"
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + name)
                Response.TransmitFile(Server.MapPath(spath))
                Response.[End]()
                Session("path") = Nothing
            End If
        End If
    End Sub

End Class