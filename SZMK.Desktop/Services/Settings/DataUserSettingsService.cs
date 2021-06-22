using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Common;
using SZMK.Desktop.Services.Settings.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Services.Settings
{
    class DataUserSettingsService: IDataUserSettingsService
    {
        public void SaveDataUser(TokensViewModel tokensModel, string salt, bool remember, string login)
        {
            try
            {
                Constants.AccessToken = tokensModel.AccessToken;

                Properties.Auth.Default.RefreshToken = tokensModel.RefreshToken;
                Properties.Auth.Default.Salt = salt;
                Properties.Auth.Default.RememberMe = remember;

                if (remember)
                {
                    Properties.Auth.Default.Login = login;
                }
                else
                {
                    Properties.Auth.Default.Login = "";
                }

                Properties.Auth.Default.Save();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void RefreshDataUser(TokensViewModel tokensModel)
        {
            try
            {
                Constants.AccessToken = tokensModel.AccessToken;

                Properties.Auth.Default.RefreshToken = tokensModel.RefreshToken;

                Properties.Auth.Default.Save();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public void DeleteDataUser()
        {
            try
            {
                Constants.AccessToken = "";

                Properties.Auth.Default.RefreshToken = "";
                Properties.Auth.Default.Salt = "";
                Properties.Auth.Default.Login = "";
                Properties.Auth.Default.RememberMe = false;

                Properties.Auth.Default.Save();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
