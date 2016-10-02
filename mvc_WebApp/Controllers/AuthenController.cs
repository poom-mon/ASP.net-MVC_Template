using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_WebApp.Controllers
{
    public class AuthenController : Controller
    {
        //
        // GET: /Authen/

        [ActionFilter.AuthenFilter]
        public ActionResult Index()
        { 
            //ViewBag.cancelActiveby = "System";
            //if (HttpContext.Session["_cancelPolicyUser"] != null)
            //{
            //    ViewBag.cancelActiveby = HttpContext.Session["_cancelPolicyUser"].ToString();
            //}
            return View();
          //  return View();
        }
         [ActionFilter.AuthenFilter]
        public ActionResult chkAuthen(ModelAuthen  data)
        {
            return Json(
                     new ModelAuthen { username = data.username, password = data.password }
                , JsonRequestBehavior.AllowGet);
        }


    }

    public class ModelAuthen {
        public string username { get; set; }
        public string password { get; set; }
    }


}
