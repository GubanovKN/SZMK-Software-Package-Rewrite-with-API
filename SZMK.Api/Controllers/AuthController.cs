using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SZMK.Api.Services;
using SZMK.Domain.BindingModels;
using SZMK.Infrastructure.Cryptography;
using SZMK.Domain.Models;
using SZMK.Infrastructure.Data;
using SZMK.Api.Filters;
using System.Web;
using System.Configuration;
using SZMK.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using SZMK.Domain.Models.Response;
using System.ServiceModel.Channels;

namespace SZMK.Api.Controllers
{
    [JwtAuthentication]
    public class AuthController : ApiController
    {
        readonly ApplicationContext context = new ApplicationContext();

        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/Tokens")]
        public async Task<HttpResponseMessage> GetToken([FromBody] LoginBindingModel loginModel)
        {
            try
            {

                await CheckUser(loginModel.Login, loginModel.Password);

                TokensViewModel tokens = JwtManager.GenerateTokens(loginModel.Login, loginModel.Salt);
                if (await new SessionManager().AddSession(tokens, loginModel, GetClientIp()))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, tokens);
                }
                else
                {
                    throw new Exception("Ошибка добавления сессии пользоваетля");
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, Ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/RefreshTokens")]
        public async Task<HttpResponseMessage> GetToken([FromBody] SessionBindingModel sessionModel)
        {
            try
            {
                TokensViewModel token = await new SessionManager().RefreshSession(sessionModel, GetClientIp());
                if (token != null)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, token);
                }
                else
                {
                    throw new Exception("Ошибка обновления токенов пользователя");
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, Ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/Logout")]
        public async Task<HttpResponseMessage> Logout([FromBody] SessionBindingModel sessionModel)
        {
            try
            {
                if (await new SessionManager().DeleteSession(sessionModel))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
                }
                else
                {
                    throw new Exception("Ошибка удаления сессии");
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/LogoutSession")]
        public async Task<HttpResponseMessage> Logout([FromBody] InfoSessionBindingModel infoSessionModel)
        {
            try
            {
                await CheckUser(infoSessionModel.Login, infoSessionModel.Password);

                if (await new SessionManager().DeleteSession(infoSessionModel))
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, await new SessionManager().GetSessions(infoSessionModel.Login));
                }
                else
                {
                    throw new Exception("Ошибка удаления сессии");
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/Sessions")]
        public async Task<HttpResponseMessage> GetSessions([FromBody] LoginBindingModel loginModel)
        {
            try
            {
                await CheckUser(loginModel.Login, loginModel.Password);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, await new SessionManager().GetSessions(loginModel.Login));
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, Ex.Message);
            }
        }
        private string GetClientIp(HttpRequestMessage request = null)
        {
            try
            {
                request = request ?? Request;

                if (request.Properties.ContainsKey("MS_HttpContext"))
                {
                    return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                }
                else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                {
                    RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                    return prop.Address;
                }
                else if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        private async Task CheckUser(string username, string password)
        {
            try
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Login == username);

                if (user != null)
                {
                    if (user.Active)
                    {
                        if (user.CountFailEnter < 5)
                        {
                            if (user.Password == new Hasher().GetHash(password, user.Salt))
                            {
                                if (!user.UpdatePassword)
                                {
                                    user.CountFailEnter = 0;
                                    await context.SaveChangesAsync();
                                }
                                else
                                {
                                    throw new Exception(UserExceptions.StringNeedUpdatePassword);
                                }
                            }
                            else
                            {
                                user.CountFailEnter++;
                                await context.SaveChangesAsync();
                                throw new Exception(UserExceptions.StringBadPassword);
                            }
                        }
                        else
                        {
                            user.Active = false;
                            await context.SaveChangesAsync();
                            throw new Exception(UserExceptions.StringOutOfRangeEnter);
                        }
                    }
                    else
                    {
                        throw new Exception(UserExceptions.StringInactive);
                    }
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
    }
}
