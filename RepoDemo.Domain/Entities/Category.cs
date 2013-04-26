using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoDemo.Domain.Entities.Abstract;

namespace RepoDemo.Domain.Entities
{
    public class Category : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}