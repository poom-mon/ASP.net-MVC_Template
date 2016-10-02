using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace mvc_WebApp.Controllers
{
    public class utilityController : Controller
    {
         //
        // GET: /upload/


        public ActionResult exportExcel()
        {
            return View();
        }


         public ActionResult exportExcelData()
        {
            var grid = new GridView();

            string g = Request.Url.OriginalString;
            string c = g.Split('/')[3];

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><th>Index</th><th>Code</th><th>Pre_name</th><th>First Name</th><th>Last Name</th><th>Home_number</th><th>Moo</th><th>Village  100  (1)</th><th>Soi</th><th>Road</th><th>City</th><th>District</th><th>Province</th><th>Region</th><th>Building 100 (2)</th><th>Floor</th><th>Room_no</th><th>Postcode</th><th>E-mail</th><th>tel1</th><th>tel2</th><th>tel3</th><th>Gender</th><th>financialamount</th><th>Date of birth</th><th>Marital Status</th><th>citizenid</th><th>personid</th><th>policyno</th><th>policystatus</th><th>policystatusdate</th><th>Planname</th><th>CAMPAIGN_COMMUNICATION_CD</th><th>Extra 1</th><th>Extra 2</th><th>Extra 3</th><th>otherremark</th></tr>");

            List<obj> tb = new List<obj>();
            obj bb = new obj()
            {
                TitleName = "name",
                FirstName = "first name ",
                Lastname = "last name ",
                email = "email",
                mobile = "mobile ",
                gender = "gender",
                born = "born",
                Product = "product",
                planCode = "plan" 
            };
            tb.Add(bb);

            foreach (var item in tb)
            { 
                string Gender = item.gender; //string.IsNullOrEmpty(item.TitleName) ? "" : (item.TitleName.IndexOf("นาย") > 0 ? "M" : "F");
                sb.Append("<tr><td></td><td></td><td>" + item.TitleName + "</td><td>" + item.FirstName + "</td><td>" + item.Lastname + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + item.email + "</td><td class='inexcel_textmode'>" + item.mobile + "</td><td></td><td></td><td>" + Gender + "</td><td></td><td>" + item.born + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + item.Product + "</td><td></td><td></td><td></td><td></td><td>" + item.planCode + "</td></tr>");

            } 

            sb.Append("</tr>");
            sb.Append("</table>"); 
             
            Response.Clear();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", "MyExcelFile.xls"));
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
           // Response.Write(@"<style>   .inexcel_textmode{ mso-number-format:\@; }  </style>");
            Response.Write(@"<style> table {border-collapse: collapse;} table, th, td {border: 1px solid black; } .inexcel_textmode{ mso-number-format:\@; }  </style>");

            Response.Write(sb.ToString());
            Response.End();


            return View();
        }
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult upload()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult UploadExcel()
        {
            try
            {
                string projectName = Request["projectName"];
                string ext = Request["ext"];

                object obj = null;
                //importBAL bal = new importBAL();
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        Stream file_stream = fileContent.InputStream;
                        string fileName = Path.GetFileName(file);
                        string extension = string.Format(".{0}", ext); //Path.GetExtension(file);

                        string plan_id, sub_plan, group_plan, tb;

                        readExcel(file_stream,extension);


                        switch (projectName.ToLower())
                        {
                            case "bupa":
                                plan_id = Request["plan_id"];
                                ///// Stream file_stream;
                                //obj = bal.getBupaLeads(file_stream, extension, plan_id);
                                break;

                            case "cigna":
                                plan_id = Request["plan_id"];
                                sub_plan = Request["sub_plan"];
                                //obj = bal.getCignaLeads(file_stream, extension, plan_id, sub_plan);
                                break; 
                        }
                    }
                }
                                
                return Json(obj);
            }
            catch (Exception ex)
            {
                //Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                string msg = ex.Message;
                return Json(string.Format("<p class='alert alert-danger'>Error : {0}</p>", msg));
            }    

            return View();
        }
         
        public void readExcel(Stream file,string extension) {
            cExcel.excel excel = new cExcel.excel();
            
            
             using (DataTable dt = excel.readToDataTable(file, extension))
             {
                 if (dt != null && dt.Rows.Count > 0)
                 {

                 }

             }
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
    public class obj{
       public string TitleName {get;set;}
       public string  FirstName {get;set;}
       public string  Lastname {get;set;}
       public string  email {get;set;}
       public string  mobile {get;set;}
       public string gender { get; set; }
       public string  born {get;set;}
       public string  Product {get;set;}
       public string  planCode { get; set; } 
    }
}
