using Warehouse_SQL.Models;

namespace Warehouse_UseCases.Interfaces
{
    public interface ICategoryUseCase
    {
        void Add(Category category);
        Category Get(int categoryId);
        List<Category> GetAll();
        void Update(Category category);

        void Update(Category category, int categoryId);
        void Delete(int categoryId);
    }
}