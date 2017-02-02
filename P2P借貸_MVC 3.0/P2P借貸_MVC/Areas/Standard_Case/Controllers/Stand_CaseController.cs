using P2P借貸_MVC.Areas.Standard_Case.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2P借貸_MVC.Areas.Standard_Case.Controllers
{
    public class Stand_CaseController : Controller
    {
        // GET: Standard_Case/Stand_Case
        private IP2PRepository<Standard_case> sc = new P2PRepository<Standard_case>();
        private IP2PRepository<Standard_case_details> sd = new P2PRepository<Standard_case_details>();

        // GET: Standard_Case/Stand_Case
        public ActionResult Loading()
        {
            var q = sc.GetAll().Where(p => p.CaseStatus == true).Select(p => p);
            return View(q);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Standard_case _Standard_case)
        {
            HttpCookie mycookie = Request.Cookies["account"];
            _Standard_case.MemberSponer = Convert.ToInt32(mycookie.Values["MemberID"]);
            _Standard_case.CaseFirstday = DateTime.Today.AddMonths(1);
            _Standard_case.CaseEndnay = DateTime.Today.AddMonths(1 + Convert.ToInt32(_Standard_case.CaseMonth));
            _Standard_case.MoneyForday = DateTime.Today.AddMonths(1);
            _Standard_case.CaseStatus = true;
            _Standard_case.CaseStatus2 = true;
            sc.Creat(_Standard_case);

            Standard_case_details q = new Standard_case_details();
            P2P借貸平台_2Entities1 db = new P2P借貸平台_2Entities1();
            q.StandcaseID = _Standard_case.StandcaseID;
            q.MerberID = Convert.ToInt32(mycookie.Values["MemberID"]);
            var s = from p in db.BasicInfo
                    where p.MemberID == _Standard_case.MemberSponer
                    select p;
            q.MerberAccount = s.First().BankAccount;
            sd.Creat(q);
            return RedirectToAction("Loading", "Stand_Case", new { Areas = "Standard_Case" });
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View(sc.GetById(Convert.ToInt32(id)));
        }

        [HttpPost]
        public ActionResult Edit(Standard_case _Standard_case, int id)
        {
            _Standard_case.StandcaseID = id;
            _Standard_case.CaseEndnay = ((DateTime)_Standard_case.CaseFirstday).AddMonths(Convert.ToInt32(_Standard_case.CaseMonth));
            _Standard_case.CaseStatus = true;
            _Standard_case.CaseStatus2 = true;
            sc.Update(_Standard_case);
            return RedirectToAction("Loading", "Stand_Case", new { Areas = "Standard_Case" });
        }
        public ActionResult Delete(int id)
        {
            var q = sd.GetAll().Where(p => p.StandcaseID == id).Select(p => new { p.SID });

            if (q.Count() > 1)
            {

            }
            else
            {
                sd.Delete(sd.GetById(q.First().SID));
                sc.Delete(sc.GetById(id));

            }
            return RedirectToAction("Loading", "Stand_Case", new { Areas = "Standard_Case" });


        }

        public ActionResult Inter(Standard_case_details _Standard_case_details, int id)
        {
            HttpCookie mycookie = Request.Cookies["account"];
            _Standard_case_details.MerberID = Convert.ToInt32(mycookie.Values["MemberID"]);

            var ScCount = sc.GetById(id).Memberprople;
            var SdCount = sd.GetAll().Where(p => p.StandcaseID == id).Select(p => p);

            if (SdCount.Count() > ScCount || SdCount.Count() == ScCount)
            {
                var q = sc.GetById(id);
                q.CaseStatus = false;
                sc.Update(q);
            }
            else
            {
                _Standard_case_details.StandcaseID = id;
                P2P借貸平台_2Entities1 db = new P2P借貸平台_2Entities1();
                var s = from p in db.BasicInfo
                        where p.MemberID == _Standard_case_details.MerberID
                        select p;
                _Standard_case_details.MerberAccount = s.First().BankAccount;
                sd.Creat(_Standard_case_details);
            }

            return RedirectToAction("Loading", "Stand_Case", new { Areas = "Standard_Case" });
        }
    }
}