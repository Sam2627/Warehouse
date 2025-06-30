using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;
using Warehouse_SQL.RepositoryInteface;

namespace Warehouse_SQL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WarehouseDbContext db;

        public CategoryRepository(WarehouseDbContext db) { this.db = db; }

        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if (category == null) return;

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category Get(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public IEnumerable<Category> GetAll()
        {
            return [.. db.Categories];

            //return await db.Categories.ToListAsync();
        }

        public void Update(Category category)
        {
            var cat = db.Categories.Find(category.CategoryId);
            if (cat == null) return;

            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
        }

        public void Update(Category category, int categoryId)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (cat == null) return;

            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
        }
    }
}
