using System.Web;
using System.Web.Mvc;

namespace SZMK_Rewrite_Package
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
