using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Desktop.Services.Managers.Interfaces
{
    interface IRoleManagerService
    {
        RoleBindingModel FormingBindingModel(RoleViewModel roleModel);
    }
}
