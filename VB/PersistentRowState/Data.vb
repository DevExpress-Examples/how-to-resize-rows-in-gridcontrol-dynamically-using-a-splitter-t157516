Imports System
Imports System.Collections.Generic

Namespace PersistentRowState

    Public Class Data

        Public Shared Function GetDataList(ByVal itemsCount As Integer) As List(Of Product)
            Dim list As List(Of Product) = New List(Of Product)()
            For i As Integer = 0 To itemsCount - 1
                list.Add(New Product() With {.Name = "Product" & i, .Description = "Description " & i, .Price = Convert.ToDecimal(i * 5 + 10)})
            Next

            Return list
        End Function
    End Class

    Public Class Product

        Public Property Name As String

        Public Property Description As String

        Public Property Price As Decimal
    End Class
End Namespace
