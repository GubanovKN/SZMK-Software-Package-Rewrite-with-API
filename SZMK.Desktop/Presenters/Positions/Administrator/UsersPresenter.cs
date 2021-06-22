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
using SZMK.Domain.BindingModels;
using SZMK.Domain.Constants;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Desktop.Presenters.Positions.Administrator
{
    class UsersPresenter : BasePresener<IUsersView>
    {
        #region Поля
        private readonly Logger logger;

        List<UserViewModel> Users;

        private readonly IUserRequestService userRequestService;
        private readonly IUserManagerService userManagerService;
        #endregion

        #region Инициализация презентера
        public UsersPresenter(IApplicationController controller, IUsersView view, IUserRequestService userRequestService, IUserManagerService userManagerService) : base(controller, view)
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();

                this.userRequestService = userRequestService;
                this.userManagerService = userManagerService;

                View.Start += () => Start();

                View.Main += () => ViewFunctionalMain();
                View.MainEdit += () => MainEdit();
                View.MainAdd += () => MainAdd();
                View.MainDelete += () => MainDelete();
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Запуск формы работы с пользователями
        private async void Start()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);
            try
            {
                load.SetStatus("Получение данных пользователей");

                ViewCategoty();

                await Refresh();

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

        #region Вывод основных категорий в соответсвии с ролями
        private void ViewCategoty()
        {
            try
            {
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.AddUser|| p.Name == RolesConstants.EditUser|| p.Name == RolesConstants.DeleteUser) == null)
                {
                    View.MainVisible = false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Основной функционал
        private async void MainAdd()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            try
            {
                UserViewModel user = new UserViewModel();
                if (Controller.Create<UserPresenter, UserViewModel>().RunDialog(user, View.Form) == System.Windows.Forms.DialogResult.OK)
                {
                    logger.Info("Начало добавление пользователя " + user.Login);

                    _ = load.RunDialogAsync(View.Form);

                    load.SetStatus("Добавление пользователя");

                    await userRequestService.Add(Constants.AccessToken, userManagerService.FormingBindingModel(user));

                    load.SetStatus("Добавление успешно пройдено!");

                    load.SetStatus("Получение данных пользователей");

                    await Refresh();

                    load.SetStatus("Успешное получение данных!");

                    load.Finish();

                    logger.Info("Успешное добавление пользователя " + user.Login);
                }
            }
            catch (Exception Ex)
            {
                load.Finish();

                View.Error(Ex.Message);
            }
        }
        private async void MainEdit()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            try
            {
                if (View.DGV.CurrentCell != null && View.DGV.CurrentCell.RowIndex >= 0 && View.DGV.SelectedRows.Count == 1)
                {
                    if (View.DGV.SelectedRows[0].DataBoundItem is UserViewModel user && user.Login != Constants.User.Login && user.Login != UserConstants.MainAdministator)
                    {
                        if (Controller.Create<UserPresenter, UserViewModel>().RunDialog(user, View.Form) == System.Windows.Forms.DialogResult.OK)
                        {
                            logger.Info("Начало изменения пользователя " + user.Login);

                            _ = load.RunDialogAsync(View.Form);

                            load.SetStatus("Добавление пользователя");

                            await userRequestService.Edit(Constants.AccessToken, userManagerService.FormingBindingModel(user));

                            load.SetStatus("Добавление успешно пройдено!");

                            load.SetStatus("Получение данных пользователей");

                            await Refresh();

                            load.SetStatus("Успешное получение данных!");

                            load.Finish();

                            logger.Info("Успешное изменение пользователя " + user.Login);
                        }
                    }
                    else
                    {
                        View.Error("Не корректный пользователь для изменения:" + Environment.NewLine + "Нельзя изменять текущего пользователя и корневого администратора");
                    }
                }
                else
                {
                    View.Error("Не выбран пользователь для изменения");
                }
            }
            catch (Exception Ex)
            {
                load.Finish();

                View.Error(Ex.Message);
            }
        }
        private async void MainDelete()
        {
            LoadPresenter load = Controller.Create<LoadPresenter>();
            try
            {
                if (View.DGV.CurrentCell != null && View.DGV.CurrentCell.RowIndex >= 0 && View.DGV.SelectedRows.Count == 1)
                {
                    if (View.DGV.SelectedRows[0].DataBoundItem is UserViewModel user && user.Login != Constants.User.Login && user.Login != UserConstants.MainAdministator)
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить пользователя?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            logger.Info("Начало удаления пользователя " + user.Login);

                            _ = load.RunDialogAsync(View.Form);

                            load.SetStatus("Добавление пользователя");

                            await userRequestService.Delete(Constants.AccessToken, userManagerService.FormingBindingModel(user));

                            load.SetStatus("Добавление успешно пройдено!");

                            load.SetStatus("Получение данных пользователей");

                            await Refresh();

                            load.SetStatus("Успешное получение данных!");

                            load.Finish();

                            logger.Info("Успешное удаление пользователя " + user.Login);
                        }
                    }
                    else
                    {
                        View.Error("Не корректный пользователь для удаления:" + Environment.NewLine + "Нельзя удалять текущего пользователя и корневого администратора");
                    }
                }
                else
                {
                    View.Error("Не выбран пользователь для изменения");
                }
            }
            catch (Exception Ex)
            {
                load.Finish();

                View.Error(Ex.Message);
            }
        }
        private void ViewFunctionalMain()
        {
            try
            {
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.AddUser) != null)
                {
                    View.MainAddVisible = View.MainDroped;
                }
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.EditUser) != null)
                {
                    View.MainEditVisible = View.MainDroped;
                }
                if (Constants.User.Roles.FirstOrDefault(p => p.Name == RolesConstants.DeleteUser) != null)
                {
                    View.MainDeleteVisible = View.MainDroped;
                }
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        #endregion

        #region Обновление данных
        private async Task Refresh()
        {

            try
            {
                logger.Info("Начало обновления данных пользовтелей");

                Users = await userRequestService.GetAll(Constants.AccessToken);

                View.DGV.DataSource = null;
                View.DGV.DataSource = Users;

                logger.Info("Успешное обновление данных пользовтелей");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion
    }
}
