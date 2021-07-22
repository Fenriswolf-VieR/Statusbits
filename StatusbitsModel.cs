using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statusbits
{
    class StatusbitsModel
    {

        public String cot { get; set; }
        public bool scanClipboard { get; set; }
        public bool isHex { get; set; }
        public bool isDec { get;set; }
        public bool isBool { get; set; }
        public bool isDecSigned { get; set; }

    }
}
