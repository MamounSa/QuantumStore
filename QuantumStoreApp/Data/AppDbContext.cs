
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuantumStore;
using QuantumStore.Data;
namespace QuantumStore;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
    
    }
    
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<Return> Returns { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
    public DbSet<TaxDetail> TaxDetails { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        //SeedData.Initialize(modelBuilder);
    }

}


