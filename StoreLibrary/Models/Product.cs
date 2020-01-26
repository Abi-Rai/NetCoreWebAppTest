using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreLibrary.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShoeID { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(50)]
        public string Name2 { get; set; }

        [MaxLength(150)]
        public string ImgUrl { get; set; }

        [MaxLength(10)]
        public string Price { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(20)]
        public string Brand { get; set; }

        [MaxLength(50)]
        public string Variant { get; set; }

        [MaxLength(10)]
        public string OnSale { get; set; }

        [MaxLength(10)]
        public string original_price { get; set; }
        public List<Reviews> Reviews { get; set; }

    }
}
