using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Common;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Views.Auth.Interfaces
{
    interface IDeleteSessionsView: IView, IMessage
    {
        event Action Start;
        event Action Delete;
        event Action Finish;

        InfoSessionViewModel Session { get; set; }

        void ShowSessions(List<InfoSessionViewModel> sessions);
    }
}
