using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectFirst.Models;

namespace ProjectFirst.Data 
{ 
    public class FirstContext : DbContext
    {
        public FirstContext (DbContextOptions<FirstContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectFirst.Models.Address> Address { get; set; }

        public DbSet<ProjectFirst.Models.Category> Category { get; set; }

        public DbSet<ProjectFirst.Models.Client> Client { get; set; }

        public DbSet<ProjectFirst.Models.Comments> Comments { get; set; }

        public DbSet<ProjectFirst.Models.Coupen> Coupen { get; set; }

        public DbSet<ProjectFirst.Models.DeliveryInformation> DeliveryInformation { get; set; }

        public DbSet<ProjectFirst.Models.Deliveryman> Deliveryman { get; set; }

        public DbSet<ProjectFirst.Models.District> District { get; set; }

        public DbSet<ProjectFirst.Models.GifCard> GifCard { get; set; }

        public DbSet<ProjectFirst.Models.Municipality> Municipality { get; set; }

        public DbSet<ProjectFirst.Models.Order> Order { get; set; }

        public DbSet<ProjectFirst.Models.Payment> Payment { get; set; }

        public DbSet<ProjectFirst.Models.Product> Product { get; set; }

        public DbSet<ProjectFirst.Models.State> State { get; set; }

        public DbSet<ProjectFirst.Models.Supplier> Supplier { get; set; }

        public DbSet<ProjectFirst.Models.SupplierAttribute> SupplierAttribute { get; set; }      

        public DbSet<ProjectFirst.Models.ProductSubCategory> ProductSubCategory { get; set; }
    }
}
