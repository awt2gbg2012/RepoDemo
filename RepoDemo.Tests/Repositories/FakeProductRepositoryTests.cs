using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoDemo.Domain.Entities;
using RepoDemo.Domain.Repositories.Abstract;
using RepoDemo.Domain.Repositories;
using RepoDemo.Tests.Helpers;

namespace RepoDemo.Tests
{
    // Dessa tester testar eg. inget vettigt (eller rättare sagt - de testar FakeRepository-implementationen)
    //
    // I verkligheten hade vi ersatt dessa tester med integrationstester - dvs. vi testar Repository<T> 
    // med en databas i botten.
    //
    // Integrationstester testar integration mellan olika delar i systemet - i det här fallet
    // integrationen mellan Repository + EF + Databas.
    //
    // Vi vill dock inte ha integrationstester bland våra Unit Tests - de skall gå snabbt att köra och
    // stå på egna ben, därmed är det uteslutet att ha databasberoende bland dem.
    [TestClass]
    public class FakeProductRepositoryTests
    {
        [TestMethod]
        public void FakeProductProductRepository_FindAll_ReturnsListOfProduct()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);

            // Act
            var products = repo.FindAll();

            // Assert
            Assert.AreEqual(1, products.Count());
            Assert.AreEqual(products.FirstOrDefault().GetType(), typeof(Product));
        }

        [TestMethod]
        public void FakeProductProductRepository_FindAll_ReturnsListOfProductWithCorrectLength()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);

            // Act
            var products = repo.FindAll();

            // Assert
            Assert.AreEqual(1, products.Count());
        }

        [TestMethod]
        public void FakeProductProductRepository_FindByID_ReturnsProductIfPresent()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);

            // Act
            var product = repo.FindByID(ObjectMother.Test1Product.ID);

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void FakeProductProductRepository_FindByID_DoesNotReturnProductIfNotPresent()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);

            // Act
            var product = repo.FindByID(2);

            // Assert
            Assert.IsNull(product);
        }

        [TestMethod]
        public void FakeProductProductRepository_Save_UpdatesProductIfPresent()
        {
            // Arrange
            string newName = "Test2";
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);
            var product = repo.FindByID(ObjectMother.Test1Product.ID);
            product.Name = newName;
            repo.Update(product);

            // Act
            product = repo.FindByID(ObjectMother.Test1Product.ID);

            // Assert
            Assert.AreEqual<string>(newName, product.Name);
        }

        [TestMethod]
        public void FakeProductProductRepository_Save_AddsProductIfNotPresent()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);
            int newID = 2;
            var product = new Product { ID = newID, Name = "Test2" };

            // Act
            repo.Add(product);

            // Assert
            Assert.AreEqual<int>(2, repo.FindAll().Count());
            Assert.IsNotNull(repo.FindAll().Where(p => p.ID == newID).FirstOrDefault());
        }

        [TestMethod]
        public void FakeProductProductRepository_Delete_RemovesNoProductIfNotPresent()
        {
            // Arrange
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product);
            int newID = 2;
            var product = new Product { ID = newID, Name = "Test2" };

            // Act
            repo.Delete(product);

            // Assert
            Assert.AreEqual<int>(1, repo.FindAll().Count());
        }

        [TestMethod]
        public void FakeProductProductRepository_Delete_RemovesProductIfPresent()
        {
            // Arrange
            var product = ObjectMother.Test2Product;
            IRepository<Product> repo = new FakeRepository<Product>(ObjectMother.Test1Product,
                                                                    product);

            // Act
            repo.Delete(product);

            // Assert
            Assert.AreEqual<int>(1, repo.FindAll().Count());
            Assert.IsNull(repo.FindAll().Where(p => p.ID == product.ID).FirstOrDefault());
        }
    }
}
