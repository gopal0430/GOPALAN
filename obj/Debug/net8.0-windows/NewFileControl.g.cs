﻿#pragma checksum "..\..\..\NewFileControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21C3DA328D09D020BCB619985E11842E96EDD2F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MyWpfApp {
    
    
    /// <summary>
    /// NewFileControl
    /// </summary>
    public partial class NewFileControl : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProductTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RateTextBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RateComboBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SeparateRowsCheckBox;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox masalaComboBox;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductsDataList;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PName;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PNameNative;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\..\NewFileControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GrandTotalTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyWpfApp;component/newfilecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewFileControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\NewFileControl.xaml"
            this.ProductTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ProductTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.RateComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\NewFileControl.xaml"
            this.RateComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RateComboBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 85 "..\..\..\NewFileControl.xaml"
            this.RateComboBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.RateComboBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.QuantityTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\NewFileControl.xaml"
            this.QuantityTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.QtyTxtBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SeparateRowsCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.masalaComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 117 "..\..\..\NewFileControl.xaml"
            this.masalaComboBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.masalaComboBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProductsDataList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 142 "..\..\..\NewFileControl.xaml"
            this.ProductsDataList.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.ProductsDataList_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.ProductsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 166 "..\..\..\NewFileControl.xaml"
            this.ProductsDataGrid.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.ProductsDataGrid_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PNameNative = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.GrandTotalTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

