using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZMK.Desktop.Common
{
    public interface IPresenter
    {
        void Run();
        DialogResult RunDialog(Form owner);
        Task<DialogResult> RunDialogAsync(Form owner);
        void SetOwner(Form owner);
        void Finish();
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument);
        DialogResult RunDialog(TArg argument, Form owner);
        Task<DialogResult> RunDialogAsync(TArg argument, Form owner);
        void SetOwner(Form owner);
        void Finish();
    }
}
