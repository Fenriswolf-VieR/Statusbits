﻿#pragma checksum "C:\Users\Rene.Viehhauser\Source\Repos\Statusbits\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "939C04FE398246338242F899AE641F31"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Statusbits
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 147
                {
                    this.ActiveBits8 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits8).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits8).ContainerContentChanging += this.ActiveBits8_ContainerContentChanging;
                }
                break;
            case 3: // MainPage.xaml line 169
                {
                    this.ActiveBits7 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits7).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits7).ContainerContentChanging += this.ActiveBits7_ContainerContentChanging;
                }
                break;
            case 4: // MainPage.xaml line 191
                {
                    this.ActiveBits6 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits6).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits6).ContainerContentChanging += this.ActiveBits6_ContainerContentChanging;
                }
                break;
            case 5: // MainPage.xaml line 214
                {
                    this.ActiveBits5 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits5).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits5).ContainerContentChanging += this.ActiveBits5_ContainerContentChanging;
                }
                break;
            case 6: // MainPage.xaml line 237
                {
                    this.ActiveBits4 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits4).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits4).ContainerContentChanging += this.ActiveBits4_ContainerContentChanging;
                }
                break;
            case 7: // MainPage.xaml line 260
                {
                    this.ActiveBits3 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits3).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits3).ContainerContentChanging += this.ActiveBits3_ContainerContentChanging;
                }
                break;
            case 8: // MainPage.xaml line 283
                {
                    this.ActiveBits2 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits2).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits2).ContainerContentChanging += this.ActiveBits2_ContainerContentChanging;
                }
                break;
            case 9: // MainPage.xaml line 306
                {
                    this.ActiveBits1 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits1).SelectionChanged += this.ActiveBits_OnSelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ActiveBits1).ContainerContentChanging += this.ActiveBits1_ContainerContentChanging;
                }
                break;
            case 10: // MainPage.xaml line 55
                {
                    this.DecimalTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.DecimalTB).KeyDown += this.DecimalTB_OnKeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.DecimalTB).LostFocus += this.DecimalTB_OnLostFocus;
                }
                break;
            case 11: // MainPage.xaml line 67
                {
                    this.SignedDecimalTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.SignedDecimalTB).KeyDown += this.SignedDecimalTB_OnKeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.SignedDecimalTB).LostFocus += this.SignedDecimalTB_OnLostFocus;
                }
                break;
            case 12: // MainPage.xaml line 82
                {
                    this.HexadecimalTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.HexadecimalTB).KeyDown += this.HexadecimalTB_OnKeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.HexadecimalTB).LostFocus += this.HexadecimalTB_OnLostFocus;
                }
                break;
            case 13: // MainPage.xaml line 96
                {
                    this.BinaryTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.BinaryTB).KeyDown += this.BinaryTB_OnKeyDown;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.BinaryTB).LostFocus += this.BinaryTB_OnLostFocus;
                }
                break;
            case 14: // MainPage.xaml line 111
                {
                    this.CotValue = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // MainPage.xaml line 122
                {
                    this.CotMessage = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // MainPage.xaml line 132
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // MainPage.xaml line 28
                {
                    this.ClipboardType = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.ClipboardType).SelectionChanged += this.ClipboardType_OnSelectionChanged;
                }
                break;
            case 18: // MainPage.xaml line 36
                {
                    this.Bit64 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.Bit64).Checked += this.Bit64_OnChecked;
                }
                break;
            case 19: // MainPage.xaml line 37
                {
                    this.Bit32 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.Bit32).Checked += this.Bit32_OnChecked;
                }
                break;
            case 20: // MainPage.xaml line 18
                {
                    this.v1000 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v1000).Click += this.V1000_OnClick;
                }
                break;
            case 21: // MainPage.xaml line 19
                {
                    this.v820 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v820).Click += this.V820_OnClick;
                }
                break;
            case 22: // MainPage.xaml line 20
                {
                    this.v810 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v810).Click += this.V810_OnClick;
                }
                break;
            case 23: // MainPage.xaml line 21
                {
                    this.v800 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v800).Click += this.V800_OnClick;
                }
                break;
            case 24: // MainPage.xaml line 22
                {
                    this.v760 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v760).Click += this.V760_OnClick;
                }
                break;
            case 25: // MainPage.xaml line 23
                {
                    this.v750 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.v750).Click += this.V750_OnClick;
                }
                break;
            case 26: // MainPage.xaml line 14
                {
                    this.en = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.en).Click += this.en_OnClick;
                }
                break;
            case 27: // MainPage.xaml line 15
                {
                    this.de = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.de).Click += this.de_OnClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

