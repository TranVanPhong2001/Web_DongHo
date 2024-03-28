using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhomZuiZeDoAn.Models;

namespace NhomZuiZeDoAn.Areas.Admin.Controllers
{
    public class DongHoesController : Controller
    {
        private DongHoContext db = new DongHoContext();

        // GET: Admin/DongHoes
        public ActionResult Index()
        {
            var dongHoes = db.DongHoes.Include(d => d.Hangss);
            return View(dongHoes.ToList());
        }

        // GET: Admin/DongHoes/Details/5
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

        // GET: Admin/DongHoes/Create
        public ActionResult Create()
        {
            ViewBag.Hang = new SelectList(db.Hangs, "MaHang", "TenHang");
            return View();
        }

        // POST: Admin/DongHoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ten,Hang,Gia,Image,XuatXu,GioiTinh")] DongHo dongHo, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //Luu hinh vao web server
                if(Image != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Theme_DongHo/image/"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path);
                }
                //Luu DongHo vao db
                dongHo.Image = "/Content/Theme_DongHo/image/" + Path.GetFileName(Image.FileName);
                db.DongHoes.Add(dongHo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hang = new SelectList(db.Hangs, "MaHang", "TenHang", dongHo.Hang);
            return View(dongHo);
        }

        // GET: Admin/DongHoes/Edit/5
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

        // POST: Admin/DongHoes/Edit/5
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

        // GET: Admin/DongHoes/Delete/5
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

        // POST: Admin/DongHoes/Delete/5
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
        public ActionResult Search(string searchString)
        {
            var products = db.DongHoes.Where(p => p.Ten.Contains(searchString)).ToList();
            return View("Index", products);
        }
    }
}
