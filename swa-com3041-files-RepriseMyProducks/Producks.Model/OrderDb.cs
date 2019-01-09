using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producks.Model
{
    class CardEntityTypeConfiguration : EntityTypeConfiguration<Card>
    {
        public CardEntityTypeConfiguration()
        {
            Property(o => o.Id).IsRequired();
            Property(c => c.HolderName).IsRequired();
            Property(c => c.CardNumber).IsRequired();
            Property(c => c.CardExpiration).IsRequired();
            Property(c => c.SecurityNumber).IsRequired();
        }
    }

    class OrderItemTypeConfiguration: EntityTypeConfiguration<OrderItem>
    {
        public OrderItemTypeConfiguration()
        {
            Property(o => o.Id).IsRequired();
            Property(o => o.name).IsRequired();
            Property(o => o.discount).IsRequired();
            Property(o => o.unitPrice).IsRequired();
            Property(o => o.units).IsRequired();
        }
    }

    class OrderTypeConfiguration: EntityTypeConfiguration<Order>
    {
        public OrderTypeConfiguration()
        {
            Property(o => o.Id).IsRequired();
            Property(o => o.OrderDate).IsRequired();
            Property(o => o.description).IsRequired();
            Property(o => o.postCode).IsRequired();
            Property(o => o.street).IsRequired();
            Property(o => o.Total).IsRequired();
            //Property(o => o.OrderCard).IsRequired();
        }
    }
    public class OrderDb : DbContext, IDisposable
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Card> Cards { get; set; }
        public OrderDb() : base("name=RepriseMyProducks.OrderDb") { }

        static OrderDb() { System.Data.Entity.Database.SetInitializer(new DbInitializer()); }

        class DbInitializer : CreateDatabaseIfNotExists<OrderDb>
        {
            protected override void Seed(OrderDb context)
            {

                var orderItems = new List<OrderItem>()
                {
                    new OrderItem {name = "Pink Cover", unitPrice = 7.99, discount = 0, units = 2, pictureUrl = ""},
                    new OrderItem {name = "IPhone Case", unitPrice = 10.99, discount = 0, units = 1, pictureUrl = ""},
                    new OrderItem {name = "Pink Bag", unitPrice = 15.99, discount = 5, units = 2, pictureUrl = ""},
                    new OrderItem {name = "Screen Protectors", unitPrice = 7.99, discount = 0, units = 1, pictureUrl = ""},
                    new OrderItem {name = "Black Socks", unitPrice = 7.99, discount = 7.00, units = 2, pictureUrl = ""},
                    new OrderItem {name = "Hairband", unitPrice = 1.49, discount = 0, units = 5, pictureUrl = ""},
                    new OrderItem {name = "TV Screen", unitPrice = 113.99, discount = 5.00, units = 1, pictureUrl = ""}


                };

                var newItems = new List<OrderItem>();
                newItems = (from o in orderItems where o.unitPrice < 10.00 select o).ToList();


                orderItems.ForEach(x => context.OrderItems.Add(x));
                newItems.ForEach(x => context.OrderItems.Add(x));

                var cardList = new List<Card>()
                {
                        new Card {HolderName = "Jeremy Fisher",CardNumber = 12345678, CardExpiration = DateTime.Now.AddDays(245), SecurityNumber = "567"},
                        new Card {HolderName = "Jemima Duck", CardNumber = 67891234,CardExpiration = DateTime.Now.AddDays(567), SecurityNumber = "439"},
                        new Card {HolderName = "Square Strong", CardNumber = 92831564,CardExpiration = DateTime.Now.AddDays(1045), SecurityNumber = "111"},
                        new Card {HolderName = "Circle Bump", CardNumber = 34528129,CardExpiration = DateTime.Now.AddDays(389), SecurityNumber = "509"}
                };

                cardList.ForEach(x => context.Cards.Add(x));
                
                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Status = "Ordered",
                    Total = orderItems.Count,
                    description = null,
                    OrderItems = orderItems,
                    street = "11 Best Street",
                    postCode = "TS4 8PS",
                    Country = "United Kingdom",
                    OrderCard = cardList[1]
                };

                Order secondOrder = new Order()
                {
                    OrderDate = DateTime.Now,
                    Status = "Ordered",
                    Total = 2,
                    description = null,
                    OrderItems = newItems,
                    street = "34 Roman Road",
                    postCode = "TS6 6YU",
                    Country = "United Kingdom",
                    OrderCard = cardList[2]
                };

                var Orders = new List<Order>()
                {
                    order,
                    secondOrder
                };

                Orders.ForEach(x => context.Orders.Add(x));
                context.SaveChanges();
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
