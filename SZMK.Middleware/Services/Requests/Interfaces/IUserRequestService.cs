using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.ViewModels;

namespace SZMK.Middleware.Services.Requests.Interfaces
{
    public interface IUserRequestService
    {
        Task<UserViewModel> GetMe(string token);
        Task<List<UserViewModel>> GetAll(string token);
        Task<bool> Add(string token, UserBindingModel userModel);
        Task<bool> Edit(string token, UserBindingModel userModel);
        Task<bool> UpdatePassword(UpdatePasswordBindingModel updatePasswordModel);
        Task<bool> Delete(string token, UserBindingModel userModel);
    }
}
