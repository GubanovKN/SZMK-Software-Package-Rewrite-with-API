using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;

namespace SZMK.Desktop.Views.Positions.Administrator.Interfaces
{
    interface IUsersView : IView, IMessage
    {
        #region События работы формы
        event Action Start;
        #endregion

        #region Основные поля формы
        DataGridView DGV { get; } 
        #endregion

        #region События основного функционала
        event Action Main;
        event Action MainAdd;
        event Action MainEdit;
        event Action MainDelete;
        #endregion

        #region Поля основного функционала
        bool MainVisible { get; set; }
        bool MainDroped { get; set; }
        bool MainAddVisible { get; set; }
        bool MainEditVisible { get; set; }
        bool MainDeleteVisible { get; set; } 
        #endregion
    }
}
