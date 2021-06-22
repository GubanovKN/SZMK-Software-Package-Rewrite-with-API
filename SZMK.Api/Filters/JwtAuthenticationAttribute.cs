using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using SZMK.Api.Services;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Filters
{
    public class JwtAuthenticationAttribute : AuthorizeAttribute, IAuthenticationFilter
    {
        public JwtAuthenticationAttribute() : base() { }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringMissingToken, request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal != null)
            {
                if (ValidateRole(principal))
                {
                    context.Principal = principal;
                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringNotEnoughAccess, request);
                }
            }
            else
            {
                context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringInvalidAccess, request);
            }
        }
        private bool ValidateRole(IPrincipal principal)
        {
            bool Validate = false;

            if (!String.IsNullOrEmpty(Roles))
            {
                string[] MasRoles = Roles.Split(',');
                foreach (var role in MasRoles)
                {
                    if (principal.IsInRole(role))
                    {
                        Validate = true;
                        break;
                    }
                }

                return Validate;
            }
            else
            {
                return true;
            }
        }
        private static bool ValidateToken(string token, out string username)
        {
            username = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);

            if (!(simplePrinciple?.Identity is ClaimsIdentity identity))
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            if (!ValidateUser(username))
                return false;

            return true;
        }
        private async Task<IEnumerable<Claim>> GetUserRoles(string username)
        {
            List<Claim> claims = new List<Claim>();

            List<Role> roles = await new RoleManager().GetRoles(username);

            foreach (Role role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }

        protected async Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            if (ValidateToken(token, out var username))
            {
                var identity = new ClaimsIdentity("Jwt");

                identity.AddClaims(await GetUserRoles(username));
                identity.AddClaim(new Claim(ClaimTypes.Name, username));

                IPrincipal user = new ClaimsPrincipal(identity);

                return user;
            }

            return null;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            context.ChallengeWith("Bearer", parameter);
        }
        private static bool ValidateUser(string username)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                User user = context.Users.FirstOrDefault(p => p.Login == username);
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}