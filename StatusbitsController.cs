using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statusbits
{
    class StatusbitsController
    {
        StatusbitsModel model;
        StatusbitsView view;

        public StatusbitsController(StatusbitsModel model, StatusbitsView view)
        {
            this.model = model;
            this.view = view;
        }

    }
}
