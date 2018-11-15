<!-- default file list -->
*Files to look at*:

* [Classes.cs](./CS/PersistentRowState/Classes.cs) (VB: [Classes.vb](./VB/PersistentRowState/Classes.vb))
* [Data.cs](./CS/PersistentRowState/Data.cs) (VB: [Data.vb](./VB/PersistentRowState/Data.vb))
* **[MainWindow.xaml](./CS/PersistentRowState/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/PersistentRowState/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/PersistentRowState/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/PersistentRowState/MainWindow.xaml))
<!-- default file list end -->
# How to resize rows in GridControl dynamically using a splitter


<p>To make the row height resizable, perform these steps:</p>
<p>1. Create a control class that describes the <strong>IResizeHelperOwner</strong> interface.</p>
<p>2. Create an attached RowHeight property, add it to this class and assign the property value to the RowData’s RowState property.</p>
<p>3. In GridControl’s view, create DataTemplate for the view’s DataRowTemplate property that contains ContentControl and the control that was created earlier. Add RowSplitter into the control’s template.</p>
<p>4. Bind ContentControl’s ContentTemplate property to the view’s DefaultDataRowTemplate to show data. Also, bind ContentControl’s height to the control’s RowHeight property to resize the row.</p>

<br/>


