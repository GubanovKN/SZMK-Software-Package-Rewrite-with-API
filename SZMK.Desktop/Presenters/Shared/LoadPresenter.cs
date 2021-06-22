using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;
using SZMK.Desktop.Views.Shared.Interfaces;

namespace SZMK.Desktop.Presenters.Shared
{
    class LoadPresenter : BasePresener<ILoadView>
    {
        public LoadPresenter(IApplicationController controller, ILoadView view) : base(controller, view) { }

        public void SetStatus(string Message)
        {
            View.Status = Message;
        }
    }
}
