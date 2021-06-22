using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SZMK.Api.Filters;
using SZMK.Api.Services;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Constants;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Domain.ViewModels;
using SZMK.Infrastructure.Cryptography;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Controllers
{
    [JwtAuthentication]
    public class UserController : ApiController
    {
        readonly ApplicationContext context = new ApplicationContext();

        [HttpGet()]
        [Route("api/user/Me")]
        public async Task<HttpResponseMessage> GetMe()
        {
            try
            {
                User user = await new UserManager().GetByLogin(JwtManager.GetPrincipal(Request.Headers.Authorization.Parameter).Identity.Name);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, await new UserManager().FormingViewModel(user));
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpGet()]
        [Route("api/user/All")]
        [JwtAuthentication(Roles = RolesConstants.ViewUser)]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                List<UserViewModel> userModels = new List<UserViewModel>();

                List<User> users = new UserManager().GetAll();

                for (int i = 0; i < users.Count; i++)
                {
                    userModels.Add(await new UserManager().FormingViewModel(users[i]));
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, userModels);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpPost()]
        [Route("api/user/Add")]
        [JwtAuthentication(Roles = RolesConstants.AddUser)]
        public async Task<HttpResponseMessage> Add([FromBody] UserBindingModel userModel)
        {
            try
            {
                await new UserManager().Add(userModel);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpPost()]
        [Route("api/user/Edit")]
        [JwtAuthentication(Roles = RolesConstants.EditUser)]
        public async Task<HttpResponseMessage> Edit([FromBody] UserBindingModel userModel)
        {
            try
            {
                await new UserManager().Edit(userModel);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost()]
        [Route("api/user/UpdatePassword")]
        public async Task<HttpResponseMessage> UpdatePassword([FromBody] UpdatePasswordBindingModel updatePasswordModel)
        {
            try
            {
                await CheckUser(updatePasswordModel.Login, updatePasswordModel.OldPassword);

                await new UserManager().UpdatePassword(updatePasswordModel);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
            }
        }
        [HttpPost()]
        [Route("api/user/Delete")]
        [JwtAuthentication(Roles = RolesConstants.DeleteUser)]
        public async Task<HttpResponseMessage> Delete([FromBody] UserBindingModel userModel)
        {
            try
            {
                await new UserManager().Delete(userModel);

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, true);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, Ex.Message);
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
                                user.CountFailEnter = 0;
                                await context.SaveChangesAsync();
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
