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
    public class ShoeDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ProductId { get; set; }
        public ShoeDetailsModel()
        {

        }
        public void OnGet()
        {
            
        }
    }
}