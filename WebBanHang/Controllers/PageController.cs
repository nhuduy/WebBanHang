using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            List <product> lstProduct = new List <product>();

            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                lstProduct = context.products.ToList();
            }
            // Truyền dữ liệu từ controller => View thông qua viewBag
            //Tên View mới DanhSachSanPham
            ViewBag.DanhSachSanPham = lstProduct;

            return View();
        }

        public ActionResult SanPham()
        {
            return View();
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult LienHe()
        {
            return View();
        }

        public ActionResult ChinhSach()
        {
            return View();
        }
        public ActionResult DieuKhoan()
        {
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

    }
}