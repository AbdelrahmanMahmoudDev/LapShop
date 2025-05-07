using LapShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Data
{
    public class MainContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BusinessInfo> BusinessInfo { get; set; }
        public virtual DbSet<CashTransaction> CashTransactions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<LapShop.Data.Models.OperatingSystem> OperatingSystems { get; set; }
        public virtual DbSet<CustomerxItem> CustomerxItems { get; set; }
        public virtual DbSet<ItemDiscount> ItemDiscounts { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<PurchaseInvoicexItem> PurchaseInvoicexItems { get; set; }
        public virtual DbSet<DeliveryMan> DeliveryMen { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }
        public virtual DbSet<SalesInvoicexItem> SalesInvoicexItems { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public MainContext() : base() { }
        public MainContext(DbContextOptions<MainContext> Options) : base(Options) { }
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
            modelBuilder.Entity<Supplier>(e => e.HasKey(a => a.SupplierId));
            modelBuilder.Entity<Slider>(e => e.HasKey(a => a.SliderId));
            modelBuilder.Entity<DeliveryMan>(e => e.HasKey(a => a.DeliveryManId));

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(a => a.CategoryId);
                e.Property(p => p.CreatedDate)
                 .HasColumnType("datetime2");
                e.Property(p => p.UpdatedDate)
                 .HasColumnType("datetime2");
            });

            modelBuilder.Entity<ItemType>(e =>
            {
                e.HasKey(a => a.ItemTypeId);
                e.Property(p => p.CreatedDate)
                 .HasColumnType("datetime2");
                e.Property(p => p.UpdatedDate)
                 .HasColumnType("datetime2");
            });

            modelBuilder.Entity<Models.OperatingSystem>(e =>
            {
                e.HasKey(a => a.OperatingSystemId);
                e.Property(p => p.CreatedDate)
                 .HasColumnType("datetime2");
                e.Property(p => p.UpdatedDate)
                 .HasColumnType("datetime2");
            });

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

                e.Property(p => p.CreatedDate)
                 .HasColumnType("datetime2");
                e.Property(p => p.UpdatedDate)
                 .HasColumnType("datetime2");
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

            modelBuilder.Entity<PurchaseInvoice>(e =>
            {
                e.HasKey(a => a.PurchaseInvoiceId);

                e.HasOne(a => a.Supplier)
                 .WithMany(a => a.PurchaseInvoices)
                 .HasForeignKey(a => a.SupplierId);
            });

            modelBuilder.Entity<PurchaseInvoicexItem>(e =>
            {
                e.HasKey(a => a.PurchaseInvoicexItemId);

                e.HasOne(a => a.PurchaseInvoice)
                 .WithMany(a => a.PurchaseInvoicexItems)
                 .HasForeignKey(a => a.PurchaseInvoiceId);

                e.HasOne(a => a.Item)
                 .WithMany(a => a.PurchaseInvoicexItems)
                 .HasForeignKey(a => a.ItemId);
            });

            modelBuilder.Entity<SalesInvoice>(e =>
            {
                e.HasKey(a => a.SalesInvoiceId);

                e.HasOne(a => a.DeliveryMan)
                 .WithMany(a => a.SalesInvoices)
                 .HasForeignKey(a => a.DeliveryManId);

                e.HasOne(a => a.Customer)
                 .WithMany(a => a.SalesInvoices)
                 .HasForeignKey(a => a.CustomerId);

                e.Property(p => p.CreatedDate)
                 .HasColumnType("datetime2");
                e.Property(p => p.UpdatedDate)
                 .HasColumnType("datetime2");
            });

            modelBuilder.Entity<SalesInvoicexItem>(e =>
            {
                e.HasKey(a => a.SalesInvoicexItemId);

                e.HasOne(a => a.SalesInvoice)
                 .WithMany(a => a.SalesInvoicexItems)
                 .HasForeignKey(a => a.SalesInvoiceId);

                e.HasOne(a => a.Item)
                 .WithMany(a => a.SalesInvoicexItems)
                 .HasForeignKey(a => a.ItemId);
            });
        }
    }
}
