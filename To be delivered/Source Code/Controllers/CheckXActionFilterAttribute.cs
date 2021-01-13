using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;


namespace Ain_Shams_Hospital.Controllers
{
    public class CheckXActionFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int ID = (int)filterContext.HttpContext.Session.GetInt32("User_Reg_Id");

            if (ID == 0)
            {
                // do something
                // e.g. Set ActionParameters etc
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Home" },
                        { "Action", "Index" } 
                    });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
