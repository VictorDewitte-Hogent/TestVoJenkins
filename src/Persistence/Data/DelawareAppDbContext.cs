using System;
using Domain.Packaging;
using Domain.Products;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Data.Configuration;

namespace Persistence.Data
{
    public class DelawareAppDbContext : DbContext
    {
        public DelawareAppDbContext(DbContextOptions<DelawareAppDbContext> options) : base(options)
            { }

        public DbSet<Box> Designs { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DesignEntityTypeConfiguration());
        }
    }
}
