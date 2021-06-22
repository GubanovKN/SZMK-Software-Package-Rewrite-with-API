using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Domain.ViewModels;
using SZMK.Infrastructure.Cryptography;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Services
{
    public class UserManager
    {
        readonly ApplicationContext context = new ApplicationContext();

        #region Получение
        public async Task<User> GetByLogin(string username)
        {
            try
            {
                User user = await context.Users.Include(p => p.RefreshSessions).Include(p => p.UserRoles).FirstOrDefaultAsync(p => p.Login == username);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception(UserExceptions.StringNotFoundUser);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public async Task<User> GetById(int Id)
        {
            try
            {
                User user = await context.Users.Include(p => p.RefreshSessions).Include(p => p.UserRoles).FirstOrDefaultAsync(p => p.Id == Id);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception(UserExceptions.StringNotFoundUser);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<User> GetAll()
        {
            try
            {
                List<User> users = context.Users.ToList();

                return users;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Добавление
        public async Task Add(UserBindingModel userModel)
        {
            try
            {
                CheckedBadFieldsPreAdd(userModel);

                byte[] Salt = new Hasher().GetSalt();

                await context.Users.AddAsync(new User
                {
                    DateCreate = DateTime.Now,
                    SurName = userModel.SurName,
                    Name = userModel.Name,
                    MiddleName = userModel.MiddleName,
                    Login = userModel.Login,
                    Salt = Salt,
                    Password = new Hasher().GetHash(userModel.Password, Salt),
                    UpdatePassword = userModel.UpdatePassword,
                    Active = userModel.Active,
                    CountFailEnter = 0
                });      

                await context.SaveChangesAsync();

                User user = await GetByLogin(userModel.Login);

                await new UserRoleManager().AddAll(user.Id, userModel.Roles);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Изменение
        public async Task Edit(UserBindingModel userModel)
        {
            try
            {
                CheckedBadFieldsPreEdit(userModel);

                User user = await GetById(userModel.Id);

                if (!user.Active && userModel.Active)
                {
                    user.CountFailEnter = 0;
                }

                if (!String.IsNullOrEmpty(userModel.Password))
                {
                    user.SurName = userModel.SurName;
                    user.Name = userModel.Name;
                    user.MiddleName = userModel.MiddleName;
                    user.Login = userModel.Login;
                    user.Password = new Hasher().GetHash(userModel.Password, user.Salt);
                    user.UpdatePassword = userModel.UpdatePassword;
                    user.Active = userModel.Active;
                }
                else
                {
                    user.SurName = userModel.SurName;
                    user.Name = userModel.Name;
                    user.MiddleName = userModel.MiddleName;
                    user.Login = userModel.Login;
                    user.UpdatePassword = userModel.UpdatePassword;
                    user.Active = userModel.Active;
                }

                await context.SaveChangesAsync();

                await new UserRoleManager().DeleteAll(user.Id);
                await new UserRoleManager().AddAll(user.Id, userModel.Roles);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public async Task UpdatePassword(UpdatePasswordBindingModel updatePasswordModel)
        {
            try
            {
                CheckBadFieldPreUpdatePassword(updatePasswordModel);

                User user = await GetByLogin(updatePasswordModel.Login);

                user.Password = new Hasher().GetHash(updatePasswordModel.NewPassword, user.Salt);

                user.UpdatePassword = false;

                await context.SaveChangesAsync();
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Удаление
        public async Task Delete(UserBindingModel userModel)
        {
            try
            {
                CheckedBadFieldsPreDelete(userModel);

                User user = await GetById(userModel.Id);

                context.Users.Remove(user);

                await context.SaveChangesAsync();

                await new UserRoleManager().DeleteAll(user.Id);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        } 
        #endregion

        #region Проверки
        private void CheckedBadFieldsPreAdd(UserBindingModel userModel)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(userModel.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (CheckBadSymbol(userModel.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<> )");
                }
                if (String.IsNullOrWhiteSpace(userModel.Name))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (CheckBadSymbol(userModel.Name))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<> )");
                }
                if (CheckBadSymbol(userModel.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<> )");
                }
                if (String.IsNullOrWhiteSpace(userModel.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (CheckBadSymbol(userModel.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<> )");
                }
                if (String.IsNullOrWhiteSpace(userModel.Password))
                {
                    throw new Exception("Необходимо заполнить пароль");
                }
                if (CheckBadSymbol(userModel.Password))
                {
                    throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
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
        private void CheckedBadFieldsPreEdit(UserBindingModel userModel)
        {
            try
            {
                if (userModel.Id < 1)
                {
                    throw new Exception("Не корректный id пользователя для изменения");
                }
                if (String.IsNullOrWhiteSpace(userModel.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (CheckBadSymbol(userModel.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<> )");
                }
                if (String.IsNullOrWhiteSpace(userModel.Name))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (CheckBadSymbol(userModel.Name))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<> )");
                }
                if (CheckBadSymbol(userModel.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<> )");
                }
                if (String.IsNullOrWhiteSpace(userModel.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (CheckBadSymbol(userModel.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<> )");
                }
                if (!String.IsNullOrEmpty(userModel.Password))
                {
                    if (String.IsNullOrWhiteSpace(userModel.Password))
                    {
                        throw new Exception("Необходимо заполнить пароль");
                    }
                    if (CheckBadSymbol(userModel.Password))
                    {
                        throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
                    }
                    if (userModel.Password.Trim().Length < 4)
                    {
                        throw new Exception("В пароле минимум 4 символа");
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckedBadFieldsPreDelete(UserBindingModel userModel)
        {
            try
            {
                if (userModel.Id < 1)
                {
                    throw new Exception("Не корректный id пользователя для удаления");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private void CheckBadFieldPreUpdatePassword(UpdatePasswordBindingModel updatePasswordModel)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(updatePasswordModel.NewPassword))
                {
                    throw new Exception("Необходимо заполнить пароль");
                }
                if (CheckBadSymbol(updatePasswordModel.NewPassword))
                {
                    throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
                }
                if (updatePasswordModel.NewPassword.Trim().Length < 4)
                {
                    throw new Exception("В пароле минимум 4 символа");
                }
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private bool CheckBadSymbol(string Message)
        {
            if (Message.IndexOf('_') != -1 || Message.IndexOf('\'') != -1 || Message.IndexOf('/') != -1 || Message.IndexOf('*') != -1 || Message.IndexOf(':') != -1 || Message.IndexOf('?') != -1 || Message.IndexOf('|') != -1 || Message.IndexOf('"') != -1 || Message.IndexOf('<') != -1 || Message.IndexOf('>') != -1 || Message.IndexOf(' ') != -1)
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
        public async Task<UserViewModel> FormingViewModel(User user)
        {
            try
            {
                if (user != null)
                {
                    List<RoleViewModel> roleModels = new List<RoleViewModel>();

                    List<Role> Roles = await new RoleManager().GetRoles(user.Login);

                    for (int i = 0; i < Roles.Count; i++)
                    {
                        roleModels.Add(new RoleManager().FormingViewModel(Roles[i]));
                    }

                    return new UserViewModel
                    {
                        Id = user.Id,
                        DateCreate = user.DateCreate,
                        SurName = user.SurName,
                        Name = user.Name,
                        MiddleName = user.MiddleName,
                        Login = user.Login,
                        UpdatePassword = user.UpdatePassword,
                        Active = user.Active,
                        Roles = roleModels
                    };
                }
                else
                {
                    throw new Exception(UserExceptions.StringNotFoundUser);
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