using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetOrdersForEmployeeQuery : QueryBase<List<DataAccess.Entities.Order>>
    {
        public int Id { get; set; }
        public async override Task<List<Order>> Execute(ServiceStorageContext context)
        {
            var employee = await context.Employees.FindAsync(this.Id);
            var orders = await context.Orders.Where(x => x.Employee == employee).ToListAsync();

            return orders;
        }
    }
}
