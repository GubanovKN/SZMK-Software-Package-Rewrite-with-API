using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Middleware.Services.Requests
{
    public class RoleRequestService : IRoleRequestService
    {
        public async Task<List<RoleViewModel>> GetAll(string token)
        {
            RequestService<List<RoleViewModel>> baseRequestService = new RequestService<List<RoleViewModel>>(token);

            return await baseRequestService.GetRequestAsync("api/role/All");
        }
    }
}
