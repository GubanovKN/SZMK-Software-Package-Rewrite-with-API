using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Services.Settings.Interfaces
{
    interface IDataUserSettingsService
    {
        void SaveDataUser(TokensViewModel tokensModel, string salt, bool remember, string login);
        void RefreshDataUser(TokensViewModel tokensModel);
        void DeleteDataUser();
    }
}
