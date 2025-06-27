using Warehouse_SQL.Models;

namespace Warehouse_UseCases.Interfaces
{
    public interface IProductUseCase
    {
        void Add(Product product);
        Product Get(int productId);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategory(int categoryId);
        void Update(Product product);
        void Delete(int productId);
        void Sell(int productId, int quantityToSell, string employeeId, string employeeName);
    }
}