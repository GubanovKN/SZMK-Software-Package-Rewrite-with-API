using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Middleware.Services.Requests
{
    public class UserRequestService : IUserRequestService
    {
        public async Task<UserViewModel> GetMe(string token)
        {
            RequestService<UserViewModel> baseRequestService = new RequestService<UserViewModel>(token);

            return await baseRequestService.GetRequestAsync("api/user/Me");
        }
        public async Task<List<UserViewModel>> GetAll(string token)
        {
            RequestService<List<UserViewModel>> baseRequestService = new RequestService<List<UserViewModel>>(token);

            return await baseRequestService.GetRequestAsync("api/user/All");
        }
        public async Task<bool> Add(string token, UserBindingModel userModel)
        {
            RequestService<bool> baseRequestService = new RequestService<bool>(token);

            StringContent content = new JsonContent<UserBindingModel>().GetContent(userModel);

            return await baseRequestService.PostRequestAsync(content,"api/user/Add");
        }
        public async Task<bool> Edit(string token, UserBindingModel userModel)
        {
            RequestService<bool> baseRequestService = new RequestService<bool>(token);

            StringContent content = new JsonContent<UserBindingModel>().GetContent(userModel);

            return await baseRequestService.PostRequestAsync(content, "api/user/Edit");
        }
        public async Task<bool> UpdatePassword(UpdatePasswordBindingModel updatePasswordModel)
        {
            RequestService<bool> baseRequestService = new RequestService<bool>();

            StringContent content = new JsonContent<UpdatePasswordBindingModel>().GetContent(updatePasswordModel);

            return await baseRequestService.PostRequestAsync(content, "api/user/UpdatePassword");
        }
        public async Task<bool> Delete(string token, UserBindingModel userModel)
        {
            RequestService<bool> baseRequestService = new RequestService<bool>(token);

            StringContent content = new JsonContent<UserBindingModel>().GetContent(userModel);

            return await baseRequestService.PostRequestAsync(content, "api/user/Delete");
        }
    }
}
