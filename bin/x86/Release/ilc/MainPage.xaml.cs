using System;
using System.Runtime.InteropServices;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Statusbits.Controller;
using Windows.ApplicationModel.DataTransfer;


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
      var dataPackageView = Clipboard.GetContent();
      if (dataPackageView.Contains(StandardDataFormats.Text))
      {
        var value = await dataPackageView.GetTextAsync();

        controller.UpdateValues(value, ClipboardType.SelectionBoxItem.ToString(), ActiveBits.SelectedItems);
      }
    }


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
