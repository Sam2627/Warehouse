using System.Threading.Tasks;
using Warehouse_SQL.Models;
using Warehouse_SQL.RepositoryInteface;
using Warehouse_UseCases.Interfaces;

namespace Warehouse_UseCases
{
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            categoryRepository.Add(category);
        }

        public Category Get(int categoryId)
        {
            return categoryRepository.Get(categoryId);
        }
        public List<Category> GetAll()
        {
            return categoryRepository.GetAll().ToList();
        }
        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }

        public void Update(Category category, int categoryId)
        {
            categoryRepository.Update(category, categoryId);
        }

        public void Delete(int categoryId)
        {
            categoryRepository.Delete(categoryId);
        }
    }
}
