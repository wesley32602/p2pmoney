using P2P借貸_MVC.Areas.AreaCollater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2P借貸_MVC.Areas.AreaCollater.Controllers
{
    public class collaterController : Controller
    {
        private P2PRepository<CollaterDetail> CollaterResposity = new AP2PRepository<CollaterDetail>();
        private P2P借貸平台_2Entities2 db = new P2P借貸平台_2Entities2();
        // GET: AreaCollater/collater
        // GET: Collater
        public ActionResult Index()
        {

            return View(CollaterResposity.GetAll());
        }
        //新增
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CollaterDetail _collater, HttpPostedFileBase Collateralimages)
        {
            HttpCookie mycookie = Request.Cookies["account"];
            if (Collateralimages != null)
            {
                if (Collateralimages.ContentLength > 0)
                {
                    //4. 將這個檔案轉成二進位
                    var imgSize = Collateralimages.ContentLength;
                    byte[] imgByte = new Byte[imgSize];
                    Collateralimages.InputStream.Read(imgByte, 0, imgSize);


                    _collater.Collateralimage = imgByte;
                }
            }
            _collater.MemberID = Convert.ToInt32(mycookie.Values["MemberID"]);
            CollaterResposity.Creat(_collater);
            return RedirectToAction("Index");
        }
        //修改
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var dbs = CollaterResposity.GetById(Convert.ToInt32(id));
            return View(dbs);
        }
        [HttpPost]
        public ActionResult Edit(CollaterDetail coll, HttpPostedFileBase Collateralimages)
        {
            HttpCookie mycookie = Request.Cookies["account"];
            if (Collateralimages != null)
            {
                if (Collateralimages.ContentLength > 0)
                {
                    //4. 將這個檔案轉成二進位
                    var imgSize = Collateralimages.ContentLength;
                    byte[] imgByte = new Byte[imgSize];
                    Collateralimages.InputStream.Read(imgByte, 0, imgSize);


                    coll.Collateralimage = imgByte;
                }
            }
            else
            {
                var CollaterImg = db.CollaterDetail.Find(coll.CollateralID).Collateralimage;
                coll.Collateralimage = CollaterImg;
            }
            coll.MemberID = Convert.ToInt32(mycookie.Values["MemberID"]); ;
            CollaterResposity.Update(coll);
            return RedirectToAction("Index");
        }
        //刪除
        public ActionResult Delete(int id = 0)
        {
            var coll = CollaterResposity.GetById(id);
            CollaterResposity.Delete(coll);
            return RedirectToAction("Index");
        }
        //讀取圖片
        public ActionResult GetImageByte(int id = 1)
        {
            CollaterDetail collater = db.CollaterDetail.Find(id);
            byte[] img = collater.Collateralimage;
            return File(img, "image/jpeg");
        }
    }
}