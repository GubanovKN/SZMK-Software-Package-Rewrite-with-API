using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;

namespace SZMK.Middleware.Services.Requests.Interfaces
{
    public interface IAuthRequestService
    {
        Task<TokensViewModel> GetTokens(LoginBindingModel loginModel);
        Task<TokensViewModel> RefreshTokens(SessionBindingModel sessionModel);
        Task<Boolean> Logout(SessionBindingModel sessionModel);
        Task<List<InfoSessionViewModel>> Logout(InfoSessionBindingModel infoSessionModel);
        Task<List<InfoSessionViewModel>> GetSessions(LoginBindingModel loginModel);
        Task<int> GetMaxSessions();
    }
}
