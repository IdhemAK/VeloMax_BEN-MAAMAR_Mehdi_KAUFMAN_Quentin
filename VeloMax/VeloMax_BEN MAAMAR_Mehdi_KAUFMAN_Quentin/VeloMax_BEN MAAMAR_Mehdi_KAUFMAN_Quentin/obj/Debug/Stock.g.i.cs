﻿#pragma checksum "..\..\Stock.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "164016413E91B7BC9816DAAFD31430D2700CD181775AD7D79CEC8D92AFB3D193"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin;


namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin {
    
    
    /// <summary>
    /// Stock
    /// </summary>
    public partial class Stock : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 123 "..\..\Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mainDataGrid;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\Stock.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid manqueStock;
        
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
            System.Uri resourceLocater = new System.Uri("/VeloMax_BEN MAAMAR_Mehdi_KAUFMAN_Quentin;component/stock.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Stock.xaml"
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
            
            #line 28 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.stock_Piece);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.trieVeloCleUnitaire);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.trieVeloParTaille);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 69 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.trieVeloParModele);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 82 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.trieVeloParLigneProduit);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 95 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.stock_Velo);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 107 "..\..\Stock.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.commander);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mainDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.manqueStock = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

