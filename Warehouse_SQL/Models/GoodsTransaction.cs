using System.ComponentModel.DataAnnotations;

namespace Warehouse_SQL.Models
{
    public class GoodsTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TimeStamp { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int StockQuantity{ get; set; }

        public int SellQuantity { get; set; }

        public double Price { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }
    }
}
