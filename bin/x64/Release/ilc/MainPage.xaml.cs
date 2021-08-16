using System;
using System.Diagnostics;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Statusbits.Controller;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;

namespace Statusbits
{
    public sealed partial class MainPage : Page
  {
    private StatusbitsController controller;
    private bool allowed_to_recieve = false;

    public MainPage(){
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

    private void ClipboardType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      allowed_to_recieve = false;
      if (ClipboardType.SelectedItem.ToString() != "no")
      {
        allowed_to_recieve = true;
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

    private void AppServiceConnected(object sender, Windows.ApplicationModel.AppService.AppServiceTriggerDetails e)
    {
        e.AppServiceConnection.RequestReceived += AppServiceConnection_RequestReceived;
    }
    private async void AppServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
    {
        if (allowed_to_recieve)
        {
            AppServiceDeferral messageDeferral = args.GetDeferral();
            string id = (string)args.Request.Message["ID"];
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                controller.UpdateValues(id, ClipboardType.SelectionBoxItem.ToString(), ActiveBits.SelectedItems);
            });
            await args.Request.SendResponseAsync(new ValueSet());
            messageDeferral.Complete();

            // we no longer need the connection
            App.AppServiceDeferral.Complete();
            App.Connection = null;
        }  
    }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
        {
            Process process = Process.GetCurrentProcess();
            ApplicationData.Current.LocalSettings.Values["processID"] = process.Id;

            App.AppServiceConnected += AppServiceConnected;
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }
    }
    }
}
