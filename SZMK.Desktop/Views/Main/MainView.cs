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
using SZMK.Desktop.Views.Main.Interfaces;

namespace SZMK.Desktop.Views.Main
{
    public partial class MainView : Form, IMainView
    {
        #region Поля
        #region Поля работы формы
        private bool _IsCancel = true;
        public bool IsCancel { get => _IsCancel; set => _IsCancel = value; }
        #endregion

        #region Основные поля формы
        private readonly ApplicationContext _context;

        private readonly Logger logger;

        public Form Form => this;

        public string UserName { get => Profile_TSB.Text; set => Profile_TSB.Text = value; } 
        #endregion

        #region Поля функционала администратора
        private bool _AdministratorDroped = false;
        public bool AdministratorVisible { get => Administrator_TSB.Visible; set => Administrator_TSB.Visible = value; }
        public bool AdministratorDroped { get => _AdministratorDroped; set => _AdministratorDroped = value; }
        public bool AdministratorUsersVisible { get => AdministratorUsers_TSB.Visible; set => AdministratorUsers_TSB.Visible = value; }
        #endregion

        #endregion

        #region События
        #region События работы формы
        public event Action Start;
        public event Action Finish; 
        #endregion

        #region Основные события формы
        public event Action Settings;
        public event Action UpdateData;
        public event Action AboutProgram;
        public event Action Logout;
        #endregion

        #region События функционала администратора
        public event Action Administrator;
        public event Action AdministratorUsers;
        #endregion
        #endregion

        #region Запуск формы
        public MainView(ApplicationContext context)
        {
            _context = context;

            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info($"Основная форма успешно инициализированна");
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }
        #endregion

        #region События формы
        private void MainView_Load(object sender, EventArgs e)
        {
            Main_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };
            Func_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };

            Start?.Invoke();
            logger.Info($"Запущена отработка запуска основной формы");
        }
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _IsCancel;

            if (e.Cancel)
            {
                Finish?.Invoke();
            }
        }
        private void Profile_TSB_DropDownClosed(object sender, EventArgs e)
        {
            RecolorProfileButton(false);
        }

        private void Profile_TSB_DropDownOpened(object sender, EventArgs e)
        {
            RecolorProfileButton(true);
        }
        private void Settings_TSB_Click(object sender, EventArgs e)
        {
            Settings?.Invoke();
            logger.Info($"Запущена форма настроек пользователя");
        }

        private void Update_TSB_Click(object sender, EventArgs e)
        {
            UpdateData?.Invoke();
            logger.Info($"Запущена форма обновления данных");
        }

        private void About_TSB_Click(object sender, EventArgs e)
        {
            AboutProgram?.Invoke();
            logger.Info($"Запущена форма информации о программе");
        }
        private void Logout_TSMI_Click(object sender, EventArgs e)
        {
            RecolorProfileButton(false);
            Logout?.Invoke();
            logger.Info($"Запущен выход из учетной записи");
        }
        private void Administrator_TSB_Click(object sender, EventArgs e)
        {
            if (_AdministratorDroped)
            {
                Administrator_TSB.Text = "  Администратор      ᐳ";
            }
            else
            {
                Administrator_TSB.Text = "  Администратор      ᐯ";
            }

            _AdministratorDroped = !AdministratorDroped;

            Administrator?.Invoke();
        }
        private void AdministratorUsers_TSB_Click(object sender, EventArgs e)
        {
            AdministratorUsers?.Invoke();
            logger.Info($"Запущена форма работы с пользователями");
        }
        private void Hide_TSB_Click(object sender, EventArgs e)
        {
            if (Main_TLP.ColumnStyles[0].Width == 200)
            {
                Hide_TSB.Image = Properties.Resources.Right;
                HideTextFunctionsButton(true);
                Main_TLP.ColumnStyles[0].Width = 40;
            }
            else
            {
                HideTextFunctionsButton(false);
                Hide_TSB.Image = Properties.Resources.Left;
                Main_TLP.ColumnStyles[0].Width = 200;
            }
        }
        #endregion

        #region Методы
        private void HideTextFunctionsButton(bool flag)
        {
            if (flag)
            {
                Administrator_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                AdministratorUsers_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
            else
            {
                Administrator_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                AdministratorUsers_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }
        private void RecolorProfileButton(bool flag)
        {
            if (flag)
            {
                Profile_TSB.Image = Properties.Resources.User_Dark;
                Profile_TSB.ForeColor = Color.FromArgb(79, 77, 89);
            }
            else
            {
                Profile_TSB.Image = Properties.Resources.User_Light;
                Profile_TSB.ForeColor = Color.FromArgb(231, 255, 255);
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
