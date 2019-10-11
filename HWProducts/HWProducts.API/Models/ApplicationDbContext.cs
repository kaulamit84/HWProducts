using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HWProducts.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("myConnectionString") { }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
    }
}