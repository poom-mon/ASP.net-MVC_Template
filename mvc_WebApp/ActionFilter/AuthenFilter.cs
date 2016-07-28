using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace mvc_WebApp.ActionFilter
{
    public class AuthenFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             //Log("OnActionExecuting", filterContext.RouteData);

            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower(); 

            if (actionName != "login" && HttpContext.Current.Session["userAuthen"] == null)
            {
                // redirect to authen page
                /*
                     string redirectOnSuccess = filterContext.HttpContext.Request.Url.PathAndQuery;
                    string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                    string loginUrl = "login" + redirectUrl; 
                    filterContext.Result = new RedirectResult(loginUrl);
                 */
                HttpContext.Current.Response.Write("<p style='color:red;font-size:10px;'>***** User is not Authen ! </p>");
            }

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Log("OnResultExecuted", filterContext.RouteData);
        }


        private void Log(string methodName, System.Web.Routing.RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
           // Debug.WriteLine(message, "Action Filter Log");

           // HttpContext.Current.Response.Write("-"+message+"<br>");
            string log = message;
        }
    }
}