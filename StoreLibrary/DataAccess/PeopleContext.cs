using Microsoft.EntityFrameworkCore;
using StoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<SupportRequests> Requests { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }

        public DbSet<ProductsBought> ProductsBoughts { get; set; }
        
    }
}
