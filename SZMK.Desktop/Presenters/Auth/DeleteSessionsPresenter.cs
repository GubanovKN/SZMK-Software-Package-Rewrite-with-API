using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;
using SZMK.Desktop.Presenters.Shared;
using SZMK.Desktop.Views.Auth.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Desktop.Presenters.Auth
{
    class DeleteSessionsPresenter : BasePresener<IDeleteSessionsView, LoginBindingModel>
    {
        #region Поля
        private readonly Logger logger;

        private LoginBindingModel loginModel;
        private List<InfoSessionViewModel> sessions;

        private readonly IAuthRequestService authRequestService;
        #endregion

        #region Инициализая презентера
        public DeleteSessionsPresenter(IApplicationController controller, IDeleteSessionsView view, IAuthRequestService authRequestService) : base(controller, view)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                this.authRequestService = authRequestService;

                View.Start += () => Start();
                View.Delete += () => Delete();
                View.Finish += () => Finish();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск формы
        public override void Run(LoginBindingModel argument)
        {
            loginModel = argument;
        }

        public override DialogResult RunDialog(LoginBindingModel argument, Form owner)
        {
            loginModel = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public override async Task<DialogResult> RunDialogAsync(LoginBindingModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return DialogResult.OK;
            }
            else
            {
                loginModel = argument;
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
                load.SetStatus("Получение сессий");

                sessions = await authRequestService.GetSessions(loginModel);

                load.SetStatus("Отображение сессий");

                View.ShowSessions(sessions);

                load.SetStatus("Успешный Отображение сессий");

                load.Finish();
                await flag;

                logger.Info($"Форма удаления сессий успешно запущена");
            }
            catch (Exception Ex)
            {
                load.Finish();
                await flag;

                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Изменение владельца формы
        public override void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }
        #endregion

        #region Работа с сессиями
        private async void Delete()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);
            try
            {
                load.SetStatus("Удаление сессии");

                sessions = await authRequestService.Logout(new InfoSessionBindingModel { Login = loginModel.Login, Password = loginModel.Password, ClientName = View.Session.ClientName, IP = View.Session.IP, RefreshToken = View.Session.RefreshToken });
                View.Session = null;
                View.ShowSessions(sessions);

                load.SetStatus("Успешное удаление сессии");

                load.Finish();
                await flag;

                logger.Info($"Удаление сессии успешно пройдено");
            }
            catch (Exception Ex)
            {
                load.Finish();
                await flag;

                View.Session = null;
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Закрытие формы
        public override void Finish()
        {
            View.Close();
        }
        #endregion
    }
}
