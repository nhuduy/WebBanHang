using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class ApiController : System.Web.Mvc.Controller
    {
        // https:// domain.com/api/products
        [System.Web.Mvc.HttpGet]
        public System.Web.Mvc.ActionResult GetProducts()
        {
            dynamic lstProduct = null;

            // Lấy dữ liệu danh sách Sản phẩm
            // Entity Framework
            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                // lstProduct = context.products.ToList(); // Lấy hết dữ liệu ra

                lstProduct = (from p in context.products
                              select new
                              {
                                  p.id,
                                  p.product_code,
                                  p.product_name,
                                  p.list_price
                              }).ToList();

                return Json(lstProduct, JsonRequestBehavior.AllowGet);
            }
        }

        public System.Web.Mvc.ActionResult GetCustomers()
        {
            dynamic lstCustomer = null;

            // Lấy dữ liệu danh sách Sản phẩm
            // Entity Framework
            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                // lstProduct = context.products.ToList(); // Lấy hết dữ liệu ra

                lstCustomer = (from p in context.customers
                              select new
                              {
                                  p.id,
                                  p.first_name,
                                  p.last_name,
                                  p.phone
                              }).ToList();

                return Json(lstCustomer, JsonRequestBehavior.AllowGet);
            }
        }

    }


}
