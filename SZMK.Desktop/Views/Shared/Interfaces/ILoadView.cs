using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Shared.Interfaces
{
    interface ILoadView: IView
    {
        string Status { set; }
        new DialogResult DialogResult { get; }
    }
}
