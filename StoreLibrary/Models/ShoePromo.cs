using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreLibrary.Models
{
    public class ShoePromo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string  ShoeIdMatch{ get; set; }

        public virtual Product SelectPromoProduct { get; set; }

    }
}
