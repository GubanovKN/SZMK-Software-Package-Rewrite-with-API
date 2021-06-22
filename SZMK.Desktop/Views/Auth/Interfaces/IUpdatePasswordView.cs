using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Auth.Interfaces
{
    interface IUpdatePasswordView: IView, IMessage
    {
        event Action Start;
        event Action Finish;

        bool Cancel { get; set; }

        string OldPassword { get; set; }
        string NewPassword { get; set; }
        string ConfrimPassword { get; set; }
    }
}
