using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public bool UpdatePassword { get; set; }
        public bool Active { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
