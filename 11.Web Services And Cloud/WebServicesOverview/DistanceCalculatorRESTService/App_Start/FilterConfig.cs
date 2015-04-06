using System.Web;
using System.Web.Mvc;

namespace DistanceCalculatorRESTService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
