using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P2P借貸_MVC.Models;

namespace P2P借貸_MVC.Controllers
{
    public class ManageController : Controller
    {
        P2P借貸平台_2Entities db = new P2P借貸平台_2Entities();

        public ActionResult Manage()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Manage_Person()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Manage_Admin()
        {
            return PartialView(db.BasicInfoes.ToList());
        }

        //[ChildActionOnly]
        public ActionResult List_Member()
        {
            return PartialView(db.BasicInfoes);
        }

        //[ChildActionOnly]
        public ActionResult List_Permission()
        {
            return PartialView(db.Definitions);
        }

        //[ChildActionOnly]
        public ActionResult List_Bank()
        {
            return PartialView(db.Banks);
        }

        [HttpGet]
        public ActionResult Bank_edit(string id)
        {
            Bank _bank = db.Banks.Where(s => s.BankCode == id).Select(s => s).First();
            return View(_bank);
        }

        [HttpPost]
        public ActionResult Bank_edit(Bank _bank)
        {
            db.Entry(_bank).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Manage", "Manage");
        }

        [HttpGet]
        public ActionResult PermissionLevel_edit(int id)
        {
            Definition _level = db.Definitions.Find(id);
            return View(_level);
        }

        [HttpPost]
        public ActionResult PermissionLevel_edit(Definition _level)
        {
            db.Entry(_level).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Manage", "Manage");
        }
    }
}