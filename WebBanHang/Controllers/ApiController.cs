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

        // POST: http://domain.com/api/products/{id}/delete
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    product products = context.products.Find(id);
                    context.products.Remove(products);
                    context.SaveChanges();
                }

                object result = new
                {
                    Code = 200,
                    Message = "Đã xóa product thành công!"
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };

                return Json(result);
            }
        }

        // POST: http://domain.com/api/products/create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]product product)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    context.products.Add(product);
                    context.SaveChanges(); // id tự sinh
                }

                object result = new
                {
                    Code = 201,
                    Message = "Đã thêm product thành công!",
                    CreatedObject = product
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };

                return Json(result);
            }
        }

        // POST: http://domain.com/api/products/{id}/edit
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, [FromBody]product product)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    product productEdited = context.products.Find(id);
                    if (!String.IsNullOrEmpty(product.category))
                    {
                        productEdited.category = product.category;
                    }
                    if (!String.IsNullOrEmpty(product.description))
                    {
                        productEdited.description = product.description;
                    }
                    productEdited.discontinued = product.discontinued;
                    productEdited.image = product.image;
                    if (product.list_price > 0)
                    {
                        productEdited.list_price = product.list_price;
                    }
                    productEdited.minimum_reorder_quantity = product.minimum_reorder_quantity;
                    productEdited.order_details = product.order_details;
                    productEdited.product_code = product.product_code;
                    productEdited.product_name = product.product_name;
                    productEdited.quantity_per_unit = product.quantity_per_unit;
                    productEdited.reorder_level = product.reorder_level;
                    productEdited.standard_cost = product.standard_cost;
                    productEdited.target_level = product.target_level;
                    context.SaveChanges();
                }

                object result = new
                {
                    Code = 200,
                    Message = "Đã hiệu chỉnh product thành công!"
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };

                return Json(result);
            }
        }
    }

    class ResponseResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object CreatedObject { get; set; }
    }


}
