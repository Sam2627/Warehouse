using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;

namespace Warehouse_SQL.RepositoryInteface
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product Get(int productId);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(int categoryId);
        void Update(Product product);
        void Delete(int productId);
    }
}
