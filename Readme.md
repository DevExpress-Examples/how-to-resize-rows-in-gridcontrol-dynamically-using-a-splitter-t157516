<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652613/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T157516)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid – Resize Row Height

This example implements resizable rows in a DevExpress WPF [Grid](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). Users can interactively change the height of individual grid rows (similar to the way columns are resized) and retain these changes for a consistent user experience.

![Resize Row Height with a Splitter](./Images/resize-row-height.gif)

## Implementation Details

### Create a Resizable Control

The `ResizableDataRow` control implements the `IResizeHelperOwner` interface to work with `ResizeHelper`. The control stores the current row height in the `RowHeight` property and updates this value when the splitter moves.

```csharp
public class ResizableDataRow : Control, IResizeHelperOwner {
    public static readonly DependencyProperty RowHeightProperty =
        DependencyProperty.RegisterAttached("RowHeight", typeof(double), typeof(ResizableDataRow), new PropertyMetadata(20d));

    double IResizeHelperOwner.ActualSize { get => RowHeight; set => RowHeight = value; }
    void IResizeHelperOwner.ChangeSize(double delta) {
        RowHeight = Math.Min(300, Math.Max(20, RowHeight + delta));
    }
    // ...
}
```

### Persist Row Height with an Attached Property

The `RowHeight` attached property stores the height value in the `RowState` property. The grid uses this value to restore the row height after scrolling or refreshing. The `ResizableDataRow` control gets and sets the row height through the `RowState` property:

```csharp
public static void SetRowHeight(DependencyObject element, double value) {
    element.SetValue(RowHeightProperty, value);
}

public static double GetRowHeight(DependencyObject element) {
    return (double)element.GetValue(RowHeightProperty);
}
```

### Define a Row Template

The template assigned to the [`DataRowTemplate`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.DataRowTemplate) property defines a `ContentControl` that displays the default row content and a `ResizableDataRow` control with a `RowSplitter` to change the row height:

```xaml
<DataTemplate x:Key="PersistentRowStateDataRowTemplate">
    <StackPanel Orientation="Vertical">
        <dx:MeasurePixelSnapper>
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>
                <ContentControl Content="{Binding}"
                                ContentTemplate="{Binding Path=View.DefaultDataRowTemplate}"
                                Height="{Binding Path=RowState.(local:ResizableDataRow.RowHeight)}" />
            </Grid>
        </dx:MeasurePixelSnapper>
        <local:ResizableDataRow>
            <local:ResizableDataRow.Template>
                <ControlTemplate>
                    <dxg:RowSplitter Name="PART_Resizer"
                                     Grid.Row="1"
                                     Cursor="SizeNS"
                                     Height="1" />
                </ControlTemplate>
            </local:ResizableDataRow.Template>
        </local:ResizableDataRow>
    </StackPanel>
</DataTemplate>
```

## Files to Review

* [MainWindow.xaml](./CS/PersistentRowState/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/PersistentRowState/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/PersistentRowState/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/PersistentRowState/MainWindow.xaml.vb))
* [Classes.cs](./CS/PersistentRowState/Classes.cs) (VB: [Classes.vb](./VB/PersistentRowState/Classes.vb))
* [Data.cs](./CS/PersistentRowState/Data.cs) (VB: [Data.vb](./VB/PersistentRowState/Data.vb))

## Documentation

* [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl)
* [RowData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.RowData)
* [RowState](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.RowData.RowState)
* [DataRowTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.DataRowTemplate)
* [DefaultDataRowTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.DefaultDataRowTemplate)

## More Examples

* [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/wpf-data-grid-implement-crud-operations)
* [WPF Data Grid – Handle Drag and Drop Operations](https://github.com/DevExpress-Examples/wpf-grid-handle-drag-and-drop)
* [WPF Data Grid – Specify Custom Content for Column Chooser Headers](https://github.com/DevExpress-Examples/wpf-data-grid-custom-content-for-column-chooser-headers)
* [WPF Data Grid – Bind to Dynamic Data](https://github.com/DevExpress-Examples/wpf-bind-gridcontrol-to-dynamic-data)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-resize-rows-using-splitter&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-grid-resize-rows-using-splitter&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
