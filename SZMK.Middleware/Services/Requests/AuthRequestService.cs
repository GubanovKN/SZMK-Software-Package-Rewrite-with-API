using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;
using SZMK.Middleware.Services.Requests.Interfaces;

namespace SZMK.Middleware.Services.Requests
{
    public class AuthRequestService : IAuthRequestService
    {
        public async Task<TokensViewModel> GetTokens(LoginBindingModel loginModel)
        {
            RequestService<TokensViewModel> baseRequestService = new RequestService<TokensViewModel>();

            StringContent content = new JsonContent<LoginBindingModel>().GetContent(loginModel);

            return await baseRequestService.PostRequestAsync(content, "api/auth/Tokens");
        }

        public async Task<TokensViewModel> RefreshTokens(SessionBindingModel sessionModel)
        {
            RequestService<TokensViewModel> baseRequestService = new RequestService<TokensViewModel>();

            StringContent content = new JsonContent<SessionBindingModel>().GetContent(sessionModel);

            return await baseRequestService.PostRequestAsync(content, $"api/auth/RefreshTokens");
        }
        public async Task<Boolean> Logout(SessionBindingModel sessionModel)
        {
            RequestService<Boolean> baseRequestService = new RequestService<Boolean>();

            StringContent content = new JsonContent<SessionBindingModel>().GetContent(sessionModel);

            return await baseRequestService.PostRequestAsync(content, $"api/auth/Logout");
        }
        public async Task<List<InfoSessionViewModel>> Logout(InfoSessionBindingModel infoSessionModel)
        {
            RequestService<List<InfoSessionViewModel>> baseRequestService = new RequestService<List<InfoSessionViewModel>>();

            StringContent content = new JsonContent<InfoSessionBindingModel>().GetContent(infoSessionModel);

            return await baseRequestService.PostRequestAsync(content, $"api/auth/LogoutSession");
        }
        public async Task<List<InfoSessionViewModel>> GetSessions(LoginBindingModel loginModel)
        {
            RequestService<List<InfoSessionViewModel>> baseRequestService = new RequestService<List<InfoSessionViewModel>>();

            StringContent content = new JsonContent<LoginBindingModel>().GetContent(loginModel);

            return await baseRequestService.PostRequestAsync(content, $"api/auth/Sessions");
        }
        public async Task<int> GetMaxSessions()
        {
            RequestService<int> baseRequestService = new RequestService<int>();

            return Convert.ToInt32(await baseRequestService.GetRequestAsync($"api/auth/MaxSessions"));
        }
    }
}
