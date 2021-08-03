
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Statusbits.Model;
using Windows.ApplicationModel.Resources;

//using WK.Libraries.SharpClipboardNS;

namespace Statusbits.Controller
{
  class StatusbitsController
  {

    private ResourceLoader resource;
    public StatusbitsModel Model { get; set; }
    private BitDecryption.BitDecryption CalculateBits;

    private Dictionary<string, BitDecryption.BitDecryption.BaseType> baseTypeHelper;
    public StatusbitsController(int bits, string version="1000")
    {
      CalculateBits = new BitDecryption.BitDecryption();
      Model = new StatusbitsModel();

      //Add Clipboard options
      Model.ClipboardOptions.Add("no");
      Model.ClipboardOptions.Add("Hexadecimal");
      Model.ClipboardOptions.Add("Decimal");
      Model.ClipboardOptions.Add("Binary");
      //Model.ClipboardOptions.Add("signed decimal");

      Model.Bit = bits;
      Model.Version = version;

      //set default value for decimal, signedDecimal, Hexadecimal, binary
      Model.Values.Add("0");
      Model.Values.Add("0");
      Model.Values.Add("0");
      Model.Values.Add("0");

      //Load bits from Version
      UpdateStatusbitsFromVersion(Model.Version);

      //Load COT Messages
      resource = new ResourceLoader("COT");
      for (var i = 0; i < Model.Bit; i++)
      {
        Model.CotMessages.Add(resource.GetString(i.ToString()));
      }
      Model.CotValue = 0;
      Model.CotMessage = Model.CotMessages[Model.CotValue];

      //create baseTypeHelper
      baseTypeHelper = new Dictionary<string, BitDecryption.BitDecryption.BaseType>();

      baseTypeHelper.Add("Decimal", BitDecryption.BitDecryption.BaseType.Decimal);
      //baseTypeHelper.Add("SignedDecimal", BitDecryption.BitDecryption.BaseType.SignedDecimal);
      baseTypeHelper.Add("Hexadecimal", BitDecryption.BitDecryption.BaseType.Hex);
      baseTypeHelper.Add("Binary", BitDecryption.BitDecryption.BaseType.Binary);
    }

    //Calculate values from input and set checkboxes
    public void UpdateValues(string value, string baseForm, IList<object> items)
    {
      Model.ErrorMsg = "";
      try
      {
        var Bit = BitDecryption.BitDecryption.Bitness.Bit64;
        if (Model.Bit == (int)BitDecryption.BitDecryption.Bitness.Bit32)
        {
          Bit = BitDecryption.BitDecryption.Bitness.Bit32;
        }

        Model.Values = CalculateBits.CalculateFromBase(value, Bit, baseTypeHelper[baseForm]);
        CalculateBits.CalculateActiveCheckboxes(Model.StatusBits, items, value, Bit, baseTypeHelper[baseForm]);

        if (Model.Bit == 64)
        {
          Model.CotValue = CalculateBits.CalculateCOT(Model.StatusBits, items);
          Model.CotMessage = Model.CotMessages[Model.CotValue];
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        Model.ErrorMsg = e.ToString();
      }
    }

    //Update Values from given Checkboxes
    public void UpdateFromCheckboxes(IList<object> items)
    {

      try
      {
        var Bit = BitDecryption.BitDecryption.Bitness.Bit64;
        if (Model.Bit == (int)BitDecryption.BitDecryption.Bitness.Bit32)
        {
          Bit = BitDecryption.BitDecryption.Bitness.Bit32;
        }

        Model.Items = items;
        Model.Values = CalculateBits.CalculateFromCheckBoxes(Model.Items, Model.StatusBits, Bit);
        if (Model.Bit == 64)
        {
          Model.CotValue = CalculateBits.CalculateCOT(Model.StatusBits, items);
          Model.CotMessage = Model.CotMessages[Model.CotValue];
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public void UpdateStatusbitsFromVersion(string version)
    {
      try
      {
        Model.Version = version;
        resource = new ResourceLoader(Model.Version);

        List<string> newStatusbits = new List<string>();

        for (var i = 0; i < Model.Bit; i++)
        {
          newStatusbits.Add(i.ToString() + " " + resource.GetString(i.ToString()));
        }
        newStatusbits.Reverse();

        Model.StatusBits = newStatusbits;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        Model.ErrorMsg = e.ToString();
      }
    }

    public void UpdateBits(int bits)
    {
      try
      {
        Model.Bit = bits;
        UpdateStatusbitsFromVersion(Model.Version);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}
