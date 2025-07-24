Imports System.Windows
Imports System.Windows.Controls

Namespace PersistentRowState

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.grid.ItemsSource = Data.GetDataList(100)
        End Sub
    End Class
End Namespace
