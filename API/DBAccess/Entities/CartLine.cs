using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class CartLine
    {
        public int Id { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
    }
}