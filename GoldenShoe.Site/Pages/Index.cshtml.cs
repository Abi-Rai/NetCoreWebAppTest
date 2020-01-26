using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GoldenShoe.Site.Models;
using GoldenShoe.Site.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreLibrary.DataAccess;
using StoreLibrary.Models;

namespace GoldenShoe.Site.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileShoesService ShoesService;
        public readonly EFdbService EFdbService;
        
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<ShoesOnly> ShoesOnly { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, JsonFileShoesService shoesService, EFdbService efdb)
        {
            _logger = logger;
            ShoesService = shoesService;
            EFdbService = efdb;
        }

        public void OnGet()
        {
            EFdbService.LoadSampleData();
            Products = EFdbService.GetProducts();
            ShoesOnly = ShoesService.GetShoesOnly();
            

            //People = db.People
            //    .Include(a => a.Purchases)
            //    .ThenInclude(b => b.Product)
            //    .ThenInclude(c => c.Reviews)
            //    ;

            //Products = db.Products;
                


            //Product p = products.Where(e => e.ShoeID == "0472503730009511").FirstOrDefault();
            //for (int i = 0; i < 3; i++)
            //{
            //    p.Stock--;
            //}
            //db.SaveChanges();



            // add ids in reviewservice here
            //ReviewsService.AddId();
        }

        
    }
}
