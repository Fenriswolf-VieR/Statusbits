using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Statusbits.Controller;
using Statusbits.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Statusbits
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StatusbitsView View;

        private string Decimal = "0";
        private string SignedDecimal = "0";
        private string Binary = "0";
        private string Hexadecimal = "0";

        private List<string> clipBoardOptions;
        private List<string> statusBits;


        public MainPage()
        {

            View = new StatusbitsView(this);

            this.InitializeComponent();

            clipBoardOptions = View.GetClipboardTypeList();
            statusBits = View.GetStatusBitsList();
        }


        private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                View.UpdateFromDecimal(DecimalTB.Text);
            }
        }

        private void SignedDecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                View.UpdateFromSignedDecimal(SignedDecimalTB.Text);
            }
        }

        private void HexadecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                View.UpdateFromHexadecimal(HexadecimalTB.Text);
            }
        }

        private void BinaryTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                View.UpdateFromBinary(BinaryTB.Text);
            }
        }

        public void UpdateValues(string decimalValue, string signedDecimal, string hexadecimal, string binary)
        {
            DecimalTB.Text = decimalValue;
            SignedDecimalTB.Text = signedDecimal;
            HexadecimalTB.Text = hexadecimal;
            BinaryTB.Text = binary;
        }
    }
}
