using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;
using Warehouse_SQL.Repository;
using Warehouse_SQL.RepositoryInteface;
using Warehouse_UseCases.Interfaces;

namespace Warehouse_UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ITransactionUseCase transactionUseCase;

        public ProductUseCase(IProductRepository productRepository, ITransactionUseCase transactionUseCase)
        {
            this.productRepository = productRepository;
            this.transactionUseCase = transactionUseCase;
        }

        public void Add(Product product)
        {
            productRepository.Add(product);
        }

        public void Delete(int productId)
        {
            productRepository.Delete(productId);
        }

        public Product Get(int productId)
        {
            return productRepository.Get(productId);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return productRepository.GetByCategory(categoryId);
        }

        public void Sell(int productId, int quantityToSell, string employeeId, string employeeName)
        {
            var product = productRepository.Get(productId);
            if (product == null) return;
            transactionUseCase.Add(productId, quantityToSell, employeeId, employeeName);
            product.Quantity -= quantityToSell;
            productRepository.Update(product);
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }
    }
}
