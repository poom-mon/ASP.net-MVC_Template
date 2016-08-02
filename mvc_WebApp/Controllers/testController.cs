using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_WebApp.Controllers
{
    public class testController : Controller
    {
        // GET: /test/ 
        public ActionResult Index()
        {
            List<Models.testModel.userInfo> obj = new List<Models.testModel.userInfo>();
            obj.Add(new Models.testModel.userInfo(){name ="sittiporn",lname="jangsang"});
            obj.Add(new Models.testModel.userInfo() { name = "cha", lname = "tae" });
             
            Models.testModel.html bb = new Models.testModel.html();
            bb.htmlForm =rederTable(obj);

            return View(bb);
        }

        public ActionResult query()
        {
            List<Models.testModel.userInfo> obj = new List<Models.testModel.userInfo>();
            obj.Add(new Models.testModel.userInfo() { name = "sittiporn", lname = "jangsang" });
            obj.Add(new Models.testModel.userInfo() { name = "cha", lname = "tae" });

            Models.testModel.html bb = new Models.testModel.html();
            bb.htmlForm = rederTable(obj);

            return   Content(bb.htmlForm) ;
        }


        public string rederTable(List<Models.testModel.userInfo> a)
        {

            string tablehtml = @"
                <table class='table'>
                    <thead> 
                        <tr>
                            {0}
                        </tr>
                    </thead>
                    <tbody>
                            {1}
                    </tbody>
                </table>
            ";
            string th = "", td = "";

            int count = 0;
            foreach (var item in a)
            {
                var type = item.GetType();
                var tdI = "";
                foreach (var item2 in type.GetProperties())
                {
                    if (count == 0)
                        th += "<th>" + item2.Name + "</th>";

                    var g = item2.GetValue(item, null);
                    tdI += "<td>" + g + "</td>";
                }

                count = 1;
                var tr = "<tr>{0}</tr>";
                td += string.Format(tr, tdI);
            }
            return string.Format(tablehtml, th, td);
        }


    }
}
