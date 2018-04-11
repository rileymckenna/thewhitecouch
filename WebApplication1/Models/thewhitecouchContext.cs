using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class thewhitecouchContext : DbContext
    {
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Checkout> Checkout { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }

        public thewhitecouchContext(DbContextOptions<thewhitecouchContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assets>(entity =>
            {
                entity.HasKey(e => e.Assetid);

                entity.ToTable("assets");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.AquiredDate)
                    .HasColumnName("aquiredDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Checkedout).HasColumnName("checkedout");

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Purchaseprice).HasColumnName("purchaseprice");

                entity.Property(e => e.Relatedid).HasColumnName("relatedid");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__assets__category__04E4BC85");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Colorid)
                    .HasConstraintName("FK__assets__colorid__05D8E0BE");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("FK__assets__imageid__02084FDA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("FK__assets__location__06CD04F7");

                entity.HasOne(d => d.Related)
                    .WithMany(p => p.InverseRelated)
                    .HasForeignKey(d => d.Relatedid)
                    .HasConstraintName("FK__assets__relatedi__03F0984C");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.Categoryid);

                entity.ToTable("categories");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.ToTable("checkout");

                entity.Property(e => e.Checkoutid).HasColumnName("checkoutid");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Contactid).HasColumnName("contactid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Checkout)
                    .HasForeignKey(d => d.Assetid)
                    .HasConstraintName("FK__checkout__asseti__114A936A");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Checkout)
                    .HasForeignKey(d => d.Contactid)
                    .HasConstraintName("FK__checkout__contac__0F624AF8");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Checkout)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("FK__checkout__locati__10566F31");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.Colorid);

                entity.ToTable("colors");

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.ToTable("customers");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Cellphone)
                    .HasColumnName("cellphone")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Officephone)
                    .HasColumnName("officephone")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("FK__customers__locat__0C85DE4D");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.Imageid);

                entity.ToTable("images");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Caption)
                    .HasColumnName("caption")
                    .HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnName("image");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("locations");

                entity.Property(e => e.AddressId).HasColumnName("addressID");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line1")
                    .HasMaxLength(50);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line2")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(50);
            });
        }
    }
}
