﻿#pragma checksum "..\..\..\Views\MapPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ECEADFDF82F6C64E48DB2E711009B027"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.ViewModels;
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


namespace Przewodnik.Views {
    
    
    /// <summary>
    /// MapPage
    /// </summary>
    public partial class MapPage : System.Windows.Controls.Grid, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Przewodnik.Views.MapPage MapPageGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MapGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer CategoryScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_centrum;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_atrakcje;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_koscioly;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_kina;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_hotele;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_zakupy;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_muzea;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_parki;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_teatry;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_transport;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton B_urzedy;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map MasterBingMap;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image InteractioIcoZoom;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image InteractioIcoZoomPlus;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image InteractioIcoZoomMinus;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Views\MapPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image InteractioIcoMove;
        
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
            System.Uri resourceLocater = new System.Uri("/Przewodnik;component/views/mappage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MapPage.xaml"
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
            this.MapPageGrid = ((Przewodnik.Views.MapPage)(target));
            return;
            case 2:
            this.MapGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.CategoryScrollViewer = ((Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer)(target));
            return;
            case 4:
            this.B_centrum = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 22 "..\..\..\Views\MapPage.xaml"
            this.B_centrum.Click += new System.Windows.RoutedEventHandler(this.home_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.B_atrakcje = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 33 "..\..\..\Views\MapPage.xaml"
            this.B_atrakcje.Click += new System.Windows.RoutedEventHandler(this.atrakcje_turystyczne_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.B_koscioly = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 44 "..\..\..\Views\MapPage.xaml"
            this.B_koscioly.Click += new System.Windows.RoutedEventHandler(this.koscioly_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.B_kina = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 56 "..\..\..\Views\MapPage.xaml"
            this.B_kina.Click += new System.Windows.RoutedEventHandler(this.kina_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.B_hotele = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 66 "..\..\..\Views\MapPage.xaml"
            this.B_hotele.Click += new System.Windows.RoutedEventHandler(this.hotele_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.B_zakupy = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 76 "..\..\..\Views\MapPage.xaml"
            this.B_zakupy.Click += new System.Windows.RoutedEventHandler(this.centra_handlowe_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.B_muzea = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 86 "..\..\..\Views\MapPage.xaml"
            this.B_muzea.Click += new System.Windows.RoutedEventHandler(this.muzea_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.B_parki = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 96 "..\..\..\Views\MapPage.xaml"
            this.B_parki.Click += new System.Windows.RoutedEventHandler(this.parki_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.B_teatry = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 106 "..\..\..\Views\MapPage.xaml"
            this.B_teatry.Click += new System.Windows.RoutedEventHandler(this.teatry_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.B_transport = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 116 "..\..\..\Views\MapPage.xaml"
            this.B_transport.Click += new System.Windows.RoutedEventHandler(this.transport_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.B_urzedy = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 126 "..\..\..\Views\MapPage.xaml"
            this.B_urzedy.Click += new System.Windows.RoutedEventHandler(this.urzedy_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.MasterBingMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            case 16:
            this.InteractioIcoZoom = ((System.Windows.Controls.Image)(target));
            return;
            case 17:
            this.InteractioIcoZoomPlus = ((System.Windows.Controls.Image)(target));
            return;
            case 18:
            this.InteractioIcoZoomMinus = ((System.Windows.Controls.Image)(target));
            return;
            case 19:
            this.InteractioIcoMove = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

