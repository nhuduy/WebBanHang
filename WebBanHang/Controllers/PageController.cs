using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DieuKhoan()
        {
            ViewBag.Message = "Đây là trang điều khoản...";

            return View();
        }

        public ActionResult SanPham()
        {
            ViewBag.Message = "Đây là trang sản phẩm...";

            return View();
        }


    }
}