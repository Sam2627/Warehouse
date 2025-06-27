using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;
using Warehouse_SQL.RepositoryInteface;

namespace Warehouse_SQL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDbContext db;

        public ProductRepository(WarehouseDbContext db)
        {
            this.db = db;
        }

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product Get(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            var prod = db.Products.Find(product.ProductId);
            if (prod == null) return;

            prod.Name = product.Name;
            prod.CategoryId = product.CategoryId;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            db.SaveChanges();
        }
    }
}
