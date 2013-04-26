using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepoDemo.Domain.Entities;

namespace RepoDemo.Tests.Helpers
{
    public class ObjectMother
    {
        public static Category Test1Category
        {
            get 
            {
                return new Category { ID = 1, Name = "Test1" };
            }
        }

        public static Category Test2Category
        {
            get
            {
                return new Category { ID = 2, Name = "Test2" };
            }
        }

        public static Category Test3Category
        {
            get
            {
                return new Category { ID = 3, Name = "Test3" };
            }
        }

        public static Product Test1Product
        {
            get
            {
                return new Product { ID = 1, Name = "Product1", Description = "Desc1", Price = 1.0M, Category = Test1Category, CategoryID = Test1Category.ID };
            }
        }

        public static Product Test2Product
        {
            get
            {
                return new Product { ID = 2, Name = "Product2", Description = "Desc2", Price = 20.0M, Category = Test2Category, CategoryID = Test2Category.ID };
            }
        }

        public static Product Test3Product
        {
            get
            {
                return new Product { ID = 3, Name = "Product3", Description = "Desc3", Price = 300.0M, Category = Test1Category, CategoryID = Test1Category.ID };
            }
        }

        public static Product Test4Product
        {
            get
            {
                return new Product { ID = 4, Name = "Product4", Description = "Desc4", Price = 4000.0M, Category = Test2Category, CategoryID = Test2Category.ID };
            }
        }

        public static Product Test5Product
        {
            get
            {
                return new Product { ID = 5, Name = "Product5", Description = "Desc5", Price = 50000.0M, Category = Test1Category, CategoryID = Test1Category.ID };
            }
        }

        public static List<Product> ProductList_5Products_Test1AndTest2Categories
        {
            get
            {
                return new List<Product> {
                    Test1Product,
                    Test2Product,
                    Test3Product,
                    Test4Product,
                    Test5Product,
                };
            }
        }
    }
}
