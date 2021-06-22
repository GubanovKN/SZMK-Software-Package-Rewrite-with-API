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

namespace SZMK.Desktop.Views.Auth
{
    public partial class UpdatePasswordView : Form, IUpdatePasswordView
    {
        #region Поля
        private readonly Logger logger;
        private bool _Cancel = true;

        public Form Form => this;

        public bool Cancel { get => _Cancel; set => _Cancel = value; }
        public string OldPassword { get => OldPassword_TB.Text; set => OldPassword_TB.Text = value; }
        public string NewPassword { get => NewPassword_TB.Text; set => NewPassword_TB.Text = value; }
        public string ConfrimPassword { get => ConfrimPassword_TB.Text; set => ConfrimPassword_TB.Text = value; }
        #endregion

        #region События
        public event Action Start;
        public event Action Finish;
        #endregion

        #region Запуск формы
        public UpdatePasswordView()
        {
            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info("Формы обновления пароля успешно инициализирована");
        }
        #endregion

        #region События формы
        private void UpdatePasswordView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
            logger.Info($"Запущена отработка запуска формы обновления пароля");
        }
        private void ShowPassword_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword_CB.Checked)
            {
                OldPassword_TB.UseSystemPasswordChar = false;
                NewPassword_TB.UseSystemPasswordChar = false;
                ConfrimPassword_TB.UseSystemPasswordChar = false;
            }
            else
            {
                OldPassword_TB.UseSystemPasswordChar = true;
                NewPassword_TB.UseSystemPasswordChar = true;
                ConfrimPassword_TB.UseSystemPasswordChar = true;
            }
        }
        private void UpdatePasswordView_FormClosing(object sender, FormClosingEventArgs e)
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
