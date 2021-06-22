using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;
using SZMK.Desktop.Presenters.Shared;
using SZMK.Desktop.Services.Managers.Interfaces;
using SZMK.Desktop.Views.Positions.Administrator.Interfaces;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Desktop.Presenters.Positions.Administrator
{
    class UserPresenter : BasePresener<IUserView, UserViewModel>
    {
        #region Поля
        private readonly Logger logger;

        private UserViewModel User;

        private List<RoleViewModel> Roles;

        private readonly IRoleRequestService roleRequestService;
        private readonly IUserManagerService userManagerService;
        #endregion

        #region Инициализация презентера
        public UserPresenter(IApplicationController controller, IUserView view, IRoleRequestService roleRequestService, IUserManagerService userManagerService) : base(controller, view)
        {
            logger = LogManager.GetCurrentClassLogger();

            this.roleRequestService = roleRequestService;
            this.userManagerService = userManagerService;

            View.Start += () => Start();
            View.Finish += () => Finish();
        }
        #endregion

        #region Запуск формы
        public override void Run(UserViewModel argument)
        {
            try
            {
                User = argument;

                View.Show();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }

        public override DialogResult RunDialog(UserViewModel argument, Form owner)
        {
            User = argument;

            SetOwner(owner);

            return View.ShowDialog();
        }

        public async override Task<DialogResult> RunDialogAsync(UserViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                User = argument;

                SetOwner(owner);
                return View.ShowDialog();
            }
        }
        private async void Start()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);
            try
            {
                load.SetStatus("Получение данных разрешений");

                Roles = await roleRequestService.GetAll(Constants.AccessToken);

                load.SetStatus("Успешное получение данных!");

                load.SetStatus("Проверка данных");

                CheckFunction();

                load.SetStatus("Успешная проверка данных!");

                load.Finish();
                await flag;
            }
            catch (Exception Ex)
            {
                load.Finish();
                await flag;

                View.Error(Ex.Message);

                View.Close();
            }
        }
        #endregion

        #region Изменение владельца формы
        public override void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }
        #endregion

        #region Проверка при запуске
        private void CheckFunction()
        {
            try
            {
                FillingDGV();

                if (User.Login != null)
                {
                    logger.Info("Вход в изменение пользователя");
                    View.RenameTitle("Изменение пользователя");
                    FillingFields();
                }
                else
                {
                    logger.Info("Вход в добавление пользователя");
                    View.RenameTitle("Новый пользователь");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void FillingFields()
        {
            try
            {
                logger.Info("Начало заполнения полей пользователя");

                View.SurName = User.SurName;
                View.UserName = User.Name;
                View.MiddleName = User.MiddleName;
                View.Login = User.Login;
                View.UpdatePassword = User.UpdatePassword;
                View.Active = User.Active;

                for (int i = 0; i < User.Roles.Count; i++)
                {
                    for (int j = 0; j < View.DGV.Rows.Count; j++)
                    {
                        if ((View.DGV.Rows[j].DataBoundItem as RoleViewModel).Id == User.Roles[i].Id)
                        {
                            View.DGV.Rows[j].Cells[0].Value = true;
                        }
                    }
                }

                logger.Info("Успешное заполнение полей пользователя");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void FillingDGV()
        {
            try
            {
                logger.Info("Начало заполнения ролей пользователя");
                View.DGV.DataSource = Roles;
                logger.Info("Успешное заполнение ролей пользователя");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Заполнение пользователя
        private void FillingUser()
        {
            try
            {
                logger.Info("Начало заполнения новых данных пользователя");

                User.SurName = View.SurName.Trim();
                User.Name = View.UserName.Trim();
                User.MiddleName = View.MiddleName.Trim();
                User.Login = View.Login.Trim();
                User.Password = View.Password.Trim();
                User.UpdatePassword = View.UpdatePassword;
                User.Active = View.Active;

                List<RoleViewModel> roles = new List<RoleViewModel>();

                for (int i = 0; i < View.DGV.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(View.DGV.Rows[i].Cells[0].Value))
                    {
                        roles.Add(View.DGV.Rows[i].DataBoundItem as RoleViewModel);
                    }
                }

                User.Roles = roles;

                logger.Info("Успешное заполнение новых данных пользователя");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Закрытие формы
        public override void Finish()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(View.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (userManagerService.CheckBadSymbol(View.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(View.UserName))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (userManagerService.CheckBadSymbol(View.UserName))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<>)");
                }
                if (userManagerService.CheckBadSymbol(View.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(View.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (userManagerService.CheckBadSymbol(View.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<>)");
                }

                if (User.Login == null || !String.IsNullOrWhiteSpace(View.Password))
                {
                    if (String.IsNullOrWhiteSpace(View.Password))
                    {
                        throw new Exception("Необходимо заполнить пароль");
                    }
                    if (userManagerService.CheckBadSymbol(View.Password))
                    {
                        throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<>)");
                    }
                    if (View.Password.Trim().Length < 4)
                    {
                        throw new Exception("В пароле минимум 4 символа");
                    }
                }

                if (View.Password != View.ConfrimPassword)
                {
                    throw new Exception("Введеные пароли не совпадают");
                }

                FillingUser();

                View.Cancel = false;
            }
            catch (Exception Ex)
            {
                View.Cancel = true;
                View.Error(Ex.Message);
            }
        }
        #endregion
    }
}
