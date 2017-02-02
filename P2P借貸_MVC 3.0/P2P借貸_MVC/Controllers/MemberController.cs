using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P2P借貸_MVC.Models;

namespace P2P借貸_MVC.Controllers
{
    public class MemberController : Controller
    {
        P2P借貸平台_2Entities db = new P2P借貸平台_2Entities();
        // GET: Member
        public ActionResult Index()
        {
            if (Request.Cookies["account"] != null)
            {
                return Redirect("~/Manage/Manage");                
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Login(BasicInfo _member)
        {
            if (Request.Form.Count > 0)
            {
                var data = db.BasicInfoes
                                .Where(s => s.MemberName == _member.MemberName && s.Password == _member.Password)
                                .Select(s => s);

                if (data.Count() > 0)
                {
                    var _data = data.First();

                    //Response.Cookies["MemberID"].Value = _data.MemberID.ToString();
                    //Response.Cookies["MemberName"].Value = _data.MemberName.ToString();
                    //Response.Cookies["PermissionLevel"].Value = _data.PermissionLevel.ToString();

                    HttpCookie _cookie = new HttpCookie("account");
                    _cookie.Values.Add("MemberID", _data.MemberID.ToString());
                    _cookie.Values.Add("MemberName", _data.MemberName.ToString());
                    _cookie.Values.Add("PermissionLevel", _data.PermissionLevel.ToString());
                    _cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(_cookie);

                    return Redirect("~/Manage/Manage");                    
                    
                }
                else
                    ViewData.Model = "登入失敗";
                    return View("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpCookie _cookie = Request.Cookies["account"];

            //var _cookie = new HttpCookie("account");

            _cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(_cookie);
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Bank = db.Banks;
            ViewBag.Level = db.Definitions;
            return View();
        }

        [HttpPost]
        public ActionResult Register(BasicInfo _Member, HttpPostedFileBase file_1)
        {
            if (file_1 != null)
            {
                if (file_1.ContentLength > 0)
                {
                    int imgSize = file_1.ContentLength;
                    byte[] imgByte = new byte[imgSize];

                    file_1.InputStream.Read(imgByte, 0, imgSize);

                    _Member.Photo = imgByte;
                }
            }

            if (_Member.WorkPlace == null)
                _Member.WorkPlace = "N/A";

            if (_Member.PermissionLevel == 0)
                _Member.PermissionLevel = 1;

            db.BasicInfoes.Add(_Member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //if (ID == null)
            //    RedirectToAction("Error");

            BasicInfo _Member = db.BasicInfoes.Find(ID);

            ViewBag.Bank = db.Banks;
            ViewBag.Level = db.Definitions;
            return View(_Member);
        }

        [HttpPost]
        public ActionResult Edit(BasicInfo _Member, HttpPostedFileBase file_1)
        {
            if (file_1 != null)
            {
                if (file_1.ContentLength > 0)
                {
                    int imgSize = file_1.ContentLength;
                    byte[] imgByte = new byte[imgSize];

                    file_1.InputStream.Read(imgByte, 0, imgSize);

                    _Member.Photo = imgByte;
                }
            }
            else
            {
                var _photo = db.BasicInfoes.Find(_Member.MemberID).Photo;
                _Member.Photo = _photo;
            }
            

            if (_Member.WorkPlace == null)
                _Member.WorkPlace = "N/A";

            if (_Member.PermissionLevel == 0)
                _Member.PermissionLevel = 1;

            db.Entry(_Member).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Manage", "Manage");
        }

        public ActionResult GetImage(int ID)
        {
            BasicInfo photo = db.BasicInfoes.Find(ID);

            byte[] img = photo.Photo;

            return File(img, "image/jpeg");
        }

        public ActionResult Delete(int ID)
        {
            BasicInfo _Member = db.BasicInfoes.Find(ID);
            db.BasicInfoes.Remove(_Member);
            db.SaveChanges();

            return RedirectToAction("Manage", "Manage");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}