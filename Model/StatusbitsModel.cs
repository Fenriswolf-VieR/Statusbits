using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources;
using Statusbits.Annotations;

namespace Statusbits.Model
{
    public class StatusbitsModel : INotifyPropertyChanged
    {
        private ResourceLoader Bits;

        public string Version = "1000";
        public string Decimal { get; set; } = "0";
        public string SignedDecimal { get; set; } = "0";
        public string Hexadecimal { get; set; } = "0";
        public string Binary { get; set; } = "0";

        public int Bit { get; set; } = 64;

        public string CalculationType { get; set; }

        public string Language { get; set; } = "en";

        public List<string> StatusBits { get; set; }

        public List<string> ClipboardOptions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StatusbitsModel()
        {
            ClipboardOptions = new List<string>();
            StatusBits = new List<string>();

            ClipboardOptions.Add("no");
            ClipboardOptions.Add("hexadecimal");
            ClipboardOptions.Add("decimal");
            ClipboardOptions.Add("binary");
            ClipboardOptions.Add("signed decimal");

            Bits = new ResourceLoader(Version);
            for (var i = 0; i < Bit; i++)
            {
                StatusBits.Add(i.ToString() + " " + Bits.GetString(i.ToString()));
            }
        }

        public void UpdateVersion(string version)
        {
            this.Version = version;

            Bits = new ResourceLoader(version);
            StatusBits.RemoveRange(0, Bit);
            for (int i = 0; i < Bit; i++)
            {
                StatusBits.Add(i.ToString() + " " + Bits.GetString(i.ToString()));
            }
        }
    }
}
