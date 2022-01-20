using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Serwis.DataAccess
{
    class ServiceStorageContextFactory : IDesignTimeDbContextFactory<ServiceStorageContext>
    {
        public ServiceStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ServiceStorage;Integrated Security=True");
            return new ServiceStorageContext(optionsBuilder.Options);
        }
    }
}
