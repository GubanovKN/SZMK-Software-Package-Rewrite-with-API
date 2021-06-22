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
using SZMK.Desktop.Views.Positions.Administrator.Interfaces;

namespace SZMK.Desktop.Views.Positions.Administrator
{
    public partial class UserView : Form, IUserView
    {
        #region Поля
        private readonly Logger logger;
        private bool _Cancel = true;

        public Form Form => this;
        public DataGridView DGV => Roles_DGV;
        public bool Cancel { get => _Cancel; set => _Cancel = value; }
        public string SurName { get => SurName_TB.Text; set => SurName_TB.Text = value; }
        public string UserName { get => Name_TB.Text; set => Name_TB.Text = value; }
        public string MiddleName { get => MiddleName_TB.Text; set => MiddleName_TB.Text = value; }
        public string Login { get => Login_TB.Text; set => Login_TB.Text = value; }
        public string ConfrimPassword { get => ConfrimPassword_TB.Text; set => ConfrimPassword_TB.Text = value; }
        public string Password { get => Password_TB.Text; set => Password_TB.Text = value; }
        public bool UpdatePassword { get => UpdatePassword_CB.Checked; set => UpdatePassword_CB.Checked = value; }
        public bool Active { get => Active_CB.Checked; set => Active_CB.Checked = value; }
        #endregion

        #region События
        public event Action Start;
        public event Action Finish;
        #endregion

        #region Запуск формы
        public UserView()
        {
            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info("Форма работы с пользователем успешно инициализирована");
        }
        #endregion

        #region События формы
        private void UserView_Load(object sender, EventArgs e)
        {
            Roles_DGV.AutoGenerateColumns = false;

            Start?.Invoke();
            logger.Info($"Запущена отработка запуска формы работы с пользователем");
        }
        private void UserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (_Cancel)
                {
                    Finish?.Invoke();

                    e.Cancel = _Cancel;
                }
            }
        }
        #endregion

        #region Методы
        public void RenameTitle(string Message)
        {
            try
            {
                Text = Message;
                Title_L.Text = Message;
            }
            catch (Exception Ex)
            {
                Error(Ex.Message);
            }
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
