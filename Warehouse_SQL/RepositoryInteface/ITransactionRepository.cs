using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_SQL.Models;

namespace Warehouse_SQL.RepositoryInteface
{
    public interface ITransactionRepository
    {
        public void Add(int productId, int soldQuantity, string employeeId, string employeeName);

        public IEnumerable<GoodsTransaction> Get(string employeeName);

        public Task<IEnumerable<GoodsTransaction>> GetAsync(string employeeName);

        public IEnumerable<GoodsTransaction> Get(string employeeName, DateTime date);

        public IEnumerable<GoodsTransaction> Search(string employeeName, DateTime startDate, DateTime endDate);

    }
}
