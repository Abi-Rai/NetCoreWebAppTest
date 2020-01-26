using System.ComponentModel.DataAnnotations;

namespace StoreLibrary.Models
{
    public class ProductsBought
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShoeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShoeName { get; set; }

        [Required]
        [MaxLength(10)]
        public string ShoePrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderIDref { get; set; }
        [Required]
        public int QuantityBought { get; set; }
    }
}