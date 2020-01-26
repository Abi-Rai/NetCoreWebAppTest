using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoldenShoe.Site.Models
{
    public class ShoesOnly
    {
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string ImgUrl { get; set; }
        public string Id { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Variant { get; set; }
        public string OnSale { get; set; }
        [JsonPropertyName("original_price")]
        public string OriginalPrice { get; set; }
        [JsonPropertyName("review_rating")]
        public string ReviewRating { get; set; }
        public string Reviews { get; set; }

        [JsonPropertyName("buyers-category")]
        public string BuyersCategory { get; set; }
        public int Position { get; set; }

        //public int Stock { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ShoesOnly>(this);
        

    }
}
