﻿#pragma checksum "..\..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CCBB60BE5D32A7BAB5F7EF7CA6F1B10183C853FB0DD136331BDAE00B0333D95B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CefSharp.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp2.MainWindow _MainWindow;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition row1;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabCtrl;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp2.UrlBar urlBar;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Back;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Forward;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Home;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _NewTbBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this._MainWindow = ((WpfApp2.MainWindow)(target));
            
            #line 10 "..\..\..\MainWindow.xaml"
            this._MainWindow.StateChanged += new System.EventHandler(this._MainWindow_StateChanged);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\MainWindow.xaml"
            this._MainWindow.Loaded += new System.Windows.RoutedEventHandler(this._MainWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.row1 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.tabCtrl = ((System.Windows.Controls.TabControl)(target));
            
            #line 127 "..\..\..\MainWindow.xaml"
            this.tabCtrl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tabCtrl_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 127 "..\..\..\MainWindow.xaml"
            this.tabCtrl.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.tabCtrl_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 128 "..\..\..\MainWindow.xaml"
            this.tabCtrl.MouseMove += new System.Windows.Input.MouseEventHandler(this.tabCtrl_MouseMove);
            
            #line default
            #line hidden
            
            #line 128 "..\..\..\MainWindow.xaml"
            this.tabCtrl.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.tabCtrl_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.urlBar = ((WpfApp2.UrlBar)(target));
            return;
            case 6:
            this.btn_Back = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\..\MainWindow.xaml"
            this.btn_Back.Click += new System.Windows.RoutedEventHandler(this.btn_Back_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Forward = ((System.Windows.Controls.Button)(target));
            
            #line 182 "..\..\..\MainWindow.xaml"
            this.btn_Forward.Click += new System.Windows.RoutedEventHandler(this.btn_Forward_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Home = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\MainWindow.xaml"
            this.btn_Home.Click += new System.Windows.RoutedEventHandler(this.btn_Home_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this._NewTbBtn = ((System.Windows.Controls.Button)(target));
            
            #line 207 "..\..\..\MainWindow.xaml"
            this._NewTbBtn.Click += new System.Windows.RoutedEventHandler(this._NewTbBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
