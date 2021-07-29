using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Statusbits.Controller;
using WK.Libraries.SharpClipboardNS;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Statusbits
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    private StatusbitsController controller;

    //private SharpClipboard clipBoard;

    public MainPage()
    {

      this.InitializeComponent();

      controller = new StatusbitsController(64);

      this.DataContext = controller;

      //clipBoard = new SharpClipboard();
      //clipBoard.ObservableFormats.Texts = true;
      //clipBoard.ClipboardChanged += ClipboardChanged;
    }

    //private void ClipboardChanged(Object sender, SharpClipboard.ClipboardChangedEventArgs e)
    //{
    //  if (e.ContentType == SharpClipboard.ContentTypes.Text)
    //  {
    //    DecimalTB.Text = clipBoard.ClipboardText;
    //  }
    //}

    private void TypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
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
        controller.UpdateValues(HexadecimalTB.Text, "Hex", ActiveBits.SelectedItems);
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
      controller = new StatusbitsController(64);

      this.DataContext = controller;
    }
    private void Bit32_OnChecked(object sender, RoutedEventArgs e)
    {
      controller = new StatusbitsController(32);

      this.DataContext = controller;
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
      controller.UpdateValues(HexadecimalTB.Text, "Hex", ActiveBits.SelectedItems);
    }

    private void BinaryTB_OnLostFocus(object sender, RoutedEventArgs e)
    {
      controller.UpdateValues(BinaryTB.Text, "Binary", ActiveBits.SelectedItems);
    }


  }
}
