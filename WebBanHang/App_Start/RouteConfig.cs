using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebBanHang.EF;

namespace WebBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Page.trang_chu",
              url: "",
              defaults: new { controller = "Page", action = "Index" }
          );

            routes.MapRoute(
               name: "Page.gioi_thieu",
               url: "gioi-thieu",
               defaults: new { controller = "Page", action = "GioiThieu" }
           );

            routes.MapRoute(
               name: "Page.lien_he",
               url: "lien-he",
               defaults: new { controller = "Page", action = "LienHe" }
           );

            routes.MapRoute(
                name: "Page.san_pham",
                url: "san-pham",
                 defaults: new { controller = "Page", action = "SanPham" }
            );

            // Route mặc định của trang Chi tiết sản phẩm
            // URL: /product-detail
            routes.MapRoute(
                name: "Page.product_detail",
                url: "chitiet-sanpham",
                defaults: new { controller = "Page", action = "ProductDetail(int id)" }
            );

            // Route mặc định của trang Sản phẩm
            // URL: /tim-kiem
            routes.MapRoute(
                name: "Page.tim_kiem",
                url: "tim-kiem",
                defaults: new { controller = "Page", action = "Index" }
            );

            // Route mặc định của trang Đơn hàng
            // URL: /gio-hang
            routes.MapRoute(
                name: "Page.gio_hang",
                url: "gio-hang",
                defaults: new { controller = "Page", action = "GioHang" }
            );

            // URL: /dang-nhap
            routes.MapRoute(
                name: "Page.dang_nhap",
                url: "dang-nhap",
                defaults: new { controller = "Page", action = "DangNhap" }
            );

            // Route mặc định của trang Đăng ký
            // URL: /dang-ky
            routes.MapRoute(
                name: "Page.dang_ky",
                url: "dang-ky",
                defaults: new { controller = "Page", action = "DangKy" }
            );

            routes.MapRoute(
                name: "Account.dang_nhap",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "DangNhap" }
           );

            routes.MapRoute(
                name: "Account.dang_ky",
                url: "dang-ky",
                defaults: new { controller = "Account", action = "DangKy" }
        );

            // Route mặc định của trang Check out
            // URL: /check-out
            routes.MapRoute(
                name: "Page.check_out",
                url: "check-out",
                defaults: new { controller = "Page", action = "CheckOut" }
            );

            // URL: /chinh-sach
            routes.MapRoute(
                name: "Page.chinh_sach",
                url: "chinh-sach",
                defaults: new { controller = "Page", action = "ChinhSach" }
            );

            // URL: /dieu-khoan
            routes.MapRoute(
                name: "Page.dieu_khoan",
                url: "dieu-khoan",
                defaults: new { controller = "Page", action = "DieuKhoan" }
            );

            // URL: /sanpham-chitiet
            routes.MapRoute(
                name: "Product.sanpham_chitiet",
                url: "sanpham-chitiet",
                defaults: new { controller = "Product", action = "ProductDetail" }
            );

            // Route dành cho Backend
            // Route Dashboard
            routes.MapRoute(
                name: "admin.page.dashboard",
                url: "admin/dashboard",
                defaults: new { controller = "Dashboard", action = "Index" },
                namespaces: new string[] { "WebBanHang.Controllers.Backend" }
            );

            // Route sản phẩm
            routes.MapRoute(
                name: "admin.products.index",
                url: "admin/products",
                defaults: new { controller = "Products", action = "Index" },
                namespaces: new string[] { "WebBanHang.Controllers.Backend" }
            );

            // Route mặc định của trang Web
            // URL: /
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
