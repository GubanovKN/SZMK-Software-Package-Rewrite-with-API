using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Main.Interfaces
{
    interface IMainView : IView, IMessage
    {
        #region События работы формы
        event Action Start;
        event Action Finish;
        #endregion

        #region Поля работы формы
        bool IsCancel { get; set; } 
        #endregion

        #region Основные события формы
        event Action Settings;
        event Action UpdateData;
        event Action AboutProgram;
        event Action Logout;
        #endregion

        #region Основные поля формы
        string UserName { get; set; }
        #endregion

        #region События функционала администратора
        event Action Administrator;
        event Action AdministratorUsers;
        #endregion

        #region Поля функционала администратора
        bool AdministratorVisible { get; set; }
        bool AdministratorDroped { get; set; }
        bool AdministratorUsersVisible { get; set; } 
        #endregion
    }
}
