using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Domain.Models.Response
{
    public class UnauthorizedExceptions
    {
        public static readonly String StringInvalidAccess = "Неверный токен доступа";
        public static readonly String StringMissingToken = "Отсутствует токен доступа";
        public static readonly String StringInvalidRefresh = "Неверный токен обновления";
        public static readonly String StringMissingRefresh = "Отсутствует токен обновления";
        public static readonly String StringNotEnoughAccess = "Недостаточно доступа для выполнения";
    }
}
