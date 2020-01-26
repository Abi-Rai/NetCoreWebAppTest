using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreLibrary.DataAccess;
using StoreLibrary.Models;

using GoldenShoe.Site.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GoldenShoe.Site.Services
{
    public class EFdbService
    {
        private readonly PeopleContext db;
        private Product selectedProduct;
        public List<Product> productsToAdd { get; set; }

        public const string CartSessionKey = "CartItem";


        public EFdbService(PeopleContext db)
        {

            this.db = db;
        }

        public IEnumerable<Person> GetPeople()
        {
            return db.People;
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }
        public IEnumerable<Purchases> GetPurchases()
        {
            return db.Purchases;
        }
        public IEnumerable<Reviews> GetReviews()
        {
            return db.Reviews;
        }
        public IEnumerable<SupportRequests> GetSupportRequests()
        {
            return db.Requests;
        }

        public void ChangeStock(string shoeID, int amount)
        {
            selectedProduct = db.Products.Where(e => e.ShoeID == shoeID).FirstOrDefault();
            selectedProduct.Stock += amount;
            db.SaveChanges();
        }
        public void PurchasesAdd(IEnumerable<CartItem> cartItems, double total)
        {
            Purchases purchases = new Purchases
            {
                DateCreated = DateTime.Now,
                OrderId = DateTime.Now.Ticks.ToString(),
                TotalPaid = total,
               
                //Products = cartItems.Select(e => e.Product).ToList()
            };

            purchases.ProductsBought = new List<ProductsBought>();

            foreach (var shoe in cartItems)
            {
                purchases.ProductsBought.Add(
                    new ProductsBought
                    {
                        ShoeID = shoe.Product.ShoeID,
                        ShoeName = shoe.Product.Name,
                        ShoePrice = shoe.Product.Price,
                        QuantityBought = shoe.Quantity,
                        OrderIDref = purchases.OrderId
                    });

                ChangeStock(shoe.ShoeId, (shoe.Quantity) * -1);
            }
            db.Purchases.Add(purchases);
            db.SaveChanges();
        }


        public void LoadSampleData()
        {
            if (db.Products.Count() == 0)
            {
                string prodFile = System.IO.File.ReadAllText("productLoad.json");
                var product = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(prodFile);
                db.AddRange(product);
                db.SaveChanges();
            }

        }
        public Product GetSelectedProduct(string shoeID)
        {
            return selectedProduct = db.Products.Where(e => e.ShoeID == shoeID).FirstOrDefault();
        }

        // ----------- NOTImplemented use AddToCart method on db service --------- 

        //private List<CartItem> cartItems;

        //public void AddToCartOnly(string id,ISession session)
        //{
        //    IEnumerable<Product> productModel = GetProducts();

        //    var value = session.GetString(CartSessionKey);
        //    cartItems = value == null ? default(List<CartItem>) : JsonConvert.DeserializeObject<List<CartItem>>(value);
        //    if (cartItems == null)
        //    {
        //        cartItems = new List<CartItem>();
        //        cartItems.Add(new CartItem
        //        {
        //            Product = productModel.Where(p => p.ShoeID == id).FirstOrDefault(),
        //            Quantity = 1,
        //            CartId = session.Id,
        //            ShoeId = id
        //        });
        //        session.SetString(CartSessionKey, JsonConvert.SerializeObject(cartItems));
        //    }
        //    else
        //    {
        //        int index = Exists(cartItems, id);
        //        if (index == -1)
        //        {
        //            cartItems.Add(new CartItem
        //            {
        //                Product = productModel.Where(p => p.ShoeID == id).FirstOrDefault(),
        //                Quantity = 1,
        //                CartId = session.Id,
        //                ShoeId = id
        //            });
        //        }
        //        else
        //        {
        //            cartItems[index].Quantity++;
        //        }
        //        session.SetString(CartSessionKey, JsonConvert.SerializeObject(cartItems));
        //    }

        //    int Exists(List<CartItem> cart, string id)
        //    {
        //        for (var i = 0; i < cart.Count; i++)
        //        {
        //            if (cart[i].Product.ShoeID == id)
        //            {
        //                return i;
        //            }
        //        }
        //        return -1;
        //    }
        //}
    }
}
