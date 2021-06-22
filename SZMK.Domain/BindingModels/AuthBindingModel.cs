using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.BindingModels
{
    public class LoginBindingModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string ClientName { get; set; }
    }
    public class UpdatePasswordBindingModel
    {
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class SessionBindingModel
    {
        public string RefreshToken { get; set; }
        public string ClientName { get; set; }
    }
    public class InfoSessionBindingModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ClientName { get; set; }
        public string IP { get; set; }
        public string RefreshToken { get; set; }
    }
}
