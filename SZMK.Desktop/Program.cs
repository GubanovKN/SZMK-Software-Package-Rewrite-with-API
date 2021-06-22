using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZMK.Desktop.Common;

namespace SZMK.Desktop
{
    static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ru-RU");
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            var controller = new ApplicationController(new LightInjectAdapter())
                        .RegisterView<Views.Auth.Interfaces.IAuthView, Views.Auth.AuthView>()
                        .RegisterView<Views.Auth.Interfaces.IDeleteSessionsView,Views.Auth.DeleteSessionsView>()
                        .RegisterView<Views.Auth.Interfaces.IUpdatePasswordView,Views.Auth.UpdatePasswordView>()
                        .RegisterService<Services.Crypto.Interfaces.ICryptoService, Services.Crypto.CryptoService>()
                        .RegisterService<Middleware.Services.Requests.Interfaces.IAuthRequestService,Middleware.Services.Requests.AuthRequestService>()
                        .RegisterService<Services.Settings.Interfaces.IDataUserSettingsService,Services.Settings.DataUserSettingsService>()
                        .RegisterView<Views.Main.Interfaces.IMainView,Views.Main.MainView>()
                        .RegisterService<Middleware.Services.Requests.Interfaces.IUserRequestService, Middleware.Services.Requests.UserRequestService>()
                        .RegisterView<Views.Positions.Administrator.Interfaces.IUsersView,Views.Positions.Administrator.UsersView>()
                        .RegisterService<Services.Managers.Interfaces.IUserManagerService, Services.Managers.UserManagerService>()
                        .RegisterService<Services.Managers.Interfaces.IRoleManagerService, Services.Managers.RoleManagerService>()
                        .RegisterView<Views.Positions.Administrator.Interfaces.IUserView, Views.Positions.Administrator.UserView>()
                        .RegisterService<Middleware.Services.Requests.Interfaces.IRoleRequestService, Middleware.Services.Requests.RoleRequestService>()
                        .RegisterView<Views.Shared.Interfaces.ILoadView, Views.Shared.LoadView>()
                        .RegisterInstance(new ApplicationContext());

            controller.Create<Presenters.Auth.AuthPresenter>().Run();
        }
    }
}
