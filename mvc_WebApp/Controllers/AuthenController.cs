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

        public ActionResult Index()
        {
            return View();
        }
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
