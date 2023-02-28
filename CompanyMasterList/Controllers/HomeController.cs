using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyMasterList.Models;

namespace CompanyMasterList.Controllers
{
    public class HomeController : Controller
    {
        Sql_PractiseEntities db = new Sql_PractiseEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult CompanyMasterList()
        {
            Sql_PractiseEntities db = new Sql_PractiseEntities();
            List<CompanyMaster> companyMaster = new List<CompanyMaster>();
            companyMaster = db.CompanyMasters.ToList();


            return View();
        }

        [HttpGet]
        public ActionResult FileMasterList()
        {
            List<FileMaster> companyMaster = new List<FileMaster>();
            companyMaster = db.FileMasters.ToList();
            return View();
        }

    }
}