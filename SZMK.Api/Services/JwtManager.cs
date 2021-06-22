using JWT.Algorithms;
using JWT.Builder;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.ViewModels;
using SZMK.Infrastructure.Cryptography;

namespace SZMK.Api.Services
{
    public static class JwtManager
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG412V8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        private static List<TokensViewModel> Sessions = new List<TokensViewModel>();

        public static TokensViewModel GenerateTokens(string username, string salt, int expireSeconds = 600)
        {
            try
            {
                var accessToken = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(Secret)
                    .AddClaim("exp", DateTimeOffset.UtcNow.AddSeconds(expireSeconds).ToUnixTimeSeconds())
                    .AddClaim(ClaimTypes.Name, username)
                    .Encode();

                var refreshToken = Guid.NewGuid().ToString("n");
                refreshToken += DateTime.UtcNow.GetHashCode();

                Sessions.Add(new TokensViewModel { AccessToken = accessToken, RefreshToken = new RFC().Encrypt(refreshToken, salt) });

                return new TokensViewModel { AccessToken = accessToken, RefreshToken = refreshToken };
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        public static bool DeleteToken(string refreshtoken)
        {
            try
            {
                TokensViewModel tokens = Sessions.FirstOrDefault(p => p.RefreshToken == refreshtoken);

                if (tokens != null)
                {
                    Sessions.Remove(tokens);

                    string json = null;
                    try
                    {
                        json = new JwtBuilder()
                        .WithAlgorithm(new HMACSHA256Algorithm())
                        .WithSecret(Secret)
                        .MustVerifySignature()
                        .Decode(tokens.AccessToken);
                    }
                    catch
                    {
                        return true;
                    }

                    dynamic des_claims = JsonConvert.DeserializeObject(json);

                    Cache BadTokens = new Cache();
                    DateTimeOffset Exp = new DateTimeOffset(new DateTime(1970, 1, 1)).AddSeconds(des_claims["exp"].Value);
                    BadTokens.Insert(tokens.AccessToken, "NoValidate", null, Exp.DateTime + Exp.Offset, Cache.NoSlidingExpiration);
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                string json = null;
                try
                {
                    json = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(Secret)
                    .MustVerifySignature()
                    .Decode(token);
                }
                catch
                {
                    return null;
                }

                Cache BadTokens = new Cache();
                if (BadTokens.Get(token) != null)
                {
                    return null;
                }

                List<Claim> claims = new List<Claim>();

                dynamic des_claims = JsonConvert.DeserializeObject(json);
                foreach (var claim in des_claims)
                {
                    claims.Add(new Claim(claim.Name.ToString(), claim.Value.ToString()));
                }

                return new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationTypes.Password));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}