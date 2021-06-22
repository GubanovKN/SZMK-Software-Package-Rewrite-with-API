using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;
using SZMK.Desktop.Presenters.Auth;
using SZMK.Desktop.Presenters.Positions.Administrator;
using SZMK.Desktop.Presenters.Shared;
using SZMK.Desktop.Services.Crypto.Interfaces;
using SZMK.Desktop.Services.Settings.Interfaces;
using SZMK.Desktop.Views.Main.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Constants;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Desktop.Presenters.Main
{
    class MainPresenter : BasePresener<IMainView>
    {
        #region Поля
        private readonly Logger logger;

        private readonly IAuthRequestService authRequestService;
        private readonly ICryptoService cryptoService;
        private readonly IDataUserSettingsService dataUserSettingsService;
        private readonly IUserRequestService userRequestService;

        private bool IsLogout = false;
        #endregion

        #region Инициализация презентера
        public MainPresenter(IApplicationController controller, IMainView view, IAuthRequestService authRequestService, ICryptoService cryptoService, IDataUserSettingsService dataUserSettingsService, IUserRequestService userRequestService) : base(controller, view)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                this.authRequestService = authRequestService;
                this.cryptoService = cryptoService;
                this.dataUserSettingsService = dataUserSettingsService;
                this.userRequestService = userRequestService;

                View.Start += () => Start();
                View.Finish += () => Finish();

                View.Logout += () => Logout();

                View.Administrator += () => ViewFunctionAdministator();
                View.AdministratorUsers += () => AdministratorUsers();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск основной формы
        private async void Start()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);
            try
            {
                load.SetStatus("Получение данных пользователя");

                Constants.User = await userRequestService.GetMe(Constants.AccessToken);

                ShowInfoUser();

                ViewCategoty();

                load.SetStatus("Успешное получение данных!");

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

        #region Показ пользователю
        private void ShowInfoUser()
        {
            View.UserName = Constants.User.Login;
        }
        #endregion

        #region Вывод основных категорий в соответсвии с ролями
        private void ViewCategoty()
        {
            try
            {
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.ViewUser) == null)
                {
                    View.AdministratorVisible = false;
                }
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Функции администратора
        private void AdministratorUsers()
        {
            try
            {
                Controller.Create<UsersPresenter>().RunDialog(View.Form);
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        private void ViewFunctionAdministator()
        {
            try
            {
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.ViewUser) != null)
                {
                    View.AdministratorUsersVisible = View.AdministratorDroped;
                }
            }
            catch(Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Выход из учетной записи
        private async void Logout()
        {
            try
            {
                IsLogout = true;

                await DeleteSessionUser();

                LoadAuthForm();

                View.Close();

                logger.Info("Успешный выход из учетной записи");
            }
            catch (Exception Ex)
            {
                IsLogout = false;

                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск формы авторизации
        private void LoadAuthForm()
        {
            try
            {
                Controller.Create<AuthPresenter>().Run();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Выход из программы
        public async new void Finish()
        {
            try
            {
                if (!Properties.Auth.Default.RememberMe && !IsLogout)
                {
                    await DeleteSessionUser();
                }

                View.IsCancel = false;

                View.Close();

                logger.Info("Успешный выход из программы");
            }
            catch (Exception Ex)
            {
                View.IsCancel = true;

                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Удаление данных об учетной записи
        public async Task DeleteSessionUser()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            _ = load.RunDialogAsync(View.Form);

            try
            {
                load.SetStatus("Выход из учетной записи");

                await authRequestService.Logout(new SessionBindingModel { RefreshToken = cryptoService.Encrypt(Properties.Auth.Default.RefreshToken, Properties.Auth.Default.Salt), ClientName = Environment.MachineName });

                dataUserSettingsService.DeleteDataUser();

                load.SetStatus("Успешный выход!");

                load.Finish();
            }
            catch (Exception Ex)
            {
                load.Finish();

                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion
    }
}
