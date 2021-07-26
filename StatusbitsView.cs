using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Statusbits.Controller;

namespace Statusbits
{
    class StatusbitsView
    {
        private StatusbitsController Controller;

        private MainPage Page;

        public StatusbitsView(MainPage page)
        {
            this.Page = page;
            Controller = new StatusbitsController(this);
        }

        public List<string> GetStatusBitsList()
        {
            return Controller.GetStatusBitsListFromModel();
        }

        public List<string> GetClipboardTypeList()
        {
            return Controller.GetClipboardTypeListFromModel();
        }

        public void UpdateFromDecimal(string value)
        {
            Controller.UpdateFromDecimal(value);
        }

        public void UpdateFromSignedDecimal(string value)
        {
            Controller.UpdateFromSignedDecimal(value);
        }

        public void UpdateFromHexadecimal(string value)
        {
            Controller.UpdateFromHexadecimal(value);
        }

        public void UpdateFromBinary(string value)
        {
            Controller.UpdateFromBinary(value);
        }

        public void UpdateValues(string decimalValue, string signedDecimal, string hexadecimal, string binary)
        {
            Page.UpdateValues(decimalValue, signedDecimal, hexadecimal, binary);
        }
    }
}
