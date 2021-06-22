using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.Exceptions;
using SZMK.Domain.Models.Response;

namespace SZMK.Middleware.Services.Requests
{
    public class RequestService<T>
    {
        public RequestService()
        {
            SetHttpClient();
        }

        public RequestService(String Token)
        {
            SetHttpClient(Token);
        }

        private void SetHttpClient(String Token = "")
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("UrlAPI"))
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.Timeout = TimeSpan.FromSeconds(30);

            if (Token != "")
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
        }

        private HttpClient _client;

        public HttpClient Client
        {
            get
            {
                return _client;
            }

            set
            {
                _client = value;
            }
        }

        public async Task<T> PostRequestAsync(StringContent stringContent, String route)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsync(route, stringContent);

                string apiResponse = await response.Content.ReadAsStringAsync();

                return new JsonResponse<T>().GetResponse(response, apiResponse);
            }
            catch (Exception ex)
            {
                ValidationException(ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetRequestAsync(String route)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(route);

                string apiResponse = await response.Content.ReadAsStringAsync();

                return new JsonResponse<T>().GetResponse(response, apiResponse);
            }
            catch (Exception ex)
            {
                ValidationException(ex);
                throw new Exception(ex.Message);
            }
        }

        private void ValidationException(Exception ex)
        {
            if (ex.Message == UnauthorizedExceptions.StringInvalidAccess)
            {
                throw new InvalidAccessTokenException(ex.Message);
            }
            else if(ex.Message == SessionExceptions.StringOutOfRangeSession)
            {
                throw new OutOfRangeSessionsException(ex.Message);
            }
            else if(ex.Message == UserExceptions.StringNeedUpdatePassword)
            {
                throw new NeedUpdatePasswordException(ex.Message);
            }
            else
            {
                throw new InvalidRefreshTokenException(ex.Message);
            }
        }
    }
}
