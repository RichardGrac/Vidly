using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            /* Restrictive permission to Anonymous Users
               Home page is allowed to All Users /controllers/Home
             */
            filters.Add(new AuthorizeAttribute());
            /* Deny 'HTTP' Request (Only 'HTTPS') */
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
