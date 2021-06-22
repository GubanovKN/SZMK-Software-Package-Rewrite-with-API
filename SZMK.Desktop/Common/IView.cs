using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Common
{
    public interface IView
    {
        void Show();
        bool IsDisposed { get; }
        DialogResult ShowDialog();
        DialogResult DialogResult { get; set; }
        Form Owner { get; set; }
        Form Form { get; }
        void Close();
    }
}
