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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WarehouseDbContext db;

        public TransactionRepository(WarehouseDbContext db)
        {
            this.db = db;
        }

        public void Add(int productId, int soldQuantity, string employeeId, string employeeName)
        {
            var product = db.Products.Find(productId);

            var transaction = new GoodsTransaction
            {
                ProductId = productId,
                ProductName = product.Name,
                TimeStamp = DateTime.Now,
                Price = product.Price.Value,
                StockQuantity = product.Quantity.Value,
                SellQuantity = soldQuantity,
                EmployeeId = employeeId,
                EmployeeName = employeeName
            };

            db.GoodsTransaction.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<GoodsTransaction> Get(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                var result = db.GoodsTransaction.ToList();
                //return db.GoodsTransaction.ToList();
                return result;
            }
            else
            {
                var result = db.GoodsTransaction.Where(x => x.EmployeeName == employeeName).ToList();
                //return db.GoodsTransaction.Where(x => x.EmployeeName == employeeName).ToList();
                return result;
            }
            
        }

        public async Task<IEnumerable<GoodsTransaction>> GetAsync(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName)) return await db.GoodsTransaction.ToListAsync();
            else return await db.GoodsTransaction.Where(x => x.EmployeeName == employeeName).ToListAsync();
        }

        public IEnumerable<GoodsTransaction> Get(string employeeName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                return db.GoodsTransaction.Where(x => x.TimeStamp.Date == date.Date);
            else
                return db.GoodsTransaction.Where(
                x => x.EmployeeName.ToLower() == employeeName.ToLower() &&
                x.TimeStamp.Date == date.Date);
        }

        public IEnumerable<GoodsTransaction> Search(string employeeName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                return db.GoodsTransaction.Where(x => x.TimeStamp.Date >= startDate.Date &&
                x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return db.GoodsTransaction.Where(x => x.EmployeeName.ToLower() == employeeName.ToLower() &&
                x.TimeStamp.Date >= startDate.Date &&
                x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
