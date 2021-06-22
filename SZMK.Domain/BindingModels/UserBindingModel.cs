using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.BindingModels
{
    public class UserBindingModel
    {
        public int Id { get; set; }

        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public bool UpdatePassword { get; set; }
        public bool Active { get; set; }

        public List<RoleBindingModel> Roles { get; set; }
    }
}
