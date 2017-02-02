using P2P借貸_MVC.Areas.AreaCollater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2P借貸_MVC.Areas.AreaCollater.Controllers
{
    public class p2pdataController : Controller
    {
        private P2P借貸平台_2Entities2 db = new P2P借貸平台_2Entities2();
        // GET: P2PData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAction()
        {
            return PartialView(db.CollaterDetail);
        }
    }
}