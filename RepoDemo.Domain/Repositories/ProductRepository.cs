using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RepoDemo.Domain.Entities;
using RepoDemo.Domain.Repositories.Abstract;

namespace RepoDemo.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> FindProductsByCategoryID(int id);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository() : base() {}

        public IQueryable<Product> FindProductsByCategoryID(int id)
        {
            return _dbSet.Where(p => p.Category.ID == id).Include(p => p.Category);
        }

        // Filter Methods for ProductRepository

        public static Func<Product, bool> FilterProductsWithEmptyDescription
        {
            get
            {
                return p => string.IsNullOrEmpty(p.Description);
            }
        }
    }
}