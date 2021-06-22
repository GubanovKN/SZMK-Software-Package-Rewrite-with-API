using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string SurName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        public string Login { get; set; }
        public byte[] Salt { get; set; }
        public string Password { get; set; }

        public bool UpdatePassword { get; set; }
        public bool Active { get; set; }
        public int CountFailEnter { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RefreshSession> RefreshSessions { get; set; }

        public ICollection<UserChange> OwnerChanges { get; set; }
        public ICollection<UserChange> UserChanges { get; set; }
    }
}
