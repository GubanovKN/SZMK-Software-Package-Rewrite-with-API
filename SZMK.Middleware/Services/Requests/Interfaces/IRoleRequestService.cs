using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.ViewModels;

namespace SZMK.Middleware.Services.Requests.Interfaces
{
    public interface IRoleRequestService
    {
        Task<List<RoleViewModel>> GetAll(string token);
    }
}
