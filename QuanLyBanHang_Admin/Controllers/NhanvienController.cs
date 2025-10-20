using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang_Admin.Models;

namespace QuanLyBanHang_Admin.Controllers
{
    public class NhanvienController : Controller
    {
        QuanLyHangHoaContext db = new QuanLyHangHoaContext();
        public IActionResult Index()
        {
            return View(db.Nhanviens);
        }
        [HttpGet]
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(CNhanVien n)
        {
            Nhanvien a = CNhanVien.chuyendoi(n);
            db.Nhanviens.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult sua(string id)
        //{
        //    Nhanvien cates = db.Nhanviens.Find(id);
        //    ViewBag.category = cates;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult sua(Nhanvien n)
        //{
        //    Nhanvien old = db.Nhanviens.Find(n.Maloai);
        //    old.Tenloai = n.Tenloai;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult xoa(string id)
        //{
        //    Nhanvien cates = db.Nhanviens.Find(id);
        //    ViewBag.category = cates;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult xoa(Nhanvien n)
        //{
        //    Nhanvien cate = db.Nhanviens.Find(n.Maloai);
        //    if (cate != null)
        //    {

        //        db.Nhanviens.Remove(cate);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
