using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_WebApp.Controllers
{
    public class recusiveController : Controller
    {
        //
        // GET: /recusive/

//        public ActionResult recusive()
//        {

//            string a = Request["companyName"] ?? "A";
//            string tt = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\db.mdf;Integrated Security=True;User Instance=True";
//            string sql = @"
//                            SELECT  company_name, company_namEn
//                            FROM  companyInfo  
//                            WHERE   company_namEn NOT IN
//                                                  (SELECT    top 1  company_namEn
//                                                    FROM   companyInfo
//                                                    WHERE   company_namEn > '" + a + @"' 
//                                                    ORDER BY company_namEn  )
//              
//                        ";
//            DataClasses1DataContext dd = new DataClasses1DataContext(tt);
//            List<model.ModelCompany.company> bb = dd.ExecuteQuery<model.ModelCompany.company>(sql).ToList();

//            List<model.ModelCompany.company> aa = new List<model.ModelCompany.company>();
//            int length = 0;

//            List<model.ModelCompany.company> g = recusiveFun(aa, bb, ref  length, a);

//            return View(g);

//        }
//        private List<model.ModelCompany.company> recusiveFun(List<model.ModelCompany.company> aa, List<model.ModelCompany.company> bb, ref int length, string querystring)
//        {
//            length++;

//            string gg = "";
//            if (length > 1)
//                gg = getItem(querystring, length);

//            foreach (var a in bb.ToList())
//                aa.Add(new model.ModelCompany.company() { company_name = a.company_name, company_namEn = gg + a.company_namEn });

//            if (length >= 3)
//                return aa;

//            return recusiveFun(aa, bb, ref length, querystring);
//        }

//        private string getItem(string querystring, int length)
//        {
//            string g = "";
//            for (int i = 2; i <= length; i++)
//            {
//                g += querystring;
//            }
//            return g;
//        }

//        public ActionResult Queryable()
//        {
//            string tt = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\db.mdf;Integrated Security=True;User Instance=True";
//            string sql = "select * from username ";
//            DataClasses1DataContext a = new DataClasses1DataContext(tt);
//            List<usr> c = a.ExecuteQuery<usr>(sql).ToList();

//            return View();
//        }


    }
}
