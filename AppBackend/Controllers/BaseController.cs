using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ORLKlinika.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsLoggedIn => HttpContext.Session.GetInt32("TehnicarId") != null;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsLoggedIn && context.RouteData.Values["action"]?.ToString() != "Login")
            {
                context.Result = RedirectToAction("Login", "Login");
            }

            base.OnActionExecuting(context);
        }
    }
}
