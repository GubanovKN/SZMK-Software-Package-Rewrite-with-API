using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Auth.Interfaces
{
    interface IAuthView : IView, IMessage
    {
        event Action Start;
        event Action Login;

        string UserName { get; set; }
        string Password { get; set; }

        bool Remember { get; set; }

        void SetNameLogin_B(string Name);
        void BlockFields(bool flag);
    }
}
