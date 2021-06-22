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
using SZMK.Desktop.Views.Auth.Interfaces;
using SZMK.Domain.BindingModels;

namespace SZMK.Desktop.Presenters.Auth
{
    class UpdatePasswordPresenter : BasePresener<IUpdatePasswordView, UpdatePasswordBindingModel>
    {
        #region Поля
        private readonly Logger logger;

        private UpdatePasswordBindingModel updatePasswordModel;

        private readonly IUserManagerService userManagerService;
        #endregion

        #region Инициализая презентера
        public UpdatePasswordPresenter(IApplicationController controller, IUpdatePasswordView view, IUserManagerService userManagerService) : base(controller, view)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                this.userManagerService = userManagerService;

                View.Start += () => Start();
                View.Finish += () => Finish();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск формы
        public override void Run(UpdatePasswordBindingModel argument)
        {
            updatePasswordModel = argument;
        }

        public override DialogResult RunDialog(UpdatePasswordBindingModel argument, Form owner)
        {
            updatePasswordModel = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public override async Task<DialogResult> RunDialogAsync(UpdatePasswordBindingModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return DialogResult.OK;
            }
            else
            {
                updatePasswordModel = argument;
                SetOwner(owner);
                return View.ShowDialog();

            }
        }
        private void Start()
        {
            try
            {
                View.OldPassword = updatePasswordModel.OldPassword;
            }
            catch (Exception Ex)
            {
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

        #region Заполнение данных
        private void FillingData()
        {
            try
            {
                logger.Info("Начато заполнение данных о новом пароле");

                updatePasswordModel.OldPassword = View.OldPassword;
                updatePasswordModel.NewPassword = View.NewPassword;

                logger.Info("Успешное заполнение данных о новом пароле");
            }
            catch(Exception Ex)
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
                if (String.IsNullOrWhiteSpace(View.OldPassword))
                {
                    throw new Exception("Необходимо заполнить старый пароль");
                }
                if (userManagerService.CheckBadSymbol(View.OldPassword))
                {
                    throw new Exception("При заполнеии старого пароля нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(View.NewPassword))
                {
                    throw new Exception("Необходимо заполнить новый пароль");
                }
                if (userManagerService.CheckBadSymbol(View.NewPassword))
                {
                    throw new Exception("При заполнеии нового пароля нельзя использовать (_\\/*:?|\"<>)");
                }
                if (View.NewPassword.Trim().Length < 4)
                {
                    throw new Exception("В новом пароле минимум 4 символа");
                }

                if (View.NewPassword != View.ConfrimPassword)
                {
                    throw new Exception("Введеные новые пароли не совпадают");
                }

                FillingData();

                View.Cancel = false;
            }
            catch (Exception Ex)
            {
                View.Cancel = true;
                View.Error(Ex.Message);
            }
            View.Close();
        }
        #endregion
    }
}
