using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDienThoai.Models;

namespace WebDienThoai.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        WebDienThoaiEntities1 db = new WebDienThoaiEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemChiTiet()
        {
            return View(db.KhachHangs.OrderBy(n => n.IdKH));
        }
        [HttpPost]
        public ActionResult LoginAdmin(FormCollection collection)
        {
            string TaiKhoan = collection["txtUser"].ToString();
            string MatKhau = collection["txtPass"].ToString();
            ThanhVien thanhvien = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == TaiKhoan && n.MatKhau == MatKhau);
            if (thanhvien != null)
            {
                Session["user"] = thanhvien;
                return RedirectToAction("Index", "QuanLySanPham");

            }
            return Content("Tài khoản hoặc mật khẩu không đúng!");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index","Admin");
        }
	}
}