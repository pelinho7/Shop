using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DBAccess.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }
        [Required]
        [MaxLength(60)]
        public string Label{get;set;}
        public bool Deleted { get; set; }
        [Required]
        public DateTime ModDate { get; set; }

        public ICollection<ProductAmount> ProductAmounts { get; set; }


        public bool ttt(){
            if(Code == "W1") return true;
            return false;
        }
    }
}