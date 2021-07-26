
using System.Collections.Generic;
using Statusbits.Model;
using BitDecryption;

namespace Statusbits.Controller
{
    class StatusbitsController
    {
        private StatusbitsModel Model;
        private StatusbitsView View;

        BitDecryption.BitDecryption CalculateBits;

        public StatusbitsController(StatusbitsView view)
        {
            this.View = view;
            this.CalculateBits = new BitDecryption.BitDecryption();
            this.Model = new StatusbitsModel();
        }

        public void UpdateClipboardType(string type)
        {
            Model.CalculationType = type;
        }
        public List<string> GetClipboardTypeListFromModel()
        {
            return Model.ClipboardOptions;
        }

        public List<string> GetStatusBitsListFromModel()
        {
            return Model.StatusBits;
        }

        public void UpdateFromDecimal(string value)
        {
            var Bit = Model.Bit;

            Model.Decimal = value;
            (Model.Binary, Model.Hexadecimal, Model.SignedDecimal) = CalculateBits.CalculateFromDec(value, Bit);
            View.UpdateValues(Model.Decimal, Model.SignedDecimal, Model.Hexadecimal, Model.Binary);
        }

        public void UpdateFromSignedDecimal(string value)
        {
            var Bit = Model.Bit;

            Model.SignedDecimal = value;
            (Model.Binary, Model.Hexadecimal, Model.Decimal) = CalculateBits.CalculateFromSignedDec(value, Bit);
            View.UpdateValues(Model.Decimal, Model.SignedDecimal, Model.Hexadecimal, Model.Binary);
        }

        public void UpdateFromHexadecimal(string value)
        {
            var Bit = Model.Bit;

            Model.Hexadecimal = value;
            (Model.Decimal, Model.SignedDecimal, Model.Binary) = CalculateBits.CalculateFromHex(value, Bit);
            View.UpdateValues(Model.Decimal, Model.SignedDecimal, Model.Hexadecimal, Model.Binary);
        }

        public void UpdateFromBinary(string value)
        {
            var Bit = Model.Bit;

            Model.Binary = value;
            (Model.Decimal, Model.Hexadecimal, Model.SignedDecimal) = CalculateBits.CalculateFromBin(value, Bit);
            View.UpdateValues(Model.Decimal, Model.SignedDecimal, Model.Hexadecimal, Model.Binary);
        }

    }
}
