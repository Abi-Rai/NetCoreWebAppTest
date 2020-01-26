using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GoldenShoe.Site.Models
{
    // Class for reviews of products
    public class Reviews
    {
        public string Id { get; set; }

        public int[] Ratings { get; set; }

        public string[] ReviewsText { get; set; }
        public int Position { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Reviews>(this);
    }
   
}
