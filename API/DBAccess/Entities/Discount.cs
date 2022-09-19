using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public double Value { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Deleted { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime ModDate { get; set; }
    }
}