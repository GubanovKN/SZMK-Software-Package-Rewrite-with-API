using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Domain.ViewModels;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Services
{
    public class RoleManager
    {
        readonly ApplicationContext context = new ApplicationContext();

        #region Получение
        public async Task<List<Role>> GetRoles(string username)
        {
            try
            {
                List<Role> Roles = new List<Role>();

                User user = await new UserManager().GetByLogin(username);

                foreach (UserRole userRole in user.UserRoles)
                {
                    Role role = await context.Roles.FirstOrDefaultAsync(p => p.Id == userRole.RoleId);
                    if (role != null)
                    {
                        Roles.Add(role);
                    }
                    else
                    {
                        throw new Exception(RoleExceptions.StringNotFoundRole);
                    }
                }

                return Roles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public List<Role> GetAll()
        {
            try
            {
                List<Role> roles = context.Roles.ToList();

                return roles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Дополнительные методы
        public RoleViewModel FormingViewModel(Role role)
        {
            try
            {
                if (role != null)
                {
                    return new RoleViewModel
                    {
                        Id = role.Id,
                        Name = role.Name
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