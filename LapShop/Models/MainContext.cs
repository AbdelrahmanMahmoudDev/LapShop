using Microsoft.EntityFrameworkCore;

namespace LapShop.Models
{
    public class MainContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BusinessInfo> BusinessInfo { get; set; }
        public virtual DbSet<CashTransaction> CashTransactions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<OperatingSystem> OperatingSystems { get; set; }
        public virtual DbSet<CustomerxItem> CustomerxItems { get; set; }
        public virtual DbSet<ItemDiscount> ItemDiscounts { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public MainContext() : base() { }
        public MainContext(DbContextOptions Options) : base(Options) { }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(200);
            configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8, 2)");
            configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e => e.HasKey(a => a.CustomerId));
            modelBuilder.Entity<Category>(e => e.HasKey(a => a.CategoryId));
            modelBuilder.Entity<ItemType>(e => e.HasKey(a => a.ItemTypeId));
            modelBuilder.Entity<OperatingSystem>(e => e.HasKey(a => a.OperatingSystemId));

            modelBuilder.Entity<BusinessInfo>(e =>
            {
                e.HasKey(a => a.BusinessInfoId);

                e.HasOne(a => a.Customer)
                 .WithMany(a => a.BusinessInfo)
                 .HasForeignKey(a => a.CustomerId);
            });

            modelBuilder.Entity<CashTransaction>(e =>
            {
                e.HasKey(a => a.CashTransactionId);

                e.HasOne(a => a.Customer)
                 .WithMany(a => a.CashTransactions)
                 .HasForeignKey(a => a.CustomerId);
            });


            modelBuilder.Entity<Item>(e =>
            {
                e.HasKey(a => a.ItemId);

                e.HasOne(a => a.Category)
                 .WithMany(a => a.Items)
                 .HasForeignKey(a => a.CategoryId);

                e.HasOne(a => a.ItemType)
                 .WithMany(a => a.Items)
                 .HasForeignKey(a => a.ItemTypeId);

                e.HasOne(a => a.OperatingSystem)
                 .WithMany(a => a.Items)
                 .HasForeignKey(a => a.OperatingSystemId);
            });

            modelBuilder.Entity<CustomerxItem>(e =>
            {
                e.HasKey(a => a.CustomerxItemId);

                e.HasOne(a => a.Customer)
                 .WithMany(a => a.CustomerxItems)
                 .HasForeignKey(a => a.CustomerId);

                e.HasOne(a => a.Item)
                 .WithMany(a => a.CustomerxItems)
                 .HasForeignKey(a => a.ItemId);
            });

            modelBuilder.Entity<ItemDiscount>(e =>
            {
                e.HasKey(a => a.ItemDiscountId);

                e.HasOne(a => a.Item)
                 .WithMany(a => a.ItemDiscounts)
                 .HasForeignKey(a => a.ItemId);
            });

            modelBuilder.Entity<ItemImage>(e =>
            {
                e.HasKey(a => a.ItemImageId);

                e.HasOne(a => a.Item)
                 .WithMany(a => a.ItemImages)
                 .HasForeignKey(a => a.ItemId);
            });
        }
    }
}
