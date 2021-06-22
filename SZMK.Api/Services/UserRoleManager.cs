using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Services
{
    public class UserRoleManager
    {
        readonly ApplicationContext context = new ApplicationContext();

        #region Получение
        public async Task<UserRole> Get(int UserId, int RoleId)
        {
            try
            {
                UserRole UserRole = await context.UserRoles.FirstOrDefaultAsync(p => p.UserId == UserId && p.RoleId == RoleId);

                if (UserRole != null)
                {
                    return UserRole;
                }
                else
                {
                    throw new Exception(UserRoleExceptions.StringNotFoundUserRole);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Добавление
        public async Task AddAll(int UserId, List<RoleBindingModel> roles)
        {
            try
            {
                for(int i=0; i < roles.Count; i++)
                {
                    await context.UserRoles.AddAsync(new UserRole
                    {
                        UserId = UserId,
                        RoleId = roles[i].Id
                    });
                }

                await context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Удаление
        public async Task DeleteAll(int UserId)
        {
            try
            {
                context.UserRoles.RemoveRange(context.UserRoles.Where(p => p.UserId == UserId));

                await context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion
    }
}