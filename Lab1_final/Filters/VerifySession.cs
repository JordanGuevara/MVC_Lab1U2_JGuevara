using System.Web;
using System.Web.Mvc;

namespace Lab1_final.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["user"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/Access/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
