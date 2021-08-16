using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Statusbits.Controller;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.ExtendedExecution;


namespace Statusbits
{
  public sealed partial class MainPage : Page
  {
    private StatusbitsController controller;

    public MainPage()
    {
      try
      {
        controller = new StatusbitsController(64);
        this.DataContext = controller;

        this.InitializeComponent();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    private async void Clipboard_ContentChanged(object sender, object e)
    {
            //AppListEntry.LaunchAsync();
            //OnExtendedMode(null,null);
      var dataPackageView = Clipboard.GetContent();
      if (dataPackageView.Contains(StandardDataFormats.Text))
      {
        var value = await dataPackageView.GetTextAsync();

        controller.UpdateValues(value, ClipboardType.SelectionBoxItem.ToString(), ActiveBits.SelectedItems);
      }
    }

     /*async void OnExtendedMode(object sender, RoutedEventArgs e)
     {
        if (this.extendedExecutionSession == null){
            this.extendedExecutionSession = new ExtendedExecutionSession(){
                Reason = ExtendedExecutionReason.Unspecified, // Change!
                Description = "general playing around"
            };
            this.extendedExecutionSession.Revoked += OnExtensionRevoked;

            var result = await this.extendedExecutionSession.RequestExtensionAsync();

             if (result == ExtendedExecutionResult.Allowed){
                // We're running extended.
             }
             else{
                // We're not.
                this.OnUnextendedMode(null, null);
             }
        }
     }

     void OnExtensionRevoked(object sender, ExtendedExecutionRevokedEventArgs args){
        this.OnUnextendedMode(null, null);
     }
     void OnUnextendedMode(object sender, RoutedEventArgs e)
     {
        if (this.extendedExecutionSession != null){
            this.extendedExecutionSession.Dispose();
            this.extendedExecutionSession = null;
        }
     }

     ExtendedExecutionSession extendedExecutionSession;*/


        private void ClipboardType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Clipboard.ContentChanged -= Clipboard_ContentChanged;
      if (ClipboardType.SelectedItem.ToString() != "no")
      {
        Clipboard.ContentChanged += Clipboard_ContentChanged;
      }
    }

    private void DecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(DecimalTB.Text, "Decimal", ActiveBits.SelectedItems);
      }
    }

    private void SignedDecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits.SelectedItems);
      }
    }

    private void HexadecimalTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(HexadecimalTB.Text, "Hexadecimal", ActiveBits.SelectedItems);
      }
    }

    private void BinaryTB_OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key == VirtualKey.Enter)
      {
        controller.UpdateValues(BinaryTB.Text, "Binary", ActiveBits.SelectedItems);
      }
    }

    private void ActiveBits_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      controller.UpdateFromCheckboxes(ActiveBits.SelectedItems);
    }

    private void Bit64_OnChecked(object sender, RoutedEventArgs e)
    {
      controller.UpdateBits(64);
    }
    private void Bit32_OnChecked(object sender, RoutedEventArgs e)
    {
      controller.UpdateBits(32);
    }

    private void DecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(DecimalTB.Text, "Decimal", ActiveBits.SelectedItems);
    }

    private void SignedDecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits.SelectedItems);
    }

    private void HexadecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(HexadecimalTB.Text, "Hexadecimal", ActiveBits.SelectedItems);
    }

    private void BinaryTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(BinaryTB.Text, "Binary", ActiveBits.SelectedItems);
    }

    private void V1000_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("1000");
    }
    private void V820_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("820");
    }

    private void V810_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("810");
    }

    private void V800_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("800");
    }
    private void V760_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("760");
    }
    private void V750_OnClick(object sender, RoutedEventArgs e)
    {
      controller.UpdateStatusbitsFromVersion("750");
    }
  }
}
