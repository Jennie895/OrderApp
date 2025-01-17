using Microsoft.EntityFrameworkCore;
using OrderApp.ApplicationCore;

namespace OrderApp.Infrastructure.Data;

public class OrderAppDbContext : DbContext
{
    public OrderAppDbContext(DbContextOptions<OrderAppDbContext> options):base(options)
    {
        
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}