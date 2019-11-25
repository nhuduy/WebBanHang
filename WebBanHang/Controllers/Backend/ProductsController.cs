using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers.Backend
{
    public class ProductsController : Controller
    {
        private QuanLyBanHangEntities db = new QuanLyBanHangEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View("~/Views/Backend/Products/Index.cshtml", db.products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
         public ActionResult Create()
         {
            return View("~/Views/Backend/Products/Create.cshtml");
         }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = 
                "id,product_code,product_name,description,standard_cost,list_price,target_level," +
                    "reorder_level,minimum_reorder_quantity,quantity_per_unit,discontinued,category,image")] 
                product product,
            HttpPostedFileBase image )
        {
            if (ModelState.IsValid)
            {
                // Xử lý file: lưu file vào thư mục 
                string _FileName = "";
                string datetimeFolderName = "";
                //Di chuyen file vao thu muc mong muon
                if (image.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(image.FileName);
                    string _FileNameExtension = Path.GetExtension(image.FileName);
                    if ((_FileNameExtension == ".png"
                        || _FileNameExtension == ".jpg"
                        || _FileNameExtension == ".jpeg") == false)
                    {
                        return View(String.Format("File có đuôi {0} không hợp lệ. Vui lòng kiểm tra lại", _FileNameExtension));
                    }

                    string uploadFolderPath = Server.MapPath("~/UploadedFiles/ProductImages");

                    if (Directory.Exists(uploadFolderPath) == false)// Nếu thư mục cần lưu trữ file upload không tồn tại ( chưa có ) => tạo mới
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    string _path = Path.Combine(uploadFolderPath, _FileName);
                    image.SaveAs(_path);
                }

                // Lưu dữ liệu
                product.image = image.FileName;
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_code,product_name,description,standard_cost,list_price,target_level,reorder_level,minimum_reorder_quantity,quantity_per_unit,discontinued,category,image")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
    }
}
