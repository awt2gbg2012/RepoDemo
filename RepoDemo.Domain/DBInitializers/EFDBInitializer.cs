using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RepoDemo.Domain.Contexts;
using RepoDemo.Domain.Entities;

namespace RepoDemo.Domain.DBInitializers
{
    public class EFDBInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            // Seed Category data
            var catWatersport = new Category { ID = 1, Name = "Watersport" };
            var catSoccer = new Category { ID = 2, Name = "Soccer" };
            var catChess = new Category { ID = 3, Name = "Chess" };
            var categories = new List<Category>
            {
                catWatersport,
                catSoccer,
                catChess,
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            // Seed Product data
            var products = new List<Product>
            {
                new Product { ID = 1, Name = @"Kayak", Description = @"A boat for one person", Price = 275M, Category = catWatersport },
                new Product { ID = 2, Name = @"Lifejacket", Description = @"Protective and fashionable", Price = 48.95M, Category = catWatersport},
                new Product { ID = 3, Name = @"Soccer ball", Description = @"FIFA-approved size and weight", Price = 19.5M, Category = catSoccer },
                new Product { ID = 4, Name = @"Corner flags", Description = @"Give your playing field that professional touch", Price = 34.95M, Category = catSoccer },
                new Product { ID = 5, Name = @"Stadium", Description = @"Flat-packed 35,000 seat stadium", Price = 79500M, Category = catSoccer },
                new Product { ID = 6, Name = @"Thinking cap", Description = @"Improve your brain efficiency by 75%", Price = 16.0M, Category = catChess },
                new Product { ID = 7, Name = @"Unsteady chair", Description = @"Secretly give your opponent a disadvantage", Price = 29.95M, Category = catChess },
                new Product { ID = 8, Name = @"Human Chess Board", Description = @"A fun game for the whole family", Price = 75.00M, Category = catChess},
                new Product { ID = 9, Name = @"Bling-bling King", Description = @"Gold-plated, diamond-studded King", Price = 275M, Category = catChess },

            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}