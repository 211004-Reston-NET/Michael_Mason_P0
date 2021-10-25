using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class StoreManagerContext : DbContext
    {
        public StoreManagerContext()
        {
        }

        public StoreManagerContext(DbContextOptions<StoreManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; private set; }
        public virtual DbSet<Customer> Customers { get; private set; }
        public virtual DbSet<Inventory> Inventories { get; private set; }
        public virtual DbSet<LineItem> LineItems { get; private set; }
        public virtual DbSet<ProdCat> ProdCats { get; private set; }
        public virtual DbSet<Product> Products { get; private set; }
        public virtual DbSet<SOrder> SOrders { get; private set; }
        public virtual DbSet<Storefront> Storefronts { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _jsonString = File.ReadAllText("../../../Projects/stuff/secret.json");
            List<string> fields = JsonSerializer.Deserialize<List<string>>(_jsonString);
            string server = fields[0];
            string username = fields[1];
            string pass = fields[2];
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer($"Server={server};Initial Catalog=StoreManager;Persist Security Info=False;User ID={username};Password={pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cat_name");

                entity.Property(e => e.CatNumber).HasColumnName("cat_number");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("cust_address");

                entity.Property(e => e.CustEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustNumber).HasColumnName("cust_number");

                entity.Property(e => e.CustPhone).HasColumnName("cust_phone");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__prod___5AB9788F");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__store__59C55456");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("line_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__line_item__order__55F4C372");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__line_item__prod___56E8E7AB");
            });

            modelBuilder.Entity<ProdCat>(entity =>
            {
                entity.ToTable("prod_cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ProdCats)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prod_cat__cat_id__4B7734FF");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.ProdCats)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__prod_cat__prod_i__4A8310C6");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProdDescription)
                    .HasColumnType("text")
                    .HasColumnName("prod_description");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdNumber).HasColumnName("prod_number");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("money")
                    .HasColumnName("prod_price");
            });

            modelBuilder.Entity<SOrder>(entity =>
            {
                entity.ToTable("s_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.OrderNumber).HasColumnName("order_number");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.SOrders)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__s_order__cust_id__531856C7");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.SOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__s_order__store_i__5224328E");
            });

            modelBuilder.Entity<Storefront>(entity =>
            {
                entity.ToTable("storefront");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("store_address");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("store_name");

                entity.Property(e => e.StorePhone).HasColumnName("store_phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
