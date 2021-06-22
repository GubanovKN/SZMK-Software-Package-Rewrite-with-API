using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Models.Response
{
    public class UserExceptions
    {
        public static readonly String StringNeedUpdatePassword = "Необходимо обновить пароль";
        public static readonly String StringNotFoundUser = "Пользователь не найден";
        public static readonly String StringBadPassword = "Не верный пароль";
        public static readonly String StringOutOfRangeEnter = "Превышено количество неверных входов";
        public static readonly String StringInactive = "Учетная запись не активна";
    }
}
