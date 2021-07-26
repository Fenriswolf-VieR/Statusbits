using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BitDecryption
{
    public class BitDecryption
    {

        private string binary;
        private string hex;
        private string signedDec;
        private string dec;

        //Calculate the binary, hexadecimal and signed decimal number from given binary number
        public (string, string, string) CalculateFromDec(string value, int Bit)
        {
            Int64 decValue64 = Int64.Parse(value);


            if (Bit == 32)
            {
                binary = Convert.ToString(decValue64 & 0xffffffff, 2);
                hex = Convert.ToString(decValue64 & 0xffffffff, 16);
                signedDec = Convert.ToString(decValue64 & 0xffffffff) ;

            }
            else if (Bit == 64)
            {
                binary = Convert.ToString(decValue64, 2);
                hex = Convert.ToString(decValue64, 16);
                signedDec = value;
            }

            return (binary, hex, signedDec);
        }

        //Calculate the decimal, signed decimal and hexadecimal number from given binary number
        //TODO signed Dec
        public (string, string, string) CalculateFromBin(string value, int Bit)
        {
            Int64 decValue64 = Convert.ToInt64(value, 2);

            if (Bit == 32)
            {
                
                dec = Convert.ToString(decValue64 & 0xffffffff);
                hex = Convert.ToString(decValue64 & 0xffffffff, 16);

                //signedDec = (value[31] == '1') ? calculateSignedDecimal(decValue64, Bit) : dec;

            }
            else if (Bit == 64)
            {

                dec = Convert.ToString(decValue64);
                hex = Convert.ToString(decValue64 & 0xffffffff, 16);
            }

            return (dec, hex, signedDec);
        }

        //Calculate the decimal, hexadecimal and signed decimal number from given hexadecimal number
        public (string, string, string) CalculateFromHex(string value, int Bit)
        {
            

            Int64 decValue64 = Convert.ToInt64(value, 16);


            if (Bit == 32)
            {
                binary = Convert.ToString(decValue64 & 0xffffffff, 2);
                dec = Convert.ToString(decValue64 & 0xffffffff);
                signedDec = dec;
            }
            else if (Bit == 64)
            {
                dec = Convert.ToString(decValue64);
                binary = Convert.ToString(decValue64, 2);
                signedDec = dec;
            }

            return (dec, signedDec, binary);
        }


        //Calculate the binary, hexadecimal and decimal number from given signed decimal number
        public (string, string, string) CalculateFromSignedDec(string value, int Bit)
        {

            Int64 decValue64 = Int64.Parse(value);


            if (Bit == 32)
            {
                binary = Convert.ToString(decValue64 & 0xffffffff, 2);
                hex = Convert.ToString(decValue64 & 0xffffffff, 16);
                dec = Convert.ToString(decValue64 & 0xffffffff);
            }
            else if (Bit == 64)
            {
                binary = Convert.ToString(decValue64, 2);
                hex = Convert.ToString(decValue64, 16);
                dec = value;
            }

            return (binary, hex, dec);
        }
        //private string calculateSignedDecimal(Int64 value, int Bit)
        //{
            
        //    if (Bit == 32)
        //    {
        //        value -= (int) Math.Pow(2, 32);
        //    } else if (Bit == 64)
        //    {
        //        value -= (int) Math.Pow(2, 64);

        //    }

        //    return Convert.ToString(value);
        //}
    }
}
