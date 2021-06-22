using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Models
{
    public class UserChange
    {
        public DateTime DateCreate { get; set; }

        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        public string Login { get; set; }
        public byte[] Salt { get; set; }
        public string Password { get; set; }

        public bool UpdatePassword { get; set; }
        public bool Active { get; set; }

        public int TypeId { get; set; }
        public UserChangeType Type { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
