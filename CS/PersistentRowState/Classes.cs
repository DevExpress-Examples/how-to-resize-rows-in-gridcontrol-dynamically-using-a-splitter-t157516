using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Utils;

namespace PersistentRowState
{
    public class ResizableDataRow : Control , IResizeHelperOwner
    {
        public static readonly DependencyProperty RowHeightProperty = DependencyProperty.RegisterAttached(
            "RowHeight",
            typeof(double), typeof(ResizableDataRow),
            new PropertyMetadata(20d));

        static ResizableDataRow()
        {
            RowData.RowDataProperty.OverrideMetadata(typeof(ResizableDataRow), new FrameworkPropertyMetadata(OnScrollViewerVerticalOffsetChanged));
        }

        static void OnScrollViewerVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ResizableDataRow)d).OnRowDataChanged((RowData)e.OldValue, (RowData)e.NewValue);
        }

        public static void SetRowHeight(DependencyObject element, double value)
        {
            element.SetValue(RowHeightProperty, value);
        }

        public static double GetRowHeight(DependencyObject element)
        {
            return (double)element.GetValue(RowHeightProperty);
        }

        ResizeHelper resizeHelper;

        RowData RowData
        {
            get { return (RowData)DataContext; }
        }

        double RowHeight
        {
            get { return GetRowHeight(RowData.RowState); }
            set { SetRowHeight(RowData.RowState, value); }
        }

        public override void OnApplyTemplate()
        {
            resizeHelper = new ResizeHelper(this);
            base.OnApplyTemplate();
            Thumb resizer = (Thumb)GetTemplateChild("PART_Resizer");
            resizeHelper.Init(resizer);
            InitializeRowHeight();
        }
        void OnRowDataChanged(RowData oldValue, RowData newValue)
        {
            if (oldValue != null)
                oldValue.ContentChanged -= new EventHandler(RowData_ContentChanged);
            if (newValue != null)
            {
                newValue.ContentChanged += new EventHandler(RowData_ContentChanged);
                InitializeRowHeight();
            }
        }
        void RowData_ContentChanged(object sender, EventArgs e)
        {
            InitializeRowHeight();
        }
        void InitializeRowHeight()
        {
            if (RowHeight == 0)
                RowHeight = 20;
        }

        #region IResizeHelperOwner Members
        double IResizeHelperOwner.ActualSize { get { return RowHeight; } set { RowHeight = value; } }
        void IResizeHelperOwner.ChangeSize(double delta)
        {
            RowHeight = Math.Min(300, Math.Max(20, RowHeight + delta));
        }
        void IResizeHelperOwner.OnDoubleClick() { }
        void IResizeHelperOwner.SetIsResizing(bool isResizing) { }
        SizeHelperBase IResizeHelperOwner.SizeHelper { get { return VerticalSizeHelper.Instance; } }
        #endregion
    }

}
