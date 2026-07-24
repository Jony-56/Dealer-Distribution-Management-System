using DDMS.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductPriceHistory> ProductPricesHistories => Set<ProductPriceHistory>();
        public DbSet<Salesman> Salesmen => Set<Salesman>();
        public DbSet<StockEntry> StockEntries => Set<StockEntry>();
        public DbSet<StockEntryItem> StockEntryItems => Set<StockEntryItem>();
        public DbSet<Dispatch> Dispatches => Set<Dispatch>();
        public DbSet<DispatchItem> DispatchItems => Set<DispatchItem>();
        public DbSet<DailyClosing> DailyClosings => Set<DailyClosing>();

        public DbSet<DailyClosingItem> DailyClosingItems => Set<DailyClosingItem>();
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<StockAdjustment> StockAdjustments => Set<StockAdjustment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
