﻿#pragma checksum "C:\Users\Sergius\documents\visual studio 2012\Projects\ScheduleBsuir\ScheduleBsuir\WelcomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C597BBE02EC075D537B735181AA5748F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ScheduleBsuir {
    
    
    public partial class WelcomePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Shell.ProgressIndicator progressBar;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox inputText;
        
        internal System.Windows.Controls.Button okButton;
        
        internal System.Windows.Controls.Button cancelButton;
        
        internal System.Windows.Controls.ListBox ScheduleList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ScheduleBsuir;component/WelcomePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.progressBar = ((Microsoft.Phone.Shell.ProgressIndicator)(this.FindName("progressBar")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.inputText = ((System.Windows.Controls.TextBox)(this.FindName("inputText")));
            this.okButton = ((System.Windows.Controls.Button)(this.FindName("okButton")));
            this.cancelButton = ((System.Windows.Controls.Button)(this.FindName("cancelButton")));
            this.ScheduleList = ((System.Windows.Controls.ListBox)(this.FindName("ScheduleList")));
        }
    }
}

