using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace mvc_WebApp.Controllers
{
    public class uploadController : Controller
    {
        //
        // GET: /upload/

        public ActionResult Index()
        {
             
            return View();
        }

        //[HttpPost]
        //public ActionResult UploadExcel()
        //{
        //    try
        //    {
        //        string projectName = Request["projectName"];
        //        string ext = Request["ext"];

        //        object obj = null;
        //        foreach (string file in Request.Files)
        //        {
        //            var fileContent = Request.Files[file];
        //            if (fileContent != null && fileContent.ContentLength > 0)
        //            {
        //                Stream file_stream = fileContent.InputStream;
        //                string fileName = Path.GetFileName(file);
        //                string extension = string.Format(".{0}", ext); //Path.GetExtension(file);

        //                string plan_id, sub_plan, group_plan, tb;

        //                switch (projectName.ToLower())
        //                {

        //                    case "cigna":
        //                        plan_id = Request["plan_id"];
        //                        sub_plan = Request["sub_plan"];
        //                        obj = getCignaLeads(file_stream, extension, plan_id, sub_plan);
        //                        break;
        //                }
        //            }
        //        }

        //        return Json(obj);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private object getCignaLeads(Stream file_stream, string extension, string plan_id, string sub_plan)
        //{
        //    List<log_cigna_model> li = new List<log_cigna_model>();

        //    excel excel = new excel();
        //    using (DataTable dt = excel.readToDataTable(file, extension))
        //    {
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                _id = dr["id"].ToString();
        //                if (!string.IsNullOrEmpty(_id))
        //                {

        //                }
        //            }
        //        }
        //    }

        //    return li;
        //}
        

    }
     
}
