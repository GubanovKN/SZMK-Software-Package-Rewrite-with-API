using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Positions.Administrator.Interfaces
{
    interface IUserView : IView, IMessage
    {
        event Action Start;
        event Action Finish;

        bool Cancel { get; set; }

        string SurName { get; set; }
        string UserName { get; set; }
        string MiddleName { get; set; }

        string Login { get; set; }
        string ConfrimPassword { get; set; }
        string Password { get; set; }
        bool UpdatePassword { get; set; }
        bool Active { get; set; }

        DataGridView DGV { get; }

        void RenameTitle(string Message);
    }
}
