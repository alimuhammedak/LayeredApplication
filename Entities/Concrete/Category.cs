using Core.Entities;

namespace Entities.Concrete;

public class Category : IEntity // Category is a concrete class that implements IEntity interface
{
    public int CategoryId { get; set; } // Primary Key
    public string CategoryName { get; set; }
}