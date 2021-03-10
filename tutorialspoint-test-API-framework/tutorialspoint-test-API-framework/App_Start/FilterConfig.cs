using System.Web;
using System.Web.Mvc;

namespace tutorialspoint_test_API_framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
