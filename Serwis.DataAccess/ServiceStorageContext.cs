using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess
{
    public class ServiceStorageContext : DbContext
    {
        public ServiceStorageContext(DbContextOptions<ServiceStorageContext> opt) : base(opt)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Regulation> Regulations { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
