using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoldenShoe.Site.Models;
using GoldenShoe.Site.Services;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.Models;

namespace GoldenShoe.Site
{
    public class DetailsModel : PageModel
    {
        private readonly EFdbService eFdb;

        public Product shoeSelectedDB { get; private set; }
        

        [BindProperty(SupportsGet = true)]
        public string ProductId { get; set; }
        public bool validId { get; set; }

        

        public DetailsModel(EFdbService eFdb)
        {
            this.eFdb = eFdb;
        }
        public void OnGet()
        {
            
            //when no id is passed through url
            if (string.IsNullOrWhiteSpace(ProductId))
            {
                ProductId = "Invalid Id";
                validId = false;
            }
            else
            {
                shoeSelectedDB = eFdb.GetProducts()
                .Where(x => x.ShoeID == ProductId)
                .FirstOrDefault<Product>();
                

                // if product id is a valid id then do
                if (shoeSelectedDB != null)
                {
                    validId = true;
                    
                }
                else
                {
                    ProductId = "Invalid Id";
                    validId = false;
                }
            }

            
            
                

        }

        //public void ReduceStock()
        //{
        //    shoeSelected.Stock--;
        //    db.SaveChanges();
        //}
        public void OnPost()
        {

        }
        //public void OnPostCart()
        //{
        //    RedirectToPage("Cart", new {id = ProductId});
        //}
    }
}