﻿#pragma checksum "..\..\PlayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "41B11F4BF0CBD00C97739AEF745E9CDAD71B83B6120C3983CCA28EA765CFF141"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using virus1;


namespace virus1 {
    
    
    /// <summary>
    /// PlayWindow
    /// </summary>
    public partial class PlayWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AttackLog;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartAttackButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DefenseOptions;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyDefenseButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimerText;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\PlayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar AttackProgressBar;
        
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
            System.Uri resourceLocater = new System.Uri("/virus1;component/playwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PlayWindow.xaml"
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
            this.AttackLog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.StartAttackButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\PlayWindow.xaml"
            this.StartAttackButton.Click += new System.Windows.RoutedEventHandler(this.StartAttack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DefenseOptions = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ApplyDefenseButton = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\PlayWindow.xaml"
            this.ApplyDefenseButton.Click += new System.Windows.RoutedEventHandler(this.ApplyDefense_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TimerText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.AttackProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 7:
            
            #line 91 "..\..\PlayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Nazad_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

