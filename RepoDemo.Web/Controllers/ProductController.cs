using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoDemo.Domain.Entities;
using RepoDemo.Domain.Contexts;
using RepoDemo.Domain.Repositories;

namespace Lektion13.Web.Controllers
{ 
    public class ProductController : Controller
    {
        private ProductRepository productRepo = new ProductRepository();
        private Repository<Category> categoryRepo = new Repository<Category>();

        //
        // GET: /Product/

        public ViewResult Index()
        {
            var products = productRepo.FindAll().Include(p => p.Category);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = productRepo.FindByID(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(categoryRepo.FindAll(), "ID", "Name");
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepo.Add(product);
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(categoryRepo.FindAll(), "ID", "Name", product.CategoryID);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = productRepo.FindByID(id);
            ViewBag.CategoryID = new SelectList(categoryRepo.FindAll(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepo.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(categoryRepo.FindAll(), "ID", "Name", product.CategoryID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = productRepo.FindByID(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productRepo.FindByID(id);
            productRepo.Delete(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}