using BulkInsertDemo.Context;
using BulkInsertDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BulkInsertDemo.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Product/Create
        [HttpPost]
        public JsonResult Save(List<Product> product)
        {
            foreach (var p in product)
            {
                if (p != null)
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                }
            }
            return Json("Success");
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);


        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);

            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Product product)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    product = db.Products.Find(id);
                    if (product == null)
                        return HttpNotFound();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}