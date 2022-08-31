using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class ProductAmount
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
    }
}