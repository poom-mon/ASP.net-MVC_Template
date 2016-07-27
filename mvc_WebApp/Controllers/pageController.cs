using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_WebApp.Controllers
{
    public class modelData {
        public string data1 { get; set; }
        public string data2 { get; set; }
    }
    public class pageController : Controller
    {
        //
        // GET: /page/ 
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult query(String data1 ,String data2)
        {  
            return Json(
                     new modelData { data1 = data1, data2 = data2 } 
                , JsonRequestBehavior.AllowGet);
        }
         
         
        


        // GET: /page/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /page/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /page/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /page/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /page/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /page/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /page/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
