using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreLibrary.DataAccess;
using StoreLibrary.Models;
using GoldenShoe.Site.Services;

namespace GoldenShoe.Site
{
    public class ChoosePurchaseModel : PageModel
    {
        private readonly PeopleContext _context;
        public List<Purchases> purchases { get; private set; }

        public List<ProductsBought> productsBoughts { get; private set; }

        public List<SelectListItem> RReasons { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "SIZE", Text = "Incorrect shoe size" },
            new SelectListItem { Value = "STYLE", Text = "Didn’t like the shoe style" },
            new SelectListItem { Value = "COLOR", Text = "Didn’t like the colour"  },
            new SelectListItem { Value = "OTHER", Text = "Other"},
        };

        public IEnumerable<Product> selectedProducts { get; private set; }

        public ChoosePurchaseModel(PeopleContext context)
        {

            _context = context;
        }
        public IEnumerable<SelectListItem> Options { get; set; }
        public bool NoResults;

        public IActionResult OnGet()
        {
            if (_context.Purchases != null && _context.Purchases.Count() != 0)
            {
                purchases = _context.Purchases.ToList();
                productsBoughts = _context.ProductsBoughts.ToList();
                selectedProducts = _context.Products.Where(x => x.ShoeID == productsBoughts.Select(c => c.ShoeID).ToString());
                
                Options = productsBoughts.Select(x =>
                new SelectListItem
                {
                    
                    Value = x.ShoeID.ToString(),
                    Text = x.ShoeName.ToString()
                });
                
                NoResults = false;
            }
            else
            {
                NoResults = true;
            }


            return Page();
        }

        [BindProperty]
        public SupportRequests Requests { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            purchases = _context.Purchases.ToList();

            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            
            Requests.OrderId = purchases.Select(x => x.OrderId).FirstOrDefault().ToString();
            Requests.RequestID = DateTime.Now.Ticks.ToString();
            _context.Requests.Add(Requests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SupportIndex");
        }

        
    }
}
