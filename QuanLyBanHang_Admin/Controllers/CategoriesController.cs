using Microsoft.AspNetCore.Mvc;
using QuanLyBanHang_Admin.Models;

namespace QuanLyBanHang_Admin.Controllers
{
    public class CategoriesController : Controller
    {
        QuanLyHangHoaContext db = new QuanLyHangHoaContext();
        public IActionResult Index()
        {
            return View(db.Loaihanghoas);
        }

        [HttpGet]
        public ActionResult them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult them(Loaihanghoa n)
        {
            db.Loaihanghoas.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult sua(string id)
        {
            Loaihanghoa cates = db.Loaihanghoas.Find(id);
            ViewBag.category = cates;
            return View();
        }
        [HttpPost]
        public ActionResult sua(Loaihanghoa n)
        {
            Loaihanghoa old = db.Loaihanghoas.Find(n.Maloai);
            old.Tenloai = n.Tenloai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult xoa(string id)
        {
            Loaihanghoa cates = db.Loaihanghoas.Find(id);
            ViewBag.category = cates;
            return View();
        }
        [HttpPost]
        public ActionResult xoa(Loaihanghoa n)
        {
            Loaihanghoa cate = db.Loaihanghoas.Find(n.Maloai);
            if (cate != null)
            {

                db.Loaihanghoas.Remove(cate);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
