using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Producks.Model
{
    class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration()
        {
            Property(c => c.Name).IsRequired();
            Property(c => c.Description).IsRequired();
        }
    }

    class BrandEntityTypeConfiguration : EntityTypeConfiguration<Brand>
    {
        public BrandEntityTypeConfiguration()
        {
            Property(b => b.Name).IsRequired();
        }
    }

    class ProductEntityTypeConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
            Property(p => p.Name).IsRequired();
            Property(p => p.Description).IsRequired();

            HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            HasRequired(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);
        }
    }

    public class StoreDb : DbContext, IDisposable
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreDb()
            : base("name=RepriseMyProducks.StoreDb")
        {
        }

        static StoreDb()
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());
        }

        class DbInitializer : CreateDatabaseIfNotExists<StoreDb>
        {
            protected override void Seed(StoreDb context)
            {
                var categories = new List<Category>()
                {
                    new Category { Name = "Covers", Description = "Davison Stores pride ourselves on our poor range of covers for your mobile device at premium prices.  If you're lukcy your phone or tablet will be protected from any dents, scratches and scuffs.", Active = true },
                    new Category { Name = "Case", Description = "Browse our wide range of cases for phones and tablets that will help you to keep your mobile device protected from the elements.", Active = false },
                    new Category { Name = "Accessories", Description = "We stock a small range of phone and tablet accessories, including car holders, sports armbands, stylus pens and very little else.", Active = true },
                    new Category { Name = "Screen Protectors", Description = "Exclusive Davison Stores screen protectors for your phone or tablet.", Active = true }
                };
                categories.ForEach(c => context.Categories.Add(c));

                var brands = new List<Brand>()
                {
                    new Brand { Name = "Soggy Sponge", Active = true },
                    new Brand { Name = "Damp Squib", Active = false },
                    new Brand { Name = "iStuff-R-Us", Active = true }
                };
                brands.ForEach(b => context.Brands.Add(b));

                context.SaveChanges();

                var products = new List<Product>()
                {
                    new Product { Active = true, Brand = brands[0], Category = categories[0], Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.", Name = "Wrap It and Hope Cover", Price = 5.99, StockLevel = 1 },
                    new Product { Active = true, Brand = brands[1], Category = categories[0], Description = "Purchase you favourite chocolate and use the provided heating element to melt it into the perfect cover for your mobile device.", Name = "Chocolate Cover", Price = 10.97, StockLevel = 0 },
                    new Product { Active = true, Brand = brands[2], Category = categories[0], Description = "Lamely adapted used and dirty teatowel.  Guaranteed fewer than two holes.", Name = "Cloth Cover", Price = 3.01, StockLevel = 6 },
                    new Product { Active = true, Brand = brands[0], Category = categories[1], Description = "Especially toughen and harden sponge entirely encases your device to prevent any interaction.", Name = "Harden Sponge Case", Price = 9.99, StockLevel = 2 },
                    new Product { Active = true, Brand = brands[0], Category = categories[1], Description = "Place your device within the water-tight container, fill with water and enjoy the cushioned protection from bumps and bangs.", Name = "Water Bath Case", Price = 20.0, StockLevel = 3 },
                    new Product { Active = false, Brand = brands[0], Category = categories[2], Description = "Keep you smartphone handsfree with this large assembly that attaches to your rear window wiper (Hatchbacks only).", Name = "Smartphone Car Holder", Price = 110.01, StockLevel = 8 },
                    new Product { Active = true, Brand = brands[0], Category = categories[2], Description = "Keep your device on your arm with this general purpose sticky tape.", Name = "Sticky Tape Sport Armband", Price = 2.99, StockLevel = 23 },
                    new Product { Active = true, Brand = brands[1], Category = categories[2], Description = "Stengthen HB pencils guaranteed to leave a mark.", Name = "Real Pencil Stylus", Price = 0.99, StockLevel = 5 },
                    new Product { Active = true, Brand = brands[0], Category = categories[3], Description = "Coat your mobile device screen in a scratch resistant, opaque film.", Name = "Spray Paint Screen Protector", Price = 4.99, StockLevel = 1 },
                    new Product { Active = true, Brand = brands[2], Category = categories[3], Description = "For his or her sensory pleasure. Fits few known smartphones.", Name = "Rippled Screen Protector", Price = 7.99, StockLevel = 5 },
                    new Product { Active = true, Brand = brands[2], Category = categories[3], Description = "For an odour than lingers on your device.", Name = "Fish Scented Screen Protector", Price = 2.88, StockLevel = 0 },
                    new Product { Active = true, Brand = brands[1], Category = categories[3], Description = "Guaranteed not to conduct electical charge from your fingers.", Name = "Non-conductive Screen Protector", Price = 10.0, StockLevel = 10 },
                };
                products.ForEach(p => context.Products.Add(p));

                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new BrandEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
