using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_SQL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }

    public class InputProductModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int? Quantity { get; set; }
    }
}
