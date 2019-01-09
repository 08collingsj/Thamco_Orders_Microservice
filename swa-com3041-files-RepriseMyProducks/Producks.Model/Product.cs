
namespace Producks.Model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int BrandId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual int StockLevel { get; set; }
        public virtual bool Active { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
