using NLog;
using RestSharp;
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
    public partial class AuthView : Form, IAuthView
    {
        #region Поля
        private readonly ApplicationContext _context;
        private readonly Logger logger;
        public Form Form => this;

        public string UserName { get => Login_TB.Text.Trim(); set => Login_TB.Text = value; }
        public string Password { get => Password_TB.Text.Trim(); set => Password_TB.Text = value; }

        public bool Remember { get => RememberMe_CB.Checked; set => RememberMe_CB.Checked = value; }
        #endregion

        #region События
        public event Action Start;
        public event Action Login;
        #endregion

        #region Запуск формы
        public AuthView(ApplicationContext context)
        {
            _context = context;

            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info($"Авторизационная форма успешно инициализированна");
        }

        public new void Show()
        {
            try
            {
                _context.MainForm = this;

                Application.Run(_context);
            }
            catch (InvalidOperationException)
            {
                base.Show();
            }
        }
        #endregion

        #region События формы
        private void AuthView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
            logger.Info($"Запущена основная форма авторизации");
        }
        private void AuthView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_B.PerformClick();
            }
        }
        private void Login_B_Click(object sender, EventArgs e)
        {
            Login?.Invoke();
            logger.Info($"Нажата кнопка входа");
        }
        #endregion

        #region Методы
        public void SetNameLogin_B(string Name)
        {
            Login_B.Invoke((MethodInvoker)delegate ()
            {
                Login_B.Text = Name;
            });
        }
        public void BlockFields(bool flag)
        {
            Login_TB.ReadOnly = flag;
            Password_TB.ReadOnly = flag;
            RememberMe_CB.Enabled = !flag;

            logger.Info($"Изменена блокировка полей на: {flag}");
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
