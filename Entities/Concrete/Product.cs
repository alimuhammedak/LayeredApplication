using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity // Product is a concrete class that implements IEntity interface
    {
        public int ProductId { get; set; } // Primary Key
        public int CategoryId { get; set; } // Foreign Key
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
