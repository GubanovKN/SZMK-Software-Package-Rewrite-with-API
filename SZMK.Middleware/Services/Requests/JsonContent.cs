using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SZMK.Middleware.Services.Requests
{
    public class JsonContent<T>
    {
        public StringContent GetContent(T entity)
        {
            return new StringContent(
                JsonConvert.SerializeObject(
                       entity, Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                       }),
                Encoding.UTF8, "application/json");
        }
    }
}
