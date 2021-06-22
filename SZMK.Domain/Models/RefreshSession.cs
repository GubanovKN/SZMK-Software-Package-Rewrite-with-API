using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Models
{
    public class RefreshSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime TimeExpired { get; set; }
        public string RefreshToken { get; set; }
        public string Salt { get; set; }
        public string IP { get; set; }
        public string ClientName { get; set; }
        public User User { get; set; }
    }
}
