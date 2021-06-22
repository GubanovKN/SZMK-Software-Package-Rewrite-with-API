using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;
using SZMK.Desktop.Common;
using SZMK.Desktop.Presenters.Main;
using SZMK.Desktop.Presenters.Shared;
using SZMK.Desktop.Services.Crypto.Interfaces;
using SZMK.Desktop.Services.Settings.Interfaces;
using SZMK.Desktop.Views.Auth.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Exceptions;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Desktop.Presenters.Auth
{
    class AuthPresenter : BasePresener<IAuthView>
    {
        #region Поля
        private int CountSeconds;
        private System.Timers.Timer timer;
        private bool StopAutoLogin = false;
        private readonly Logger logger;

        private readonly IAuthRequestService authRequestService;
        private readonly IUserRequestService userRequestService;
        private readonly ICryptoService cryptoService;
        private readonly IDataUserSettingsService dataUserSettingsService;
        #endregion

        #region Инициализая презентера
        public AuthPresenter(IApplicationController controller, IAuthView view, IAuthRequestService authRequestService, IUserRequestService userRequestService, ICryptoService cryptoService, IDataUserSettingsService dataUserSettingsService) : base(controller, view)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                timer = new System.Timers.Timer(1000);

                this.authRequestService = authRequestService;
                this.userRequestService = userRequestService;
                this.cryptoService = cryptoService;
                this.dataUserSettingsService = dataUserSettingsService;

                View.Start += () => Start();
                View.Login += () => Login();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск формы
        private async void Start()
        {
            try
            {
                if (Properties.Auth.Default.RememberMe)
                {
                    View.BlockFields(true);
                    View.UserName = Properties.Auth.Default.Login;

                    await Task.Run(() => WaitingAutoLogin());

                    if (!StopAutoLogin)
                    {
                        await AutoLogin();
                    }
                    else
                    {
                        await DeleteSessionUser();
                        View.BlockFields(false);
                        View.SetNameLogin_B($"Войти");
                    }
                }
            }
            catch (Exception Ex)
            {
                View.SetNameLogin_B($"Войти");
                View.BlockFields(false);
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Автоматическая авторизация
        private void WaitingAutoLogin()
        {
            try
            {
                CountSeconds = 5;

                View.SetNameLogin_B($"Отмена({CountSeconds})");

                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                while (CountSeconds > 0)
                {
                    if (StopAutoLogin)
                    {
                        break;
                    }
                }

                timer.Stop();

                logger.Info("Ожидание автоматической авторизации успешно пройдено");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                CountSeconds--;

                View.SetNameLogin_B($"Отмена({CountSeconds})");

                Thread.Sleep(1000);
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }

        private async Task AutoLogin()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);
            try
            {
                load.SetStatus("Авторизация пользователя");

                TokensViewModel tokens = await authRequestService.RefreshTokens(new SessionBindingModel { RefreshToken = cryptoService.Encrypt(Properties.Auth.Default.RefreshToken, Properties.Auth.Default.Salt), ClientName = Environment.MachineName });

                dataUserSettingsService.RefreshDataUser(tokens);

                load.SetStatus("Пользователь авторизован");
                load.Finish();
                await flag;

                LoadMainForm();

                View.Close();

                logger.Info("Автоматическая авторизация успешно пройдена");
            }
            catch (NeedUpdatePasswordException Ex)
            {
                load.Finish();
                await flag;

                View.Error(Ex.Message);

                await UpdatePassword();

                View.Password = "";
            }
            catch (Exception Ex)
            {
                load.Finish();
                await flag;

                dataUserSettingsService.DeleteDataUser();

                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Авторизация
        private async void Login()
        {
            if (!timer.Enabled)
            {
                LoadPresenter load = Controller.Create<LoadPresenter>();
                var flag = load.RunDialogAsync(View.Form);

                try
                {
                    load.SetStatus("Авторизация пользователя");

                    string Salt = cryptoService.GetSalt(6);

                    TokensViewModel tokens = await authRequestService.GetTokens(new LoginBindingModel { Login = View.UserName, Password = View.Password, Salt = Salt, ClientName = Environment.MachineName });

                    dataUserSettingsService.SaveDataUser(tokens, Salt, View.Remember, View.UserName);

                    load.SetStatus("Пользователь авторизован");
                    load.Finish();
                    await flag;

                    LoadMainForm();

                    View.Close();

                    logger.Info("Авторизация успешно пройдена");
                }
                catch (OutOfRangeSessionsException Ex)
                {
                    load.Finish();
                    await flag;

                    View.Error(Ex.Message);

                    DeleteSession();

                    View.Password = "";
                }
                catch (NeedUpdatePasswordException Ex)
                {
                    load.Finish();
                    await flag;

                    View.Error(Ex.Message);

                    await UpdatePassword();

                    View.Password = "";
                }
                catch (Exception Ex)
                {
                    load.Finish();
                    await flag;

                    View.Password = "";
                    View.Error(Ex.Message);
                }
            }
            else
            {
                StopAutoLogin = true;
            }
        }
        #endregion

        #region Ошибки авторизации
        private void DeleteSession()
        {
            try
            {
                Controller.Create<DeleteSessionsPresenter, LoginBindingModel>().RunDialog(new LoginBindingModel { Login = View.UserName, Password = View.Password }, View.Form);
            }
            catch(Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        private async Task UpdatePassword()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            try
            {
                UpdatePasswordBindingModel updatePasswordModel = new UpdatePasswordBindingModel { Login = View.UserName, OldPassword = View.Password };

                if (Controller.Create<UpdatePasswordPresenter, UpdatePasswordBindingModel>().RunDialog(updatePasswordModel, View.Form) == System.Windows.Forms.DialogResult.OK)
                {
                    _ = load.RunDialogAsync(View.Form);

                    load.SetStatus("Изменение пароля пользователя");

                    await userRequestService.UpdatePassword(updatePasswordModel);

                    load.SetStatus("Успешное изменение пароля");

                    load.Finish();
                }
            }
            catch(Exception Ex)
            {
                load.Finish();

                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск основной формы
        private void LoadMainForm()
        {
            try
            {
                Controller.Create<MainPresenter>().Run();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Удаление данных об учетной записи
        public async Task DeleteSessionUser()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                load.SetStatus("Выход из учетной записи");

                await authRequestService.Logout(new SessionBindingModel { RefreshToken = cryptoService.Encrypt(Properties.Auth.Default.RefreshToken, Properties.Auth.Default.Salt), ClientName = Environment.MachineName });

                dataUserSettingsService.DeleteDataUser();

                load.SetStatus("Успешный выход!");

                load.Finish();
                await flag;
            }
            catch (Exception Ex)
            {
                load.Finish();
                await flag;

                View.Error(Ex.Message);
            }
        }
        #endregion
    }
}
