using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoldenShoe.Site.Models;
using GoldenShoe.Site.Services;



namespace GoldenShoe.Site
{

    public class StoreModel : PageModel
    {
        
        public IEnumerable<ShoesOnly> ShoesOnly{get; private set;}
        public StoreModel(JsonFileShoesService shoesService)
        {
            //ShoesService = shoesService;
        }
        public void OnGet()
        {
            //ShoesOnly = ShoesService.GetShoesOnly();
        }
        
    }
}