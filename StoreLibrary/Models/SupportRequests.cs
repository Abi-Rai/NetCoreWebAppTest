using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StoreLibrary.Models
{
    public class SupportRequests
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string RequestID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Reason { get; set; }

        
        [MaxLength(150)]
        public string Message { get; set; }

        [Required]
        [MaxLength(50)]
        public string ForShoeID { get; set; }

        
        [MaxLength(50)]
        public string OrderId { get; set; }
    }
}
