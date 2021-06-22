using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SZMK.Api.Filters;
using SZMK.Api.Services;
using SZMK.Domain.Constants;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;

namespace SZMK.Api.Controllers
{
    [JwtAuthentication]
    public class RoleController : ApiController
    {
        [HttpGet()]
        [Route("api/role/All")]
        [JwtAuthentication(Roles = RolesConstants.ViewUser)]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<RoleViewModel> roleModels = new List<RoleViewModel>();

                List<Role> roles = new RoleManager().GetAll();

                for (int i = 0; i < roles.Count; i++)
                {
                    roleModels.Add(new RoleManager().FormingViewModel(roles[i]));
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, roleModels);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, Ex.Message);
            }
        }
    }
}
