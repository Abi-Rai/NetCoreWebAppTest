using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreLibrary.Models
{
    public class CartItem
    {
        [Key]
        public string Id { get; set; }

        // cart id stores session ID, can be called User ID each session
        [Required]
        [MaxLength(70)]
        public string CartId { get; set; }
        public int Quantity { get; set; }

        [MaxLength(50)]
        public string ShoeId { get; set; }
        public virtual Product Product { get; set; }

    }
}
