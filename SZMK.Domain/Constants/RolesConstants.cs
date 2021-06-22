using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.Models;

namespace SZMK.Domain.Constants
{
    public class RolesConstants
    {
        public const string AddUser = "Добавление пользователя";
        public const string EditUser = "Изменение пользователя";
        public const string DeleteUser = "Удаление пользователя";
        public const string ViewUser = "Просмотр пользователя";

        public readonly Role[] Roles =
            {
                new Role { Id = 1, Name = AddUser, DateCreate = DateTime.Now },
                new Role { Id = 2, Name = EditUser, DateCreate = DateTime.Now },
                new Role { Id = 3, Name = DeleteUser, DateCreate = DateTime.Now },
                new Role { Id = 4, Name = ViewUser, DateCreate = DateTime.Now }
            };
    }
}
