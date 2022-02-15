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
            optionsBuilder.UseSqlServer("Server=tcp:serwis.database.windows.net,1433;Initial Catalog=ServiceStorage;Persist Security Info=False;User ID=Przemek;Password=WNn2mhorvn;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //local Data Source=localhost\\SQLEXPRESS;Initial Catalog=ServiceStorage;Integrated Security=True
            return new ServiceStorageContext(optionsBuilder.Options);
        }
    }
}
