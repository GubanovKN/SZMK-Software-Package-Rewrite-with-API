using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Views.Auth.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Views.Auth
{
    public partial class DeleteSessionsView : Form, IDeleteSessionsView
    {
        #region Поля
        private readonly Logger logger;

        private InfoSessionViewModel _session;

        public event Action Start;
        public event Action Delete;
        public event Action Finish;

        public Form Form => this;
        public InfoSessionViewModel Session { get => _session; set => _session = value; }
        #endregion

        #region Запуск формы
        public DeleteSessionsView()
        {
            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info($"Форма удаления сессий успешно инициализированна");
        }
        #endregion

        #region События формы
        private void DeleteSessionsView_Load(object sender, EventArgs e)
        {
            Sessions_DGV.AutoGenerateColumns = false;

            Start?.Invoke();
        }
        private void Sessions_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Sessions_DGV.Columns[e.ColumnIndex].Name == "Deleted")
            {
                if (MessageBox.Show("Вы уверены в удалении сессии?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _session = Sessions_DGV.Rows[e.RowIndex].DataBoundItem as InfoSessionViewModel;

                    if (_session != null)
                    {
                        Delete?.Invoke();
                    }
                    else
                    {
                        Error("Не удалось получить сессию");
                    }
                }
            }
        }
        private void Close_B_Click(object sender, EventArgs e)
        {
            Finish?.Invoke();
        }
        #endregion

        #region Методы
        public void ShowSessions(List<InfoSessionViewModel> sessions)
        {
            Sessions_DGV.DataSource = null;
            Sessions_DGV.DataSource = sessions;

            logger.Info($"Успешное отображение сессий");
        }
        #endregion

        #region Информационный блок
        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string Message)
        {
            logger.Error(Message);
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
