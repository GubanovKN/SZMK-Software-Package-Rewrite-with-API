using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SZMK.Api.Services
{
    public static class ConfigurationService
    {
        private static readonly string _maxCountSessions = ConfigurationManager.AppSettings.Get("MaxCountSessions");

        public static int MaxCountSessions
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_maxCountSessions);
                }
                catch
                {
                    return 10;
                }
            }
        }
    }
}