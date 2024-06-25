<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652613/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T157516)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Classes.cs](./CS/PersistentRowState/Classes.cs) (VB: [Classes.vb](./VB/PersistentRowState/Classes.vb))
* [Data.cs](./CS/PersistentRowState/Data.cs) (VB: [Data.vb](./VB/PersistentRowState/Data.vb))
* **[MainWindow.xaml](./CS/PersistentRowState/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/PersistentRowState/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/PersistentRowState/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/PersistentRowState/MainWindow.xaml.vb))
<!-- default file list end -->
# How to resize rows in GridControl dynamically using a splitter


<p>To make the row height resizable, perform these steps:</p>
<p>1. Create a control class that describes the <strong>IResizeHelperOwner</strong> interface.</p>
<p>2. Create an attached RowHeight property, add it to this class and assign the property value to the RowData’s RowState property.</p>
<p>3. In GridControl’s view, create DataTemplate for the view’s DataRowTemplate property that contains ContentControl and the control that was created earlier. Add RowSplitter into the control’s template.</p>
<p>4. Bind ContentControl’s ContentTemplate property to the view’s DefaultDataRowTemplate to show data. Also, bind ContentControl’s height to the control’s RowHeight property to resize the row.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-resize-rows-in-gridcontrol-dynamically-using-a-splitter-t157516&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-resize-rows-in-gridcontrol-dynamically-using-a-splitter-t157516&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
