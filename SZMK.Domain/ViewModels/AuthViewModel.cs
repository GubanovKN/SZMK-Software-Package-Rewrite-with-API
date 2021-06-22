using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.ViewModels
{
    public class InfoSessionViewModel
    {
        public string ClientName { get; set; }
        public string IP { get; set; }
        public string RefreshToken { get; set; }
    }
    public class TokensViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
