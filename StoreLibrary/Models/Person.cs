using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreLibrary.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string CustomerInfo { get; set; }
        public List<Purchases> Purchases { get; set; }
    }
}
