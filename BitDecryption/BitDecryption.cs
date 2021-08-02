using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BitDecryption
{
  public class BitDecryption
  {
    private string binary;
    private string hex;
    private string signedDec;
    private string dec;

    public enum BaseType
    {
      Decimal = 10,
      Binary = 2,
      Hex = 16,
      SignedDecimal = 10
    }

    public enum Bitness
    {
      Bit64 = 64,
      Bit32 = 32
    }

    //Calculate Values 
    public List<string> CalculateFromBase(string value, Bitness bit, BaseType baseType)
    {
      if (string.IsNullOrEmpty(value))
      {
        value = "0";
      }

      //replace spaces from formatting
      value = value.Replace(" ", "");
      UInt64 unsignedDecValue64;

      //for conversion of negative numbers to uint64
      if (Convert.ToInt64(value, (int) baseType) < 0)
      {
        Int64 test = Convert.ToInt64(value, (int) baseType);
        value = Convert.ToString(test, 2);
        baseType = BaseType.Binary;
      }

      unsignedDecValue64 = Convert.ToUInt64(value, (int)baseType);


      switch (bit)
      {
        case Bitness.Bit32:
          dec = Convert.ToString(unsignedDecValue64 & 0xffffffff);
          hex = Convert.ToString((long) unsignedDecValue64 & 0xffffffff, 16);
          binary = Convert.ToString((long) unsignedDecValue64 & 0xffffffff, 2);
          break;
        case Bitness.Bit64:
          dec = Convert.ToString(unsignedDecValue64);
          hex = Convert.ToString((long) unsignedDecValue64, 16);
          binary = Convert.ToString((long) unsignedDecValue64, 2);
          break;
      }
      return new List<string>() { dec, signedDec, hex, binary };
    }

    //Update all Values from selected Checkboxes
    public List<string> CalculateFromCheckBoxes(IList<object> items, List<string> allStatusbits, Bitness bit)
    {
      IEnumerator item = items.GetEnumerator();

      Int64 decimalNumber = 0;
      int index;
      string currentItem;

      for (int i = 0; i < items.Count; i++)
      {
        item.MoveNext();
        currentItem = item.Current.ToString();
        index = (int) bit - 1 - allStatusbits.IndexOf(currentItem);
        decimalNumber += (Int64)Math.Pow(2, index);
      }

      List<string> values = new List<string>();
      values = CalculateFromBase(decimalNumber.ToString(), bit, BaseType.Decimal);
      return FormatString(values);
    }

    public IList<object> CalculateActiveCheckboxes(List<string> allStatusBits, IList<object> items, string number, Bitness bit, BaseType baseType)
    {
      for (int i = items.Count - 1; i >= 0; i--)
      {
        items.RemoveAt(i);
      }

      if (string.IsNullOrEmpty(number))
      {
        number = "0";
      }

      //replace spaces from formatting
      number = number.Replace(" ", "");

      UInt64 unsignedDecValue64;

      unsignedDecValue64 = Convert.ToUInt64(number, (int)baseType);

      int index = 0;

      while(unsignedDecValue64 > 0)
      {
        if (unsignedDecValue64 % 2 == 1)
        {
          items.Add(allStatusBits[(int)bit - 1 - index]);
        }

        index++;
        unsignedDecValue64 /= 2;
      }
      return items;
    }
    public int CalculateCOT(List<string> allStatusBits, IList<object> items)
    {
      List<string> cot = new List<string>();
      allStatusBits.Reverse();
      cot = allStatusBits.GetRange(32, 6);
      allStatusBits.Reverse();
      int value = 0;

      for (int i = 0; i < cot.Count; i++)
      {
        if (items.Contains(cot[i]))
        {
          value += (int)Math.Pow(2, i);
        }
      }

      return value;
    }

    private List<string> FormatString(List<string> values)
    {
      int spacesBinary = 0;
      int spacesDecimal = 0;
      int spacesHexadecimal = 0;

      for (int i = 1; i < values[3].Length; i++)
      {
        //binary => space every 4 digits: 0000 0000 0000
        if (i % 4 == 0 && i < binary.Length)
        {
          values[3] = values[3].Insert(values[3].Length - (i + spacesBinary), " ");
          spacesBinary += 1;
        }
        //decimal => space every 3 digits: 100 000 000
        if (i % 3 == 0 && i < dec.Length)
        {
          values[0] = values[0].Insert(values[0].Length - (i + spacesDecimal), " ");
          spacesDecimal++;
        }
        //hex => space every 2 digits: FF FF FF
        if (i % 2 == 0 && i < hex.Length)
        {
          values[2] = values[2].Insert(values[2].Length - (i + spacesHexadecimal), " ");
          spacesHexadecimal++;
        }
      }

      return values;
    }
  }
}
