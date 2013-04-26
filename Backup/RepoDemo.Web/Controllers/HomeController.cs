using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion13.Domain.Repositories;
using Lektion13.Domain.Entities;

namespace Lektion13.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            // Generiskt Repository - Här skapas ett repository för Category
            // Repositoryt kräver typer som implementerar IEntity
            Repository<Category> categoryRepo = new Repository<Category>();

            // Samtliga metoder som finns med i det generiska repositoriet
            var categories = categoryRepo.FindAll();

            var filteredCategories = categoryRepo.FindAll(c => c.Name.Contains("sport"));

            var category = categoryRepo.FindByID(0);

            category.Name = "New Name!";
            categoryRepo.Save(category);

            categoryRepo.Delete(category);


















            ProductRepository productRepo = new ProductRepository();

            var products = productRepo.FindAll(); // + övriga "grund"-metoder

            // Metoder implementerade i ProductRepository:
            var productsForCategory = productRepo.FindProductsByCategoryID(0);

            var productsWithEmptyName = productRepo.FindAll(ProductRepository
                                                            .FilterProductsWithEmptyDescription);


            return View();
        }
    }
}
