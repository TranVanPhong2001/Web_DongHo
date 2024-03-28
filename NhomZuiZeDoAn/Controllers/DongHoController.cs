using NhomZuiZeDoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhomZuiZeDoAn.Controllers
{
    public class DongHoController : Controller
    {        
        private DongHoContext db = new DongHoContext();

        public ActionResult Index()
        {
            var listDongHo = db.DongHoes.ToList();
            return View("Index", listDongHo);
        }
        public ActionResult Details(int id) 
        {
            var chitietDH = db.DongHoes.FirstOrDefault(x=> x.Id == id);
            return View("Details", chitietDH);
        }
        public ActionResult Search(string searchString)
        {
            var products = db.DongHoes.Where(p => p.Ten.Contains(searchString)).ToList();
            return View("Index", products);
        }
        public ActionResult PhanLoai()
        {
            var distinctLoaiDongHoList = db.DongHoes.Select(d => d.Hangss.TenHang).Distinct().ToList();
            ViewBag.LoaiDongHoList = new SelectList(distinctLoaiDongHoList);
            return PartialView("_LoaiDongHoListPartial");
        }
    }
}