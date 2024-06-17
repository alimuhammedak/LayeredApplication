using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

// This class is used to connect to the database and perform operations on the database.
public class NorthwindContext : DbContext
{
    // This method is used to define the tables in the database.
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    // This method is used to connect to the database.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"data source=.;initial catalog=Northwind;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
    }
}