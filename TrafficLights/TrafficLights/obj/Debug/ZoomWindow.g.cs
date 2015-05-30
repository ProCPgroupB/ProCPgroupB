﻿#pragma checksum "..\..\ZoomWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "788BCBE06D6F8F1C5CE6125BAEB3B28B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace TrafficLights {
    
    
    /// <summary>
    /// ZoomWindow
    /// </summary>
    public partial class ZoomWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mapCanvas;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNorth;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSouth;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWest;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEast;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PART_CLOSE;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTitle;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ZoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbLane;
        
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
            System.Uri resourceLocater = new System.Uri("/TrafficLights;component/zoomwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ZoomWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.mapCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.btnNorth = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\ZoomWindow.xaml"
            this.btnNorth.Click += new System.Windows.RoutedEventHandler(this.btnNorth_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSouth = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\ZoomWindow.xaml"
            this.btnSouth.Click += new System.Windows.RoutedEventHandler(this.btnSouth_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnWest = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ZoomWindow.xaml"
            this.btnWest.Click += new System.Windows.RoutedEventHandler(this.btnWest_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnEast = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ZoomWindow.xaml"
            this.btnEast.Click += new System.Windows.RoutedEventHandler(this.btnEast_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\ZoomWindow.xaml"
            ((System.Windows.Controls.DockPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ZoomWindow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PART_CLOSE = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\ZoomWindow.xaml"
            this.PART_CLOSE.Click += new System.Windows.RoutedEventHandler(this.closeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 67 "..\..\ZoomWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ZoomWindow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tbLane = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

