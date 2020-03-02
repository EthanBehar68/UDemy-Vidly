using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // redirect to error page when actions throw exception
            filters.Add(new AuthorizeAttribute());
        }
    }
}
