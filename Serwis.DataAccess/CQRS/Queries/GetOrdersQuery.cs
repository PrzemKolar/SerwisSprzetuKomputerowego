using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetOrdersQuery : QueryBase<List<Order>>
    {
        public override async Task<List<Order>> Execute(ServiceStorageContext context)
        {
            var orders = await context.Orders.ToListAsync();
            return orders;
        }
    }
}
