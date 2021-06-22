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
    public partial class UsersView : Form, IUsersView
    {
        #region Поля
        #region Основные поля формы
        private readonly Logger logger;

        public Form Form => this;

        public DataGridView DGV => Users_DGV;
        #endregion

        #region Поля основного функционала
        private bool _MainDroped = false;
        public bool MainVisible { get => Main_TSB.Visible; set => Main_TSB.Visible = value; }
        public bool MainDroped { get => _MainDroped; set => _MainDroped = value; }
        public bool MainAddVisible { get => MainAdd_TSB.Visible; set => MainAdd_TSB.Visible = value; }
        public bool MainEditVisible { get => MainEdit_TSB.Visible; set => MainEdit_TSB.Visible = value; }
        public bool MainDeleteVisible { get => MainDelete_TSB.Visible; set => MainDelete_TSB.Visible = value; }
        #endregion
        #endregion

        #region События
        #region События работы формы
        public event Action Start;
        #endregion

        #region События основного функционала
        public event Action Main;
        public event Action MainAdd;
        public event Action MainEdit;
        public event Action MainDelete;
        #endregion
        #endregion

        #region Запуск формы
        public UsersView()
        {
            logger = LogManager.GetCurrentClassLogger();

            InitializeComponent();

            logger.Info("Формы работы с пользователями успешно инициализирована");
        }
        #endregion

        #region События формы
        private void UsersView_Load(object sender, EventArgs e)
        {
            Users_DGV.AutoGenerateColumns = false;

            Main_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };
            Func_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };

            Start?.Invoke();
            logger.Info($"Запущена отработка запуска формы работы с пользователями");
        }
        private void Main_TSB_Click(object sender, EventArgs e)
        {
            if (_MainDroped)
            {
                Main_TSB.Text = " Основное   ᐳ";
            }
            else
            {
                Main_TSB.Text = " Основное   ᐯ";
            }

            _MainDroped = !_MainDroped;

            Main?.Invoke();
        }
        private void MainAdd_TSB_Click(object sender, EventArgs e)
        {
            MainAdd?.Invoke();
            logger.Info("Запущена форма добавления пользователя");
        }

        private void MainEdit_TSB_Click(object sender, EventArgs e)
        {
            MainEdit?.Invoke();
            logger.Info("Запущена форма изменения пользователя");
        }

        private void MainDelete_TSB_Click(object sender, EventArgs e)
        {
            MainDelete?.Invoke();
            logger.Info("Запущена форма удаления пользователя");
        }

        private void Hide_TSB_Click(object sender, EventArgs e)
        {
            if (Main_TLP.ColumnStyles[0].Width == 150)
            {
                Hide_TSB.Image = Properties.Resources.Right;
                HideTextFunctionsButton(true);
                Main_TLP.ColumnStyles[0].Width = 40;
            }
            else
            {
                HideTextFunctionsButton(false);
                Hide_TSB.Image = Properties.Resources.Left;
                Main_TLP.ColumnStyles[0].Width = 150;
            }
        }
        #endregion

        #region Методы
        private void HideTextFunctionsButton(bool flag)
        {
            if (flag)
            {
                Main_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                MainAdd_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                MainEdit_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                MainDelete_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
            else
            {
                Main_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MainAdd_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MainEdit_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                MainDelete_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
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
