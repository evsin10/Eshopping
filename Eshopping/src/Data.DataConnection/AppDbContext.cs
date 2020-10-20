using Data.Models.Interfaces;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Threading;

namespace Data.DataConnection
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerCustomers> SellerCustomers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-2JBPUPQ;Database:;Trusted_Connection=True;");
        }
        private void ApplyChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IEditInfo).ToList();
            foreach (var entry in entries)
            {
                var entity = (IEditInfo)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }
        public override int SaveChanges()
        {
            return base.SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess);
                
        }
        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}
