using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Models
{
    public partial class MultiStoreContext : DbContext
    {
        public MultiStoreContext()
        {
        }

        public MultiStoreContext(DbContextOptions<MultiStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<MemberShip> MemberShip { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SlideShow> SlideShow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MultiStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreAddress).HasMaxLength(200);

                entity.Property(e => e.StoreLogo).HasMaxLength(200);

                entity.Property(e => e.StoreName).HasMaxLength(200);

                entity.Property(e => e.StorePhone).HasMaxLength(200);

                entity.Property(e => e.StoreWebsite).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_Role_Account");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_Invoice_Account");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.InvoiceId })
                    .HasName("PK__InvoiceD__F975AC668BB67518");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Quantity).HasMaxLength(200);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Invoice_InvoiceDetails");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InvoiceDetails_Product");
            });

            modelBuilder.Entity<MemberShip>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MemberShip)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_MemberShip_Account");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.MemberShip)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("fk_MemberShip_Package");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_Photo_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Quantity).HasMaxLength(200);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_Product_Account");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<SlideShow>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
