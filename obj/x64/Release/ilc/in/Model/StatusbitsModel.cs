using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Statusbits.Annotations;

namespace Statusbits.Model
{
  public class StatusbitsModel : INotifyPropertyChanged
  {

    private string _version;
    public string Version
    {
      get => _version;
      set { _version = value; OnPropertyChanged(nameof(Version)); }
    }

    private string _errorMsg = "";
    public string ErrorMsg
    {
      get => _errorMsg;
      set { _errorMsg = value; OnPropertyChanged(nameof(ErrorMsg)); }
    }

    private int _bit;
    public int Bit
    {
      get => _bit;
      set { _bit = value; OnPropertyChanged(nameof(Bit)); }
    }

    private string _calculationType;
    public string CalculationType
    {
      get => _calculationType;
      set { _calculationType = value; OnPropertyChanged(nameof(CalculationType)); }
    }

    private string _language;
    public string Language
    {
      get => _language;
      set { _language = value; OnPropertyChanged(nameof(Language)); }
    }

    private int _cotValue;
    public int CotValue
    {
      get => _cotValue;
      set { _cotValue = value; OnPropertyChanged(nameof(CotValue)); }
    }

    private string _cotMessage;
    public string CotMessage
    {
      get => _cotMessage;
      set { _cotMessage = value; OnPropertyChanged(nameof(CotMessage)); }
    }

    private List<string> _cotMessages = new List<string>();
    public List<string> CotMessages
    {
      get => _cotMessages;
      set { _cotMessages = value; OnPropertyChanged(nameof(CotMessages)); }
    }

    private List<string> _statusBits = new List<string>();
    public List<string> StatusBits
    {
      get => _statusBits;
      set { _statusBits = value; OnPropertyChanged(nameof(StatusBits)); }
    }

    private List<string> _clipboardOptions = new List<string>();
    public List<string> ClipboardOptions
    {
      get => _clipboardOptions;
      set { _clipboardOptions = value; OnPropertyChanged(nameof(ClipboardOptions)); }
    }

    private List<string> _values = new List<string>();
    public List<string> Values
    {
      get => _values;
      set { _values = value; OnPropertyChanged(nameof(Values)); }
    }

    private IList<object> _items = new List<object>();
    public IList<object> Items
    {
      get => _items;
      set { _items = value; OnPropertyChanged(nameof(Items)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
