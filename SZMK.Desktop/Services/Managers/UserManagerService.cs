using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Services.Managers.Interfaces;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Services.Managers
{
    public class UserManagerService : IUserManagerService
    {
        #region Проверки
        public void CheckedBadFields(UserViewModel userModel)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(userModel.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (CheckBadSymbol(userModel.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(userModel.Name))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (CheckBadSymbol(userModel.Name))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<>)");
                }
                if (CheckBadSymbol(userModel.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(userModel.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (CheckBadSymbol(userModel.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<>)");
                }
                if (String.IsNullOrWhiteSpace(userModel.Password))
                {
                    throw new Exception("Необходимо заполнить пароль");
                }
                if (CheckBadSymbol(userModel.Password))
                {
                    throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<>)");
                }
                if (userModel.Password.Trim().Length < 4)
                {
                    throw new Exception("В пароле минимум 4 символа");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public bool CheckBadSymbol(string Message)
        {
            if (Message.IndexOf('_') != -1 || Message.IndexOf('\'') != -1 || Message.IndexOf('/') != -1 || Message.IndexOf('*') != -1 || Message.IndexOf(':') != -1 || Message.IndexOf('?') != -1 || Message.IndexOf('|') != -1 || Message.IndexOf('"') != -1 || Message.IndexOf('<') != -1 || Message.IndexOf('>') != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Дополнительные методы
        public UserBindingModel FormingBindingModel(UserViewModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    List<RoleBindingModel> roles = new List<RoleBindingModel>();

                    for(int i=0; i < userModel.Roles.Count; i++)
                    {
                        roles.Add(new RoleManagerService().FormingBindingModel(userModel.Roles[i]));
                    }

                    return new UserBindingModel
                    {
                        Id = userModel.Id,
                        SurName = userModel.SurName,
                        Name = userModel.Name,
                        MiddleName = userModel.MiddleName,
                        Login = userModel.Login,
                        Password = userModel.Password,
                        UpdatePassword = userModel.UpdatePassword,
                        Active = userModel.Active,
                        Roles = roles
                    };
                }
                else
                {
                    throw new Exception("Пустое значение пользоваетля");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion
    }
}
