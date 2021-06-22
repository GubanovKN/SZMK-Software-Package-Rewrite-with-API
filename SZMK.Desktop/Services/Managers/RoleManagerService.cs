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
    public class RoleManagerService : IRoleManagerService
    {
        #region Дополнительные методы
        public RoleBindingModel FormingBindingModel(RoleViewModel roleModel)
        {
            try
            {
                if (roleModel != null)
                {
                    return new RoleBindingModel
                    {
                        Id = roleModel.Id,
                        Name = roleModel.Name
                    };
                }
                else
                {
                    throw new Exception("Пустое значение роли");
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
