﻿#pragma checksum "C:\Users\Primo Babi\Documents\GitHub\Avtomehanik\App1\Nalog\Dodaj_Nalog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7F560A1F2820F072C8B14F51D344CD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1.Nalog
{
    partial class Dodaj_Nalog : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.textBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 13 "..\..\..\Nalog\Dodaj_Nalog.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button).Click += this.DodajNalog;
                    #line default
                }
                break;
            case 4:
                {
                    this.textBlock1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.textBlock3 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.textBlock2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.textBox1 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.textBox2 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.textBox3 = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.button1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\Nalog\Dodaj_Nalog.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button1).Click += this.DodajOpravilo;
                    #line default
                }
                break;
            case 11:
                {
                    this.gridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 12:
                {
                    this.textBlock4 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.textBlock5 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14:
                {
                    this.textBlock6 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.textBlock7 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16:
                {
                    this.button2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 48 "..\..\..\Nalog\Dodaj_Nalog.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button2).Click += this.button2_Click;
                    #line default
                }
                break;
            case 17:
                {
                    global::Windows.UI.Xaml.Controls.Button element17 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\Nalog\Dodaj_Nalog.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element17).Click += this.IzbrisiOpravilo;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

