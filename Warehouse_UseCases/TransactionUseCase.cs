using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;
using Warehouse_SQL.RepositoryInteface;
using Warehouse_UseCases.Interfaces;

namespace Warehouse_UseCases
{
    public class TransactionUseCase : ITransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public void Add(int productId, int soldQuantity, string employeeId, string employeeName)
        {
            transactionRepository.Add(productId, soldQuantity, employeeId, employeeName);
        }

        public IEnumerable<GoodsTransaction> Get(string employeeName)
        {
            return transactionRepository.Get(employeeName);
        }

        public async Task<IEnumerable<GoodsTransaction>> GetAsync(string employeeName)
        {
            return await transactionRepository.GetAsync(employeeName);
        }

        public IEnumerable<GoodsTransaction> Get(string employeeName, DateTime date)
        {
            return transactionRepository.Get(employeeName, date);
        }

        public IEnumerable<GoodsTransaction> Search(string employeeName, DateTime startDate, DateTime endDate)
        {
            return transactionRepository.Search(employeeName, startDate, endDate);
        }
    }
}
