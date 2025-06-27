using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;

namespace Warehouse_SQL.RepositoryInteface
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category Get(int categoryId);
        IEnumerable<Category> GetAll();
        void Update(Category category);
        void Update(Category category, int categoryId);
        void Delete(int categoryId);
    }
}
