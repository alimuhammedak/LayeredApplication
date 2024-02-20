using Core.Entities;

namespace Entities.Concrete;

public class Order : IEntity
{
    public int OrderID { get; set; }
    public string CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public string shipCity { get; set; }
}