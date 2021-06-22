using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Domain.Models;

namespace SZMK.Domain.Constants
{
    public class UserChangeTypeConstants
    {
        public const string AddUser = "Добавление пользователя";
        public const string ChangeUser = "Изменение пользователя";
        public const string DeleteUser = "Удаление пользователя";

        public readonly UserChangeType[] UserChangeTypes =
            {
                new UserChangeType { Id = 1, Name = AddUser, DateCreate = DateTime.Now },
                new UserChangeType { Id = 2, Name = ChangeUser, DateCreate = DateTime.Now },
                new UserChangeType { Id = 3, Name = DeleteUser, DateCreate = DateTime.Now }
            };
    }
}
