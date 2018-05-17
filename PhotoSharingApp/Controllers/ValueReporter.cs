using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSharingApp.Controllers
{
    public class ValueReporter : ActionFilterAttribute
    {
        private void logValues(RouteData routeData)
        {
            Debug.WriteLine("Action Values");
            foreach(var item in routeData.Values)
            {
                Debug.Write("key : ");
                Debug.WriteLine(item.Key);
                Debug.Write("value : ");
                Debug.WriteLine(item.Value);
            }

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logValues(filterContext.RouteData);

            base.OnActionExecuting(filterContext);
        }
    }
}