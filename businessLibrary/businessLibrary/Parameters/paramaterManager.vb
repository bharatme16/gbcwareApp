Public Class paramaterManager


    'Get invoice number
    Public Function GenerateInvoiceNumber(ByVal claimNumber As String, ByVal revLetter As String) As String
        Dim newInvoiceNumber As String
        Dim revisionLetter As String
        If revLetter = "-" Then
            revisionLetter = "A"
        Else
            revisionLetter = characterAutoIncrement(revLetter)
        End If
        newInvoiceNumber = Trim(claimNumber + "-(" + revisionLetter + ")")

        Return newInvoiceNumber

    End Function

    'Increment auto increment
    Public Function characterAutoIncrement(ByVal thisletter As Char) As Char
        Dim nextletter As String = Chr(Asc(thisletter) + 1)
        Return nextletter
    End Function

End Class
