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
using GoldenShoe.Site.Helpers;

namespace GoldenShoe.Site
{
    public class DetailsModel : PageModel
    {
        private readonly EFdbService eFdb;

        public Product shoeSelectedDB { get; private set; } // single product selection
        public IEnumerable<Product> promoShoesOnly { get; set; }

        

        [BindProperty(SupportsGet = true)] 
        public string ProductId { get; set; } // url get shoe ID
        public bool validId { get; set; }


        // declarations for shoe promo
        public List<ShoePromo> ShoePromos { get; set; }
        public bool Promo;


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

                // get selected products shoe promos
                ShoePromos = eFdb.GetShoePromos(shoeSelectedDB.ShoeID);

                if (ShoePromos != null) // if promo shoes not null set bool promo true
                {
                    Promo = true;
                }

                if (Promo == true)
                {
                    ShuffleList.ShuffleThisList(ShoePromos); // if there are promo matches shuffle the list so that new products are promoted each OnGet

                    ShoePromos = ShoePromos.Take(3).ToList(); // only take the first three after shuffling the list
                    promoShoesOnly = eFdb.GetProducts();

                    foreach (var item in ShoePromos)
                    {
                        item.SelectPromoProduct = promoShoesOnly.Where(x => x.ShoeID == item.ShoeIdMatch).FirstOrDefault(); // store the product data onto the selected promo product
                    }
                }

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
        public void OnPost()
        {
        }
    }
}