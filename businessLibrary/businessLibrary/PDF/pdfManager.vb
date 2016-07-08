Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class pdfManager
    'Merge Pdf files
    Public Sub MergeFiles(ByVal destinationFile As String, ByVal arrayFiles As ArrayList)
        'Note: The merging is based on the list of the files path

        'To change the order of files to be merged
        'The order in which the files is inserted into the list need to be changed in the <Array List>.

        ' Create a Document object 
        'Size A4
        'margin: 50,50,25,25
        Dim document = New Document(PageSize.LETTER, 50, 50, 25, 25)

        ' Create a new PdfWrite object, writing the output to a MemoryStream
        Dim output = New MemoryStream()

        'Create the file
        Dim writer = PdfWriter.GetInstance(document, New FileStream(destinationFile, FileMode.Create))

        'Open the document
        document.Open()


        Try
            'First index of the file is 0
            Dim f As Integer = 0

            'Create the reader: read the first document 
            Dim reader As New PdfReader(arrayFiles.Item(f).ToString)

            'Retrieve total # of pages in the document
            Dim n As Integer = reader.NumberOfPages

            'Read the content of the document
            Dim cb As PdfContentByte = writer.DirectContent

            'Create new page
            Dim page As PdfImportedPage

            'Rotation: LandScape/portrait
            Dim rotation As Integer

            'Add the content
            'While the document count is less than the list provided
            While f < arrayFiles.Count

                Dim i As Integer = 0
                'Page number 
                While i < n
                    i += 1
                    document.SetPageSize(reader.GetPageSizeWithRotation(i))
                    'create new page
                    document.NewPage()
                    'Insert page 
                    page = writer.GetImportedPage(reader, i)
                    'rotate the page
                    rotation = reader.GetPageRotation(i)
                    If rotation = 90 OrElse rotation = 270 Then
                        cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0,
                         reader.GetPageSizeWithRotation(i).Height)
                    Else
                        cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0,
                         0)
                    End If
                End While
                f += 1
                'Check the document count
                If f < arrayFiles.Count Then
                    'if next document exist read
                    reader = New PdfReader(arrayFiles.Item(f).ToString)
                    'Retreive number of pages
                    n = reader.NumberOfPages
                End If

            End While
            'Close the document
            document.Close()
        Catch ex As Exception
            Dim strOb As String = ex.Message
        End Try

    End Sub

    'Page Number
    Public Function CountPageNo(ByVal strFileName As String) As Integer
        'Read the file from the given path
        Dim reader As New PdfReader(strFileName)

        ' Retrieve total number of pages
        Return reader.NumberOfPages
    End Function
End Class
