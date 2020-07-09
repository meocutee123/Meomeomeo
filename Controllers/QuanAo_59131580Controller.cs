using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT20_59131580.Models;

namespace KT20_59131580.Controllers
{
    public class QuanAo_59131580Controller : Controller
    {
        private KT20_59131580Entities db = new KT20_59131580Entities();

        // GET: QuanAo_59131580
        public ActionResult Index()
        {
            var quanAos = db.QuanAos.Include(q => q.LOAIQUANAO);
            return View(quanAos.ToList());
        }

        // GET: QuanAo_59131580/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanAo quanAo = db.QuanAos.Find(id);
            if (quanAo == null)
            {
                return HttpNotFound();
            }
            return View(quanAo);
        }

        // GET: QuanAo_59131580/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LOAIQUANAOs, "MaLoai", "TenLoai");
            return View();
        }

        // POST: QuanAo_59131580/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQA,TenQA,MoTa,XuatXu,DonGia,AnhMinhHoa,MaLoai")] QuanAo quanAo, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                string postedFileName = Path.GetFileName(Avatar.FileName);
                var path = Server.MapPath("/Images/" + postedFileName);
                Avatar.SaveAs(path);
                quanAo.AnhMinhHoa = "/Images/" + postedFileName;

                db.QuanAos.Add(quanAo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LOAIQUANAOs, "MaLoai", "TenLoai", quanAo.MaLoai);
            return View(quanAo);
        }

        // GET: QuanAo_59131580/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanAo quanAo = db.QuanAos.Find(id);
            if (quanAo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LOAIQUANAOs, "MaLoai", "TenLoai", quanAo.MaLoai);
            return View(quanAo);
        }

        // POST: QuanAo_59131580/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQA,TenQA,MoTa,XuatXu,DonGia,AnhMinhHoa,MaLoai")] QuanAo quanAo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanAo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LOAIQUANAOs, "MaLoai", "TenLoai", quanAo.MaLoai);
            return View(quanAo);
        }

        // GET: QuanAo_59131580/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanAo quanAo = db.QuanAos.Find(id);
            if (quanAo == null)
            {
                return HttpNotFound();
            }
            return View(quanAo);
        }
        public ActionResult TimKiem_59131580(string MaQA = "", string TenQA = "")
        {
            
            ViewBag.MaQA = MaQA;
            ViewBag.TenQA = TenQA;
            
            var nhanViens = db.QuanAos.SqlQuery("NhanVien_TimKiem'" + MaQA + "','" + TenQA + "'");
            if (nhanViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(nhanViens.ToList());
        }
        // POST: QuanAo_59131580/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanAo quanAo = db.QuanAos.Find(id);
            db.QuanAos.Remove(quanAo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
