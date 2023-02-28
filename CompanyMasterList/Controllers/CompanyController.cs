using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyMasterList.Models;

namespace CompanyMasterList.Controllers
{
    public class CompanyController : Controller
    {
        Sql_PractiseEntities db = new Sql_PractiseEntities();

      [HttpGet]
        public ActionResult CompanyMasterList()
        {
            Sql_PractiseEntities db = new Sql_PractiseEntities();
            List<CompanyMaster> companyMaster = new List<CompanyMaster>();
            companyMaster = db.CompanyMasters.ToList(); 
            return View(companyMaster);
        }

        [HttpGet]
        public ActionResult FileMasterList()
        {
            List<FileMaster> MasterList = new List<FileMaster>();
            MasterList = db.FileMasters.ToList();
            return View(MasterList);
        }



        [HttpGet]
        public ActionResult AddEditFileMasterList(int? Id)
        {
            List<CompanyMaster> Master = db.CompanyMasters.ToList();
            ViewBag.CompanyMasterList = new SelectList(Master, "Id", "Companyname");
            if (Id == null)
            {
                return View();
            }
            else
            {
                var Filedatamodel =  db.FileMasters.Find(Id);
                return View(Filedatamodel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditFileMasterList(int? Id, FileMaster ModelObj)
        {
            bool IsExists = false;

            FileMaster FileList = db.FileMasters.Find(Id);

            if (FileList != null)
            {
                IsExists = true;
            }
            else
            {
                FileList = new FileMaster();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (IsExists)
                    {
                        //employee.EmployeeID = employeeData.EmployeeID;
                        FileList.FileName = ModelObj.FileName;
                        FileList.CompanyId = ModelObj.CompanyId;
                        //FileList.CompanyMaster.Companyname = ModelObj.CompanyMaster.Companyname;

                        db.FileMasters.Add(FileList);

                    }
                    else
                    {
                        //employee.EmployeeID = employeeData.EmployeeID;
                        FileList.FileName = ModelObj.FileName;
                        FileList.CompanyId = ModelObj.CompanyId;
                        db.FileMasters.Add(FileList);
                    }

                     db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("FileMasterList", "Company");
            }
            return View(FileList);
        }

        [HttpGet]
        public ActionResult AddEditCompnayMasterList(int? Id)
        {
            if (Id == null)
            {
                return View();
            }
            else
            {
                var Companydatamodel = db.CompanyMasters.Find(Id);
                return View(Companydatamodel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditCompnayMasterList(int? Id, CompanyMaster ModelObj)
        {
            bool IsExists = false;

            CompanyMaster FileList = db.CompanyMasters.Find(Id);

            if (FileList != null)
            {
                IsExists = true;
            }
            else
            {
                FileList = new CompanyMaster();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (IsExists)
                    {
                        FileList.Companyname = ModelObj.Companyname;
                        FileList.Status = true;
                        db.CompanyMasters.Add(FileList);
                    }
                    else
                    {
                        FileList.Companyname = ModelObj.Companyname;
                        FileList.Status = true;
                        db.CompanyMasters.Add(FileList);
                    }

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("CompanyMasterList", "Company");
            }
            return View(FileList);
        }
    }
}