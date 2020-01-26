using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldenShoe.Site.Controllers;
using GoldenShoe.Site.Helpers;
using GoldenShoe.Site.Models;
using GoldenShoe.Site.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreLibrary.Models;


namespace GoldenShoe.Site
{
    public class CartModel : PageModel
    {

        EFdbService EFdbService;
        public List<CartItem> cartItems { get; set; }

        public string ShoePrice { get; set; }
        public double Total { get; set; }

        public const string CartSessionKey = "CartItem";

        public CartModel(EFdbService eFdb)
        {
            this.EFdbService = eFdb;
        }
        public void OnGet()
        {
            cartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, CartSessionKey);
            if (cartItems != null && cartItems.Count() != 0)
            {
                Total = cartItems.Sum(x => (Convert.ToInt32(x.Product.Price) * x.Quantity));
                ShoePrice = cartItems.Select(x => x.Product.Price).ToString();
            }
        }


        public IActionResult OnGetBuyNow(string id)
        {
            //var productModel = new ProductModel();
            IEnumerable<Product> productModel = EFdbService.GetProducts();
            cartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, CartSessionKey);
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
                cartItems.Add(new CartItem
                {
                    Product = productModel.Where(p => p.ShoeID == id).FirstOrDefault(),
                    Quantity = 1,
                    CartId = HttpContext.Session.Id,
                    ShoeId = id
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, CartSessionKey, cartItems);
            }
            else
            {
                int index = Exists(cartItems, id);
                if (index == -1)
                {
                    cartItems.Add(new CartItem
                    {
                        Product = productModel.Where(p => p.ShoeID == id).FirstOrDefault(),
                        Quantity = 1,
                        CartId = HttpContext.Session.Id,
                        ShoeId = id
                    });
                }
                else
                {
                    cartItems[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, CartSessionKey, cartItems);
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetDelete(string id)
        {
            cartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, CartSessionKey);
            int index = Exists(cartItems, id);
            cartItems.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, CartSessionKey, cartItems);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, CartSessionKey);
            for (var i = 0; i < cartItems.Count; i++)
            {
                cartItems[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, CartSessionKey, cartItems);
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetPurchase()
        {
            cartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, CartSessionKey);
            Total = cartItems.Sum(x => (Convert.ToInt32(x.Product.Price) * x.Quantity));
            EFdbService.PurchasesAdd(cartItems, Total);
            cartItems.RemoveRange(0, cartItems.Count());
            SessionHelper.SetObjectAsJson(HttpContext.Session, CartSessionKey, cartItems);
            
            return RedirectToPage("Cart");
        }

        private int Exists(List<CartItem> cart, string id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ShoeID == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}