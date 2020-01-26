using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreLibrary.Models
{
    public class Purchases
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderId { get; set; }
        [Required]
        public System.DateTime DateCreated { get; set; }

        [Required]
        public double TotalPaid { get; set; }
        
        public List<ProductsBought> ProductsBought { get; set; }


    }
}
