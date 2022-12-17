Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid

Namespace PersistentRowState

    Public Class ResizableDataRow
        Inherits Control
        Implements IResizeHelperOwner

        Public Shared ReadOnly RowHeightProperty As DependencyProperty = DependencyProperty.RegisterAttached("RowHeight", GetType(Double), GetType(ResizableDataRow), New PropertyMetadata(20R))

        Shared Sub New()
            Call RowData.RowDataProperty.OverrideMetadata(GetType(ResizableDataRow), New FrameworkPropertyMetadata(AddressOf OnScrollViewerVerticalOffsetChanged))
        End Sub

        Private Shared Sub OnScrollViewerVerticalOffsetChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            CType(d, ResizableDataRow).OnRowDataChanged(CType(e.OldValue, RowData), CType(e.NewValue, RowData))
        End Sub

        Public Shared Sub SetRowHeight(ByVal element As DependencyObject, ByVal value As Double)
            element.SetValue(RowHeightProperty, value)
        End Sub

        Public Shared Function GetRowHeight(ByVal element As DependencyObject) As Double
            Return CDbl(element.GetValue(RowHeightProperty))
        End Function

        Private resizeHelper As ResizeHelper

        Private ReadOnly Property RowData As RowData
            Get
                Return CType(DataContext, RowData)
            End Get
        End Property

        Private Property RowHeight As Double
            Get
                Return GetRowHeight(RowData.RowState)
            End Get

            Set(ByVal value As Double)
                SetRowHeight(RowData.RowState, value)
            End Set
        End Property

        Public Overrides Sub OnApplyTemplate()
            resizeHelper = New ResizeHelper(Me)
            MyBase.OnApplyTemplate()
            Dim resizer As Thumb = CType(GetTemplateChild("PART_Resizer"), Thumb)
            resizeHelper.Init(resizer)
            InitializeRowHeight()
        End Sub

        Private Sub OnRowDataChanged(ByVal oldValue As RowData, ByVal newValue As RowData)
            If oldValue IsNot Nothing Then RemoveHandler oldValue.ContentChanged, New EventHandler(AddressOf RowData_ContentChanged)
            If newValue IsNot Nothing Then
                AddHandler newValue.ContentChanged, New EventHandler(AddressOf RowData_ContentChanged)
                InitializeRowHeight()
            End If
        End Sub

        Private Sub RowData_ContentChanged(ByVal sender As Object, ByVal e As EventArgs)
            InitializeRowHeight()
        End Sub

        Private Sub InitializeRowHeight()
            If RowHeight = 0 Then RowHeight = 20
        End Sub

'#Region "IResizeHelperOwner Members"
        Private Property ActualSize As Double Implements IResizeHelperOwner.ActualSize
            Get
                Return RowHeight
            End Get

            Set(ByVal value As Double)
                RowHeight = value
            End Set
        End Property

        Private Sub ChangeSize(ByVal delta As Double) Implements IResizeHelperOwner.ChangeSize
            RowHeight = Math.Min(300, Math.Max(20, RowHeight + delta))
        End Sub

        Private Sub OnDoubleClick() Implements IResizeHelperOwner.OnDoubleClick
        End Sub

        Private Sub SetIsResizing(ByVal isResizing As Boolean) Implements IResizeHelperOwner.SetIsResizing
        End Sub

        Private ReadOnly Property SizeHelper As SizeHelperBase Implements IResizeHelperOwner.SizeHelper
            Get
                Return VerticalSizeHelper.Instance
            End Get
        End Property
'#End Region
    End Class
End Namespace
