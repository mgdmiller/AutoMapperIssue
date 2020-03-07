using Demo.ODataApp.Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.ODataApp.Service.Context
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderPosition> Positions { get; set; }

        public OrdersContext(DbContextOptions options) : base(options)
        {
        }
    }
}