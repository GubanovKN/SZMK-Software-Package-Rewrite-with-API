using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SZMK.Middleware.Services.Requests
{
    public class JsonResponse<T>
    {
        public T GetResponse(HttpResponseMessage response, String apiResponse)
        {
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }

            throw new Exception(JsonConvert.DeserializeObject<String>(apiResponse));

        }
    }
}
