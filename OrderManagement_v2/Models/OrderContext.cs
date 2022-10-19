using Microsoft.EntityFrameworkCore;

namespace OrderManagement_v2.Models
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
