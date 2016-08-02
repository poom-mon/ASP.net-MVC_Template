using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_WebApp.Controllers
{
    public class utilityController : Controller
    {
         //
        // GET: /upload/

        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult getPartial(modelPass data)
        {
            ActionResult objreturn = null;
            switch (data.systemImport)
            {
                case systemImport.bupa:
                    objreturn = PartialView("partial/bupa");
                    break;
                case systemImport.cigna:
                    objreturn = PartialView("partial/cigna");
                    break;
                case systemImport.thailife:
                    objreturn = PartialView("partial/thailife");
                    break; 
            }
            return objreturn;
        }

    }
    public class modelPass
    {
        public systemImport systemImport { get; set; }
    }
    public enum systemImport
    {
        motorcycle,
        bupa,
        cigna,
        thailife
    }
}
