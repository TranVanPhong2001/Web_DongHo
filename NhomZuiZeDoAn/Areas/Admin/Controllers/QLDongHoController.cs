using NhomZuiZeDoAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NhomZuiZeDoAn.Areas.Admin.Controllers
{
    [Authorize]
    public class QLDongHoController : Controller
    {
        private DongHoContext db = new DongHoContext();
        // GET: Admin/QLDongHo
        public ActionResult Index()
        {
            var listDongHo1 = db.DongHoes.ToList();
            return View("Index", listDongHo1);
            
        }

        // GET: Admin/QLDongHo/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            return View(dongHo);
        }
        // GET: Admin/QLDongHo/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hang = new SelectList(db.Hangs, "MaHang", "TenHang", dongHo.Hang);
            return View(dongHo);
        }
        // POST: Admin/QLDongHo/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ten,Hang,Gia,Image,XuatXu,GioiTinh")] DongHo dongHo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dongHo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hang = new SelectList(db.Hangs, "MaHang", "TenHang", dongHo.Hang);
            return View(dongHo);
        }

        // GET: Admin/QLDongHo/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DongHo dongHo = db.DongHoes.Find(id);
            if (dongHo == null)
            {
                return HttpNotFound();
            }
            return View(dongHo);
        }

        // POST: Admin/QLDongHo/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DongHo dongHo = db.DongHoes.Find(id);
            db.DongHoes.Remove(dongHo);
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